using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImgLoc_Click(object sender, EventArgs e)
        {
            new FmImageLocalizer().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmHtml2Excel().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmUrl2Excel().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FrmHtml2DB().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FrmDB2Excel().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FrmScript().Show();
        }

        private void tasklist_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in tasklist.Items)
            {
                if (item.Selected)
                {

                }
            }
        }

        private void hTML2DBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmHtml2DB().ShowDialog();
        }

        private void dB2EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDB2Excel().ShowDialog();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tasklist.Items.Clear();
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
            //loadPath(path);
            //ruleModel = RuleModel.Open;
        }

        private void cRAWLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCrawler().ShowDialog();
        }

        private void rULEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmRule().Show();
        }

        private void xML2EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmXml2Excel().Show();
        }

        private void sINGLECRAWLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSingleCrawler().Show();
        }

        private void eXCELCRAWLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmExcelCrawler().Show();
        }
    }
}
