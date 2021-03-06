﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;

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
                if (!string.IsNullOrWhiteSpace(savepath))
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
                if (!string.IsNullOrWhiteSpace(savepricepath))
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
        public void Persistence2Excel(int row, string htmlPragraph, string savePath, string savePricePath)
        {
            SavePath = savePath;
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
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
            //赋值给单元格
            string[] result = htmlPragraph.Split(new string[] { "$#$" }, 12, StringSplitOptions.None);
            for (int i = 0; i < result.Length; i++)
            {
                if (i == 1)
                {
                    if (!string.IsNullOrWhiteSpace(result[i]))
                    {
                        int count = result[i].Length;
                        result[i] = count.ToString() + "A";
                    }
                }
                if (i == 4)
                {
                    if (!string.IsNullOrWhiteSpace(result[i]))
                    {
                        string[] area = result[i].Split(new string[] { "景区门票" }, StringSplitOptions.RemoveEmptyEntries);
                        result[i] = area[0] + "省" + area[1] + "市";
                    }
                }
                worksheet1.Cells[row, i + 1] = result[i];
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, savePath, null);
            //关闭1
            worksheet1 = null;
            workbook1 = null;
            excel1.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
            excel1 = null;
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

        public void PersistenceDB2Excel4Scenic(DataSet ds, string path)
        {
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
            if (!File.Exists(path))
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
                worksheet1.Cells[1, 12] = "主图";
            }
            else
            {
                workbook1 = excel1.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
            }
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                for (int column = 1; column <= ds.Tables[0].Columns.Count - 1; column++)
                {
                    worksheet1.Cells[row + 2, column] = ds.Tables[0].Rows[row][column].ToString();
                }
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, path, null);
            //关闭1
            worksheet1 = null;
            workbook1 = null;
            excel1.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
            excel1 = null;
            System.GC.Collect();
        }

        public void PersistenceDB2Excel4Ticketprice(DataSet ds, string path)
        {
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
            if (!File.Exists(path))
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
                workbook1 = excel1.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
            }
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                for (int column = 1; column <= ds.Tables[0].Columns.Count - 1; column++)
                {
                    worksheet1.Cells[row + 2, column] = ds.Tables[0].Rows[row][column].ToString();
                }
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, path, null);
            //关闭1
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
                    if (string.IsNullOrWhiteSpace(dt.Rows[i][1].ToString())) continue;

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

        /// <summary>
        /// 获取-景区表website-内容 v.20121205
        /// </summary>
        /// <returns></returns>
        public List<Webentity> getWebsitelist()
        {
            try
            {
                //一个现象, wps的excel文件是et结尾.  微软的excel是以elsx结尾
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= d:\浙江省景区.xlsx;Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 景区,城市,网址,seo from [杭州$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new System.Data.DataTable();
                ad.Fill(dt);
                List<Webentity> weblist = new List<Webentity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt.Rows[i][0].ToString()))
                    {
                        dt.Rows[i][0] = dt.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "杭州" : dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql2 = "select 景区,城市,网址,seo from [宁波$]";
                OleDbCommand cmd2 = new OleDbCommand(sql2, new OleDbConnection(conn));
                OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                System.Data.DataTable dt2 = new System.Data.DataTable();
                ad2.Fill(dt2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt2.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt2.Rows[i][0].ToString()))
                    {
                        dt2.Rows[i][0] = dt2.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt2.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt2.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "宁波" : dt2.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt2.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt2.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql3 = "select 景区,城市,网址,seo from [温州$]";
                OleDbCommand cmd3 = new OleDbCommand(sql3, new OleDbConnection(conn));
                OleDbDataAdapter ad3 = new OleDbDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                System.Data.DataTable dt3 = new System.Data.DataTable();
                ad3.Fill(dt3);
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt3.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt3.Rows[i][0].ToString()))
                    {
                        dt3.Rows[i][0] = dt3.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt3.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt3.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "温州" : dt3.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt3.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt3.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql4 = "select 景区,城市,网址,seo from [嘉兴$]";
                OleDbCommand cmd4 = new OleDbCommand(sql4, new OleDbConnection(conn));
                OleDbDataAdapter ad4 = new OleDbDataAdapter(cmd4);
                DataSet ds4 = new DataSet();
                System.Data.DataTable dt4 = new System.Data.DataTable();
                ad4.Fill(dt4);
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt4.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt4.Rows[i][0].ToString()))
                    {
                        dt4.Rows[i][0] = dt4.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt4.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt4.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "嘉兴" : dt4.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt4.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt4.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql5 = "select 景区,城市,网址,seo from [湖州$]";
                OleDbCommand cmd5 = new OleDbCommand(sql5, new OleDbConnection(conn));
                OleDbDataAdapter ad5 = new OleDbDataAdapter(cmd5);
                DataSet ds5 = new DataSet();
                System.Data.DataTable dt5 = new System.Data.DataTable();
                ad5.Fill(dt5);
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt5.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt5.Rows[i][0].ToString()))
                    {
                        dt5.Rows[i][0] = dt5.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt5.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt5.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "湖州" : dt5.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt5.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt5.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql6 = "select 景区,城市,网址,seo from [绍兴$]";
                OleDbCommand cmd6 = new OleDbCommand(sql6, new OleDbConnection(conn));
                OleDbDataAdapter ad6 = new OleDbDataAdapter(cmd6);
                DataSet ds6 = new DataSet();
                System.Data.DataTable dt6 = new System.Data.DataTable();
                ad6.Fill(dt6);
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt6.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt6.Rows[i][0].ToString()))
                    {
                        dt6.Rows[i][0] = dt6.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt6.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt6.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "绍兴" : dt6.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt6.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt6.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql7 = "select 景区,城市,网址,seo from [金华$]";
                OleDbCommand cmd7 = new OleDbCommand(sql7, new OleDbConnection(conn));
                OleDbDataAdapter ad7 = new OleDbDataAdapter(cmd7);
                DataSet ds7 = new DataSet();
                System.Data.DataTable dt7 = new System.Data.DataTable();
                ad7.Fill(dt7);
                for (int i = 0; i < dt7.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt7.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt7.Rows[i][0].ToString()))
                    {
                        dt7.Rows[i][0] = dt7.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt7.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt7.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "金华" : dt7.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt7.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt7.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql8 = "select 景区,城市,网址,seo from [衢州$]";
                OleDbCommand cmd8 = new OleDbCommand(sql8, new OleDbConnection(conn));
                OleDbDataAdapter ad8 = new OleDbDataAdapter(cmd8);
                DataSet ds8 = new DataSet();
                System.Data.DataTable dt8 = new System.Data.DataTable();
                ad8.Fill(dt8);
                for (int i = 0; i < dt8.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt8.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt8.Rows[i][0].ToString()))
                    {
                        dt8.Rows[i][0] = dt8.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt8.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt8.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "衢州" : dt8.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt8.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt8.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql9 = "select 景区,城市,网址,seo from [舟山$]";
                OleDbCommand cmd9 = new OleDbCommand(sql9, new OleDbConnection(conn));
                OleDbDataAdapter ad9 = new OleDbDataAdapter(cmd9);
                DataSet ds9 = new DataSet();
                System.Data.DataTable dt9 = new System.Data.DataTable();
                ad9.Fill(dt9);
                for (int i = 0; i < dt9.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt9.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt9.Rows[i][0].ToString()))
                    {
                        dt9.Rows[i][0] = dt9.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt9.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt9.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "舟山" : dt9.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt9.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt9.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql10 = "select 景区,城市,网址,seo from [台州$]";
                OleDbCommand cmd10 = new OleDbCommand(sql10, new OleDbConnection(conn));
                OleDbDataAdapter ad10 = new OleDbDataAdapter(cmd10);
                DataSet ds10 = new DataSet();
                System.Data.DataTable dt10 = new System.Data.DataTable();
                ad10.Fill(dt10);
                for (int i = 0; i < dt10.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt10.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt10.Rows[i][0].ToString()))
                    {
                        dt10.Rows[i][0] = dt10.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt10.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt10.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "台州" : dt10.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt10.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt10.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql11 = "select 景区,城市,网址,seo from [丽水$]";
                OleDbCommand cmd11 = new OleDbCommand(sql11, new OleDbConnection(conn));
                OleDbDataAdapter ad11 = new OleDbDataAdapter(cmd11);
                DataSet ds11 = new DataSet();
                System.Data.DataTable dt11 = new System.Data.DataTable();
                ad11.Fill(dt11);
                for (int i = 0; i < dt11.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt11.Rows[i][2].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt11.Rows[i][0].ToString()))
                    {
                        dt11.Rows[i][0] = dt11.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    weblist.Add(new Webentity()
                    {
                        ScenicName = dt11.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        City = string.IsNullOrWhiteSpace(dt11.Rows[i][1].ToString().Replace("\n", "").Trim()) ? "丽水" : dt11.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Website = dt11.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Seoname = dt11.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                return weblist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public class Webentity
        {
            public string ScenicName { get; set; }
            public string City { get; set; }
            public string Website { get; set; }
            public string Seoname { get; set; }
        }

        /// <summary>
        /// 获取excel上的价格 v.20121214
        /// </summary>
        public List<Entity.PriceEntity> getPricelist()
        {
            try
            {
                //一个现象, wps的excel文件是et结尾.  微软的excel是以elsx结尾
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= d:\浙江省景区.xlsx;Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 景区,门票名称,门市价,网上现售价 from [杭州$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new System.Data.DataTable();
                ad.Fill(dt);
                List<Entity.PriceEntity> pricelist = new List<Entity.PriceEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt.Rows[i][0].ToString()))
                    {
                        dt.Rows[i][0] = dt.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql2 = "select 景区,门票名称,门市价,网上现售价 from [宁波$]";
                OleDbCommand cmd2 = new OleDbCommand(sql2, new OleDbConnection(conn));
                OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                System.Data.DataTable dt2 = new System.Data.DataTable();
                ad2.Fill(dt2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt2.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt2.Rows[i][0].ToString()))
                    {
                        dt2.Rows[i][0] = dt2.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt2.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt2.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt2.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt2.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql3 = "select 景区,门票名称,门市价,网上现售价 from [温州$]";
                OleDbCommand cmd3 = new OleDbCommand(sql3, new OleDbConnection(conn));
                OleDbDataAdapter ad3 = new OleDbDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                System.Data.DataTable dt3 = new System.Data.DataTable();
                ad3.Fill(dt3);
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt3.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt3.Rows[i][0].ToString()))
                    {
                        dt3.Rows[i][0] = dt3.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt3.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt3.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt3.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt3.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql4 = "select 景区,门票名称,门市价,网上现售价 from [嘉兴$]";
                OleDbCommand cmd4 = new OleDbCommand(sql4, new OleDbConnection(conn));
                OleDbDataAdapter ad4 = new OleDbDataAdapter(cmd4);
                DataSet ds4 = new DataSet();
                System.Data.DataTable dt4 = new System.Data.DataTable();
                ad4.Fill(dt4);
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt4.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt4.Rows[i][0].ToString()))
                    {
                        dt4.Rows[i][0] = dt4.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt4.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt4.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt4.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt4.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql5 = "select 景区,门票名称,门市价,网上现售价 from [湖州$]";
                OleDbCommand cmd5 = new OleDbCommand(sql5, new OleDbConnection(conn));
                OleDbDataAdapter ad5 = new OleDbDataAdapter(cmd5);
                DataSet ds5 = new DataSet();
                System.Data.DataTable dt5 = new System.Data.DataTable();
                ad5.Fill(dt5);
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt5.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt5.Rows[i][0].ToString()))
                    {
                        dt5.Rows[i][0] = dt5.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt5.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt5.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt5.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt5.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql6 = "select 景区,门票名称,门市价,网上现售价 from [绍兴$]";
                OleDbCommand cmd6 = new OleDbCommand(sql6, new OleDbConnection(conn));
                OleDbDataAdapter ad6 = new OleDbDataAdapter(cmd6);
                DataSet ds6 = new DataSet();
                System.Data.DataTable dt6 = new System.Data.DataTable();
                ad6.Fill(dt6);
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt6.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt6.Rows[i][0].ToString()))
                    {
                        dt6.Rows[i][0] = dt6.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt6.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt6.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt6.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt6.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql7 = "select 景区,门票名称,门市价,网上现售价 from [金华$]";
                OleDbCommand cmd7 = new OleDbCommand(sql7, new OleDbConnection(conn));
                OleDbDataAdapter ad7 = new OleDbDataAdapter(cmd7);
                DataSet ds7 = new DataSet();
                System.Data.DataTable dt7 = new System.Data.DataTable();
                ad7.Fill(dt7);
                for (int i = 0; i < dt7.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt7.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt7.Rows[i][0].ToString()))
                    {
                        dt7.Rows[i][0] = dt7.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt7.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt7.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt7.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt7.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql8 = "select 景区,门票名称,门市价,网上现售价 from [衢州$]";
                OleDbCommand cmd8 = new OleDbCommand(sql8, new OleDbConnection(conn));
                OleDbDataAdapter ad8 = new OleDbDataAdapter(cmd8);
                DataSet ds8 = new DataSet();
                System.Data.DataTable dt8 = new System.Data.DataTable();
                ad8.Fill(dt8);
                for (int i = 0; i < dt8.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt8.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt8.Rows[i][0].ToString()))
                    {
                        dt8.Rows[i][0] = dt8.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt8.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt8.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt8.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt8.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql9 = "select 景区,门票名称,门市价,网上现售价 from [舟山$]";
                OleDbCommand cmd9 = new OleDbCommand(sql9, new OleDbConnection(conn));
                OleDbDataAdapter ad9 = new OleDbDataAdapter(cmd9);
                DataSet ds9 = new DataSet();
                System.Data.DataTable dt9 = new System.Data.DataTable();
                ad9.Fill(dt9);
                for (int i = 0; i < dt9.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt9.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt9.Rows[i][0].ToString()))
                    {
                        dt9.Rows[i][0] = dt9.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt9.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt9.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt9.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt9.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql10 = "select 景区,门票名称,门市价,网上现售价 from [台州$]";
                OleDbCommand cmd10 = new OleDbCommand(sql10, new OleDbConnection(conn));
                OleDbDataAdapter ad10 = new OleDbDataAdapter(cmd10);
                DataSet ds10 = new DataSet();
                System.Data.DataTable dt10 = new System.Data.DataTable();
                ad10.Fill(dt10);
                for (int i = 0; i < dt10.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt10.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt10.Rows[i][0].ToString()))
                    {
                        dt10.Rows[i][0] = dt10.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt10.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt10.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt10.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt10.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                string sql11 = "select 景区,门票名称,门市价,网上现售价 from [丽水$]";
                OleDbCommand cmd11 = new OleDbCommand(sql11, new OleDbConnection(conn));
                OleDbDataAdapter ad11 = new OleDbDataAdapter(cmd11);
                DataSet ds11 = new DataSet();
                System.Data.DataTable dt11 = new System.Data.DataTable();
                ad11.Fill(dt11);
                for (int i = 0; i < dt11.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrWhiteSpace(dt11.Rows[i][1].ToString())) continue;

                    var j = 1;
                    while (string.IsNullOrWhiteSpace(dt11.Rows[i][0].ToString()))
                    {
                        dt11.Rows[i][0] = dt11.Rows[i - j][0];
                        j++;
                    }

                    //如果excel中的行不为空,添加
                    //如果excel中的行不为空,添加
                    pricelist.Add(new Entity.PriceEntity()
                    {
                        scenicname = dt11.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt11.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt11.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt11.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }

                return pricelist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
