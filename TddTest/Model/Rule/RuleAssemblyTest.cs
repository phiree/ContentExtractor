﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using CE.Domain.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
    public class RuleAssemblyTest
    {
        //[Test]
        //public void FilterUsingRuleSetTest()
        //{
        //    //两个条件
        //    BaseRule rule1 = new BeginEndRule("<div id=dv1>", "</div>", true, true, true, true);
        //    rule1.RuleNo = 10;
        //    BaseRule rule2 = new BeginEndRule("<span id=sp1>", "</span>", true, true, true, true);
        //    rule2.RuleNo = 11;
        //    RuleSet ruleset = new RuleSet();
        //    ruleset.Rules.Add(rule1);
        //    ruleset.Rules.Add(rule2);
        //    ruleset.Code = "Pro1";


        //    //第二个set
        //    BaseRule rule3 = new BeginEndRule("<div id=dv2>", "</div>", true, true, true, true);
        //    rule3.RuleNo = 10;
        //    BaseRule rule4 = new BeginEndRule("<span id=sp2>", "</span>", true, true, true, true);
        //    rule4.RuleNo = 11;
        //    RuleSet ruleset2 = new RuleSet();
        //    ruleset2.Code = "Pro2";

        //    ruleset2.Rules.Add(rule3);
        //    ruleset2.Rules.Add(rule4);

        //    RuleAssembly assm = new RuleAssembly();
        //    assm.CodeName = "Ass";
        //    ruleset.SetNo = 10;
        //    ruleset2.SetNo = 11;
        //    assm.RuleSets.Add(ruleset);
        //    assm.RuleSets.Add(ruleset2);


        //    Assert.AreEqual("<div id=dv1>a</div><span id=sp1>b</span>,<div id=dv2>div2</div><span id=sp2>span2</span>", assm.FilterUsingAssembly(
        //        @"1<div id=dv1>a</div>2<span id=sp1>b</span>nodeed<div id=dv2>div2</div><span id=sp2>span2</span>"
        //        , false));

        //    //输出为json格式
        //    Assert.AreEqual(@"{Pro1:""<div id=dv1>a</div><span id=sp1>b</span>"",Pro2:""<div id=dv2>div2</div><span id=sp2>span2</span>""}", assm.FilterUsingAssembly(
        //       @"1<div id=dv1>a</div>2<span id=sp1>b</span>nodeed<div id=dv2>div2</div><span id=sp2>span2</span>"
        //       , true));
        //}

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
            
            string content2="<!-- 右侧导航 end  -->"
			+"<!--标签、幻灯片、点评滚动 start -->"
			+"<div class=\"jqlast_main\">"
                +"<!--标签start -->"
                +"<div class=\"udiy\" id=\"udiy-tag\"><div id=\"portal-frame-16753065536\"  class=\"udiyframe frame-1\" ><div id=\"portal-frame-16753065536-left\" class=\"udiycolumn frame-1-c\"><div id=\"portal-block-445000270656\" class=\"udiyblock\"  type=\"CommonSource\"> <div id=\"jqlast_maincontent\" class=\"jqlast_main_title\">"
    +"<h1>"
        +"仙都风景名胜区</h1>"
        	        +"<span class=\"grade\">AAAA</span>"
        		+"<span onmouseover=\"show_dk(event,this)\" onmouseout=\"hide_dk()\" class=\"cosPicLast s_dpjj_img\"></span>"
		+"<div class=\"thDiv\">"
			+"                                                  <div class=\"thDiv\">"
             +"       <span id=\"checkGuid_0_0\" class=\"checkGuid yanKer\">"
               +"         <div class=\"nopicYk none\" style=\"display: none; \">"
                +"            <span class=\"nopicYk_head\"></span>"
                 +"           <div class=\"nopicYk_mit\">"
                    +"                                                <p class=\"nopicYk_p\">该景区已参加验客大赛，赶快写博客、打擂台，赢万元轿车吧！"
                 +"                       <a href=\"http://www.17u.com/special/yanke/\" target=\"_blank\" title=\"什么是验客大赛？\" rel=\"nofollow\">(什么是验客大赛?)</a>"
                 +"                   </p>"
                             +"                               </div>"
                        +"</div>"
                 +"   </span>"
               +" </div>"
                +"                                                		</div>"
+"</div>"
+"<span class=\"list_sale\" id=\"last_sale\" style=\"display: none\">"
	+"<span id=\"last_sale_t\"></span>前有人预订了该景点                "
+"</span></div></div><div class=\"udiyclr\"></div></div></div>"
         +"       <!--标签end -->                "
          +"      <div class=\"jqlat_slide\">"
          +"          <div class=\"slideBox\">";

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

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            #endregion

            Assert.AreEqual("仙都风景名胜区$#$AAAA$#$",
                assm.FilterUsingAssembly(content, false));
            Assert.AreEqual("{title:\"仙都风景名胜区\"$#$level:\"AAAA\"$#$}",
                assm.FilterUsingAssembly(content, true));

            Assert.AreEqual("仙都风景名胜区$#$AAAA$#$",
                assm.FilterUsingAssembly(content2, false));
            Assert.AreEqual("{title:\"仙都风景名胜区\"$#$level:\"AAAA\"$#$}",
                assm.FilterUsingAssembly(content2, true));
        }


    }
}
