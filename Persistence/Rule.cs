using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPersistence;
using System.Xml;
using System.IO;
namespace Persistence
{
    public class Rule : IRule
    {
        public PersistenceWay Persistenceway { get; set; }
        private string persistencepath;
        public string PersistencePath
        {
            get
            {
                if (string.IsNullOrEmpty(persistencepath))
                {
                    return @"d:\";
                }
                else
                {
                    return persistencepath;
                }
            }
            set
            {
                persistencepath = value;
            }
        }

        public Rule(string persistencepath)
        {
            this.PersistencePath = persistencepath;
        }

        /// <summary>
        /// 持久化rule
        /// </summary>
        /// <param name="PersistencePath"></param>
        /// <param name="ruleAssembly"></param>
        public void SaveRule(CE.Domain.Rule.RuleAssembly ruleAssembly)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (!File.Exists(PersistencePath + ruleAssembly.Name + ".xml"))
            {
                XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "GB2312", null);
                xmlDoc.AppendChild(dec);
                //创建一个根节点（一级）
                XmlElement xeroot = xmlDoc.CreateElement(ruleAssembly.Name);
                xmlDoc.AppendChild(xeroot);
                XmlNode root = xmlDoc.SelectSingleNode(ruleAssembly.Name);//查找<root>
                foreach (var ruleset in ruleAssembly.RuleSets)
                {
                    XmlElement xe1 = xmlDoc.CreateElement(ruleset.Name);//创建一个<ruleset>节点
                    XmlElement xesub1 = xmlDoc.CreateElement("RuleSetId");
                    xesub1.InnerText = ruleset.Id == 0 ? "" : ruleset.Id.ToString();
                    xe1.AppendChild(xesub1);
                    XmlElement xesub2 = xmlDoc.CreateElement("RuleSetName");
                    xesub2.InnerText = ruleset.Name ?? "";
                    xe1.AppendChild(xesub2);
                    XmlElement xesub3 = xmlDoc.CreateElement("RuleSetSetNo");
                    xesub3.InnerText = ruleset.SetNo.ToString();
                    xe1.AppendChild(xesub3);
                    XmlElement xesub5 = xmlDoc.CreateElement("RuleSetRules");
                    foreach (var item in ruleset.Rules)
                    {
                        CE.Domain.Rule.BeginEndRule ber = (CE.Domain.Rule.BeginEndRule)item;
                        XmlElement xe2 = xmlDoc.CreateElement(ber.Name);

                        XmlElement xe2sub1 = xmlDoc.CreateElement("Id");
                        xe2sub1.InnerText = ber.Id.ToString();
                        xe2.AppendChild(xe2sub1);
                        XmlElement xe2sub2 = xmlDoc.CreateElement("Name");
                        xe2sub2.InnerText = ber.Name;
                        xe2.AppendChild(xe2sub2);
                        XmlElement xe2sub3 = xmlDoc.CreateElement("RuleNo");
                        xe2sub3.InnerText = ber.RuleNo.ToString();
                        xe2.AppendChild(xe2sub3);
                        XmlElement xe2sub4 = xmlDoc.CreateElement("PreAppenddBefore");
                        xe2sub4.InnerText = ber.PreAppenddBefore.ToString();
                        xe2.AppendChild(xe2sub4);
                        XmlElement xe2sub5 = xmlDoc.CreateElement("AppendAfter");
                        xe2sub5.InnerText = ber.AppendAfter.ToString();
                        xe2.AppendChild(xe2sub5);
                        XmlElement xe2sub6 = xmlDoc.CreateElement("Enabled");
                        xe2sub6.InnerText = ber.Enabled.ToString();
                        xe2.AppendChild(xe2sub6);

                        XmlElement xe2sub11 = xmlDoc.CreateElement("BeginMark");
                        xe2sub11.InnerText = ber.BeginMark.ToString();
                        xe2.AppendChild(xe2sub11);
                        XmlElement xe2sub12 = xmlDoc.CreateElement("EndMark");
                        xe2sub12.InnerText = ber.EndMark;
                        xe2.AppendChild(xe2sub12);
                        XmlElement xe2sub13 = xmlDoc.CreateElement("IncludeBeginMark");
                        xe2sub13.InnerText = ber.IncludeBeginMark.ToString();
                        xe2.AppendChild(xe2sub13);
                        XmlElement xe2sub14 = xmlDoc.CreateElement("IncludeEndMark");
                        xe2sub14.InnerText = ber.IncludeEndMark.ToString();
                        xe2.AppendChild(xe2sub14);
                        XmlElement xe2sub15 = xmlDoc.CreateElement("RemoveBegin");
                        xe2sub15.InnerText = ber.RemoveBegin.ToString();
                        xe2.AppendChild(xe2sub15);
                        XmlElement xe2sub16 = xmlDoc.CreateElement("RemoveEnd");
                        xe2sub16.InnerText = ber.RemoveEnd.ToString();
                        xe2.AppendChild(xe2sub16);

                        xesub5.AppendChild(xe2);
                    }
                    xe1.AppendChild(xesub5);
                    root.AppendChild(xe1);
                }
                xmlDoc.Save(PersistencePath + ruleAssembly.Name + ".xml");
            }
            else
            {
                //xmlDoc.Load(path + ruleAssembly.Name + ".xml");
                //删除文件.并重新调用本方法,创建一个新的xml保存文件
                File.Delete(PersistencePath + ruleAssembly.Name + ".xml");
                SaveRule(ruleAssembly);
            }
        }

        /// <summary>
        /// 读取rule
        /// </summary>
        /// <param name="PersistencePath"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public CE.Domain.Rule.RuleAssembly ReadRule(string assemblyName)
        {
            CE.Domain.Rule.RuleAssembly rassembly = new CE.Domain.Rule.RuleAssembly();
            List<CE.Domain.Rule.RuleSet> rsetlist = new List<CE.Domain.Rule.RuleSet>();
            CE.Domain.Rule.RuleSet rset = new CE.Domain.Rule.RuleSet();
            List<CE.Domain.Rule.BaseRule> berlist;
            CE.Domain.Rule.BeginEndRule ber;
            //加载xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(PersistencePath + assemblyName + ".xml");
            //xn整篇
            XmlNode assembly = xmlDoc.SelectSingleNode(assemblyName);
            //xnl各个ruleset
            XmlNodeList rulesets = assembly.ChildNodes;
            #region rulesetlist
            foreach (XmlNode item in rulesets)
            {
                //单个ruleset
                XmlElement ruleset = (XmlElement)item;
                //ruleset属性集合
                XmlNodeList rulesetnode = ruleset.ChildNodes;
                rset = new CE.Domain.Rule.RuleSet();
                #region ruleset
                foreach (XmlNode item2 in rulesetnode)
                {
                    berlist = new List<CE.Domain.Rule.BaseRule>();
                    //单个ruleset属性
                    if (item2.Name == "RuleSetId")
                    {
                        rset.Id = int.Parse(item2.InnerText == string.Empty ? "0" : item2.InnerText);
                        continue;
                    }
                    if (item2.Name == "RuleSetName")
                    {
                        rset.Name = item2.InnerText;
                        continue;
                    }
                    if (item2.Name == "RuleSetSetNo")
                    {
                        rset.SetNo = int.Parse(item2.InnerText == string.Empty ? "False" : item2.InnerText);
                        continue;
                    }
                    if (item2.Name == "RuleSetRules")
                    {
                        //rules
                        XmlNodeList rulesinset = item2.ChildNodes;
                        #region rule
                        foreach (XmlNode rule in rulesinset)
                        {
                            //单个rule
                            XmlNodeList rulenodes = rule.ChildNodes;
                            string Id = string.Empty;
                            string Name = string.Empty;
                            string RuleNo = string.Empty;
                            string PreAppenddBefore = string.Empty;
                            string AppendAfter = string.Empty;
                            string Enabled = string.Empty;
                            string BeginMark = string.Empty;
                            string EndMark = string.Empty;
                            bool IncludeBeginMark = false;
                            bool IncludeEndMark = false;
                            bool RemoveBegin = false;
                            bool RemoveEnd = false;
                            foreach (XmlNode rulenode in rulenodes)
                            {
                                if (rulenode.Name == "Id")
                                {
                                    Id = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "Name")
                                {
                                    Name = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "RuleNo")
                                {
                                    RuleNo = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "PreAppenddBefore")
                                {
                                    PreAppenddBefore = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "AppendAfter")
                                {
                                    AppendAfter = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "Enabled")
                                {
                                    Enabled = rulenode.InnerText;
                                    continue;
                                }

                                if (rulenode.Name == "BeginMark")
                                {
                                    BeginMark = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "EndMark")
                                {
                                    EndMark = rulenode.InnerText;
                                    continue;
                                }
                                if (rulenode.Name == "IncludeBeginMark")
                                {
                                    IncludeBeginMark = bool.Parse(rulenode.InnerText);
                                    continue;
                                }
                                if (rulenode.Name == "IncludeEndMark")
                                {
                                    IncludeEndMark = bool.Parse(rulenode.InnerText);
                                    continue;
                                }
                                if (rulenode.Name == "RemoveBegin")
                                {
                                    RemoveBegin = bool.Parse(rulenode.InnerText);
                                    continue;
                                }
                                if (rulenode.Name == "RemoveEnd")
                                {
                                    RemoveEnd = bool.Parse(rulenode.InnerText);
                                    continue;
                                }
                            }
                            ber = new CE.Domain.Rule.BeginEndRule(BeginMark, EndMark, IncludeBeginMark, IncludeEndMark, RemoveBegin, RemoveEnd);
                            ber.Id = int.Parse(Id);
                            ber.Name = Name;
                            ber.RuleNo = int.Parse(RuleNo);
                            ber.PreAppenddBefore = PreAppenddBefore;
                            ber.AppendAfter = AppendAfter;
                            ber.Enabled = bool.Parse(Enabled);
                            CE.Domain.Rule.BaseRule br = ber;
                            berlist.Add(br);
                        }
                        #endregion
                        rset.Rules = berlist;
                        continue;
                    }
                }
                #endregion
                rsetlist.Add(rset);
            }
            #endregion
            rassembly.RuleSets = rsetlist;
            return rassembly;
        }

        /// <summary>
        /// 根据传入的ruleassembly,将结果保存到execl中
        /// </summary>
        /// <param name="ruelassembly"></param>
        public void PersisteceRule(CE.Domain.Rule.RuleAssembly ruelassembly)
        {
            
        }
    }
}
