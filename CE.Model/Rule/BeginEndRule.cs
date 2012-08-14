using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Model.Rule
{
    /// <summary>
    /// 能够获取某项特定内容的规则集合
    /// </summary>
    public class BeginEndRule:IRule
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OrderNumber { get; set; }
        public string RawContent { get; set; }
       
        public TargetSite Site { get; set; }

        public string ExcuteFilter(string rawContent)
        {
            throw new NotImplementedException();
        }
    }

}
