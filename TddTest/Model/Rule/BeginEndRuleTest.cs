﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.BLL;
using CE.Model.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
    public class BeginEndRuleTest
    {
        [Test]
        public void FilterUsingRuleTest()
        {

            Assert.AreEqual("<div>仙都风景名胜区",
                new BeginEndRule("<div>", "</div>", true, false).FilterUsingRule("<div>仙都风景名胜区</div>"));

        }





    }
}