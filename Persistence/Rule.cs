using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPersistence;
using System.Xml;
using System.IO;
namespace Persistence
{
    public class Rule:IRule
    {
        public void SaveRule(CE.Domain.Rule.RuleAssembly ruleAssembly)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (!File.Exists(@"d:\" + ruleAssembly.Name + ".xml"))
            {
                //File.Create(@"d:\" + ruleAssembly.Name + ".xml");
                XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "GB2312", null);
                xmlDoc.AppendChild(dec);
                //创建一个根节点（一级）
                XmlElement xeroot = xmlDoc.CreateElement(ruleAssembly.Name);
                xmlDoc.AppendChild(xeroot);
                //保存到D盘下以ruleAssembly.Name命名的xml中
                //xmlDoc.Save(@"d:\" + ruleAssembly.Name + ".xml");
            }
            else
            {
                xmlDoc.Load(@"d:\" + ruleAssembly.Name + ".xml");
            }
            XmlNode root = xmlDoc.SelectSingleNode(ruleAssembly.Name);//查找<root>
            foreach (var ruleset in ruleAssembly.RuleSets)
            {
                XmlElement xe1 = xmlDoc.CreateElement(ruleset.Name);//创建一个<ruleset>节点
                //xe1.SetAttribute("Name", "李赞红");//设置该节点genre属性
                //xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性
                XmlElement xesub1 = xmlDoc.CreateElement("RuleSetId");
                xesub1.InnerText = ruleset.Id==0?"":ruleset.Id.ToString();
                xe1.AppendChild(xesub1);
                XmlElement xesub2 = xmlDoc.CreateElement("RuleSetName");
                xesub2.InnerText = ruleset.Name??"";
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmlDoc.CreateElement("RuleSetSetNo");
                xesub3.InnerText = ruleset.SetNo.ToString();
                xe1.AppendChild(xesub3);
                XmlElement xesub4 = xmlDoc.CreateElement("RuleSetNeedImageLocalizer");
                xesub4.InnerText = ruleset.NeedImageLocalizer.ToString();
                xe1.AppendChild(xesub4);
                XmlElement xesub5 = xmlDoc.CreateElement("RuleSetRules");
                foreach (var item in ruleset.Rules)
                {
                    XmlElement xe2 = xmlDoc.CreateElement(item.Name);
                    XmlElement xe2sub1 = xmlDoc.CreateElement("RuleSetId");
                    xe2sub1.InnerText = ruleset.Id.ToString();
                    xe2.AppendChild(xe2sub1);
                    XmlElement xe2sub2 = xmlDoc.CreateElement("RuleSetName");
                    xe2sub2.InnerText = ruleset.Name;
                    xe2.AppendChild(xe2sub2);
                    XmlElement xe2sub3 = xmlDoc.CreateElement("RuleSetSetNo");
                    xe2sub3.InnerText = ruleset.SetNo.ToString();
                    xe2.AppendChild(xe2sub3);
                    XmlElement xe2sub4 = xmlDoc.CreateElement("RuleSetNeedImageLocalizer");
                    xe2sub4.InnerText = ruleset.NeedImageLocalizer.ToString();
                    xe2.AppendChild(xe2sub4);
                    xesub5.AppendChild(xe2);
                }
                xe1.AppendChild(xesub5);
                root.AppendChild(xe1);//添加到<bookstore>节点中
            }
            xmlDoc.Save(@"d:\"+ruleAssembly.Name+".xml");
        }
    }
}
