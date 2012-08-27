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

            string rawContent =@"<p class=""tkType"">
													ddsn class=""tkSpan"" style=""cursor: default"" id=""se_title_1"">
														<span>鼎湖峰</span>
													</span>
												</p>
													<span fan=""2"" class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""2"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">¥</span>2</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">¥60</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">¥</span>48</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(2851,1381);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
										";
            Assert.AreEqual("鼎湖峰$#$60$#$48$#$",
                new RegexRule(@"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*""parGd"">.(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>").FilterUsingRule(ref rawContent));
           // new RegexRule(@"id=""se_title_\d+""\>\r*\s+\<span\>(?<t_name>.*?)\</span\>").FilterUsingRule(ref rawContent));
            /*
             name: id=""se_title_1"">\s*<span>(?<t_name>.*?)</span>
             */
        }

      
    }
}
