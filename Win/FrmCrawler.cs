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
    public partial class FrmCrawler : Form
    {

        public FrmCrawler()
        {
            InitializeComponent();

            //txtRegex.Text = Settings.FileMatches;
            //txtPath.Text = Settings.FileSystemFolder;

            //m_downloader = new Downloader();
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
        }

        //private void DownloaderStatusChanged(object sender, DownloaderStatusChangedEventArgs e)
        //{
        //    UpdateToolStrip();
        //}

        private void UpdateToolStrip()
        {
            //Application.Current.Dispatcher.Invoke(
            //    DispatcherPriority.Background,
            //    new Action<bool>((b) => this.buttonResume.IsEnabled = b),
            //    (m_downloader.Status == DownloaderStatusType.Suspended));

            //Application.Current.Dispatcher.Invoke(
            //    DispatcherPriority.Background,
            //    new Action<bool>((b) => this.buttonGo.IsEnabled = b),
            //    (m_downloader.Status == DownloaderStatusType.NotStarted));

            //Application.Current.Dispatcher.Invoke(
            //    DispatcherPriority.Background,
            //    new Action<bool>((b) => this.buttonSuspend.IsEnabled = this.buttonStop.IsEnabled = b),
            //    (m_downloader.Status == DownloaderStatusType.Running));
        }
    }
}
