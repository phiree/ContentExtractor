using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Domain
{
    /// <summary>
    /// 站点设置类
    /// </summary>
   public class SiteConfig
    {
       /// <summary>
       /// 图片的本地保存地址
       /// </summary>
       public const string SaveDirectoryForFetchedImages = @"D:\testImageLocalizer\";
       /// <summary>
       /// 图片虚拟路径
       /// </summary>
       public const string PathForFetchedImages = "/scenicimg/";
    }
}
