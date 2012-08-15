using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.BLL;
using CE.Model.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
   public class RuleSetTest
    {
        [Test]
        public void FilterUsingRuleSetTest()
        {
            //两个条件
            BaseRule rule1 = new BeginEndRule("<div>", "</div>", false, false);
            rule1.OrderNumber = 10;
            BaseRule rule2= new BeginEndRule("<span>", "</span>", false, false);
            rule2.OrderNumber = 11;
            RuleSet ruleset = new RuleSet();
            
            ruleset.Rules.Add(rule1);
            ruleset.Rules.Add(rule2);

            Assert.AreEqual("ab", ruleset.FilterUsingRuleSet("1<div>a</div>2<span>b</span>3", false));

            //输出为json格式
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Rules.Add(rule1);
            ruleset2.Rules.Add(rule2);
            ruleset2.Code = "name";

            Assert.AreEqual(@"{name:""ab""}", ruleset2.FilterUsingRuleSet("1<div>a</div>2<span>b</span>3", true));
        }




    }
}
