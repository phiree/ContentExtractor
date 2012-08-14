using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.BLL.Rule
{
    /// <summary>
    /// 规则接口
    /// </summary>
   public  interface IRule
    {
       string ExcuteFilter(string rawContent);
    }
}
