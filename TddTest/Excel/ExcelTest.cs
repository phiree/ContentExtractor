﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TddTest.Excel
{
    [TestFixture]
    public class ExcelTest
    {
        [Test]
        public void Persistence2ExcelTest()
        {
            ExcelOpr.ExcelOpr eo = new ExcelOpr.ExcelOpr();
            eo.Persistence2Excel(2, "杭州西溪湿地$AAAA");
            List<ExcelOpr.Entity.ScenicEntity> sclist = eo.getSceniclist();
            Assert.AreEqual(sclist[0].name, "杭州西溪湿地");
            Assert.AreEqual(sclist[0].level, "AAAA");
        }
    }
}