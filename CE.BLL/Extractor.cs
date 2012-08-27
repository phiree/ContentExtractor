using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CE.Component;
using CE.Domain.Rule;
using IPersistence;
using System.IO;

namespace CE.BLL
{
    public class Extractor
    {
        private CE.Component.Interface.IResponseHandler responsehandler;
        public CE.Component.Interface.IResponseHandler responseHandler
        {
            get
            {
                if (null == responsehandler)
                {
                    responsehandler = new CE.Component.ResponseHandler();
                }
                return responsehandler;
            }
            set
            {
                responsehandler = value;
            }
        }
        public RuleAssembly ruleassembly { get; set; }

        private HtmlHandler htmlHandler = new HtmlHandler();

        public string AnalysisUrl(string url)
        {
            //RuleAssembly ruleAssembly = GetRuleAssembly(url);
            string htmlcode = responseHandler.GetResponseHtml(url);
            string result = ruleassembly.FilterUsingAssembly(htmlcode, false);
            return result;
        }

        public void PersistenceToExcel(List<string> url, string rulepath, string savepath)
        {
            IRule rule = new Persistence.Rule(Path.GetDirectoryName(rulepath));
            ruleassembly = rule.ReadRule(Path.GetFileNameWithoutExtension(rulepath));
            ExcelOpr.ExcelOpr excelopr = new ExcelOpr.ExcelOpr();
            //获取
            //
            for (int i = 0; i < url.Count; i++)
            {
                string result = AnalysisUrl(url[i]);
                result = ruleassembly.FilterUsingAssembly(result, false);
                excelopr.Persistence2Excel(i + 2, result, savepath);
            }
        }

        public void Persistence2Excel8Html(string htmlPath, string rulePath, string savePath)
        {
            List<string> htmllist = new List<string>();
            //查看是否存在html文件, 并添加到列表中
            if (Directory.Exists(htmlPath))
            {
                foreach (string d in Directory.GetFileSystemEntries(htmlPath))
                {
                    htmllist.Add(d);
                }
            }
            else
            {
                return;
            }
            //查看
            IRule rule = new Persistence.Rule(Path.GetDirectoryName(rulePath));
            ruleassembly = rule.ReadRule(Path.GetFileNameWithoutExtension(rulePath));
            ExcelOpr.ExcelOpr excelopr = new ExcelOpr.ExcelOpr();
            for (int i = 0; i < htmllist.Count; i++)
            {
                string html = htmlHandler.ReadHtml(htmllist[i]);
                string result = ruleassembly.FilterUsingAssembly(html, false);
                excelopr.Persistence2Excel(i + 2, result, savePath);
            }
        }

        /// <summary>
        /// 根据url 返回对应的RuleAssembly
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public CE.Domain.Rule.RuleAssembly GetRuleAssembly(string url)
        {
            #region 模拟一个规则集合

            //两个条件
            BaseRule rule1 = new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";


            //第二个set
            BaseRule rule3 = new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true);
            rule3.RuleNo = 10;
            rule3.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule3);

            RuleAssembly assm = new RuleAssembly();
            assm.Name = "同程";
            assm.CodeName = "tongcheng";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);

            #endregion
            return assm;
        }
    }
}
