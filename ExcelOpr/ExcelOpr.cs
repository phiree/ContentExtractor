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
                if (string.IsNullOrEmpty(savepath))
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

        public void Persistence2Excel(int row,string htmlPragraph)
        {
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1;
            Worksheet worksheet1;
            if (!File.Exists(@"d:\sst.xls"))
            {
                workbook1 = excel1.Workbooks.Add(true);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                worksheet1 = (Worksheet)workbook1.Worksheets.Add(Type.Missing, workbook1.Worksheets["sheet1"], 1, Type.Missing);
                excel1.Visible = false;
            }
            else
            {
                workbook1 = excel1.Workbooks.Open(@"d:\sst.xls", Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
            }
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
            //赋值给单元格
            string[] result = htmlPragraph.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                worksheet1.Cells[row, i+1] = result[i];
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, "d:\\sst.xls", null);
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
                    //string[] srclist = GetPiclist(dt.Rows[i][0].ToString().Replace("\n", "").Trim()).Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                    string scdetail = dt.Rows[i][6].ToString().Replace("\n", "").Trim();
                    //for (int j = 0; j < srclist.Length / 2; j++)
                    //{
                    //    scdetail = scdetail.Replace(srclist[j], srclist[j + srclist.Length / 2]);
                    //}

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
