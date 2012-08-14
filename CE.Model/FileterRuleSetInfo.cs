using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Model
{
    /// <summary>
    /// 能够获取某项特定内容的规则集合
    /// </summary>
    public class FileterRuleSetInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 该内容对应的属性名称,用来做对象序列化
        /// </summary>
        public string CodeName { get; set; }
        public List<FilterRuleInfo> Rules { get; set; }
        /// <summary>
        /// 该规则集合应用到的网站.
        /// </summary>
        public TargetSite Site { get; set; }
    }

}
