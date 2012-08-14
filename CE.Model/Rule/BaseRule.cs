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
        public abstract string FilterUsingRule(string rawContent);
    }
}
