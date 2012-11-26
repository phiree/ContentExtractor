using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Domain.Rule
{
    /// <summary>
    /// 能够替换某项特定内容的规则集合
    /// </summary>
    public class ReplaceRule : BaseRule
    {
        public string OldMark { get; set; }
        public string NewMark { get; set; }

        public ReplaceRule(string oldmark, string newmark)
        {
            OldMark = oldmark;
            NewMark = newmark;
        }

        public override string FilterUsingRule(ref string rawContent)
        {
            string filteredContent = rawContent;
            if (string.IsNullOrEmpty(OldMark) || string.IsNullOrEmpty(OldMark))
            {
                return filteredContent;
            }

            return filteredContent.Replace(OldMark, NewMark);
        }
    }
}
