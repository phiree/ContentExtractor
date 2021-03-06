﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IPersistence;
using CE.Domain.Rule;
using CE.Component;
using System.Text.RegularExpressions;

namespace Win
{
    public partial class FrmHtml2DBMulti : Form
    {
        DBOper.IDBOper dboper = new DBOper.DBOper();
        public RuleAssembly ruleassembly { get; set; }
        private HtmlHandler htmlHandler = new HtmlHandler();
        private ExcelOpr.ExcelOpr excelOpr = new ExcelOpr.ExcelOpr();

        public FrmHtml2DBMulti()
        {
            InitializeComponent();
        }

        private void btnHtml_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            string path = fbd.SelectedPath;
            txtHtml.Text = path;
        }

        private void btnRule_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();//类的实例化
            //openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);//打开位置
            //openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"; //文件类型
            //openFileDialog1.FilterIndex = 1;//表示默认筛选情况
            //openFileDialog1.RestoreDirectory = true;//获取或设置一个值，该值指示对话框在关闭前是否还原当前目录。
            //openFileDialog1.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            //openFileDialog1.CheckFileExists = true;  //验证路径有效性
            //openFileDialog1.CheckPathExists = true; //验证文件有效性
            //if (openFileDialog1.ShowDialog() != DialogResult.OK)
            //    return;
            //string path = openFileDialog1.FileName;
            //this.txtRule.Text = path;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            string path = fbd.SelectedPath;
            txtRule.Text = path;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            bool bresult = true;

            #region 验证
            if (string.IsNullOrEmpty(txtHtml.Text))
            {
                MessageBox.Show("请选择Html文件夹.");
                return;
            }
            if (string.IsNullOrEmpty(txtRule.Text))
            {
                MessageBox.Show("请选择相应的规则.");
                return;
            }
            #endregion

            #region html转化成实体
            var selist = new List<DBOper.Entity.ScenicEntity>();
            List<DBOper.Entity.TicketEntity> tlist = new List<DBOper.Entity.TicketEntity>(); ;
            DBOper.Entity.ScenicEntity se=new DBOper.Entity.ScenicEntity();
            DBOper.Entity.TicketEntity te;

            var htmllist = new List<string>();
            #region 查看是否存在html文件, 并添加到列表中
            if (Directory.Exists(txtHtml.Text))
            {
                foreach (string d in Directory.GetFileSystemEntries(txtHtml.Text))
                {
                    htmllist.Add(d);
                }
            }
            else
            {
                return;
            }
            #endregion

            var rulelist = new Dictionary<string, string>();
            #region 查看是否存在Rule文件, 并添加到列表中
            if (Directory.Exists(txtRule.Text))
            {
                foreach (string r in Directory.GetFileSystemEntries(txtRule.Text))
                {
                    var key = System.IO.Path.GetFileNameWithoutExtension(r);
                    rulelist.Add(key, r);
                }
            }
            else
            {
                return;
            }
            #endregion
            //查看
            IRule rule = null;
            //rule.PersistencePath = Path.GetDirectoryName(txtRule.Text);//20121207-sst注释
            //ruleassembly = rule.ReadRule(Path.GetFileNameWithoutExtension(txtRule.Text));//20121012-sst注释
            DBOper.IDBOper dbopr = new DBOper.DBOper();
            for (int i = 0; i < htmllist.Count; i++)
            {
                //20121207-new
                var fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(htmllist[i]);
                if (fileNameWithoutExtension != null)
                {
                    var html_type = fileNameWithoutExtension.Split('-')[0];
                    var rule_type = rulelist[html_type];
                    rule = new Persistence.Rule {PersistencePath = Path.GetDirectoryName(rule_type)};
                    //20121207-old
                    te = new DBOper.Entity.TicketEntity();
                    string html = htmlHandler.ReadHtml(htmllist[i]);

                    string htmlPragraph = rule.ReadRule(Path.GetFileNameWithoutExtension(rule_type)).FilterUsingAssembly(html, false);
                    if (string.IsNullOrEmpty(htmlPragraph)) continue;
                    string[] result = htmlPragraph.Split(new string[] { "$#$" }, 14, StringSplitOptions.None);
                    for (int j = 0; j < result.Length; j++)
                    {
                        if (string.IsNullOrEmpty(result[0]))
                            continue;
                        #region 景区结果分析
                        if (j == 1)
                        {
                            if (!string.IsNullOrEmpty(result[j]))
                            {
                                int count = result[j].Length;
                                result[j] = count.ToString() + "A";
                            }
                        }
                        if (j == 4)
                        {
                            if (!string.IsNullOrEmpty(result[j]))
                            {
                                string[] area = result[j].Split(new string[] { "景区门票" }, StringSplitOptions.RemoveEmptyEntries);
                                result[j] = area[0] + "省" + area[1] + "市";
                            }
                        }
                        if (j == 11)
                        {
                            if (!string.IsNullOrEmpty(result[j]))
                            {
                                var temp = result[j].Replace("$#$", "");
                                string[] ticketprice = temp.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var item in ticketprice)
                                {
                                    string[] data = item.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                                    te = new DBOper.Entity.TicketEntity();
                                    te.scenicname = result[0].ToString();
                                    te.ticketname = data[0].ToString();
                                    te.orgprice = data[1].ToString();
                                    te.olprice = data[2].ToString();
                                    tlist.Add(te);
                                }
                            }
                        }
                        if (j == 12)
                        {
                            //var tmp = result[j].split(new string[] { @"scenicimg/", @""" />" }, stringsplitoptions.removeemptyentries);
                            //var tmp = result[j].Split(new string[] { @""" />" }, StringSplitOptions.RemoveEmptyEntries);
                            //if (tmp.Length > 0)
                            //{
                            //    result[j] = tmp[0];
                            //}
                            string pattern = @"(?<=src="").*?(?="")";
                            Regex rex = new Regex(pattern);
                            MatchCollection matchs = rex.Matches(result[j]);
                            if (matchs.Count > 0)
                            {
                                result[j] = matchs[0].Value;
                            }
                        }
                        #endregion
                    }
                    #region 景区转化&存储
                    se.name = result[0].ToString();
                    se.level = result[1].ToString();
                    se.address = result[2].ToString();
                    se.seoname = string.Empty;//result[3].ToString();
                    se.areaid = result[4].ToString();
                    se.topic = result[5].ToString();
                    se.topicseo = result[6].ToString();
                    se.trafficintro = result[7].ToString();
                    se.bookintro = result[8].ToString();
                    se.scenicdetail = result[9].ToString();
                    se.scenicintro = result[10].ToString();
                    se.mainimg = result[12].ToString();
                }
                se.ticketlist = tlist;
                bresult &= dbopr.Persistence2DB(se);
                #endregion
            }
            #endregion

            if (bresult)
            {
                MessageBox.Show("转化成功");
            }
            else
            {
                MessageBox.Show("转化失败");
            }
        }

        private void btnHtml2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            string path = fbd.SelectedPath;
            txtHtml2.Text = path;
        }

        private void btnRule2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//类的实例化
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);//打开位置
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"; //文件类型
            openFileDialog1.FilterIndex = 1;//表示默认筛选情况
            openFileDialog1.RestoreDirectory = true;//获取或设置一个值，该值指示对话框在关闭前是否还原当前目录。
            openFileDialog1.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            openFileDialog1.CheckFileExists = true;  //验证路径有效性
            openFileDialog1.CheckPathExists = true; //验证文件有效性
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string path = openFileDialog1.FileName;
            this.txtRule2.Text = path;
        }

        private void btnConvert2_Click(object sender, EventArgs e)
        {
            var pricelist = excelOpr.getPricelist();
            var reseult=dboper.Persistence2DB(pricelist);
            if (reseult)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("failed");
            }
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            List<ExcelOpr.ExcelOpr.Webentity> websites = excelOpr.getWebsitelist();
            var result = dboper.PersistenceCity2DB(websites) & dboper.PersistenceSeo2DB(websites);
            if (result)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("failed");
            }
        }
    }
}
