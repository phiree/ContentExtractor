using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CE.Domain.Rule
{
    /// <summary>
    /// 
    /// </summary>
    public class RuleAssembly
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Rule.RuleSet> RuleSets { get; set; }
        /// <summary>
        /// 规则集的集合,用于处理完整的html源码.
        /// </summary>
        public string CodeName { get; set; }

        public RuleAssembly()
        {
            RuleSets = new List<RuleSet>();
        }
        public string FilterUsingAssembly(string rawContent, bool returnJsonFormat)
        {
            string result = string.Empty;
            RuleSets.Sort(SortCompare);
            foreach (RuleSet ruleset in RuleSets)
            {
                result += ruleset.FilterUsingRuleSet(ref rawContent, returnJsonFormat)+",";
            }
            if (!string.IsNullOrEmpty(result))
            {
                result = result.TrimEnd(',');
            }
            if (returnJsonFormat)
            {
                result = "{" + result + "}";
            }
            return result;
        }

        private int SortCompare(RuleSet rule1, RuleSet rule2)
        {
            return rule1.SetNo.CompareTo(rule2.SetNo);
        }
    }
}
