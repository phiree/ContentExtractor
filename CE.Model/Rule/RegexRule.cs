using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace CE.Domain.Rule
{
    /// <summary>
    /// 使用正则表达式提取内容
    /// </summary>
    public class RegexRule : BaseRule
    {
        /// <summary>
        /// 
        /// </summary>
        public string RegexExp { get; set; }

        public RegexRule(string regexexp)
        {
            RegexExp = regexexp;

        }

        /// <summary>
        /// 根据规则, 过滤出结果
        /// 
        /// </summary>
        /// <param name="rawContent"></param>
        /// <returns></returns>
        public override string FilterUsingRule(ref string rawContent)
        {
            string filteredContent = string.Empty;

            Regex reg = new Regex(RegexExp, RegexOptions.Singleline);
            string[] groupNames = reg.GetGroupNames();
            MatchCollection matchs = reg.Matches(rawContent);

            foreach (Match m in matchs)
            {
                //从原始内容中删除已经提取的内容
                if (m.Value == string.Empty) continue;
                rawContent = rawContent.Replace(m.Value, string.Empty);

                //继续提取精确内容,通过regexgroup

                for (int i = 0; i < m.Groups.Count; i++)
                {
                    string groupName = groupNames[i];
                    int demo;
                    if (!int.TryParse(groupName, out demo))
                    {
                        Group g = m.Groups[groupNames[i]];


                        filteredContent += g.Value + "||";
                    }
                }
                filteredContent += "&&";
            }

            return filteredContent;
        }
    }

}
