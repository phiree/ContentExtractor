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
    public partial class FrmXml2Excel : Form
    {
        public FrmXml2Excel()
        {
            InitializeComponent();
        }

        private void btnSce_Click(object sender, EventArgs e)
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
            this.txtSce.Text = path;
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {

            var fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            string path = fbd.SelectedPath;
            txtPrice.Text = path;
            if (!path.EndsWith(@"\"))
            {
                txtPrice.Text = path + @"\";
            }
            else
            {
                txtPrice.Text = path;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ExcelOplib.XmlHelper.Xml2Excel(txtSce.Text, txtPrice.Text);
            MessageBox.Show("操作完成!@");
        }
    }
}
