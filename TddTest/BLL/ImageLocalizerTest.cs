using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.BLL;
using System.IO;
namespace TddTest.BLL
{
    /// <summary>
    /// 将服务器的图片按照指定名称保存至本地磁盘,并返回Url相对路径.
    /// </summary>
    [TestFixture]
    public class ImageLocalizerTest
    {
        [Test]
        public void SavePhotoFromUrlTest()
        {
            string savePath="/ScenicImg/";
            string savePathPhy=@"d:\testImageLocalizer\";
            string savedFileName = Guid.NewGuid().ToString();
            ImageLocalizer localizer = new ImageLocalizer(
                "http://www.tourol.cn/theme/default/image/newversion/Logo2.png"
                ,savePathPhy
                , savePath
                ,savedFileName);
        string actual= localizer.SavePhotoFromUrl();
        Assert.AreEqual(savePath+ savedFileName+".png", actual);
        FileInfo file = new FileInfo(savePathPhy + savedFileName + ".png");
        Assert.IsTrue(file.Exists);
        Assert.IsTrue(file.LastAccessTime.AddSeconds(2) > DateTime.Now);
        
        }
    }
}
