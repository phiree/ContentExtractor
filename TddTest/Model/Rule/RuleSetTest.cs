using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.BLL;
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
            RuleSet ruleset = new RuleSet();
            
            ruleset.Rules.Add(rule1);
            ruleset.Rules.Add(rule2);
            string raw="1<div>a</div>2<span>b</span>3";
            Assert.AreEqual("ab", ruleset.FilterUsingRuleSet(ref raw, false));

            //输出为json格式
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Rules.Add(rule1);
            ruleset2.Rules.Add(rule2);
            ruleset2.Code = "name";
            string raw2 = "1<div>a</div>2<span>b</span>3";
            Assert.AreEqual(@"name:""ab""", ruleset2.FilterUsingRuleSet(ref raw2, true));
        }




    }
}
