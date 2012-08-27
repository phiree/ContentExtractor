using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Component
{
    public class HtmlHandler
    {
        public  static string ReadHtml(string filename)
        {
            string html =System.IO.File.ReadAllText(filename);
           
            return html;
        }
    }
}
