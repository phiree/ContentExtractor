﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.Domain.Rule;
using System.IO;

namespace TddTest.ITest
{
    /// <summary>
    /// 保存规则
    /// </summary>
    [TestFixture]
    public class RuleTest
    {
        public void SaveRuleToncheng()
        {
            #region 模拟11个ruleset

            //第1个条件
            BaseRule rule1 = new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第2个set
            BaseRule rule3 = new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule3);

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "tongcheng";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"d:\";
            rule.SaveRule(assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"d:\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines = File.ReadAllLines(@"d:\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(), 35);

            //测试,第12行是否相同
            Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }

        [Test]
        public void SaveRuleLvmama()
        {
            #region 模拟11个ruleset

            //第1个条件
            BaseRule rule1 = new BeginEndRule(@"<h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第2个条件
            BaseRule rule2 = new BeginEndRule("<span class=\"orange02\" >", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第3个条件
            BaseRule rule3 = new BeginEndRule("<span class=\"misp2\">景点地址：", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "景区地址rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "景区地址";
            ruleset3.Rules.Add(rule3);
            ruleset3.Code = "scenicadd";
            ruleset3.OldRegex = new List<string>() { @"入园凭证：.*\s*.*\s*.*" };
            ruleset3.NewRegex = new List<string>() { @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第4个条件
            BaseRule rule4 = new BeginEndRule("fdsafsd", "fdasfsd", false, false, true, true);
            rule4.RuleNo = 10;
            rule4.Name = "seonamerule";
            RuleSet ruleset4 = new RuleSet();
            ruleset4.Name = "seoname";
            ruleset4.Rules.Add(rule4);
            ruleset4.Code = "seoname";

            //第5个条件
            BaseRule rule5 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule5.RuleNo = 10;
            rule5.Name = "seonamerule0";
            BaseRule rule51 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule51.RuleNo = 12;
            rule51.Name = "seonamerule1";
            BaseRule rule52 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule52.RuleNo = 12;
            rule52.Name = "seonamerule2";
            RuleSet ruleset5 = new RuleSet();
            ruleset5.Name = "seoname";
            ruleset5.Rules.Add(rule5);
            ruleset5.Rules.Add(rule51);
            ruleset5.Rules.Add(rule52);
            ruleset5.Code = "seoname";

            //第6个条件
            BaseRule rule6 = new BeginEndRule(@"<a href=""http://www.lvmama.com/search/ticket-subject-", @".html""", false, false, true, true);
            rule6.RuleNo = 10;
            rule6.Name = "景区主题rule";
            RuleSet ruleset6 = new RuleSet();
            ruleset6.Name = "景区主题";
            ruleset6.Rules.Add(rule6);
            ruleset6.Code = "scenictopic";

            //第7个条件
            BaseRule rule7 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule7.RuleNo = 10;
            rule7.Name = "topicseorule";
            RuleSet ruleset7 = new RuleSet();
            ruleset7.Name = "topicseo";
            ruleset7.Rules.Add(rule7);
            ruleset7.Code = "fdsafsdfsd";

            //第8个条件
            BaseRule rule8 = new BeginEndRule(@"<div class=""traffic_line"">", "</div>", false, false, true, true);
            rule8.RuleNo = 10;
            rule8.Name = "交通指南rule";
            RuleSet ruleset8 = new RuleSet();
            ruleset8.Name = "交通指南";
            ruleset8.Rules.Add(rule8);
            ruleset8.Code = "trafficeintro";
            ruleset8.OldRegex = new List<string>() { "驴妈妈" };
            ruleset8.NewRegex = new List<string>() { "旅游在线" };

            //第9个条件
            BaseRule rule9 = new BeginEndRule(@"<div class=""tictke_notes"">
                    <ul>
                       <li>
                        ", @"</li>
                    </ul>
                  </div>", false, false, true, true);
            rule9.RuleNo = 10;
            rule9.Name = "订票说明rule";
            RuleSet ruleset9 = new RuleSet();
            ruleset9.Name = "订票说明";
            ruleset9.Rules.Add(rule9);
            ruleset9.Code = "bookintro";
            ruleset9.OldRegex = new List<string>() { "同程", @"入园凭证：.*\s*.*\s*.*" };
            ruleset9.NewRegex = new List<string>() { "旅游在线", @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第10个条件
            BaseRule rule10 = new BeginEndRule(@"<div class=""pane pane_Introduction_in"" id=""Introduction"">", @"<div class=""pane "">", true, false, true, true);
            rule10.RuleNo = 10;
            rule10.Name = "景区详情rule";
            RuleSet ruleset10 = new RuleSet();
            ruleset10.Name = "景区详情";
            ruleset10.Rules.Add(rule10);
            ruleset10.Code = "scenicdetail";
            ruleset10.NeedImageLocalizer = true;
            ruleset10.ImageLocalizerType = "detailimg";
            ruleset10.OldRegex = new List<string>() { "同程" };
            ruleset10.NewRegex = new List<string>() { "旅游在线" };
            ruleset10.ImagePath = @"e:\testDetailimgLocalizer\";
            ruleset10.VirtualPath = "/scenicimg/detailimg";

            //第11个条件
            BaseRule rule11 = new BeginEndRule("fdsafsdfsd", "fdasfds", false, false, true, true);
            rule11.RuleNo = 10;
            rule11.Name = "景区简介rule";
            RuleSet ruleset11 = new RuleSet();
            ruleset11.Name = "景区简介";
            ruleset11.Rules.Add(rule11);
            ruleset11.Code = "scenicintro";
            ruleset11.OldRegex = new List<string>() { "同程" };
            ruleset11.NewRegex = new List<string>() { "旅游在线" };

            //第12个条件
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule12 = new RegexRule(regexExp);
            rule12.RuleNo = 10;
            rule12.Name = "价格rule";
            RuleSet ruleset12 = new RuleSet();
            ruleset12.Name = "价格";
            ruleset12.Rules.Add(rule12);
            ruleset12.Code = "scenicprice";

            BaseRule rule13 = new BeginEndRule(@"<ul class=""Slides"">", @"</ul>", false, false, true, true);
            rule13.RuleNo = 10;
            rule13.Name = "主图rule";
            RuleSet ruleset13 = new RuleSet();
            ruleset13.Name = "主图";
            ruleset13.Rules.Add(rule13);
            ruleset13.Code = "mainimg";
            ruleset13.NeedImageLocalizer = true;
            ruleset13.ImageLocalizerType = "detailimg";
            ruleset13.ImagePath = @"e:\testMainimgLocalizer\";
            ruleset13.VirtualPath = "/scenicimg/mainimg";

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "rlvmamacom";
            ruleset.SetNo = 11;
            ruleset2.SetNo = 12;
            ruleset3.SetNo = 13;
            ruleset4.SetNo = 14;
            ruleset5.SetNo = 15;
            ruleset6.SetNo = 16;
            ruleset7.SetNo = 17;
            ruleset8.SetNo = 18;
            ruleset9.SetNo = 19;
            ruleset10.SetNo = 20;
            ruleset11.SetNo = 21;
            ruleset12.SetNo = 22;
            ruleset13.SetNo = 23;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);
            assm.RuleSets.Add(ruleset4);
            assm.RuleSets.Add(ruleset5);
            assm.RuleSets.Add(ruleset6);
            assm.RuleSets.Add(ruleset7);
            assm.RuleSets.Add(ruleset8);
            assm.RuleSets.Add(ruleset9);
            assm.RuleSets.Add(ruleset10);
            assm.RuleSets.Add(ruleset11);
            assm.RuleSets.Add(ruleset12);
            assm.RuleSets.Add(ruleset13);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"e:\downloadrules\";
            rule.SaveRule(assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"e:\downloadrules\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines = File.ReadAllLines(@"e:\downloadrules\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(), 35);

            //测试,第12行是否相同
            //Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }

        [Test]
        public void SaveRule17Ucn()
        {
            #region 模拟11个ruleset

            //第1个条件
            BaseRule rule1 = new BeginEndRule(@"<h1>
        ", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第2个条件
            BaseRule rule2 = new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第3个条件
            BaseRule rule3 = new BeginEndRule("<span class=\"misp2\">景点地址：", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "景区地址rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "景区地址";
            ruleset3.Rules.Add(rule3);
            ruleset3.Code = "scenicadd";
            ruleset3.OldRegex = new List<string>() { @"入园凭证：.*\s*.*\s*.*" };
            ruleset3.NewRegex = new List<string>() { @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };
            
            //第4个条件
            BaseRule rule4 = new BeginEndRule("fdsafsd", "fdasfsd", false, false, true, true);
            rule4.RuleNo = 10;
            rule4.Name = "seonamerule";
            RuleSet ruleset4 = new RuleSet();
            ruleset4.Name = "seoname";
            ruleset4.Rules.Add(rule4);
            ruleset4.Code = "seoname";

            //第5个条件
            BaseRule rule5 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule5.RuleNo = 10;
            rule5.Name = "seonamerule0";
            BaseRule rule51 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule51.RuleNo = 12;
            rule51.Name = "seonamerule1";
            BaseRule rule52 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule52.RuleNo = 12;
            rule52.Name = "seonamerule2";
            RuleSet ruleset5 = new RuleSet();
            ruleset5.Name = "seoname";
            ruleset5.Rules.Add(rule5);
            ruleset5.Rules.Add(rule51);
            ruleset5.Rules.Add(rule52);
            ruleset5.Code = "seoname";

            //第6个条件
            BaseRule rule6 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule6.RuleNo = 10;
            rule6.Name = "景区主题rule";
            RuleSet ruleset6 = new RuleSet();
            ruleset6.Name = "景区主题";
            ruleset6.Rules.Add(rule6);
            ruleset6.Code = "scenictopic";

            //第7个条件
            BaseRule rule7 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule7.RuleNo = 10;
            rule7.Name = "topicseorule";
            RuleSet ruleset7 = new RuleSet();
            ruleset7.Name = "topicseo";
            ruleset7.Rules.Add(rule7);
            ruleset7.Code = "fdsafsdfsd";

            //第8个条件
            BaseRule rule8 = new BeginEndRule("<!-- 交通指南 start -->", "<!-- 交通指南 end -->", false, false, true, true);
            rule8.RuleNo = 10;
            rule8.Name = "交通指南rule";
            RuleSet ruleset8 = new RuleSet();
            ruleset8.Name = "交通指南";
            ruleset8.Rules.Add(rule8);
            ruleset8.Code = "trafficeintro";
            ruleset8.OldRegex = new List<string>() { "同程" };
            ruleset8.NewRegex = new List<string>() { "旅游在线" };

            //第9个条件
            BaseRule rule9 = new BeginEndRule("<div class=\"point_intro\" id=\"xuzhi\">", "<div class=\"point_intro\" id=\"jieshao\">", true, false, true, true);
            rule9.RuleNo = 10;
            rule9.Name = "订票说明rule";
            RuleSet ruleset9 = new RuleSet();
            ruleset9.Name = "订票说明";
            ruleset9.Rules.Add(rule9);
            ruleset9.Code = "bookintro";
            ruleset9.OldRegex = new List<string>() { "同程", @"入园凭证：.*\s*.*\s*.*" };
            ruleset9.NewRegex = new List<string>() { "旅游在线", @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };
            
            //第10个条件
            BaseRule rule10 = new BeginEndRule(@"<DL class=intro_information>", @"<H4 class=intro_head>", true, false, true, true);
            rule10.RuleNo = 10;
            rule10.Name = "景区详情rule";
            RuleSet ruleset10 = new RuleSet();
            ruleset10.Name = "景区详情";
            ruleset10.Rules.Add(rule10);
            ruleset10.Code = "scenicdetail";
            ruleset10.NeedImageLocalizer = true;
            ruleset10.ImageLocalizerType = "detailimg";
            ruleset10.OldRegex = new List<string>() { "同程" };
            ruleset10.NewRegex = new List<string>() { "旅游在线" };
            ruleset10.ImagePath = @"e:\testDetailimgLocalizer\";
            ruleset10.VirtualPath = "/scenicimg/detailimg";

            //第11个条件
            BaseRule rule11 = new BeginEndRule("fdsafsdfsd", "</h1>", false, false, true, true);
            rule11.RuleNo = 10;
            rule11.Name = "景区简介rule";
            RuleSet ruleset11 = new RuleSet();
            ruleset11.Name = "景区简介";
            ruleset11.Rules.Add(rule11);
            ruleset11.Code = "scenicintro";
            ruleset11.OldRegex = new List<string>() { "同程" };
            ruleset11.NewRegex = new List<string>() { "旅游在线" };

            //第12个条件
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule12 = new RegexRule(regexExp);
            rule12.RuleNo = 10;
            rule12.Name = "价格rule";
            RuleSet ruleset12 = new RuleSet();
            ruleset12.Name = "价格";
            ruleset12.Rules.Add(rule12);
            ruleset12.Code = "scenicprice";

            BeginEndRule rule13 = new BeginEndRule(@"<div id=""comSlide_main"" class=""slide_main""  >",@"/div>",false,false,true,true);
            rule13.RuleNo = 10;
            rule13.Name = "主图rule";
            RuleSet ruleset13 = new RuleSet();
            ruleset13.Name = "主图";
            ruleset13.Rules.Add(rule13);
            ruleset13.Code = "mainimg";
            ruleset13.NeedImageLocalizer = true;
            ruleset13.ImageLocalizerType = "mainimg";
            ruleset13.ImagePath = @"e:\testMainimgLocalizer\";
            ruleset13.VirtualPath = "/scenicimg/mainimg";

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "r17ucn";
            ruleset.SetNo = 11;
            ruleset2.SetNo = 12;
            ruleset3.SetNo = 13;
            ruleset4.SetNo = 14;
            ruleset5.SetNo = 15;
            ruleset6.SetNo = 16;
            ruleset7.SetNo = 17;
            ruleset8.SetNo = 18;
            ruleset9.SetNo = 19;
            ruleset10.SetNo = 20;
            ruleset11.SetNo = 21;
            ruleset12.SetNo = 22;
            ruleset13.SetNo = 23;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);
            assm.RuleSets.Add(ruleset4);
            assm.RuleSets.Add(ruleset5);
            assm.RuleSets.Add(ruleset6);
            assm.RuleSets.Add(ruleset7);
            assm.RuleSets.Add(ruleset8);
            assm.RuleSets.Add(ruleset9);
            assm.RuleSets.Add(ruleset10);
            assm.RuleSets.Add(ruleset11);
            assm.RuleSets.Add(ruleset12);
            assm.RuleSets.Add(ruleset13);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"e:\downloadrules\";
            rule.SaveRule(assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"e:\downloadrules\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines = File.ReadAllLines(@"e:\downloadrules\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(), 35);

            //测试,第12行是否相同
            //Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }

        [Test]
        public void SaveRule17Ucom()
        {
            #region 模拟11个ruleset

            //第1个条件
            BaseRule rule1 = new BeginEndRule(@"<div class=""Name"">", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第2个条件
            BaseRule rule2 = new BeginEndRule("<span class=\"orange02\" >", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第3个条件
            BaseRule rule3 = new BeginEndRule("<span class=\"misp2\">景点地址：", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "景区地址rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "景区地址";
            ruleset3.Rules.Add(rule3);
            ruleset3.Code = "scenicadd";
            ruleset3.OldRegex = new List<string>() { @"入园凭证：.*\s*.*\s*.*" };
            ruleset3.NewRegex = new List<string>() { @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };
            

            //第4个条件
            BaseRule rule4 = new BeginEndRule("fdsafsd", "fdasfsd", false, false, true, true);
            rule4.RuleNo = 10;
            rule4.Name = "seonamerule";
            RuleSet ruleset4 = new RuleSet();
            ruleset4.Name = "seoname";
            ruleset4.Rules.Add(rule4);
            ruleset4.Code = "seoname";

            //第5个条件
            BaseRule rule5 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule5.RuleNo = 10;
            rule5.Name = "seonamerule0";
            BaseRule rule51 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule51.RuleNo = 12;
            rule51.Name = "seonamerule1";
            BaseRule rule52 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule52.RuleNo = 12;
            rule52.Name = "seonamerule2";
            RuleSet ruleset5 = new RuleSet();
            ruleset5.Name = "seoname";
            ruleset5.Rules.Add(rule5);
            ruleset5.Rules.Add(rule51);
            ruleset5.Rules.Add(rule52);
            ruleset5.Code = "seoname";

            //第6个条件
            BaseRule rule6 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule6.RuleNo = 10;
            rule6.Name = "景区主题rule";
            RuleSet ruleset6 = new RuleSet();
            ruleset6.Name = "景区主题";
            ruleset6.Rules.Add(rule6);
            ruleset6.Code = "scenictopic";

            //第7个条件
            BaseRule rule7 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule7.RuleNo = 10;
            rule7.Name = "topicseorule";
            RuleSet ruleset7 = new RuleSet();
            ruleset7.Name = "topicseo";
            ruleset7.Rules.Add(rule7);
            ruleset7.Code = "fdsafsdfsd";

            //第8个条件
            BaseRule rule8 = new BeginEndRule("<div class=\"drive_way\">", "</div>", false, false, true, true);
            rule8.RuleNo = 10;
            rule8.Name = "交通指南rule";
            RuleSet ruleset8 = new RuleSet();
            ruleset8.Name = "交通指南";
            ruleset8.Rules.Add(rule8);
            ruleset8.Code = "trafficeintro";
            ruleset8.OldRegex = new List<string>() { "同程" };
            ruleset8.NewRegex = new List<string>() { "旅游在线" };

            //第9个条件
            BaseRule rule9 = new BeginEndRule("<div class=\"bd\">", "<div class=\"point_intro\" id=\"jieshao\">", true, false, true, true);
            rule9.RuleNo = 10;
            rule9.Name = "订票说明rule";
            RuleSet ruleset9 = new RuleSet();
            ruleset9.Name = "订票说明";
            ruleset9.Rules.Add(rule9);
            ruleset9.Code = "bookintro";
            ruleset9.OldRegex = new List<string>() { "同程", @"入园凭证：.*\s*.*\s*.*" };
            ruleset9.NewRegex = new List<string>() { "旅游在线", @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第10个条件
            BaseRule rule10 = new BeginEndRule("<DL class=intro_information>", "<H4 class=intro_head>", true, false, true, true);
            rule10.RuleNo = 10;
            rule10.Name = "景区详情rule";
            RuleSet ruleset10 = new RuleSet();
            ruleset10.Name = "景区详情";
            ruleset10.Rules.Add(rule10);
            ruleset10.Code = "scenicdetail";
            ruleset10.NeedImageLocalizer = true;
            ruleset10.ImageLocalizerType = "detailimg";
            ruleset10.OldRegex = new List<string>() { "同程" };
            ruleset10.NewRegex = new List<string>() { "旅游在线" };
            ruleset10.ImagePath = @"e:\testDetailimgLocalizer\";
            ruleset10.VirtualPath = "/scenicimg/detailimg";

            //第11个条件
            BaseRule rule11 = new BeginEndRule("fdsafsdfsd", "</h1>", false, false, true, true);
            rule11.RuleNo = 10;
            rule11.Name = "景区简介rule";
            RuleSet ruleset11 = new RuleSet();
            ruleset11.Name = "景区简介";
            ruleset11.Rules.Add(rule11);
            ruleset11.Code = "scenicintro";
            ruleset11.OldRegex = new List<string>() { "同程" };
            ruleset11.NewRegex = new List<string>() { "旅游在线" };

            //第12个条件
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule12 = new RegexRule(regexExp);
            rule12.RuleNo = 10;
            rule12.Name = "价格rule";
            RuleSet ruleset12 = new RuleSet();
            ruleset12.Name = "价格";
            ruleset12.Rules.Add(rule12);
            ruleset12.Code = "scenicprice";

            BaseRule rule13 = new BeginEndRule(@"<ul class=""oUl"">", @"</ul>", false, false, true, true);
            rule13.RuleNo = 10;
            rule13.Name = "主图rule";
            RuleSet ruleset13 = new RuleSet();
            ruleset13.Name = "主图";
            ruleset13.Rules.Add(rule13);
            ruleset13.Code = "mainimg";
            ruleset13.NeedImageLocalizer = true;
            ruleset13.ImageLocalizerType = "mainimg";
            ruleset13.ImagePath = @"e:\testMainimgLocalizer\";
            ruleset13.VirtualPath = "/scenicimg/mainimg";

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "r17ucom";
            ruleset.SetNo = 11;
            ruleset2.SetNo = 12;
            ruleset3.SetNo = 13;
            ruleset4.SetNo = 14;
            ruleset5.SetNo = 15;
            ruleset6.SetNo = 16;
            ruleset7.SetNo = 17;
            ruleset8.SetNo = 18;
            ruleset9.SetNo = 19;
            ruleset10.SetNo = 20;
            ruleset11.SetNo = 21;
            ruleset12.SetNo = 22;
            ruleset13.SetNo = 23;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);
            assm.RuleSets.Add(ruleset4);
            assm.RuleSets.Add(ruleset5);
            assm.RuleSets.Add(ruleset6);
            assm.RuleSets.Add(ruleset7);
            assm.RuleSets.Add(ruleset8);
            assm.RuleSets.Add(ruleset9);
            assm.RuleSets.Add(ruleset10);
            assm.RuleSets.Add(ruleset11);
            assm.RuleSets.Add(ruleset12);
            assm.RuleSets.Add(ruleset13);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"e:\downloadrules\";
            rule.SaveRule(assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"e:\downloadrules\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines = File.ReadAllLines(@"e:\downloadrules\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(), 35);

            //测试,第12行是否相同
            //Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }

        [Test]
        public void SaveRuleTuniu()
        {
            #region 模拟11个ruleset

            //第1个条件
            BaseRule rule1 = new BeginEndRule(@"<h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";

            //第2个条件
            BaseRule rule2 = new BeginEndRule("<span class=\"orange02\" >", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第3个条件
            BaseRule rule3 = new BeginEndRule("<span class=\"misp2\">景点地址：", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "景区地址rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "景区地址";
            ruleset3.Rules.Add(rule3);
            ruleset3.Code = "scenicadd";
            ruleset3.OldRegex = new List<string>() { @"入园凭证：.*\s*.*\s*.*" };
            ruleset3.NewRegex = new List<string>() { @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第4个条件
            BaseRule rule4 = new BeginEndRule("fdsafsd", "fdasfsd", false, false, true, true);
            rule4.RuleNo = 10;
            rule4.Name = "seonamerule";
            RuleSet ruleset4 = new RuleSet();
            ruleset4.Name = "seoname";
            ruleset4.Rules.Add(rule4);
            ruleset4.Code = "seoname";

            //第5个条件
            BaseRule rule5 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule5.RuleNo = 10;
            rule5.Name = "seonamerule0";
            BaseRule rule51 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule51.RuleNo = 12;
            rule51.Name = "seonamerule1";
            BaseRule rule52 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule52.RuleNo = 12;
            rule52.Name = "seonamerule2";
            RuleSet ruleset5 = new RuleSet();
            ruleset5.Name = "seoname";
            ruleset5.Rules.Add(rule5);
            ruleset5.Rules.Add(rule51);
            ruleset5.Rules.Add(rule52);
            ruleset5.Code = "seoname";

            //第6个条件
            BaseRule rule6 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule6.RuleNo = 10;
            rule6.Name = "景区主题rule";
            RuleSet ruleset6 = new RuleSet();
            ruleset6.Name = "景区主题";
            ruleset6.Rules.Add(rule6);
            ruleset6.Code = "scenictopic";

            //第7个条件
            BaseRule rule7 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule7.RuleNo = 10;
            rule7.Name = "topicseorule";
            RuleSet ruleset7 = new RuleSet();
            ruleset7.Name = "topicseo";
            ruleset7.Rules.Add(rule7);
            ruleset7.Code = "fdsafsdfsd";

            //第8个条件
            BaseRule rule8 = new BeginEndRule("<ul class=\"traffic_infor\">", "</ul>", false, false, true, true);
            rule8.RuleNo = 10;
            rule8.Name = "交通指南rule";
            RuleSet ruleset8 = new RuleSet();
            ruleset8.Name = "交通指南";
            ruleset8.Rules.Add(rule8);
            ruleset8.Code = "trafficeintro";
            ruleset8.OldRegex = new List<string>() { "同程" };
            ruleset8.NewRegex = new List<string>() { "旅游在线" };

            //第9个条件
            BaseRule rule9 = new BeginEndRule("<h2 id=\"ydxz\" class=\"detail_h2\"><span>(*)</span></h2>",
                @"</div>
          <div", true, false, true, true);
            rule9.RuleNo = 10;
            rule9.Name = "订票说明rule";
            RuleSet ruleset9 = new RuleSet();
            ruleset9.Name = "订票说明";
            ruleset9.Rules.Add(rule9);
            ruleset9.Code = "bookintro";
            ruleset9.OldRegex = new List<string>() { "同程", @"入园凭证：.*\s*.*\s*.*" };
            ruleset9.NewRegex = new List<string>() { "旅游在线", @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第10个条件
            BaseRule rule10 = new BeginEndRule("<h2 id=\"jqjs\" class=\"detail_h2\"><span>(*)</span></h2>",
                @"</div>
          <div", true, false, true, true);
            rule10.RuleNo = 10;
            rule10.Name = "景区详情rule";
            RuleSet ruleset10 = new RuleSet();
            ruleset10.Name = "景区详情";
            ruleset10.Rules.Add(rule10);
            ruleset10.Code = "scenicdetail";
            ruleset10.NeedImageLocalizer = true;
            ruleset10.ImageLocalizerType = "detailimg";
            ruleset10.OldRegex = new List<string>() { "同程" };
            ruleset10.NewRegex = new List<string>() { "旅游在线" };
            ruleset10.ImagePath = @"e:\testDetailimgLocalizer\";
            ruleset10.VirtualPath = "/scenicimg/detailimg";

            //第11个条件
            BaseRule rule11 = new BeginEndRule("fdsafsdfsd", "</h1>", false, false, true, true);
            rule11.RuleNo = 10;
            rule11.Name = "景区简介rule";
            RuleSet ruleset11 = new RuleSet();
            ruleset11.Name = "景区简介";
            ruleset11.Rules.Add(rule11);
            ruleset11.Code = "scenicintro";
            ruleset11.OldRegex = new List<string>() { "同程" };
            ruleset11.NewRegex = new List<string>() { "旅游在线" };

            //第12个条件
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule12 = new RegexRule(regexExp);
            rule12.RuleNo = 10;
            rule12.Name = "价格rule";
            RuleSet ruleset12 = new RuleSet();
            ruleset12.Name = "价格";
            ruleset12.Rules.Add(rule12);
            ruleset12.Code = "scenicprice";

            BaseRule rule13 = new BeginEndRule(@"<ul class=""oUl"">", @"</ul>", false, false, true, true);
            rule13.RuleNo = 10;
            rule13.Name = "主图rule";
            RuleSet ruleset13 = new RuleSet();
            ruleset13.Name = "主图";
            ruleset13.Rules.Add(rule13);
            ruleset13.Code = "mainimg";
            ruleset13.NeedImageLocalizer = true;
            ruleset13.ImageLocalizerType = "mainimg";
            ruleset13.ImagePath = @"e:\testMainimgLocalizer\";
            ruleset13.VirtualPath = "/scenicimg/mainimg";

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "rtuniucom";
            ruleset.SetNo = 11;
            ruleset2.SetNo = 12;
            ruleset3.SetNo = 13;
            ruleset4.SetNo = 14;
            ruleset5.SetNo = 15;
            ruleset6.SetNo = 16;
            ruleset7.SetNo = 17;
            ruleset8.SetNo = 18;
            ruleset9.SetNo = 19;
            ruleset10.SetNo = 20;
            ruleset11.SetNo = 21;
            ruleset12.SetNo = 22;
            ruleset13.SetNo = 23;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);
            assm.RuleSets.Add(ruleset4);
            assm.RuleSets.Add(ruleset5);
            assm.RuleSets.Add(ruleset6);
            assm.RuleSets.Add(ruleset7);
            assm.RuleSets.Add(ruleset8);
            assm.RuleSets.Add(ruleset9);
            assm.RuleSets.Add(ruleset10);
            assm.RuleSets.Add(ruleset11);
            assm.RuleSets.Add(ruleset12);
            assm.RuleSets.Add(ruleset13);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"e:\downloadrules\";
            rule.SaveRule(assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"e:\downloadrules\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines = File.ReadAllLines(@"e:\downloadrules\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(), 35);

            //测试,第12行是否相同
            //Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }

        [Test]
        public void SaveRuleNettvl()
        {
            #region 模拟11个ruleset

            //第1个条件
            BaseRule rule1 = new BeginEndRule(@"<h1 id=pTitle>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";

            //第2个条件
            BaseRule rule2 = new BeginEndRule("<span class=\"orange02\" >", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第3个条件
            BaseRule rule3 = new BeginEndRule("<span class=\"misp2\">景点地址：", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "景区地址rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "景区地址";
            ruleset3.Rules.Add(rule3);
            ruleset3.Code = "scenicadd";
            ruleset3.OldRegex = new List<string>() { @"入园凭证：.*\s*.*\s*.*" };
            ruleset3.NewRegex = new List<string>() { @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第4个条件
            BaseRule rule4 = new BeginEndRule("fdsafsd", "fdasfsd", false, false, true, true);
            rule4.RuleNo = 10;
            rule4.Name = "seonamerule";
            RuleSet ruleset4 = new RuleSet();
            ruleset4.Name = "seoname";
            ruleset4.Rules.Add(rule4);
            ruleset4.Code = "seoname";

            //第5个条件
            BaseRule rule5 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule5.RuleNo = 10;
            rule5.Name = "seonamerule0";
            BaseRule rule51 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule51.RuleNo = 12;
            rule51.Name = "seonamerule1";
            BaseRule rule52 = new BeginEndRule("<a name=\"nav_open\" class=\"n_nav_common\" href=\"javascript:void(0);\">", "<s></s>", false, false, true, true);
            rule52.RuleNo = 12;
            rule52.Name = "seonamerule2";
            RuleSet ruleset5 = new RuleSet();
            ruleset5.Name = "seoname";
            ruleset5.Rules.Add(rule5);
            ruleset5.Rules.Add(rule51);
            ruleset5.Rules.Add(rule52);
            ruleset5.Code = "seoname";

            //第6个条件
            BaseRule rule6 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule6.RuleNo = 10;
            rule6.Name = "景区主题rule";
            RuleSet ruleset6 = new RuleSet();
            ruleset6.Name = "景区主题";
            ruleset6.Rules.Add(rule6);
            ruleset6.Code = "scenictopic";

            //第7个条件
            BaseRule rule7 = new BeginEndRule("fdsafsdfsd", "fdsafsdfsd", false, false, true, true);
            rule7.RuleNo = 10;
            rule7.Name = "topicseorule";
            RuleSet ruleset7 = new RuleSet();
            ruleset7.Name = "topicseo";
            ruleset7.Rules.Add(rule7);
            ruleset7.Code = "fdsafsdfsd";

            //第8个条件
            BaseRule rule8 = new BeginEndRule(@"<dd id=""ShopTab1"" style=""display:none;"">", "</dd>", false, false, true, true);
            rule8.RuleNo = 10;
            rule8.Name = "交通指南rule";
            RuleSet ruleset8 = new RuleSet();
            ruleset8.Name = "交通指南";
            ruleset8.Rules.Add(rule8);
            ruleset8.Code = "trafficeintro";
            ruleset8.OldRegex = new List<string>() { "同程" };
            ruleset8.NewRegex = new List<string>() { "旅游在线" };

            //第9个条件
            BaseRule rule9 = new BeginEndRule("ds",@"fdsf", true, false, true, true);
            rule9.RuleNo = 10;
            rule9.Name = "订票说明rule";
            RuleSet ruleset9 = new RuleSet();
            ruleset9.Name = "订票说明";
            ruleset9.Rules.Add(rule9);
            ruleset9.Code = "bookintro";
            ruleset9.OldRegex = new List<string>() { "同程", @"入园凭证：.*\s*.*\s*.*" };
            ruleset9.NewRegex = new List<string>() { "旅游在线", @"取票凭证：</span><span class=""info_content""><p>凭身份证到景区售票窗口取票入园。</p>" };

            //第10个条件
            BaseRule rule10 = new BeginEndRule(@"<dd id=""ShopTab0"">",
                @"</dd>", true, false, true, true);
            rule10.RuleNo = 10;
            rule10.Name = "景区详情rule";
            RuleSet ruleset10 = new RuleSet();
            ruleset10.Name = "景区详情";
            ruleset10.Rules.Add(rule10);
            ruleset10.Code = "scenicdetail";
            ruleset10.NeedImageLocalizer = true;
            ruleset10.ImageLocalizerType = "detailimg";
            ruleset10.OldRegex = new List<string>() { "同程" };
            ruleset10.NewRegex = new List<string>() { "旅游在线" };
            ruleset10.ImagePath = @"e:\testDetailimgLocalizer\";
            ruleset10.VirtualPath = "/scenicimg/detailimg";

            //第11个条件
            BaseRule rule11 = new BeginEndRule("fdsafsdfsd", "</h1>", false, false, true, true);
            rule11.RuleNo = 10;
            rule11.Name = "景区简介rule";
            RuleSet ruleset11 = new RuleSet();
            ruleset11.Name = "景区简介";
            ruleset11.Rules.Add(rule11);
            ruleset11.Code = "scenicintro";
            ruleset11.OldRegex = new List<string>() { "同程" };
            ruleset11.NewRegex = new List<string>() { "旅游在线" };

            //第12个条件
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule12 = new RegexRule(regexExp);
            rule12.RuleNo = 10;
            rule12.Name = "价格rule";
            RuleSet ruleset12 = new RuleSet();
            ruleset12.Name = "价格";
            ruleset12.Rules.Add(rule12);
            ruleset12.Code = "scenicprice";

            BaseRule rule13 = new BeginEndRule(@"<div class=""p_font_PicUrl"">", @"</div>", false, false, false, false);
            rule13.RuleNo = 10;
            rule13.Name = "主图rule";
            RuleSet ruleset13 = new RuleSet();
            ruleset13.Name = "主图";
            ruleset13.Rules.Add(rule13);
            ruleset13.Code = "mainimg";
            ruleset13.NeedImageLocalizer = true;
            ruleset13.ImageLocalizerType = "detailimg";
            ruleset13.ImagePath = @"e:\testMainimgLocalizer\";
            ruleset13.VirtualPath = "/scenicimg/mainimg";

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "rnettvlcom";
            ruleset.SetNo = 11;
            ruleset2.SetNo = 12;
            ruleset3.SetNo = 13;
            ruleset4.SetNo = 14;
            ruleset5.SetNo = 15;
            ruleset6.SetNo = 16;
            ruleset7.SetNo = 17;
            ruleset8.SetNo = 18;
            ruleset9.SetNo = 19;
            ruleset10.SetNo = 20;
            ruleset11.SetNo = 21;
            ruleset12.SetNo = 22;
            ruleset13.SetNo = 23;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);
            assm.RuleSets.Add(ruleset4);
            assm.RuleSets.Add(ruleset5);
            assm.RuleSets.Add(ruleset6);
            assm.RuleSets.Add(ruleset7);
            assm.RuleSets.Add(ruleset8);
            assm.RuleSets.Add(ruleset9);
            assm.RuleSets.Add(ruleset10);
            assm.RuleSets.Add(ruleset11);
            assm.RuleSets.Add(ruleset12);
            assm.RuleSets.Add(ruleset13);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"e:\downloadrules\";
            rule.SaveRule(assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"e:\downloadrules\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines = File.ReadAllLines(@"e:\downloadrules\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(), 35);

            //测试,第12行是否相同
            //Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }

        [Test]
        public void ReadRule()
        {
            IPersistence.IRule rule = new Persistence.Rule();
            rule.PersistencePath = @"d:\";
            #region 写一个xml
            #region 模拟2个ruleset

            //第1个set
            BaseRule rule1 = new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第2个set
            BaseRule rule2 = new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第3个set
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule3 = new RegexRule(regexExp);
            rule3.RuleNo = 10;
            rule3.Name = "价格rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "价格";
            ruleset3.Code = "price";
            ruleset3.Rules.Add(rule3);

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            assm.Name = "tongchengcom";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            ruleset3.SetNo = 12;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);

            #endregion

            rule.SaveRule(assm);
            #endregion

            #region 读一个xml

            CE.Domain.Rule.RuleAssembly ra = rule.ReadRule(assm.Name);
            CE.Domain.Rule.BeginEndRule ber = (CE.Domain.Rule.BeginEndRule)ra.RuleSets[0].Rules[0];
            Assert.AreEqual(ber.Name, "标题rule");
            Assert.AreEqual(ber.RuleNo.ToString(), "10");
            Assert.AreEqual(ber.Enabled.ToString(), "True");
            Assert.AreEqual(ber.BeginMark, "<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>");
            Assert.AreEqual(ber.EndMark, "</h1>");

            CE.Domain.Rule.BeginEndRule ber1 = ra.RuleSets[0].Rules[0] as CE.Domain.Rule.BeginEndRule;
            Assert.IsNotNull(ber1);
            CE.Domain.Rule.RegexRule ber2 = ra.RuleSets[2].Rules[0] as CE.Domain.Rule.RegexRule;
            Assert.IsNotNull(ber1);

            #endregion
        }
    }
}
