using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CE.Component;
namespace Win
{
    public partial class FmImageLocalizer : Form
    {
        public FmImageLocalizer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            tbxResult.Clear();
            foreach (string s in tbxUrls.Lines)
            {
                string newName=s.GetHashCode().ToString();
                 ImageLocalizer localizer = new ImageLocalizer(s,tbxDir.Text,tbxPath.Text,newName);
                newName=  localizer.SavePhotoFromUrl();
               tbxResult.AppendText(newName + Environment.NewLine);
            }
           
            
            
        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
