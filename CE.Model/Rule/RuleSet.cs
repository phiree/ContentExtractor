using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CE.Component;
using CE.Domain;
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
        public List<BaseRule> Rules { get; set; }

        public RuleSet()
        {
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

               string filtered= rule.FilterUsingRule(ref rawContent);
                
               completeResult += filtered;
                
            }
            if (returnJsonFormat)
            {
                completeResult =  Code + ":\"" + completeResult+"\"";
            }
            if (NeedImageLocalizer)
            {
                string[] imageUrls = TextHelper.GetImageUrl(completeResult);
                foreach (string imageUrl in imageUrls)
                { 
                    ImageLocalizer localizer=new ImageLocalizer(imageUrl
                        
                        , SiteConfig.SaveDirectoryForFetchedImages
                        ,SiteConfig.PathForFetchedImages
                        ,Math.Abs(imageUrl.GetHashCode()).ToString());
                   string newImagePath= localizer.SavePhotoFromUrl();
                   completeResult = completeResult.Replace(imageUrl, newImagePath);
                }
            }
            return completeResult;
        }

        private int SortCompare(BaseRule rule1, BaseRule rule2)
        {
            return rule1.RuleNo.CompareTo(rule2.RuleNo);
        }
    }
}
