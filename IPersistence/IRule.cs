using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPersistence
{
    public interface IRule
    {
         void SaveRule(CE.Domain.Rule.BaseRule rule);
        
    }
}
