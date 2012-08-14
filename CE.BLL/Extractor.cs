using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
namespace CE.BLL
{
    public class Extractor
    {
        public static string getDataFromUrl(string url)
        {
            string str = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            //设置http头
            request.AllowAutoRedirect = true;
            request.AllowWriteStreamBuffering = true;
            request.Referer = "";
            request.Timeout = 10 * 1000;
            request.UserAgent = "";

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //根据http应答的http头来判断编码
                    string characterSet = response.CharacterSet;
                    Encoding encode;
                    if (characterSet != "")
                    {
                        if (characterSet == "ISO-8859-1")
                        {
                            characterSet = "gb2312";
                        }
                        encode = Encoding.GetEncoding(characterSet);
                    }
                    else
                    {
                        encode = Encoding.Default;
                    }

                    //声明一个内存流来保存http应答流
                    Stream receiveStream = response.GetResponseStream();
                    MemoryStream mStream = new MemoryStream();

                    byte[] bf = new byte[255];
                    int count = receiveStream.Read(bf, 0, 255);
                    while (count > 0)
                    {
                        mStream.Write(bf, 0, count);
                        count = receiveStream.Read(bf, 0, 255);
                    }
                    receiveStream.Close();

                    mStream.Seek(0, SeekOrigin.Begin);

                    //从内存流里读取字符串
                    StreamReader reader = new StreamReader(mStream, encode);
                    char[] buffer = new char[1024];
                    count = reader.Read(buffer, 0, 1024);
                    while (count > 0)
                    {
                        str += new String(buffer, 0, count);
                        count = reader.Read(buffer, 0, 1024);
                    }

                    //从解析出的字符串里判断charset，如果和http应答的编码不一直
                    //那么以页面声明的为准，再次从内存流里重新读取文本
                    Regex reg =
                        new Regex(@"<meta[\s\S]+?charset=(.*)""[\s\S]+?>",
                                  RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    MatchCollection mc = reg.Matches(str);
                    if (mc.Count > 0)
                    {
                        string tempCharSet = mc[0].Result("$1");
                        if (string.Compare(tempCharSet, characterSet, true) != 0)
                        {
                            encode = Encoding.GetEncoding(tempCharSet);
                            str = string.Empty;
                            mStream.Seek(0, SeekOrigin.Begin);
                            reader = new StreamReader(mStream, encode);
                            buffer = new char[255];
                            count = reader.Read(buffer, 0, 255);
                            while (count > 0)
                            {
                                str += new String(buffer, 0, count);
                                count = reader.Read(buffer, 0, 255);
                            }
                        }
                    }
                    reader.Close();
                    mStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
            return str;
        }
    }
}
