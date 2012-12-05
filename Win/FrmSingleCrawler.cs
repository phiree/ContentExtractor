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
    public partial class FrmSingleCrawler : Form
    {
        private Downloader m_downloader;

        public FrmSingleCrawler()
        {
            InitializeComponent();
            m_downloader = new Downloader();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("请填写需要存储的路径!");
                return;
            }
            m_downloader.InitSeeds(txtUrl.Text.Split(new string[]{"\n"},
                StringSplitOptions.RemoveEmptyEntries), string.Empty, string.Empty);
            m_downloader.Start();
        }
    }
}
