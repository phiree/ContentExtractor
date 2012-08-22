using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPersistence
{
    public interface IRule
    {
        /// <summary>
        /// 持久化rule
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ruleAssembly"></param>
        void SaveRule(CE.Domain.Rule.RuleAssembly ruleAssembly);

        /// <summary>
        /// 读取rule
        /// </summary>
        /// <param name="path"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        CE.Domain.Rule.RuleAssembly ReadRule(string assemblyName);
    }
}
