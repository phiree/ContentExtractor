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

        //public Rule(string persistencepath)
        //{
        //    this.PersistencePath = persistencepath;
        //}

        /// <summary>
        /// 持久化rule
        /// </summary>
        /// <param name="PersistencePath"></param>
        /// <param name="ruleAssembly"></param>
        /// <remarks>保存前要先设置persistencePath</remarks>
        public void SaveRule(CE.Domain.Rule.RuleAssembly ruleAssembly)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (!File.Exists(PersistencePath.EndsWith("\\") ? PersistencePath + ruleAssembly.Name + ".xml" : PersistencePath + "\\" + ruleAssembly.Name + ".xml"))
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

                    XmlElement xesub4 = xmlDoc.CreateElement("NeedImageLocalizer");
                    xesub4.InnerText = ruleset.NeedImageLocalizer.ToString();
                    xe1.AppendChild(xesub4);
                    //ImagePath
                    XmlElement xesub6 = xmlDoc.CreateElement("ImagePath");
                    xesub6.InnerText = ruleset.ImagePath ?? "";
                    xe1.AppendChild(xesub6);
                    //VirtualPath
                    XmlElement xesub7 = xmlDoc.CreateElement("VirtualPath");
                    xesub7.InnerText = ruleset.VirtualPath ?? "";
                    xe1.AppendChild(xesub7);
                    //ImagePath
                    XmlElement xesub8 = xmlDoc.CreateElement("OldRegex");
                    if (ruleset.OldRegex.Count > 0)
                    {
                        foreach (string item in ruleset.OldRegex)
                        {
                            XmlElement xe2sub = xmlDoc.CreateElement("regexrule");
                            xe2sub.InnerText = item;
                            xesub8.AppendChild(xe2sub);
                        }
                    }
                    xe1.AppendChild(xesub8);
                    //VirtualPath
                    XmlElement xesub9 = xmlDoc.CreateElement("NewRegex");
                    if (ruleset.NewRegex.Count > 0)
                    {
                        foreach (string item in ruleset.NewRegex)
                        {
                            XmlElement xe2sub = xmlDoc.CreateElement("regexrule");
                            xe2sub.InnerText = item;
                            xesub9.AppendChild(xe2sub);
                        }
                    }
                    xe1.AppendChild(xesub9);
                    //RuleSetRules
                    XmlElement xesub5 = xmlDoc.CreateElement("RuleSetRules");
                    foreach (var item in ruleset.Rules)
                    {
                        CE.Domain.Rule.BeginEndRule br = item as CE.Domain.Rule.BeginEndRule;
                        CE.Domain.Rule.RegexRule rr = item as CE.Domain.Rule.RegexRule;
                        CE.Domain.Rule.ReplaceRule rer = item as CE.Domain.Rule.ReplaceRule;
                        if (br != null)
                        {
                            #region cao!
                            XmlElement xe2 = xmlDoc.CreateElement(br.Name);

                            //baseRule的属性
                            XmlElement xe2sub1 = xmlDoc.CreateElement("Id");
                            xe2sub1.InnerText = br.Id.ToString();
                            xe2.AppendChild(xe2sub1);

                            XmlElement xe2sub2 = xmlDoc.CreateElement("Name");
                            xe2sub2.InnerText = br.Name;
                            xe2.AppendChild(xe2sub2);

                            XmlElement xe2sub3 = xmlDoc.CreateElement("RuleNo");
                            xe2sub3.InnerText = br.RuleNo.ToString();
                            xe2.AppendChild(xe2sub3);

                            XmlElement xe2sub4 = xmlDoc.CreateElement("PreAppenddBefore");
                            xe2sub4.InnerText = br.PreAppenddBefore.ToString();
                            xe2.AppendChild(xe2sub4);

                            XmlElement xe2sub5 = xmlDoc.CreateElement("AppendAfter");
                            xe2sub5.InnerText = br.AppendAfter.ToString();
                            xe2.AppendChild(xe2sub5);

                            XmlElement xe2sub6 = xmlDoc.CreateElement("Enabled");
                            xe2sub6.InnerText = br.Enabled.ToString();
                            xe2.AppendChild(xe2sub6);

                            //子类Rule的属性

                            CE.Domain.Rule.BeginEndRule ber = (CE.Domain.Rule.BeginEndRule)br;

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

                            #endregion
                        }
                        if (rr != null)
                        {
                            #region cao!
                            XmlElement xe2 = xmlDoc.CreateElement(rr.Name);

                            //baseRule的属性
                            XmlElement xe2sub1 = xmlDoc.CreateElement("Id");
                            xe2sub1.InnerText = rr.Id.ToString();
                            xe2.AppendChild(xe2sub1);
                            XmlElement xe2sub2 = xmlDoc.CreateElement("Name");
                            xe2sub2.InnerText = rr.Name;
                            xe2.AppendChild(xe2sub2);
                            XmlElement xe2sub3 = xmlDoc.CreateElement("RuleNo");
                            xe2sub3.InnerText = rr.RuleNo.ToString();
                            xe2.AppendChild(xe2sub3);
                            XmlElement xe2sub4 = xmlDoc.CreateElement("PreAppenddBefore");
                            xe2sub4.InnerText = rr.PreAppenddBefore.ToString();
                            xe2.AppendChild(xe2sub4);
                            XmlElement xe2sub5 = xmlDoc.CreateElement("AppendAfter");
                            xe2sub5.InnerText = rr.AppendAfter.ToString();
                            xe2.AppendChild(xe2sub5);
                            XmlElement xe2sub6 = xmlDoc.CreateElement("Enabled");
                            xe2sub6.InnerText = rr.Enabled.ToString();
                            xe2.AppendChild(xe2sub6);

                            //子类Rule的属性

                            XmlElement xe2sub11 = xmlDoc.CreateElement("RegexExp");
                            xe2sub11.InnerText = rr.RegexExp.ToString();
                            xe2.AppendChild(xe2sub11);
                            xesub5.AppendChild(xe2);
                            #endregion
                        }
                        if (rer != null)
                        {
                            #region cao!
                            XmlElement xe2 = xmlDoc.CreateElement(rer.Name);

                            //baseRule的属性
                            XmlElement xe2sub1 = xmlDoc.CreateElement("Id");
                            xe2sub1.InnerText = rer.Id.ToString();
                            xe2.AppendChild(xe2sub1);
                            XmlElement xe2sub2 = xmlDoc.CreateElement("Name");
                            xe2sub2.InnerText = rer.Name;
                            xe2.AppendChild(xe2sub2);
                            XmlElement xe2sub3 = xmlDoc.CreateElement("RuleNo");
                            xe2sub3.InnerText = rer.RuleNo.ToString();
                            xe2.AppendChild(xe2sub3);
                            XmlElement xe2sub4 = xmlDoc.CreateElement("PreAppenddBefore");
                            xe2sub4.InnerText = rer.PreAppenddBefore.ToString();
                            xe2.AppendChild(xe2sub4);
                            XmlElement xe2sub5 = xmlDoc.CreateElement("AppendAfter");
                            xe2sub5.InnerText = rer.AppendAfter.ToString();
                            xe2.AppendChild(xe2sub5);
                            XmlElement xe2sub6 = xmlDoc.CreateElement("Enabled");
                            xe2sub6.InnerText = rer.Enabled.ToString();
                            xe2.AppendChild(xe2sub6);

                            //子类Rule的属性

                            XmlElement xe2sub11 = xmlDoc.CreateElement("OldMark");
                            xe2sub11.InnerText = rer.OldMark.ToString();
                            xe2.AppendChild(xe2sub11);
                            XmlElement xe2sub12 = xmlDoc.CreateElement("NewMark");
                            xe2sub12.InnerText = rer.NewMark.ToString();
                            xe2.AppendChild(xe2sub12);
                            xesub5.AppendChild(xe2);
                            #endregion
                        }
                    }
                    xe1.AppendChild(xesub5);
                    root.AppendChild(xe1);
                }
                xmlDoc.Save(PersistencePath.EndsWith("\\") ? PersistencePath + ruleAssembly.Name + ".xml" : PersistencePath + "\\" + ruleAssembly.Name + ".xml");
            }
            else
            {
                //xmlDoc.Load(path + ruleAssembly.Name + ".xml");
                //删除文件.并重新调用本方法,创建一个新的xml保存文件
                File.Delete(PersistencePath.EndsWith("\\") ? PersistencePath + ruleAssembly.Name + ".xml" : PersistencePath + "\\" + ruleAssembly.Name + ".xml");
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
            //List<CE.Domain.Rule.BaseRule> berlist;
            CE.Domain.Rule.BeginEndRule ber;
            CE.Domain.Rule.RegexRule rr;
            //加载xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(PersistencePath.EndsWith("\\") ? PersistencePath + assemblyName + ".xml" : PersistencePath + "\\" + assemblyName + ".xml");
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
                    brlist = new List<CE.Domain.Rule.BaseRule>();
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
                    if (item2.Name == "NeedImageLocalizer")
                    {
                        rset.NeedImageLocalizer = bool.Parse(item2.InnerText);
                        continue;
                    }
                    if (item2.Name == "ImagePath")
                    {
                        rset.ImagePath = item2.InnerText;
                        continue;
                    }
                    if (item2.Name == "VirtualPath")
                    {
                        rset.VirtualPath = item2.InnerText;
                        continue;
                    }
                    if (item2.Name == "OldRegex")
                    {
                        XmlNodeList rulesinset = item2.ChildNodes;
                        foreach (XmlNode rule in rulesinset)
                        {
                            rset.OldRegex.Add(rule.InnerText);
                        }
                        continue;
                    }
                    if (item2.Name == "NewRegex")
                    {
                        XmlNodeList rulesinset = item2.ChildNodes;
                        foreach (XmlNode rule in rulesinset)
                        {
                            rset.NewRegex.Add(rule.InnerText);
                        }
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
                            #region 属性
                            //baserule属性
                            string Id = string.Empty;
                            string Name = string.Empty;
                            string RuleNo = string.Empty;
                            string PreAppenddBefore = string.Empty;
                            string AppendAfter = string.Empty;
                            string Enabled = string.Empty;
                            //子类beginendrule属性
                            string BeginMark = string.Empty;
                            string EndMark = string.Empty;
                            bool IncludeBeginMark = false;
                            bool IncludeEndMark = false;
                            bool RemoveBegin = false;
                            bool RemoveEnd = false;
                            //子类regexrule属性
                            string RegexExp = string.Empty;
                            #endregion
                            //子类标识
                            Type type = typeof(CE.Domain.Rule.BeginEndRule);
                            foreach (XmlNode rulenode in rulenodes)
                            {
                                #region baserule属性
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
                                #endregion

                                #region ber属性
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
                                #endregion

                                #region rr属性
                                if (rulenode.Name == "RegexExp")
                                {
                                    RegexExp = rulenode.InnerText;
                                    type = typeof(CE.Domain.Rule.RegexRule);
                                    continue;
                                }
                                #endregion
                            }
                            CE.Domain.Rule.BaseRule br;
                            if (type == typeof(CE.Domain.Rule.BeginEndRule))
                            {
                                ber = new CE.Domain.Rule.BeginEndRule(BeginMark, EndMark, IncludeBeginMark, IncludeEndMark, RemoveBegin, RemoveEnd);
                                ber.Id = int.Parse(Id);
                                ber.Name = Name;
                                ber.RuleNo = int.Parse(RuleNo);
                                ber.PreAppenddBefore = PreAppenddBefore;
                                ber.AppendAfter = AppendAfter;
                                ber.Enabled = bool.Parse(Enabled);
                                br = ber;
                            }
                            else if (type == typeof(CE.Domain.Rule.RegexRule))
                            {
                                rr = new CE.Domain.Rule.RegexRule(RegexExp);
                                rr.Id = int.Parse(Id);
                                rr.Name = Name;
                                rr.RuleNo = int.Parse(RuleNo);
                                rr.PreAppenddBefore = PreAppenddBefore;
                                rr.AppendAfter = AppendAfter;
                                rr.Enabled = bool.Parse(Enabled);
                                br = rr;
                            }
                            else
                            {
                                br = new CE.Domain.Rule.BaseRule();
                            }
                            brlist.Add(br);
                        }
                        #endregion
                        rset.Rules = brlist;
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

        public List<CE.Domain.Rule.BaseRule> brlist { get; set; }

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

        //public void PersisteceRule(CE.Domain.Rule.RuleAssembly ruelassembly)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
