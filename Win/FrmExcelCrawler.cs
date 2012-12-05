using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CE.Crawler;

namespace Win
{
    public partial class FrmExcelCrawler : Form
    {
        private Downloader m_downloader;

        public FrmExcelCrawler()
        {
            InitializeComponent();
            m_downloader = new Downloader();
        }

        private void btnRule_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//类的实例化
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);//打开位置
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; //文件类型
            openFileDialog1.FilterIndex = 1;//表示默认筛选情况
            openFileDialog1.RestoreDirectory = true;//获取或设置一个值，该值指示对话框在关闭前是否还原当前目录。
            openFileDialog1.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            openFileDialog1.CheckFileExists = true;  //验证路径有效性
            openFileDialog1.CheckPathExists = true; //验证文件有效性
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string path = openFileDialog1.FileName;
            this.txtRule.AppendText(path);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ExcelOpr.ExcelOpr exceloper = new ExcelOpr.ExcelOpr();
            List<string> websites = exceloper.getWebsitelist();
            if (websites != null && websites.Count != 0)
            {
                m_downloader.InitSeeds(websites.ToArray<string>(), string.Empty, string.Empty);
                m_downloader.Start();
            }
            else
            {
                MessageBox.Show("excel读取错误");
            }
        }
    }
}
