using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Reflection;
using System.IO;

namespace ExcelOpr
{
    /// <summary>
    /// Excel操作类 
    /// <!--说明程序约定3条-->
    /// 1.将excel放在d盘下, 文件名为"2012年浙江省A级旅游景区汇总统计表.xls"
    /// 2.在d盘下创建scenicimg文件夹, 并确保是空.
    /// 3.将各景区图片放在以景区命名的文件夹中, 并将此文件夹放到d盘的图片文件夹中.
    /// </summary>
    public class ExcelOpr
    {
        public void Persistence2Excel()
        {
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1;
            Worksheet worksheet1;
            if (!File.Exists(@"d:\sst.xls"))
            {
                workbook1 = excel1.Workbooks.Add(true);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                worksheet1 = (Worksheet)workbook1.Worksheets.Add(Type.Missing, workbook1.Worksheets["sheet1"], 1, Type.Missing);
                excel1.Visible = true;
                worksheet1.Cells[1, 1] = "姓名";
                worksheet1.Cells[1, 2] = "性别";
                excel1.Visible = true;
                excel1.DisplayAlerts = false;//不显示提示框
                workbook1.Close(true, "d:\\1.xls", null);
                //关闭
                worksheet1 = null;
                workbook1 = null;
                excel1.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
                excel1 = null;
                System.GC.Collect();
            }
            else
            {
                workbook1 = excel1.Workbooks.Open(@"d:\sst.xls", Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                worksheet1.Cells[1, 1] = "姓名";
                worksheet1.Cells[1, 2] = "性别";
                excel1.Visible = true;
                excel1.DisplayAlerts = false;//不显示提示框
                workbook1.Close(true, "d:\\1.xls", null);
                //关闭
                worksheet1 = null;
                workbook1 = null;
                excel1.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
                excel1 = null;
                System.GC.Collect();
            }
        }
    }
}
