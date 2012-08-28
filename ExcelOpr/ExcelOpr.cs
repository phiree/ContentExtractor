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
        private string savepath;
        public string SavePath
        {
            get
            {
                if (!string.IsNullOrEmpty(savepath))
                {
                    return savepath;
                }
                else
                {
                    return @"d:\sst.xls";
                }
            }
            set
            {
                savepath = value;
            }
        }

        private string savepricepath;
        public string SavePricePath
        {
            get
            {
                if (!string.IsNullOrEmpty(savepricepath))
                {
                    return savepricepath;
                }
                else
                {
                    return @"d:\sst2.xls";
                }
            }
            set
            {
                savepath = value;
            }
        }

        /// <summary>
        /// 持久化景区信息
        /// </summary>
        /// <param name="row"></param>
        /// <param name="htmlPragraph"></param>
        /// <param name="savePath"></param>
        public void Persistence2Excel(int row, string htmlPragraph, string savePath,string savePricePath)
        {
            SavePath = savePath;
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
            Microsoft.Office.Interop.Excel.Application excel2 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook2 = null;
            Worksheet worksheet2 = null;
            if (!File.Exists(SavePath))
            {
                workbook1 = excel1.Workbooks.Add(Missing.Value);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
                //赋值给title
                worksheet1.Cells[1, 1] = "名称";
                worksheet1.Cells[1, 2] = "等级";
                worksheet1.Cells[1, 3] = "景区地址";
                worksheet1.Cells[1, 4] = "seoname";
                worksheet1.Cells[1, 5] = "区域";
                worksheet1.Cells[1, 6] = "景区主题";
                worksheet1.Cells[1, 7] = "topicseo";
                worksheet1.Cells[1, 8] = "交通指南";
                worksheet1.Cells[1, 9] = "订票说明";
                worksheet1.Cells[1, 10] = "景区详情";
                worksheet1.Cells[1, 11] = "景区简介";
                worksheet1.Cells[1, 12] = "票价";
            }
            else
            {
                workbook1 = excel1.Workbooks.Open(SavePath, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
            }
            if (!File.Exists(savePricePath))
            {
                workbook2 = excel2.Workbooks.Add(Missing.Value);
                worksheet2 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel2.Visible = false;
                //赋值给title
                worksheet2.Cells[1, 1] = "景区名称";
                worksheet2.Cells[1, 2] = "门票名称";
                worksheet2.Cells[1, 3] = "原价";
                worksheet2.Cells[1, 4] = "在线支付价";
            }
            else
            {
                workbook2 = excel1.Workbooks.Open(savePricePath, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet2 = (Worksheet)workbook2.Worksheets["sheet1"];
                excel2.Visible = false;
            }
            //赋值给单元格
            string[] result = htmlPragraph.Split(new string[] { "$#$" }, 12, StringSplitOptions.None);
            for (int i = 0; i < result.Length; i++)
            {
                if (i == 1)
                {
                    if (!string.IsNullOrEmpty(result[i]))
                    {
                        int count = result[i].Length;
                        result[i] = count.ToString() + "A";
                    }
                }
                if (i == 4)
                {
                    if (!string.IsNullOrEmpty(result[i]))
                    {
                        string[] area = result[i].Split(new string[] { "景区门票" }, StringSplitOptions.RemoveEmptyEntries);
                        result[i] = area[0] + "省" + area[1] + "市";
                    }
                }
                if (i == 11)
                {
                    if (!string.IsNullOrEmpty(result[i]))
                    { 
                        var temp=result[i].Replace("$#$","");
                        string[] ticketprice = temp.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in ticketprice)
                        {
                            string[] data = item.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            for (int j = 0; j < data.Length; j++)
                            {
                                worksheet2.Rows.CurrentRegion.Cells[1, j + 1] = data[j];
                            }
                        }
                    }
                }
                worksheet1.Cells[row, i + 1] = result[i];
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, savePath, null);
            excel2.Visible = false;
            excel2.DisplayAlerts = false;//不显示提示框
            workbook2.Close(true, savePricePath, null);
            //关闭1
            worksheet1 = null;
            workbook1 = null;
            excel1.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
            excel1 = null;
            //关闭2
            worksheet2 = null;
            workbook2 = null;
            excel2.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel2);
            excel2 = null;
            System.GC.Collect();
        }

        /// <summary>
        /// 持久化景区票价
        /// </summary>
        /// <param name="row"></param>
        /// <param name="htmlPragraph"></param>
        /// <param name="savepricePath"></param>
        public void PersistencePrice2Excel(int row, string htmlPragraph, string savepricePath)
        {
            SavePricePath = savepricePath;
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
            if (!File.Exists(SavePricePath))
            {
                workbook1 = excel1.Workbooks.Add(Missing.Value);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
                //赋值给title
                worksheet1.Cells[1, 1] = "景区名称";
                worksheet1.Cells[1, 2] = "门票名称";
                worksheet1.Cells[1, 3] = "原价";
                worksheet1.Cells[1, 4] = "在线支付价";
            }
            else
            {
                workbook1 = excel1.Workbooks.Open(SavePricePath, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
            }
            //赋值给单元格
            string[] result = htmlPragraph.Split(new string[] { "&&" }, StringSplitOptions.None);
            foreach (string item in result)
            {
                string[] temp = item.Split(new string[] { "$#$" }, 3, StringSplitOptions.None);
                //worksheet1.Cells[row, 1] = temp[0];
                worksheet1.Cells[row, 2] = temp[0];
                worksheet1.Cells[row, 3] = temp[1];
                worksheet1.Cells[row, 4] = temp[2];
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, savepricePath, null);
            //关闭
            worksheet1 = null;
            workbook1 = null;
            excel1.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
            excel1 = null;
            System.GC.Collect();
        }

        /// <summary>
        /// 获取-景区表-内容
        /// </summary>
        /// <returns></returns>
        public List<Entity.ScenicEntity> getSceniclist()
        {
            try
            {
                //一个现象, wps的excel文件是et结尾.  微软的excel是以elsx结尾
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\sst.xls;Extended Properties=Excel 8.0;";
                //Sheet1为excel中表的名字
                string sql = "select 名称,seoname,区域,景区主题,交通指南,订票说明,景区详情,等级,景区地址,topicseo,景区简介 from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new System.Data.DataTable();
                ad.Fill(dt);
                List<Entity.ScenicEntity> slist = new List<Entity.ScenicEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                    //对景区详情处理
                    string scdetail = dt.Rows[i][6].ToString().Replace("\n", "").Trim();

                    //如果excel中的行不为空,添加
                    slist.Add(new Entity.ScenicEntity()
                    {
                        name = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        seoname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        areaid = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        topic = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        trafficintro = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
                        bookintro = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
                        scenicdetail = scdetail,
                        level = dt.Rows[i][7].ToString().Replace("\n", "").Trim(),
                        address = dt.Rows[i][8].ToString().Replace("\n", "").Trim(),
                        topicseo = dt.Rows[i][9].ToString().Replace("\n", "").Trim(),
                        scenicintro = dt.Rows[i][10].ToString().Replace("\n", "").Trim()
                    });
                }
                return slist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
