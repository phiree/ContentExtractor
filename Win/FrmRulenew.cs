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
    public partial class FrmRulenew : Form
    {
        public FrmRulenew()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void rbtnBeginend_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                //显示
                label1.Visible = true;
                label2.Visible = true;
                rtxtBegin.Visible = true;
                rtxtEnd.Visible = true;
                //隐藏
                label5.Visible = false;
                rtxtRegex.Visible = false;
            }
        }

        private void rbtnRegex_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                //显示
                label5.Visible = true;
                rtxtRegex.Visible = true;
                //隐藏
                label1.Visible = false;
                label2.Visible = false;
                rtxtBegin.Visible = false;
                rtxtEnd.Visible = false;
            }
        }
    }
}
