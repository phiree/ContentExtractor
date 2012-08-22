using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CE.Component;
using CE.Domain.Rule;
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
                tbxDir.Text = folderBrowserDialog1.SelectedPath+@"\";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //两个条件
            BaseRule rule1 = new BeginEndRule("<div id=dv1>", "</div>", true, true, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "rule1inset1";
            BaseRule rule2 = new BeginEndRule("<span id=sp1>", "</span>", true, true, true, true);
            rule2.RuleNo = 11;
            rule2.Name = "rule11inset1";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "ruleset1";
            ruleset.Rules.Add(rule1);
            ruleset.Rules.Add(rule2);
            ruleset.Code = "Pro1";

            //第二个set
            BaseRule rule3 = new BeginEndRule("<div id=dv2>", "</div>", true, true, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "rule3inset2";
            BaseRule rule4 = new BeginEndRule("<span id=sp2>", "</span>", true, true, true, true);
            rule4.RuleNo = 11;
            rule4.Name = "rule4inset2";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "ruleset2";
            ruleset2.Code = "Pro2";

            ruleset2.Rules.Add(rule3);
            ruleset2.Rules.Add(rule4);

            RuleAssembly assm = new RuleAssembly();
            assm.Name = "sst";
            assm.CodeName = "Ass";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            IPersistence.IRule rule = new Persistence.Rule();
            rule.SaveRule(assm);
            MessageBox.Show("操作完成，请查看" + @"d:\" + assm.Name + ".xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPersistence.IRule rule = new Persistence.Rule();
            rule.ReadRule("sst");
        }
    }
}
