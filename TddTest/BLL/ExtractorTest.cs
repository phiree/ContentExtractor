using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using CE.Domain;
using System.IO;
using CE.Domain.Rule;
namespace TddTest.BLL
{
    /// <summary>
    /// 根据某个规则,提取内容
    /// </summary>
    [TestFixture]
    public class ExtractorTest
    {
        [Test]
        public void SaveRule()
        {
            //两个条件
            BaseRule rule1 = new BeginEndRule("<div id=dv1>", "</div>", true, true, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "rule1inset1";
            BaseRule rule2 = new BeginEndRule("<span id=sp1>", "</span>", true, true, true, true);
            rule2.RuleNo = 11;
            rule2.Name = "rule11inset1";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "ruleset1";
            ruleset.Rules.Add(rule1);
            ruleset.Rules.Add(rule2);
            ruleset.Code = "Pro1";


            //第二个set
            BaseRule rule3 = new BeginEndRule("<div id=dv2>", "</div>", true, true, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "rule3inset2";
            BaseRule rule4 = new BeginEndRule("<span id=sp2>", "</span>", true, true, true, true);
            rule4.RuleNo = 11;
            rule4.Name = "rule4inset2";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "ruleset2";
            ruleset2.Code = "Pro2";

            ruleset2.Rules.Add(rule3);
            ruleset2.Rules.Add(rule4);

            RuleAssembly assm = new RuleAssembly();
            assm.Name = "sst";
            assm.CodeName = "Ass";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            IPersistence.IRule rule = new Persistence.Rule();
            rule.SaveRule(@"d:\", assm);

            //测试,是否存在该文件
            Assert.IsTrue(File.Exists(@"d:\" + assm.Name + ".xml"));

            //测试,是否达到指定行数
            //(xml[1]+assembly[2]+rulesetNum[z]*(ruleProperty[x]+rulesetProperty[y]))
            //x=12;y=4;z=2   得35
            string[] filelines=File.ReadAllLines(@"d:\" + assm.Name + ".xml");
            Assert.GreaterOrEqual(filelines.Count(),35);

            //测试,第12行是否相同
            Assert.AreEqual("<RuleNo>10</RuleNo>", filelines[11].Trim());
        }
    }
}
