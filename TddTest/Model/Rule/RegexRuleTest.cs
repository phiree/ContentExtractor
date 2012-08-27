using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CE.Domain.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
    public class RegexRuleTest
    {
        [Test]
        public void FilterUsingRuleTest()
        {

            string rawContent = @"	 <html><meta keywor......../>
<title>启园</title>
<p class=""tkType"">
													<span class=""tkSpan"" style=""cursor: default"" id=""se_title_10"">
														<span>清明上河图</span>
													</span>
												</p>
													<span fan=2  class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""2"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">￥</span>2</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">￥95</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">￥</span>85</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(5886,13033);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
										<tr class=""listTr"">
											<td>
												<p class=""tkType"">
													<span class=""tkSpan"" style=""cursor: default"" id=""se_title_11"">
														<span>广州/香港街</span>
													</span>
												</p>
													<span fan=2  class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""2"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">￥</span>2</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">￥95</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">￥</span>85</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(5886,13034);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
										<tr class=""listTr"">
											<td>
												<p class=""tkType"">
													<span class=""tkSpan"" style=""cursor: default"" id=""se_title_12"">
														<span>屏岩洞府</span>
													</span>
												</p>
													<span fan=2  class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""2"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">￥</span>2</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">￥80</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">￥</span>70</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(5886,13039);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
										<tr class=""listTr"">
											<td>
<span id=""jibie"">aaaa</span>
							";

            string raw1 = rawContent;
            string regexExp=@"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            Assert.AreEqual("清明上河图$#$95$#$85$#$##$##广州/香港街$#$95$#$85$#$##$##屏岩洞府$#$80$#$70$#$##$##",
                new RegexRule(regexExp).FilterUsingRule(ref raw1));
           // new RegexRule(@"id=""se_title_\d+""\>\r*\s+\<span\>(?<t_name>.*?)\</span\>").FilterUsingRule(ref rawContent));
            /*
             name: id=""se_title_1"">\s*<span>(?<t_name>.*?)</span>
             */
            string raw2 = rawContent;
            RuleSet set = new RuleSet();
            BaseRule rule1 = new RegexRule(regexExp);
            rule1.RuleNo = 10;
            BaseRule rule2 = new BeginEndRule("<title>","</title>",false,false,true,true);
            rule2.RuleNo = 9;
            set.Rules.Add(rule1);
            set.Rules.Add(rule2);

            string result=set.FilterUsingRuleSet(ref raw2, false);
            Console.Write(result);
            Assert.AreEqual("启园清明上河图$#$95$#$85$#$##$##广州/香港街$#$95$#$85$#$##$##屏岩洞府$#$80$#$70$#$##$##",
         result);
        }

      
    }
}
