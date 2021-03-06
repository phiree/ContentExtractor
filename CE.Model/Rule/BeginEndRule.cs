﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Domain.Rule
{
    /// <summary>
    /// 能够获取某项特定内容的规则集合
    /// </summary>
    public class BeginEndRule:BaseRule
    {
        public string BeginMark{get;set;}
        public string EndMark { get; set; }
       /// <summary>
       /// 是否包含用于定位的字符串
       /// </summary>

        public bool IncludeBeginMark { get; set; }
        public bool IncludeEndMark { get; set; }
        /// <summary>
        /// 过滤完成后是否删除开始/结束标识字符串
        /// </summary>
        public bool RemoveBegin { get; set; }
        public bool RemoveEnd { get; set; }

        /// <summary>
        /// 初始化规则
        /// </summary>
        /// <param name="beginmark"></param>
        /// <param name="endmark"></param>
        /// <param name="includeBegin"></param>
        /// <param name="includeEnd"></param>
        /// <param name="removeBegin"></param>
        /// <param name="removeEnd"></param>
        public BeginEndRule(string beginmark,string endmark,bool includeBegin,bool includeEnd,bool removeBegin,bool removeEnd)
            :base(1,string.Empty,string.Empty)
        {
            BeginMark = beginmark;
            EndMark = endmark;
            IncludeBeginMark = includeBegin;
            IncludeEndMark = includeEnd;
            RemoveBegin = removeBegin;
            RemoveEnd = removeEnd;
        }
       
        /// <summary>
        /// 根据规则, 过滤出结果
        /// </summary>
        /// <param name="rawContent"></param>
        /// <returns></returns>
        public override string FilterUsingRule(ref string rawContent)
        {
            string filteredContent = rawContent;
            if (!this.Enabled)
                return filteredContent;
            if (string.IsNullOrEmpty(this.BeginMark) || string.IsNullOrEmpty(this.EndMark))
                return filteredContent;
            //断言:标记在文中唯一
            //开始标记--结束标记 是否包括,攫取后添加的头部标签.的尾部
            int startIndex = filteredContent.IndexOf(this.BeginMark, StringComparison.OrdinalIgnoreCase);
            if (startIndex == -1)
            {
                return string.Empty;
            }
            //原等式,起始点错误,如下修改
            //int endIndex = rawContent.IndexOf(this.EndMark, startIndex);
            int endIndex = rawContent.IndexOf(this.EndMark, startIndex + this.BeginMark.Length);
            if (endIndex == -1)
                return string.Empty;
            filteredContent = rawContent.Substring(startIndex + this.BeginMark.Length, endIndex - startIndex - this.BeginMark.Length);

            if (this.IncludeBeginMark)
            {
                filteredContent = BeginMark + filteredContent;
            }
            if (this.IncludeEndMark)
            {
                filteredContent += EndMark;
            }
            string tobeRemoved = filteredContent;
            if ((!IncludeBeginMark) && RemoveBegin)
            {
                tobeRemoved = BeginMark + tobeRemoved;
            }
            if ((!IncludeEndMark) && RemoveEnd)
            {
                tobeRemoved += EndMark;
            }
            rawContent = rawContent.Replace(tobeRemoved, string.Empty);

            FixFilteredContent(filteredContent);
            return filteredContent;
        }
    }

}
