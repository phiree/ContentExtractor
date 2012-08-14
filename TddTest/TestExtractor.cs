using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.BLL;
using CE.Model;
namespace TddTest
{
    /// <summary>
    /// 内容萃取器
    /// </summary>
    [TestFixture]
    public class TestExtractor
    {
        /// <summary>
        ///   test2-1:
        ///從url獲取網頁內容(webrequest)
        /// </summary>
        [Test]
        public void t_GetContentFromUrl()
        {
            Assert.IsTrue( Extractor
                .getDataFromUrl("http://www.163.com")
                .IndexOf("网易,邮箱,游戏,新闻,体育,娱乐,女性,亚运,论坛,短信,数码,汽车,手机,财经,科技,相册")
                > 0);
        }
        /// <summary>
        /// test12-2:
	    ///为某个网站添加一个规则
        /// </summary>
        [Test]
        public void t_AddRuleToSite()
        {
          
        }
    }
}
