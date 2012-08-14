using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

using System.Text.RegularExpressions;

using System.Web;
using CE.Model;
namespace CE.BLL
{
    /// <summary>
    /// 从原始html中提取正文
    /// </summary>
    public class FilterNews
    {

        string rawContent;

        string pageUrl;
        public string PageUrl
        {
            get { return pageUrl; }
            set { pageUrl = value; }
        }
        private List<FilterRuleInfo> Filters
        {
            get;
            set;
        }
        
        public string GetRawContent()
        {
            WebRequest request = WebRequest.Create(pageUrl);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream, Encoding.Default);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        public FilterNews()
        {

        }
        public FilterNews(int rssId, string rawContent)
        {
          
            this.rawContent = rawContent;
        }
        private int SortCompare(FilterRuleInfo rule1,FilterRuleInfo rule2)
        {
            return rule1.OrderId.CompareTo(rule2.OrderId);
        }
        public string GetFilteredContent(out string imgUrl)
        {
            rawContent = GetRawContent();
            StringBuilder sb = new StringBuilder();
            bool hasGetPic = false; ;
            imgUrl = string.Empty;
            Filters.Sort(SortCompare);
            foreach (FilterRuleInfo rule in Filters)
            {
                if (!rule.Enabled)
                    continue;
                if (string.IsNullOrEmpty(rule.BeginMark) || string.IsNullOrEmpty(rule.EndMark))
                    continue;
                //断言:标记在文中唯一
                //开始标记--结束标记 是否包括,攫取后添加的头部标签.的尾部
                int startIndex = rawContent.IndexOf(rule.BeginMark, StringComparison.OrdinalIgnoreCase);
                int endIndex = rawContent.IndexOf(rule.EndMark);
                if (startIndex == -1 || endIndex == -1)
                    continue;
                string filter = rawContent.Substring(startIndex + rule.BeginMark.Length, endIndex - startIndex - rule.BeginMark.Length);

                if (!hasGetPic)
                {
                    hasGetPic = true;
                    string pattern = "<[img|IMG|Img](?:.*)src=(\"{1}|\'{1})([^\\[^>]+[gif|jpg|jpeg|bmp|png]*)(\"{1}|\'{1})(?:.*)>";
                    Regex rex = new Regex(pattern);
                    Match match = rex.Match(filter.Trim());
                    string picUrl = match.Groups[2].Value;
                    if (match.Success && (picUrl.EndsWith("gif") || picUrl.EndsWith("jpg")))
                    { 
                    
                  
                        imgUrl = match.Value;
                        int a = imgUrl.IndexOf("src=");
                       
                        imgUrl = imgUrl.Substring(a + 5);
                        int c = imgUrl.IndexOf("\"");
                        imgUrl = imgUrl.Substring(0, c);
                    }
                }
                rawContent = rawContent.Remove(startIndex, filter.Length + rule.EndMark.Length + rule.BeginMark.Length);

                sb.Append(filter);
                if (rule.IncludeBeginMark)
                {
                    sb.Insert(0, rule.BeginMark);
                }
                if (rule.IncludeEndMark)
                {
                    sb.Append(rule.EndMark);
                }
                if (!string.IsNullOrEmpty(rule.AppendBefore.Trim()))
                {
                    sb.Insert(0, rule.AppendBefore);
                }
                if (!string.IsNullOrEmpty(rule.AppendAfter.Trim()))
                {
                    sb.Append(rule.AppendAfter);
                }
                //if(rule.
            }
            return sb.ToString();
        }

       
      


    }
}
