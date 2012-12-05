
namespace CE.Crawler
{
    using System.Threading;
    using System.Collections;
    using System;
    using System.Net;
    using System.Text;
    using System.IO;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using CE.Crawler.Common;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 爬虫状态类型
    /// </summary>
    public enum CrawlerStatusType
    {
        Idle,//空闲
        Fetch,  // 抓去FetchWebContent
        Parse,  // 转换ParseWebPage
        Save,   // 保存SaveToRepository
    }

    /// <summary>
    /// 爬虫状态转换事件类型
    /// </summary>
    public enum CrawlerStatusChangedEventType
    {

    }

    public delegate void CrawlerStatusChangedEventHandler(object sender, CrawlerStatusChangedEventArgs e);
    public class CrawlerStatusChangedEventArgs : EventArgs
    {
        public CrawlerStatusChangedEventType EventType
        {
            get;
            set;
        }
    }

    /// <summary>
    /// foamliu, 2009/12/27, 爬虫是能够自动下载网页的程序.
    /// Web的重要特性:
    /// 1.网络上的信息分散在数以十亿计的网页中, 而这些网页由遍布地球各个角落的数以百万计服务器负责存储.
    /// 2.Web是一个迅速演化的动态实体.
    /// </summary>
    public class CrawlerThread
    {
        public event CrawlerStatusChangedEventHandler StatusChanged;

        private Thread m_thread;
        private ManualResetEvent m_suspendEvent = new ManualResetEvent(true);
        private CrawlerStatusType m_statusType;
        private string m_url;
        private Downloader m_downloader;
        private string m_regex;
        private string m_regex2;
        private bool m_dirty;

        #region Props

        private string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }


        public CrawlerStatusType Status
        {
            get
            {
                return m_statusType;
            }
            set
            {
                if (m_statusType != value)
                {
                    m_statusType = value;
                    this.m_dirty = true;
                }

            }
        }

        public string MimeType
        {
            get;
            set;
        }

        public string Url
        {
            get
            {
                return m_url;
            }
            set
            {
                if (m_url != value)
                {
                    m_url = value;
                    this.m_dirty = true;
                }
            }
        }

        public string Regx
        {
            get
            {
                return m_regex;
            }
            set
            {
                m_regex = value;
            }
        }

        #endregion

        #region ctor

        public CrawlerThread(Downloader d, string regexcon, string regexcon2)
        {
            m_thread = new Thread(CrawlerThread.DoWork);
            m_name = m_thread.ManagedThreadId.ToString();
            m_regex = regexcon;
            m_regex2 = regexcon2;
            this.m_downloader = d;
            this.m_dirty = false;
        }

        #endregion

        public void Start()
        {
            m_thread.Start(this);
        }

        public void Abort()
        {
            m_thread.Abort();
        }

        public void Suspend()
        {
            m_suspendEvent.Reset();
        }

        public void Resume()
        {
            m_suspendEvent.Set();
        }

        private void Flush()
        {
            if (this.m_dirty)
                this.StatusChanged(this, null);
        }

        /// <summary>
        /// doCrawlerwork
        /// </summary>
        /// <param name="data"></param>
        private static void DoWork(object data)
        {
            try
            {
                CrawlerThread crawler = (CrawlerThread)data;
                Downloader downloader = crawler.m_downloader;
                string regex = crawler.m_regex;
                string regex2 = crawler.m_regex2;
                UrlQueueManager queue = downloader.UrlsQueueFrontier;
                

                while (true)
                {
                    crawler.m_suspendEvent.WaitOne(Timeout.Infinite);

                    if (queue.Count > 0)
                    {
                        try
                        {
                            // 从队列中获取URL
                            string url = (string)queue.Dequeue();
                            // 获取页面
                            Fetch(crawler, url, regex, regex2);
                            // TODO: 检测是否完成
                            //if (false) break;

                        }
                        catch (InvalidOperationException)
                        {
                            SleepWhenQueueIsEmpty(crawler);
                        }
                    }
                    else
                    {
                        SleepWhenQueueIsEmpty(crawler);
                    }


                }
            }
            catch (ThreadAbortException)
            {
                // 线程被放弃
            }
        }

        /// <summary>
        /// foamliu, 2009/12/27.
        /// 这个方法主要做三件事:
        /// 1.获取页面.
        /// 2.提取URL并加入队列.
        /// 3.保存页面(到网页库).
        /// </summary>
        /// <param name="crawler">爬虫</param>
        /// <param name="url">起始URL</param>
        /// <param name="regexOutput">抓取URL的规则</param>
        /// <param name="regexFollow"></param>
        private static void Fetch(CrawlerThread crawler, string url, string regexOutput, string regexFollow)
        {
            try
            {
                // 获取页面.
                crawler.Url = url;
                crawler.Status = CrawlerStatusType.Fetch;
                crawler.Flush();

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                // 设置超时以避免耗费不必要的时间等待响应缓慢的服务器或尺寸过大的网页.
                req.Timeout = MemCache.ConnectionTimeoutMs;
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                string contentType = crawler.MimeType = response.ContentType;
                //crawler.Size = response.ContentLength;

                //WebClient w = new WebClient();
                //System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();
                //VarPost.Add("cityid", "33");//将textBox1中的数据变为用a标识的参数，并用POST传值方式传给网页 ­
                //VarPost.Add("ThemeId", "0");
                //VarPost.Add("priceRange", "0");
                //VarPost.Add("Gradeid", "0");
                //VarPost.Add("Ctypeid", "0");
                //VarPost.Add("pageindex", "3");
                //VarPost.Add("SortType", "2");
                ////将参数列表VarPost中的所有数据用POST传值的方式传给http://申请好的域名或用IIs配置好的地址/Default.aspx，
                ////并将从网页上返回的数据以字节流存放到byRemoteInfo中)(注：IIS配置的时候经常没配置好会提示错误，嘿) ­          
                //byte[] byRemoteInfo = w.UploadValues("http://www.17u.com/tickets/Ajax/GetSceneryListByAjax.html", "POST", VarPost);
                //string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);


                if (contentType != "text/html" &&
                    !MemCache.AllowAllMimeTypes &&
                    !MemCache.AllowedFileTypes.Contains(contentType))
                {
                    //return;
                }

                byte[] buffer = ReadInstreamIntoMemory(response.GetResponseStream());
                response.Close();

                // 保存页面(到网页库).
                crawler.Status = CrawlerStatusType.Save;
                crawler.Flush();

                string html = Encoding.UTF8.GetString(buffer);
                string baseUri = Utility.GetBaseUri(url);
                string[] links = null;
                if(!string.IsNullOrEmpty(regexOutput) && !string.IsNullOrEmpty(regexFollow))
                { Parser.ExtractLinks(baseUri, html, regexOutput, regexFollow); }
                

                if (Settings.DataStoreMode == "1")
                {
                    //SQLiteUtility.InsertToRepo(PageRank.calcPageRank(url),url, 0, "", buffer, DateTime.Now, DateTime.Now, 0, "", Environment.MachineName,links.Length);
                }
                else
                {
                    ////2012.12.5修改[old]  由输出regex判断模式改为多模式判断(包含不轮询)
                    ////是否匹配提取html的过滤条件
                    //if (Regex.IsMatch(url, regexOutput))
                    //{
                    //    FileSystemUtility.StoreWebFile(url, buffer);
                    //}
                    //2012.12.5修改[new]  由输出regex判断模式改为多模式判断(包含不轮询)
                    if (string.IsNullOrEmpty(regexOutput))
                    {
                        regexOutput = url;
                    }
                    if (Regex.IsMatch(url, regexOutput))
                    {
                        FileSystemUtility.StoreWebFile(url, buffer);
                    }
                }

                crawler.m_downloader.CrawledUrlSet.Add(url);
                crawler.m_downloader.CrawleHistroy.Add(new CrawlHistroyEntry() { Timestamp = DateTime.UtcNow, Url = url, Size = response.ContentLength });
                lock (crawler.m_downloader.TotalSizelock)
                {
                    crawler.m_downloader.TotalSize += response.ContentLength;
                }

                // 提取URL并加入队列.
                UrlQueueManager queue = crawler.m_downloader.UrlsQueueFrontier;

                if (contentType.Contains("text/html"))
                {
                    crawler.Status = CrawlerStatusType.Parse;
                    crawler.Flush();

                    foreach (string link in links)
                    {
                        // 避免爬虫陷阱
                        if (link.Length > 256) continue;
                        // 避免出现环
                        if (crawler.m_downloader.CrawledUrlSet.Contains(link)) continue;
                        // 加入队列
                        queue.Enqueue(link);
                    }
                }

                crawler.Url = string.Empty;
                crawler.Status = CrawlerStatusType.Idle;
                crawler.MimeType = string.Empty;
                crawler.Flush();

            }
            catch (IOException ioEx)
            {
                if (ioEx.InnerException != null)
                {

                    if (ioEx.InnerException is SocketException)
                    {
                        SocketException socketEx = (SocketException)ioEx.InnerException;
                        if (socketEx.NativeErrorCode == 10054)
                        {
                            // 远程主机强迫关闭了一个现有的连接。
                            //Logger.Error(ioEx.Message);
                        }
                    }
                    else
                    {
                        int hr = (int)ioEx.GetType().GetProperty("HResult",
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic).GetValue(ioEx, null);

                        if (hr == -2147024864)
                        {
                            // 另一个程序正在使用此文件，进程无法访问。 
                            // 束手无策 TODO: 想个办法
                            //Logger.Error(ioEx.Message);
                        }
                        else
                        {
                            //throw;
                            //Logger.Error(ioEx.Message);
                        }
                    }
                }
            }
            catch (NotSupportedException /*nsEx*/)
            {
                // 无法识别该 URI 前缀。
                // 束手无策 TODO: 想个办法
                //Logger.Error(nsEx.Message);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message);
            }


        }

        /// <summary>
        /// 考虑：会不会占用太多内存？
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static byte[] ReadInstreamIntoMemory(Stream stream)
        {
            int bufferSize = 16384;
            byte[] buffer = new byte[bufferSize];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                int numBytesRead = stream.Read(buffer, 0, bufferSize);
                if (numBytesRead <= 0) break;
                ms.Write(buffer, 0, numBytesRead);
            }
            return ms.ToArray();
        }

        /// <summary>
        /// 为避免挤占CPU, 队列为空时睡觉. 
        /// </summary>
        /// <param name="crawler"></param>
        private static void SleepWhenQueueIsEmpty(CrawlerThread crawler)
        {
            crawler.Status = CrawlerStatusType.Idle;
            crawler.Url = string.Empty;
            crawler.Flush();

            Thread.Sleep(MemCache.ThreadSleepTimeWhenQueueIsEmptyMs);
        }


    }

}
