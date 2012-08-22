using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.Domain.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
   public class RuleSetTest
    {
        [Test]
        public void FilterUsingRuleSetTest()
        {
            //两个条件
            BaseRule rule1 = new BeginEndRule("<div>", "</div>", false, false, true, true);
            rule1.RuleNo = 10;
            BaseRule rule2 = new BeginEndRule("<span>", "</span>", false, false, true, true);
            rule2.RuleNo = 11;
            BaseRule rule3 = new BeginEndRule("<div id=img>", "</div>", false, false, true, true);
            rule3.RuleNo = 12;
            RuleSet ruleset = new RuleSet();
            
            ruleset.Rules.Add(rule1);
            ruleset.Rules.Add(rule2); 
            ruleset.Rules.Add(rule3);
            ruleset.NeedImageLocalizer = true;
            string raw= @"1<div>a</div>2<span>b</span>3<div id=img><img src=""http://www.tourol.com/Img/slide/1.png""/></div>";
            Assert.AreEqual(@"ab<img src=""/FetchImages/" + Math.Abs( "http://www.tourol.com/Img/slide/1.png".GetHashCode())+ ".png\"/>", ruleset.FilterUsingRuleSet(ref raw, false));

            //输出为json格式
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Rules.Add(rule1);
            ruleset2.Rules.Add(rule2);
            ruleset2.Code = "name";
            string raw2 = "1<div>a</div>2<span>b</span>3";
            Assert.AreEqual(@"name:""ab""", ruleset2.FilterUsingRuleSet(ref raw2, true));
        }

        [Test]
        public void FilterUsingRuleSetTestReal()
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
            #region 模拟2个ruleset

            //两个条件
            BaseRule rule1 = new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第二个set
            BaseRule rule3 = new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule3);

            Assert.AreEqual("仙都风景名胜区",
                ruleset.FilterUsingRuleSet(ref content,false));
            Assert.AreEqual("AAAA",
                ruleset2.FilterUsingRuleSet(ref content, false));
            #endregion
        }
    }
}
