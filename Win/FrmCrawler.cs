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
    public partial class FrmCrawler : Form
    {
        private Downloader m_downloader;

        public FrmCrawler()
        {
            InitializeComponent();

            m_downloader = new Downloader();
            //m_downloader.StatusChanged += new DownloaderStatusChangedEventHandler(DownloaderStatusChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
            { 
                MessageBox.Show("请填写要抓去的url地址!");
                return;
            }
            if (string.IsNullOrEmpty(txtRegex.Text))
            { 
                MessageBox.Show("请填写正则表达式!");
                return;
            }
            if (string.IsNullOrEmpty(txtPath.Text))
            { 
                MessageBox.Show("请填写需要存储的路径!");
                return;
            }

            m_downloader.InitSeeds(new string[] { txtUrl.Text });
            m_downloader.Start();
        }
    }
}
