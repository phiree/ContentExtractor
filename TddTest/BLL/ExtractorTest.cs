﻿using System;
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
            BaseRule rule2 = new BeginEndRule("<span id=sp1>", "</span>", true, true, true, true);
            rule2.RuleNo = 11;
            RuleSet ruleset = new RuleSet();
            ruleset.Rules.Add(rule1);
            ruleset.Rules.Add(rule2);
            ruleset.Code = "Pro1";


            //第二个set
            BaseRule rule3 = new BeginEndRule("<div id=dv2>", "</div>", true, true, true, true);
            rule3.RuleNo = 10;
            BaseRule rule4 = new BeginEndRule("<span id=sp2>", "</span>", true, true, true, true);
            rule4.RuleNo = 11;
            RuleSet ruleset2 = new RuleSet();
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
            rule.SaveRule(assm);
        }
    }
}
