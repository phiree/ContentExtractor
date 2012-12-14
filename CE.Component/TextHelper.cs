using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace CE.Component
{
    public class TextHelper
    {
        public static string[] GetImageUrl(string raw, string regexpattern)
        {
            List<string> imageUrls = new List<string>();
            string pattern=string.Empty;
            var regexp=(RegexPattern)Enum.Parse(typeof(RegexPattern),regexpattern);
            if (regexp == RegexPattern.detailimg)
            {
                pattern = "<[img|IMG|Img](?:.*).*?src=(\"{1}|\'{1})([^\\[^>]+[gif|jpg|jpeg|bmp|png]{1})(\"{1}|\'{1})[>]?";
                Regex rex = new Regex(pattern);
                MatchCollection matchs = rex.Matches(raw);
                foreach (Match m in matchs)
                {
                    imageUrls.Add(m.Groups[2].Value);
                }
            }
            if (regexp == RegexPattern.mainimg)
            {
                pattern = @"(?<=nsrc="").*?(?="")";
                Regex rex = new Regex(pattern);
                MatchCollection matchs = rex.Matches(raw);
                foreach (Match m in matchs)
                {
                    imageUrls.Add(m.Value);
                }
            }
            return imageUrls.ToArray();
        }

        public enum RegexPattern
        {
            mainimg, detailimg
        }
    }
}
