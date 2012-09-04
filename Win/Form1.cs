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

        private void button3_Click(object sender, EventArgs e)
        {
            new FrmRule().Show();
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
    }
}
