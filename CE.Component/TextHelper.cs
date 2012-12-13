using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace CE.Component
{
  public   class TextHelper
    {
      public static string[] GetImageUrl(string raw)
      {
          List<string> imageUrls = new List<string>();
          string pattern = "<[img|IMG|Img](?:.*).*?src=(\"{1}|\'{1})([^\\[^>]+[gif|jpg|jpeg|bmp|png]{1})(\"{1}|\'{1})[>]?";
          Regex rex = new Regex(pattern);
          MatchCollection matchs = rex.Matches(raw);
          foreach(Match m in matchs)
          { 
             imageUrls.Add(m.Groups[2].Value);
          }
          return imageUrls.ToArray();
      }
    }
}
