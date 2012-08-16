using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Domain.Rule
{
    public class BaseRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 规则的序号.多个规则服役时,按照序号一次执行.
        /// </summary>
        public int RuleNo { get; set; }
        //是需要移除的内容?
        //补全不完整的tag
        public string PreAppenddBefore { get; set; }
        public string AppendAfter { get; set; }
        public bool Enabled { get; set; }
        public virtual  string FilterUsingRule(ref string rawContent){return string.Empty;}
        public BaseRule(int orderNumber,string preappendBefore
            ,string appendAfter)
        {
            RuleNo = orderNumber;
            PreAppenddBefore = preappendBefore;
            AppendAfter = appendAfter;
            Enabled = true;
           
        }
        public void RemoveFilteredFromRaw()
        { 
            
        }
        
        protected void FixFilteredContent(string filteredContent)
        {
           
            if (!string.IsNullOrEmpty(this.PreAppenddBefore.Trim()))
            {
                filteredContent = PreAppenddBefore + filteredContent;
            }
            if (!string.IsNullOrEmpty(AppendAfter.Trim()))
            {
                filteredContent += AppendAfter;
            }
        
        }
    }
}
