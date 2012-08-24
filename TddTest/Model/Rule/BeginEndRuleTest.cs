using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.Domain.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
    public class BeginEndRuleTest
    {
        [Test]
        public void FilterUsingRuleTest()
        {

            string rawContent = "<div>仙都风景名胜区</div>";
            Assert.AreEqual("<div>仙都风景名胜区",
                new BeginEndRule("<div>", "</div>", true, false, true, true).FilterUsingRule(ref rawContent));

        }

        [Test]
        public void FilterUsingRuleTestReal()
        {
            string content = "<div id=\"portal-block-445000270656\" class=\"udiyblock\" type=\"CommonSource\"> <div id=\"jqlast_maincontent\" class=\"jqlast_main_title\">"
                                        + "<h1>仙都风景名胜区</h1><span class=\"grade\">AAAA</span><span onmouseover=\"show_dk(event,this)\" onmouseout=\"hide_dk()\" class=\"cosPicLast s_dpjj_img\"></span><div class=\"thDiv\"><div class=\"thDiv\">"
                                        + "<span id=\"checkGuid_0_0\" class=\"checkGuid yanKer\">"
                                        + "<div class=\"nopicYk none\" style=\"display: none; \">"
                                        + "<span class=\"nopicYk_head\"></span>"
                                        + "<div class=\"nopicYk_mit\">"
                                        + "<p class=\"nopicYk_p\">该景区已参加验客大赛，赶快写博客、打擂台，赢万元轿车吧！"
                                        + "<a href=\"http://www.17u.com/special/yanke/\" target=\"_blank\" title=\"什么是验客大赛？\" rel=\"nofollow\">(什么是验客大赛?)</a>"
                                        + "</p></div></div></span></div></div></div><span class=\"list_sale\" id=\"last_sale\" style=\"display: block; \"><span id=\"last_sale_t\">8分钟</span>前有人预订了该景点</span></div>";
            Assert.AreEqual("仙都风景名胜区",
                new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>", "</h1>", false, false, true, true).FilterUsingRule(ref content));
            Assert.AreEqual("AAAA",
                new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true).FilterUsingRule(ref content));
        }

        /// <summary>
        /// 没有匹配项的情况
        /// </summary>
        [Test]
        public void FilterWithnoitemTest()
        {
            string content = "<div id=\"portal-block-445000270656\" class=\"udiyblock\" type=\"CommonSource\"> <div id=\"jqlast_maincontent\" class=\"jqlast_main_title\">"
                                        + "<h1>仙都风景名胜区</h1><span class=\"grade\">AAAA</span><span onmouseover=\"show_dk(event,this)\" onmouseout=\"hide_dk()\" class=\"cosPicLast s_dpjj_img\"></span><div class=\"thDiv\"><div class=\"thDiv\">"
                                        + "<span id=\"checkGuid_0_0\" class=\"checkGuid yanKer\">"
                                        + "<div class=\"nopicYk none\" style=\"display: none; \">"
                                        + "<span class=\"nopicYk_head\"></span>"
                                        + "<div class=\"nopicYk_mit\">"
                                        + "<p class=\"nopicYk_p\">该景区已参加验客大赛，赶快写博客、打擂台，赢万元轿车吧！"
                                        + "<a href=\"http://www.17u.com/special/yanke/\" target=\"_blank\" title=\"什么是验客大赛？\" rel=\"nofollow\">(什么是验客大赛?)</a>"
                                        + "</p></div></div></span></div></div></div><span class=\"list_sale\" id=\"last_sale\" style=\"display: block; \"><span id=\"last_sale_t\">8分钟</span>前有人预订了该景点</span></div>";
            Assert.AreEqual("",
                new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h2>", "</h2>", false, false, true, true).FilterUsingRule(ref content));
        }
    }
}
