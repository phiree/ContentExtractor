using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CE.Crawler.Common
{
    /// <summary>
    /// 存储Web文件在本地文件系统
    /// </summary>
    public class FileSystemUtility
    {
        private static string fileFolder = MemCache.FileSystemFolder;

        public static void StoreWebFile(string url, byte[] resource)
        {
            FileStream fs = null;
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            string filePath = fileFolder + "\\" + Math.Abs(url.GetHashCode()) + ".html";
            if (File.Exists(filePath)) return;
            try
            {

                fs = new FileStream(filePath, FileMode.Create);
               
                fs.Write(resource, 0, resource.Length);
                fs.Flush();
                //FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message + e.StackTrace);
            }
            finally
            {
                fs.Close();
            }
        }

        public static void StoreWebFile(string url, object resource)
        {
            StreamWriter sw = null;
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            try
            {
                string filePath = fileFolder + "\\" + System.Guid.NewGuid().ToString() + ".doc";
                sw = new StreamWriter(filePath);
                string content = resource.ToString();
                sw.Write(resource);
                sw.Flush();
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message + e.StackTrace);
            }
            finally
            {
                sw.Close();
            }
        }

        public static void StoreWebFile(string url, byte[] resource,string prefixtag)
        {
            string[] prefixtags = prefixtag.Split(new char[] { '.', '/' },StringSplitOptions.RemoveEmptyEntries);
            if (prefixtags.Length < 3) {
                StoreWebFile(url, resource);
            }
            FileStream fs = null;
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            string filePath = fileFolder + "\\r" + prefixtags[2] + prefixtags[3] + "-" + Math.Abs(url.GetHashCode()) + ".html";
            if (File.Exists(filePath)) 
                return;
            try
            {

                fs = new FileStream(filePath, FileMode.Create);

                fs.Write(resource, 0, resource.Length);
                fs.Flush();
                //FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message + e.StackTrace);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
