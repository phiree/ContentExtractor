using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.BLL;
using System.IO;
using CE.Component;
namespace TddTest.BLL
{
    /// <summary>
    /// 将服务器的图片按照指定名称保存至本地磁盘,并返回Url相对路径.
    /// </summary>
    [TestFixture]
    public class ResponseHanlderTest
    {
        [Test]
        public void GetResponseHtmlTest()
        {

            Assert.IsTrue(ResponseHandler.GetResponseHtml("http://www.tourol.cn").IndexOf("浙江旅游") > 0);
        
        }
    }
}
