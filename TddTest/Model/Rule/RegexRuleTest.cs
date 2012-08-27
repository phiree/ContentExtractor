using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.Domain.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
    public class RegexRuleTest
    {
        [Test]
        public void FilterUsingRuleTest()
        {

            string rawContent = new CE.Component.HtmlHandler().ReadHtml(@"D:\downloading\2113864687.html");
            Assert.AreEqual("启园$#$60$#$48$#$",
                new RegexRule(@"<div class=""st_bod"">(?<name>.*?)</div>.*?<span class=""parGd"">.(?<price>\d+)</span>").FilterUsingRule(ref rawContent));
           // new RegexRule(@"id=""se_title_\d+""\>\r*\s+\<span\>(?<t_name>.*?)\</span\>").FilterUsingRule(ref rawContent));
            /*
             name: id=""se_title_1"">\s*<span>(?<t_name>.*?)</span>
             */
        }

      
    }
}
