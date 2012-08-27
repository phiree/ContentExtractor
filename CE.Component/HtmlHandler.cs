using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Component
{
    public class HtmlHandler
    {
        public string ReadHtml(string filename)
        {
            string html = System.IO.File.ReadAllText(filename);
            //string[] htmlArray=System.IO.File.ReadAllLines(filename);
            //for (int i = 0; i < htmlArray.Length; i++)
            //{
            //    html += htmlArray[i].Trim();
            //}
            return html;
        }
    }
}
