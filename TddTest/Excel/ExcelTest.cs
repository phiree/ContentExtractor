using System;
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
            eo.Persistence2Excel();

        }
    }
}
