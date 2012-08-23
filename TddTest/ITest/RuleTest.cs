using System;
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
        [Test]
        public void SaveRule()
        {
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
            assm.Name = "tongcheng";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            #endregion

            IPersistence.IRule rule = new Persistence.Rule(@"d:\");
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
        public void ReadRule()
        {
            IPersistence.IRule rule = new Persistence.Rule(@"d:\");
            #region 写一个xml
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
            assm.Name = "tongcheng";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            #endregion

            rule.SaveRule(assm);
            #endregion

            #region 读一个xml

            CE.Domain.Rule.RuleAssembly ra = rule.ReadRule(assm.Name);
            CE.Domain.Rule.BeginEndRule ber=(CE.Domain.Rule.BeginEndRule)ra.RuleSets[0].Rules[0];
            Assert.AreEqual(ber.Name, "标题rule");
            Assert.AreEqual(ber.RuleNo.ToString(), "10");
            Assert.AreEqual(ber.Enabled.ToString(), "True");
            Assert.AreEqual(ber.BeginMark, "<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>");
            Assert.AreEqual(ber.EndMark, "</h1>");

            #endregion
        }
    }
}
