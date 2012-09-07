using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CE.Component;
using CE.Domain;
using System.IO;
using System.Text.RegularExpressions;
namespace CE.Domain.Rule
{
    /// <summary>
    /// 用于提取特定内容的一组rule
    /// 最终结果等于每个rule匹配出来的结果之和.
    /// </summary>
    public class RuleSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SetNo { get; set; }
        /// <summary>
        /// 目标对象的属性.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否需要将远程图片保存至本地
        /// </summary>
        public bool NeedImageLocalizer { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 虚拟路径
        /// </summary>
        public string VirtualPath { get; set; }
        /// <summary>
        /// 要替换的字符正则表达式
        /// </summary>
        /// <remarks>
        /// 正则表达式
        /// </remarks>
        public string OldRegex { get; set; }
        /// <summary>
        /// 替换后的字符
        /// </summary>
        /// <remarks>
        /// 字符串  不是正则表达式
        /// </remarks>
        public string NewRegex { get; set; }
        public List<BaseRule> Rules { get; set; }
        public RuleSet()
        {
            Id = 0;
            Name = string.Empty;
            SetNo = 0;
            Code = string.Empty;
            NeedImageLocalizer = false;
            Rules = new List<BaseRule>();
        }
        /// <summary>
        /// 最终结果
        /// </summary>

        /// <summary>
        /// 按照order,使用rule过滤.
        /// </summary>
        /// <param name="rawContent"></param>
        /// <returns></returns>
        public string FilterUsingRuleSet(ref string rawContent, bool returnJsonFormat)
        {
            string completeResult = string.Empty;
            Rules.Sort(SortCompare);
            foreach (BaseRule rule in Rules)
            {
                //通过规则过滤文本
                string filtered = rule.FilterUsingRule(ref rawContent);

                //合并
                completeResult += filtered;
            }
            //判断是否有替换文本
            if (!string.IsNullOrEmpty(OldRegex))
            {
                MatchCollection mc = Regex.Matches(completeResult, OldRegex);
                if (mc.Count > 0)
                {
                    foreach (Match item in mc)
                    {
                        completeResult = completeResult.Replace(item.Value, NewRegex);
                    }
                }
            }
            //是否返回json格式
            if (returnJsonFormat)
            {
                completeResult = Code + ":\"" + completeResult + "\"";
            }
            if (NeedImageLocalizer)
            {
                string[] imageUrls = TextHelper.GetImageUrl(completeResult);
                foreach (string imageUrl in imageUrls)
                {
                    ImageLocalizer localizer = new ImageLocalizer(imageUrl
                        , ImagePath
                        , VirtualPath
                        , Math.Abs(imageUrl.GetHashCode()).ToString());
                    string newImagePath = localizer.SavePhotoFromUrl();
                    completeResult = completeResult.Replace(imageUrl, newImagePath);
                }
                //string[] temp=ImagePath.Split(new char[]{'\\'},StringSplitOptions.RemoveEmptyEntries);
                //ImagePath = string.Empty;
                //for (int i = 0; i < temp.Length-1; i++)
                //{
                //    ImagePath += temp[i] + "\\";
                //}
            }
            return completeResult;
        }

        private int SortCompare(BaseRule rule1, BaseRule rule2)
        {
            return rule1.RuleNo.CompareTo(rule2.RuleNo);
        }
    }
}
