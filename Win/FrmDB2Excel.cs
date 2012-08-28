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
    public partial class FrmDB2Excel : Form
    {
        public FrmDB2Excel()
        {
            InitializeComponent();
        }

        private void btnSce_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            string path = fbd.SelectedPath;
            if (path.EndsWith(@"\"))
            {
                txtSce.Text = path.Remove(path.Length - 1);
            }
            else
            {
                txtSce.Text = path;
            }
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            string path = fbd.SelectedPath;
            txtPrice.Text = path;
            if (path.EndsWith(@"\"))
            {
                txtPrice.Text = path.Remove(path.Length - 1);
            }
            else
            {
                txtPrice.Text = path;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DBOper.IDBOper dboper = new DBOper.DBOper();
            DataSet dsTicketprice = dboper.GetTiketprice();
            DataSet dsScenic = dboper.GetScenic();
            CE.BLL.Extractor ext = new CE.BLL.Extractor();
            ext.PersistenceDB2Excel4Scenic(dsScenic, txtSce.Text.Trim() + @"景区表格式.xls");
            ext.PersistenceDB2Excel4Ticketprice(dsTicketprice, txtPrice.Text.Trim() + @"价格表格式.xls");
            MessageBox.Show("操作完成!@");
        }
    }
}
