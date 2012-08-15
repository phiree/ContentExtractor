using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CE.Model;
using CE.Model.Rule;
namespace TddTest.TestData
{
  public  class RuleData
    {
      public const string TestRawContent=
@"
<html>
<div id=""jqlast_maincontent"" class=""jqlast_main_title"">
    <h1>
        仙都风景名胜区</h1>
        	        <span class=""grade"">AAAA</span>
        		<span onmouseover=""show_dk(event,this)"" onmouseout=""hide_dk()"" class=""cosPicLast s_dpjj_img""></span>
		<div class=""thDiv"">
			                                                  <div class=""thDiv"">
                    <span id=""checkGuid_0_0"" class=""checkGuid yanKer"">
                        <div class=""nopicYk none"" style=""display: none; "">
                            <span class=""nopicYk_head""></span>
                            <div class=""nopicYk_mit"">
                                                                    <p class=""nopicYk_p"">该景区已参加验客大赛，赶快写博客、打擂台，赢万元轿车吧！
                                        <a href=""http://www.17u.com/special/yanke/"" target=""_blank"" title=""什么是验客大赛？"" rel=""nofollow"">(什么是验客大赛?)</a>
                                    </p>
                                                            </div>
                        </div>
                    </span>
                </div>
                                                                		</div>
</div>

<html>
";
      public const string RawContent_Exclude = "needcontent<div>exclude</div>-endof<span>include</span>";
        public static BaseRule BuildRuleSimple()
        {
            BeginEndRule rule = new BeginEndRule();
            rule.BeginMark = @"<div id=""jqlast_maincontent"" class=""jqlast_main_title"">
    <h1>
        ";
            rule.EndMark = @"</h1>";
            return rule;
        }
        public static BaseRule BuildRuleIncludeBegin()
        {
            BeginEndRule rule = new BeginEndRule();
            rule.BeginMark = @"<div id=""jqlast_maincontent"" class=""jqlast_main_title"">
    <h1>
        ";
            rule.EndMark = @"</h1>";
            return rule;
        }
        public static BaseRule BuildRuleExcludeContent()
        {
            BeginEndRule rule = new BeginEndRule();
            rule.BeginMark = "<div>";
            rule.EndMark = "</div>";
            rule.IncludeBeginMark = rule.IncludeEndMark = true;
            rule.IsExcludeContent = true;
            return rule;
        }

        public static RuleSet BuildRuleSet()
        {
            RuleSet ruleset = new RuleSet();

            return ruleset;
        }
    }
}
