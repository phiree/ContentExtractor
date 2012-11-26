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
        IPersistence.IRule rule;
        RuleAssembly ruleAssemly;
        RuleModel ruleModel = RuleModel.New;

        public FrmRule()
        {
            ruleAssemly = new RuleAssembly();
            rule = new Persistence.Rule();
            InitializeComponent();
        }

        /// <summary>
        /// 修改rule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRulename.Text))
            {
                MessageBox.Show("请输入规则名称");
                return;
            }
            foreach (ListViewItem item in rulelist.Items)
            {
                if (item.Selected)
                {
                    RuleSet rs = ruleAssemly.RuleSets.Where(x => x.Name == item.Text).FirstOrDefault();
                    BeginEndRule ber = rs.Rules[0] as BeginEndRule;
                    RegexRule rr = rs.Rules[0] as RegexRule;
                    if (ber != null)
                    {
                        ber.Name = txtRulename.Text.Trim();
                        ber.BeginMark = rtxtBegin.Text;
                        ber.EndMark = rtxtEnd.Text;
                    }
                    else
                    {
                        rr.Name = txtRulename.Text.Trim();
                        rr.RegexExp = rtxtRegex.Text;
                    }
                }
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 添加ruleset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //20120911
            if (ruleAssemly == null)
            {
                ruleAssemly = new RuleAssembly();
            }
            //
            rtxtBegin.Text = string.Empty;
            rtxtEnd.Text = string.Empty;
            FrmRulenew frm = new FrmRulenew();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                RuleSet rs = new RuleSet();
                rs.Name = frm.txtName.Text;
                if (frm.rbtnBeginend.Checked)
                {
                    BaseRule br = new BeginEndRule(frm.rtxtBegin.Text, frm.rtxtEnd.Text, false, false, false, false);
                    br.Name = frm.txtRulename.Text;
                    rs.Rules.Add(br);
                }
                else
                {
                    BaseRule rr = new RegexRule(frm.rtxtRegex.Text);
                    rr.Name = frm.txtRulename.Text;
                    rs.Rules.Add(rr);
                }
                ruleAssemly.RuleSets.Add(rs);
                loadRulelist(ruleAssemly);
            }
        }

        /// <summary>
        /// 删除ruleset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 打开ruleassembly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            loadPath(path);
            ruleModel = RuleModel.Open;
        }

        /// <summary>
        /// 新建ruleset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            rtxtBegin.Text = string.Empty;
            rtxtEnd.Text = string.Empty;
            rulelist.Items.Clear();
            ruleAssemly = null;
            ruleModel = RuleModel.New;
        }

        /// <summary>
        /// 保存ruleassembly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml文件|*.xml|所有文件|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            string fName = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //loadPath(saveFileDialog.FileName);
                ruleAssemly.Name = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                rule.PersistencePath = Path.GetDirectoryName(saveFileDialog.FileName);
                rule.SaveRule(ruleAssemly);
                MessageBox.Show("保存成功!");
            }
        }

        /// <summary>
        /// 路径加载
        /// </summary>
        /// <param name="path"></param>
        private void loadPath(string path)
        {
            //rule = new Persistence.Rule();
            rule.PersistencePath = Path.GetDirectoryName(path);
            ruleAssemly = rule.ReadRule(Path.GetFileNameWithoutExtension(path));
            loadRulelist(ruleAssemly);
        }

        /// <summary>
        /// 加载ruleassembly
        /// </summary>
        /// <param name="ruleAssemly"></param>
        private void loadRulelist(RuleAssembly ruleAssemly)
        {
            rulelist.Items.Clear();
            foreach (RuleSet ruleset in ruleAssemly.RuleSets)
            {
                ListViewItem lvi = rulelist.Items.Add(ruleset.Name);
            }
        }

        /// <summary>
        /// 列表选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rulelist_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in rulelist.Items)
            {
                if (item.Selected)
                {
                    RuleSet rs = ruleAssemly.RuleSets.Where(x => x.Name == item.Text).FirstOrDefault();
                    BeginEndRule ber;
                    RegexRule rr;
                    ber = rs.Rules[0] as BeginEndRule;
                    rr = rs.Rules[0] as RegexRule;
                    if (ber != null)
                    {
                        rbtnBeginend.Checked = true;
                        rtxtBegin.Text = ber.BeginMark;
                        rtxtEnd.Text = ber.EndMark;
                        txtRulename.Text = ber.Name;
                    }
                    else
                    {
                        rbtnRegex.Checked = true;
                        rtxtRegex.Text = rr.RegexExp;
                        txtRulename.Text = rr.Name;
                    }
                }
            }
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
                label3.Visible = false;
                rtxtRegex.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                //显示
                label3.Visible = true;
                rtxtRegex.Visible = true;
                //隐藏
                label1.Visible = false;
                label2.Visible = false;
                rtxtBegin.Visible = false;
                rtxtEnd.Visible = false;
            }
        }
    }

    public enum RuleModel
    {
        New,
        Open
    }
}
