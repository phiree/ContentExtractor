using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

using System.Text.RegularExpressions;

using System.Web;
using CE.Domain;
namespace CE.BLL
{
    /// <summary>
    /// 将远程服务器图片保存到本地,并且返回本地url路径
    /// </summary>
    public class ImageLocalizer
    {
     
        public string ImageUrl { get; set; }
        /// <summary>
        /// 物理目录的路径.
        /// </summary>
        public string SavePathPhy { get; set; }
        /// <summary>
        /// 网站相对路径.
        /// </summary>
        public string SavePath { get; set; }
        public string SavedFileName { get; set; }
        public bool Overwrite { get; set; }
        public ImageLocalizer(string imageUrl, string savePathPhy, string savePath,string savedFileName)
        {
            this.ImageUrl = imageUrl;
            this.SavePath = savePath;
            this.SavedFileName = savedFileName;
            this.SavePathPhy = savePathPhy;
            Overwrite = false;
        }


        /// <summary>
        /// 从图片地址下载图片到本地磁盘
        /// </summary>
        /// <param name="ToLocalPath">图片本地磁盘地址</param>
        /// <param name="Url">图片网址</param>
        /// <returns></returns>
        public string SavePhotoFromUrl()
        {
            string filePath = string.Empty;

            WebResponse response = null;
            Stream stream = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ImageUrl);

                response = request.GetResponse();
                stream = response.GetResponseStream();

                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    string fileName =SavedFileName  + Path.GetExtension(ImageUrl);
                    string filePathPhy = SavePathPhy  + fileName;
                    filePath = SavePath  + fileName;
                    SaveBinaryFile(response.GetResponseStream(), filePathPhy);

                }

            }
            catch (Exception err)
            {
                throw err;
            }
            return filePath;
        }

        private void GetFileNameFromUrl()
        {

        }
        /// <summary>
        /// Save a binary file to disk.
        /// </summary>
        /// <param name="response">The response used to save the file</param>
        // 将二进制文件保存到磁盘
        private void SaveBinaryFile(Stream stream, string FileName)
        {

            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                Stream outStream = System.IO.File.Create(FileName);
                Stream inStream = stream;

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
