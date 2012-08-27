using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CE.Domain.Rule;
using IPersistence;
using System.IO;

namespace Win
{
    public partial class FrmRule : Form
    {
        IRule rule = null;
        public FrmRule()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in rulelist.Items)
            {
                if (item.Selected)
                {
                    RuleSet rs = ruleAssemly.RuleSets.Where(x => x.Name == item.Text).FirstOrDefault();
                    BeginEndRule ber = (BeginEndRule)rs.Rules[0];
                    ber.BeginMark = rtxtBegin.Text;
                    ber.EndMark = rtxtEnd.Text;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            rtxtBegin.Text = string.Empty;
            rtxtEnd.Text = string.Empty;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in rulelist.Items)
            {
                if (item.Selected)
                {
                    rulelist.Items.Remove(item);
                    ruleAssemly.RuleSets.Remove(ruleAssemly.RuleSets.Where(x => x.Name == item.Text).FirstOrDefault());
                }
            }
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            rulelist.Items.Clear();
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
            loadRulelist(path);
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml文件|*.xml|所有文件|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            string fName = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ruleAssemly.Name = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                rule.SaveRule(ruleAssemly);
                MessageBox.Show("保存成功!");
            }
        }

        RuleAssembly ruleAssemly = null;
        private void loadRulelist(string path)
        {
            rule = new Persistence.Rule(Path.GetDirectoryName(path));
            ruleAssemly = rule.ReadRule(Path.GetFileNameWithoutExtension(path));
            foreach (RuleSet ruleset in ruleAssemly.RuleSets)
            {
                ListViewItem lvi=rulelist.Items.Add(ruleset.Name);
            }
        }

        private void rulelist_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in rulelist.Items)
            {
                if (item.Selected)
                {
                    RuleSet rs=ruleAssemly.RuleSets.Where(x => x.Name == item.Text).FirstOrDefault();
                    BeginEndRule ber=(BeginEndRule)rs.Rules[0];
                    rtxtBegin.Text = ber.BeginMark;
                    rtxtEnd.Text = ber.EndMark;
                }
            }
        }
    }
}
