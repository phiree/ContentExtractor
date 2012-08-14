using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Model.Rule
{
    public class BaseRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //是需要移除的内容?
        public bool IsExcludeContent { get; set; }
        //补全不完整的tag
        public string PretendBefore { get; set; }
        public string AppendAfter { get; set; }
        public bool Enabled { get; set; }
        public virtual  string FilterUsingRule(string rawContent){return string.Empty;}
        public void FixFilteredContent(string filteredContent)
        {
           
            if (!string.IsNullOrEmpty(this.PretendBefore.Trim()))
            {
                filteredContent = PretendBefore + filteredContent;
            }
            if (!string.IsNullOrEmpty(AppendAfter.Trim()))
            {
                filteredContent += AppendAfter;
            }
        
        }
    }
}
