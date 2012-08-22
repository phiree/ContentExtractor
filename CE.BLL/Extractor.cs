using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CE.Component;
using CE.Domain.Rule;

namespace CE.BLL
{
    public class Extractor
    {
        public CE.Component.Interface.IResponseHandler responseHandler
        {
            get;
            set;
        }

        public string AnalysisUrl(string url)
        {
                RuleAssembly ruleAssembly = GetRuleAssembly(url);
                string htmlcode = responseHandler.GetResponseHtml(url);
                string result = ruleAssembly.FilterUsingAssembly(htmlcode, false);
                return result;
        }

        public string PersistenceToExcel(string url)
        {
            string result=AnalysisUrl(url);
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
