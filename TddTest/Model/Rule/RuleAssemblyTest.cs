using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using CE.Domain.Rule;

namespace TddTest.Model.Rule
{
    [TestFixture]
    public class RuleAssemblyTest
    {
        //[Test]
        //public void FilterUsingRuleSetTest()
        //{
        //    //两个条件
        //    BaseRule rule1 = new BeginEndRule("<div id=dv1>", "</div>", true, true, true, true);
        //    rule1.RuleNo = 10;
        //    BaseRule rule2 = new BeginEndRule("<span id=sp1>", "</span>", true, true, true, true);
        //    rule2.RuleNo = 11;
        //    RuleSet ruleset = new RuleSet();
        //    ruleset.Rules.Add(rule1);
        //    ruleset.Rules.Add(rule2);
        //    ruleset.Code = "Pro1";


        //    //第二个set
        //    BaseRule rule3 = new BeginEndRule("<div id=dv2>", "</div>", true, true, true, true);
        //    rule3.RuleNo = 10;
        //    BaseRule rule4 = new BeginEndRule("<span id=sp2>", "</span>", true, true, true, true);
        //    rule4.RuleNo = 11;
        //    RuleSet ruleset2 = new RuleSet();
        //    ruleset2.Code = "Pro2";

        //    ruleset2.Rules.Add(rule3);
        //    ruleset2.Rules.Add(rule4);

        //    RuleAssembly assm = new RuleAssembly();
        //    assm.CodeName = "Ass";
        //    ruleset.SetNo = 10;
        //    ruleset2.SetNo = 11;
        //    assm.RuleSets.Add(ruleset);
        //    assm.RuleSets.Add(ruleset2);


        //    Assert.AreEqual("<div id=dv1>a</div><span id=sp1>b</span>,<div id=dv2>div2</div><span id=sp2>span2</span>", assm.FilterUsingAssembly(
        //        @"1<div id=dv1>a</div>2<span id=sp1>b</span>nodeed<div id=dv2>div2</div><span id=sp2>span2</span>"
        //        , false));

        //    //输出为json格式
        //    Assert.AreEqual(@"{Pro1:""<div id=dv1>a</div><span id=sp1>b</span>"",Pro2:""<div id=dv2>div2</div><span id=sp2>span2</span>""}", assm.FilterUsingAssembly(
        //       @"1<div id=dv1>a</div>2<span id=sp1>b</span>nodeed<div id=dv2>div2</div><span id=sp2>span2</span>"
        //       , true));
        //}

        [Test]
        public void FilterUsingRuleSetTestReal()
        {
            #region 测试内容
            string content = "<div id=\"portal-block-445000270656\" class=\"udiyblock\" type=\"CommonSource\"> <div id=\"jqlast_maincontent\" class=\"jqlast_main_title\">"
                                        + "<h1>仙都风景名胜区</h1><span class=\"grade\">AAAA</span><span onmouseover=\"show_dk(event,this)\" onmouseout=\"hide_dk()\" class=\"cosPicLast s_dpjj_img\"></span><div class=\"thDiv\"><div class=\"thDiv\">"
                                        + "<span id=\"checkGuid_0_0\" class=\"checkGuid yanKer\">"
                                        + "<div class=\"nopicYk none\" style=\"display: none; \">"
                                        + "<span class=\"nopicYk_head\"></span>"
                                        + "<div class=\"nopicYk_mit\">"
                                        + "<p class=\"nopicYk_p\">该景区已参加验客大赛，赶快写博客、打擂台，赢万元轿车吧！"
                                        + "<a href=\"http://www.17u.com/special/yanke/\" target=\"_blank\" title=\"什么是验客大赛？\" rel=\"nofollow\">(什么是验客大赛?)</a>"
                                        + "</p></div></div></span></div></div></div><span class=\"list_sale\" id=\"last_sale\" style=\"display: block; \"><span id=\"last_sale_t\">8分钟</span>前有人预订了该景点</span></div>";
            
            string content2="<!-- 右侧导航 end  -->"
			+"<!--标签、幻灯片、点评滚动 start -->"
			+"<div class=\"jqlast_main\">"
                +"<!--标签start -->"
                +"<div class=\"udiy\" id=\"udiy-tag\"><div id=\"portal-frame-16753065536\"  class=\"udiyframe frame-1\" ><div id=\"portal-frame-16753065536-left\" class=\"udiycolumn frame-1-c\"><div id=\"portal-block-445000270656\" class=\"udiyblock\"  type=\"CommonSource\"> <div id=\"jqlast_maincontent\" class=\"jqlast_main_title\">"
    +"<h1>"
        +"仙都风景名胜区</h1>"
        	        +"<span class=\"grade\">AAAA</span>"
        		+"<span onmouseover=\"show_dk(event,this)\" onmouseout=\"hide_dk()\" class=\"cosPicLast s_dpjj_img\"></span>"
		+"<div class=\"thDiv\">"
			+"                                                  <div class=\"thDiv\">"
             +"       <span id=\"checkGuid_0_0\" class=\"checkGuid yanKer\">"
               +"         <div class=\"nopicYk none\" style=\"display: none; \">"
                +"            <span class=\"nopicYk_head\"></span>"
                 +"           <div class=\"nopicYk_mit\">"
                    +"                                                <p class=\"nopicYk_p\">该景区已参加验客大赛，赶快写博客、打擂台，赢万元轿车吧！"
                 +"                       <a href=\"http://www.17u.com/special/yanke/\" target=\"_blank\" title=\"什么是验客大赛？\" rel=\"nofollow\">(什么是验客大赛?)</a>"
                 +"                   </p>"
                             +"                               </div>"
                        +"</div>"
                 +"   </span>"
               +" </div>"
                +"                                                		</div>"
+"</div>"
+"<span class=\"list_sale\" id=\"last_sale\" style=\"display: none\">"
	+"<span id=\"last_sale_t\"></span>前有人预订了该景点                "
+"</span></div></div><div class=\"udiyclr\"></div></div></div>"
         +"       <!--标签end -->                "
          +"      <div class=\"jqlat_slide\">"
          +"          <div class=\"slideBox\">";

            string content3 = content2+@"<div class=""leftside column_750"">
		<div class=""mCBag mb10"">
			<div class=""bigName"">
				<div class=""Name"">
					<h1>仙都风景名胜区</h1>
					<span class=""orange02"">AAAA</span>
				</div>
				<div class=""moreInf"">
					<span class=""misp2"">景点地址：浙江省丽水市缙云县境内
</span>
							<a href=""#traffic"" title=""仙都风景名胜区地图"">查看地图</a>
				</div>
			</div>
			<div class=""bigPrice"">
				<span class=""moneyfh"">¥</span>
				<span class=""hmMoney"">78</span>
			</div>
		</div>
			<div class=""picChange mb10"" id=""oDiv"">
				<ul class=""oUl"">
							<li><img alt="""" src=""http://ustatic.17u.cn/uploadfile/scenerypic_17u/448_228/2012/05/03/2/2012050311280766585.jpg""></li>
							<li><img alt="""" src=""http://ustatic.17u.cn/uploadfile/scenerypic_17u/448_228/2012/05/03/2/2012050311275654637.jpg""></li>
							<li><img alt="""" src=""http://ustatic.17u.cn/uploadfile/scenerypic_17u/448_228/2012/05/03/2/2012050311274649748.jpg""></li>
							<li><img alt="""" src=""http://ustatic.17u.cn/uploadfile/scenerypic_17u/448_228/2012/05/03/2/2012050311273583641.jpg""></li>
							<li><img alt="""" src=""http://ustatic.17u.cn/uploadfile/scenerypic_17u/448_228/2012/03/27/2/2012032715463598616.jpg""></li>
				</ul>
				<div class=""imgBag"" style=""opacity: 1; "">
					<img alt="""" src=""http://ustatic.17u.cn/uploadfile/scenerypic_17u/448_228/2012/05/03/2/2012050311280766585.jpg"">
				</div>
				<div class=""oUl_over"" style=""top: -1px; "">
				</div>
			</div>
		<ul class=""mainHeader"">
			<li class=""hot_at""><a>景点门票</a></li>
			<li class=""""><a href=""#jieshao"">景点介绍</a></li>
			<li class=""""><a href=""#traffic"">交通指南</a></li>
			<li class=""""><a href=""#experience"">实地体验</a></li>
		</ul>
		<!--样式 -->
		<div class=""line2 mb10"">
		</div>
			<div id=""menpiao"" class=""mb15"">
				<div class="""" id=""api"">
					<table cellspacing=""0"" cellpadding=""0"" border=""0"" class=""priceTAR"" id=""scenceList_0"">
						<tbody>
							<tr>
								<th width=""350"">
									门票类型
								</th>
								<th width=""80"">
									票面价格
								</th>
								<th width=""80"">
									同程价格
								</th>
								<th width=""80"" style=""text-align:left;"">
									支付方式
								</th>
								<th width=""80"">&nbsp;
								</th>
							</tr>
									<tr class=""mp_type"">
										<td colspan=""5"">
										<div class=""st_bod"">特价票</div>
										</td>
									</tr>
										<tr class=""listTr"">
											<td>
												<p class=""tkType"">
													<span class=""tkSpan"" style=""cursor: default"" id=""se_title_0"">
														<a title=""★9月特惠月★联票"" href=""javaScript:void(0)"">★9月特惠月★联票</a><a class=""jq_infoicon"" href=""javascript:void(0);""></a>
													</span>
												</p>
													<span fan=""1"" class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""1"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">¥</span>1</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">¥130</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">¥</span>78</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(2851,19638);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
											<tr id=""se_read_0"" class=""none"">
												<td colspan=""5"">
													<div class=""attractionsExp"">
														<p>仙都★9月特惠月★联票，6折优惠；有效期：8月25日-9月30日；
包含景点：鼎湖峰、小赤壁、芙蓉峡、赵侯祠、倪翁洞、朱潭山 。</p>
													</div>
													<div class=""hdbox"">
														<span id=""hidden_hear_0"" class=""hidden_bg""><a class=""hdw"" href=""javascript:void(0);"">
															隐藏</a></span></div>
												</td>
											</tr>
									<tr class=""mp_type"">
										<td colspan=""5"">
										<div class=""st_bod"">成人票</div>
										</td>
									</tr>
										<tr class=""listTr"">
											<td>
												<p class=""tkType"">
													<span class=""tkSpan"" style=""cursor: default"" id=""se_title_5"">
														<span>倪翁洞</span>
													</span>
												</p>
													<span fan=""1"" class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""1"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">¥</span>1</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">¥10</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">¥</span>8</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(2851,2002);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
										
										<tr class=""listTr"">
											<td>
												<p class=""tkType"">
													<span class=""tkSpan"" style=""cursor: default"" id=""se_title_7"">
														<span>套票</span>
													</span>
												</p>
													<span fan=""4"" class=""xjq_new"" _left=""420"" _top=""581"" _width=""115"" _height=""22"">
														<s fxprice=""4"" danbaotype=""0"" class=""return"">
															<span class=""return_tt clearfix""></span><span class=""return_ct""><span class=""nob"">¥</span>4</span>
														</s>
													</span>
											</td>
											<td class=""sp_price"">
												<span class=""parGd"">¥130</span>
											</td>
											<td>
												<dl class=""saveMne"">
													<dt><span class=""Mne"">¥</span>104</dt>
												</dl>
											</td>
											<td>
												<span id=""onlinepay_0_0"">景区支付</span>
											</td>
											<td>
												<a title=""预订"" href=""javascript:void(0)"" onclick=""GetOrderUrl(2851,10381);return false;"" class=""yd_butm"" rel=""nofollow"">
													预&nbsp;订</a>
											</td>
										</tr>
						</tbody>
					</table>
					<div style=""display: block;"" id=""zhifu"" class=""jq_zhifu"">
						<span class=""zhifu_jiantou""></span>
						<p>
<span>景区支付：<font>无需提前在线付款</font>，订单提交成功后，游玩时到景区售票窗口付款取票游玩，出游安排更自由、轻松。</span>						</p>
					</div>
				</div>
</div>
				<div class=""point_intro"" id=""xuzhi"">
					<div class=""title"">
						<h2 class=""title_sp_01"">仙都风景名胜区购票须知</h2>
					</div>
					<div class=""bd"">
						<div class=""yd_info"">
							<h3>预订限制</h3>
							<div class=""info_p"">
								<span class=""num"">1.</span>
								<div class=""p_so"">
									为了能成功提交订单，您需在游玩当天12:30前预订
								</div>
							</div>
						</div>
									<div class=""yd_info mtop"">
										<h3>仙都风景名胜区预订说明</h3>
										<div class=""info_p"">
												<span class=""num"">1</span>
												<div class=""p_so"">
													<span class=""info_tit"">开放时间：</span>
													<span class=""info_content""><p>
	7：00~17：30&nbsp;</p>
</span>
												</div>
												<span class=""num"">2</span>
												<div class=""p_so"">
													<span class=""info_tit"">取票地点：</span>
													<span class=""info_content""><p>
	鼎湖峰取票点</p>
</span>
												</div>
												<span class=""num"">3</span>
												<div class=""p_so"">
													<span class=""info_tit"">入园凭证：</span>
													<span class=""info_content""><p>
	同程网预订成功确认订单短信</p>
</span>
												</div>
												<span class=""num"">4</span>
												<div class=""p_so"">
													<span class=""info_tit"">特殊人群：</span>
													<span class=""info_content""><p>
 A.免费政策：儿童身高1.2米以下免费 ，军官证凭证免费<br>
 B.优惠政策： 儿童身高1.2-1.4米半价。学生票凭证半价，老年人60-70周岁半价，70岁以上浙江省内免费省外半票<br>
 其他优惠以景区公布为准。<br>
 请到景区自行购买。<br>
 &nbsp;</p>
</span>
												</div>
												<span class=""num"">5</span>
												<div class=""p_so"">
													<span class=""info_tit"">发票说明：</span>
													<span class=""info_content""><p>
	网络预订景区门票，同程网不提供发票</p>
</span>
												</div>
												<span class=""num"">6</span>
												<div class=""p_so"">
													<span class=""info_tit"">温馨提示：</span>
													<span class=""info_content""><p>
	&nbsp;</p>
<p align=""left"">
	套票包含仙都里面的六个景点门票（三天内门票有效）</p>
</span>
												</div>
												<span class=""num"">7</span>
												<div class=""p_so"">
													<span class=""info_tit"">退改规则：</span>
													<span class=""info_content""><p>
	暂无</p>
</span>
												</div>
										</div>
									</div>
					 </div>
				</div>
<div class=""point_intro"" id=""jieshao"">
	<div class=""title"">
		<h2 class=""title_sp_01"">仙都风景名胜区介绍</h2>
	</div>
	<div class=""intro_content"" id=""sp_intro"">
	<h4 class=""intro_head"">去<font size=""+0"">仙都风景名胜区</font>的N大理由</h4><!-- 简介模块头部 -->
<ul class=""reason_ul""><!-- 理由无序列表 -->
<li><span>理由1</span> 
<p>由于仙都风光秀丽，建国以来，上海、长春、北京、浙江等电影制片厂，在此拍摄了《凤凰之歌》、《摩雅傣》、《阿诗玛》、《连心坝》、《 漂泊奇遇》、《八仙的传说》等二十多部家喻户晓的影片。</p>
</li><li><span>理由2</span> 
<p>皇都归客看仙都,缙云县仙都是一处以峰岩奇绝、山水神秀为景观特色，融田园风光为一体，以观光、度假为主的国家级风景名胜区。</p>
</li><li><span>理由3</span> 
<p>仙都，古称缙云山。道教典籍称仙都为玄都祈仙洞天，属三十六小洞天之第二十九</p>
</li><li><span>理由4</span> 
<p>以观光、避暑休闲和开展科学文化活动为一体的国家AAAA级重点风景名胜区。</p>
</li><li><span>理由5</span> 
<p>仙都乃是文人墨客聚集之处，遗留下来历史悠久的璀璨文化。</p>
</li><li><span>理由6</span> 
<p>仙都源于玄宗皇帝的“这是仙人荟萃之都也！</p></li></ul>
<h4 class=""intro_head"">同程驴友这样评价<font size=""+0"">仙都风景名胜区</font></h4>
<div class=""assess_div""><!-- 评论 -->
<dl class=""assess"">
<dd>不愧是仙都胜境，有时候都让人恍惚间以为是在桂林！我们浙江的山山水水都是那样的秀丽迷人，冬天都已是那么美了，春天还不知会美成什 么 样子呢！无限憧憬 ....... 
</dd><dt>— — 13814urzist</dt></dl>
<dl class=""assess"">
<dd>风景区非常好，景点售票人态度很好，感觉这次游玩非常愉快！推荐鼎湖峰，不愧为仙都第一景，大概需要半天时间！ 
</dd><dt>— — 15325pmeafa </dt></dl>
<dl class=""assess"">
<dd>景区风景确实很美，不愧叫仙都啊，虽然下着雨，我还摔了一跤，但还是留下了很好的印象。 
</dd><dt>— —lintea</dt></dl>
<dl class=""assess"">
<dd>仙人汇集，都曰胜境，风和水青，景色秀丽，美不胜收！ 
</dd><dt>— — 13735buzvlh
</dt></dl></div>
<h4 class=""intro_head""><font size=""+0"">仙都风景名胜区</font>详情</h4>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>景区简介</span>仙都风景名胜区 
</dt><dd><!-- 景区介绍 -->
<p>仙都，位于浙江省丽水市缙云县境内，是一处以峰岩奇绝、山水神秀为景观特色，融田园风光与人文史迹为一体，以观光、避暑休闲和开展科学 文化活动为一体的国家级重点风景名胜区；亦是一个山明水秀、景物优美、气候宜人的游览胜地。境内九曲练溪，十里画廊，山水飘逸，云雾缭绕。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544657962.jpg"" width=""726"" height=""295""> </div>
<p>仙都 ，是一处以峰岩奇绝、山水神秀为特色、融田园风光与人文史迹为一体 , 以观光、休闲、度假和科普为主的国家级重点风景名胜区、国家首 批 AAAA 级旅游区。境内九曲练溪、十里画廊；山水飘逸、云雾缭绕。有奇峰一百六、异洞二十七，有“桂林之秀、黄山之奇、华山之险”的美誉。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544714174.jpg"" width=""726"" height=""295""> </div>
<p>仙都风景名胜区由仙都、黄龙、岩门、大洋四大景区组成及鼎湖峰、倪翁洞、小赤壁、芙蓉峡、黄帝祠宇等三百多个景点组成，总面积为 166.2 平方 公里。 相传在唐天宝年间有许多缤纷彩云回旋于此山，山谷乐声震天，山林增辉。当时有刺史苗奉倩上报玄宗。玄宗听后惊叹地说：“这是仙人荟萃 之都也 ！”并亲自写下“仙都”二字。仙都盛名由此传到今天。仙都景色美在天然，奇峰异石，千姿百态；她有桂林山水之秀又有雁荡奇峰怪石之神 韵。 </p>
<p>仙都景区是仙都风景名胜区的主景区，它是由鼎湖峰、倪翁洞、芙蓉峡、小赤壁、朱潭山、赵侯祠等景点组成，占地27平方公里。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113535953799.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>游玩景点</span>鼎湖峰 
</dt><dd><!-- 景区介绍 -->
<p>鼎湖峰，东南以步虚山、仙都山为屏，西北傍练溪碧水，高170.8米，底部面积2468平方米，顶部面积710平方米，拔地而起,直刺云天,享有“天下 第一峰”、“天下第一石”、“天下第一笋”之誉。它状如春笋，故又称石笋。峰巅苍松翠柏间有一小湖泊，相传是轩辕黄帝在此炼丹时，被鼎压塌 成湖，故称鼎湖。唐代诗人白居易诗云：“黄帝旌旗去不回，片云孤石独崔嵬。有时风激鼎湖浪，散作晴天雨点来。”</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113540895541.jpg"" width=""726"" height=""295""> </div>
<p>鼎湖峰景点有：童子峰 、仰止亭、步虚山 、步虚亭 、 黄帝祠宇 、 轩辕黄帝史迹展览馆 、“鼎湖胜迹”题刻 、 仙都草堂 、 叶清臣《独峰 山铭》摩崖 、轩辕辙迹 、 沈括摩崖题刻 、 毛维蟾题刻 、 丹穴 </p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113540888724.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>游玩景点</span>小赤壁 
</dt><dd><!-- 景区介绍 -->
<p>下洋村隔溪对岸有山一线，长数里，临溪一面绝壁陡峭，高达百米；下有碧潭，深不见底。那峭壁红白相间，远远望去，犹如焰火烧过，和长江赤 壁相似，由于规模较小，故又称小赤壁。小赤壁，古称白岩，南宋文学家楼钥在《北行日录》和《游白石岩》、《游仙都及白岩》等诗文中，均有记 载。峭壁上的“小赤壁”三字，署名“印海”。明缙云樊献科有诗云“削壁入云天，凌空几岁年。石桥藏野艇，幽谷泻飞泉。涧隐诸峰合，林荫一鹤 眠。草堂归路近，明月半溪烟。”</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544993753.jpg"" width=""726"" height=""295""> </div>
<p>小赤壁景点有：姑妇岩 、天鹅孵蛋、仙剖岩 、 桑岩寨 、仙释岩 、仙榜岩 、 小蓬莱 、 八仙亭 、豹狮山 、共亭、 龙首峰、 青福寺、螺髻 峰、桑潭、周村、冷热气洞、下洋、步仙桥、龙耕路、袁枚《游仙都峰记》刻石、大组岩、雨蓑岩。 </p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544911862.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>游玩景点</span>倪翁洞 
</dt><dd><!-- 景区介绍 -->
<p>倪翁洞，位于“阳谷三窍”最北。洞高二丈，方五太。洞有两口，一为东北，二为东南，洞正中有楷书“初阳谷”三大字。《仙都志》云：“ 宋嘉泰间郡人陈百朋《括苍续志》云：‘洞正属仙都山，练溪旁。初阳谷中崖上有洞名三字，或云李阳冰篆。’”其中“初”字，缺一点，只有在清 晨第一缕阳光射进时，才可补全，持续时间极短，机遇十分难得。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544493887.jpg"" width=""726"" height=""295""> </div>
<p>倪翁，《仙都志》：“古老相传昔有倪长官隐居于此，今失其名。”北宋大文学家欧阳修称“缙云之隐者。”后人认为：“彼以此遁俗为高， 而终以无名于后世，可谓获其志矣，倪翁颇类是在传 不传 之间耶。”（今有人考查认为倪翁即倪子，范蠡之师）宋乾道间处州郡宋钱竽题仙都诗云 “初阳使是扶桑谷，洞里神仙招我来。”洞中有石孔四个，俗称天来仓，自来油。一个盛米，一个盛油，一个盛菜，一个盛水，是当年倪翁生活用具 。柴米油盐，样样齐备，而且用了自然会生。 </p>
<p>倪翁洞景点有：青塘、老鼠偷油 、玉甑岩 、 “旭山”题刻 、 云英谷、谢公岭 、独峰书院 、 初阳谷洞。 </p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113541212692.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>游玩景点</span>芙蓉峡 
</dt><dd><!-- 景区介绍 -->
<p>芙蓉峡，南距鼎湖峰三公里。好溪水从胪膛、东方、靖岳奔流而来，经胡截地，过截脉岭，入石壁潭，就进入仙都的北大门－－芙蓉峡。此处 ，东有马鞍山高踞云空之上，山的沟壑如龙蛇，逶迤而下，那沐白、上章、梅宅的农舍，散落其间，烟村暮树、仪态万方，是人间又一处桃花源。好 溪西畔，山崖临水，□□嵯峨，延绵数百米，远远望去，如万朵芙蓉浮水而开。相传东海八仙从西王母蟠桃会回来，见此处紫芝从生，一起按下去头 ，入山采摘。那性急的兰采和不小心将何仙姑的花蓝撞翻。芙蓉散落一地，吸水而化成，故称芙蓉峡。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113540945229.jpg"" width=""726"" height=""295""> </div>
<p>芙蓉峡，三面围抱，一谷出口。中心低凹成洞天，相传是仙人僻五谷茹草的地方，故称紫芝坞。坞：土堡，小城和四周高，中间低的谷地之意 。坞外峡谷长数百米，最窄处仅容一人过往，大有一夫当关，万夫莫开之势。从谷口往里看，这山壁像钢铁铸成的城墙，故芙蓉峡又名铁城。影片《 阿诗玛》中，阿黑为救情人阿诗玛，跃马直奔。见前方有山岭挡道，怒发神箭，射裂山崖，接着纵马穿峡而过的镜头，即摄于此。明李永明有诗云： “乱削芙蓉傍水开，碧潭钓艇日徘徊。花迷谷口连环迥，雁落峰头卓锡嵬。题石令公传铁峡，茹芝仙客吊荒石。好溪更有千秋月，曾照青莲作赋才。 ” </p>
<p>芙蓉峡景点有：紫芝坞、铁门峡 、 螺丝岩 、 “铁城”摩崖题刻 、仙掌岩 、 孔雀岩 、碌碡岙、石壁潭、截脉岭。 </p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113541091360.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>游玩景点</span>赵侯祠 
</dt><dd><!-- 景区介绍 -->
<p>赵侯祠又叫赵侯庙，又名乌伤侯庙，是仙都最古老的庙宇之一。这里供奉的是汉代人赵炳，他精通法术，为百姓治病，救了许多人。为了纪念 他，百姓在此给他建了祠堂。旁边的神医洞内还供奉自古到今八位神医的石像，是祁求全家平安、健康、幸福的地方。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113545069119.jpg"" width=""726"" height=""295""> </div>
<p>景点内的山谷堆放着许多硕大无比的巨石。从赵侯舟向谷内眺望，这堆石头的上部，是鸟形巨石；下部石头较小，且如鸟蛋。人们望形主义， 取名为天鹅孵蛋。进入谷中，从石下往上看，蛋石均已开裂，似乎刚被刀剑所剖，称为仙剖岩或剖瓜石。电影《两个巡逻兵》、《摩雅傣》、《连心 坝》、《莲花童子哪吒》等影片，均在此拍过外景。 </p>
<p>赵侯祠景点位于仙都景区东侧，由赵侯祠、神农洞、招隐洞、青龙岩、天鹅孵蛋、仙剖岩、赵侯舟等景观组成。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113545038547.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>游玩景点</span>朱潭山 
</dt><dd><!-- 景区介绍 -->
<p>朱潭山位于仙都景区。主要景点有仙堤、晦翁阁、九龙壁、超然亭。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113545139719.jpg"" width=""726"" height=""295""> </div>
<p>进入景点位于两桥之间的长堤，叫做仙堤。仙堤两边杨柳婆娑，用卵石铺成的长堤既浪漫又多情，是当地恋人拍摄婚纱照的首选之地，并且知名度 越来越高，吸引了丽水、金华、武义邻近县市成千上万对新人纷纷沓至。建国以后，成为中央、省、地方领导和游人留影的必到之处。这里也曾是《 阿诗玛》、《绝代双骄》 、 《天龙八部》 、 《汉武大帝》等数十部影视剧的拍摄基地。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544677243.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>关注内容</span>祭祀黄帝典礼 
</dt><dd><!-- 景区介绍 -->
<p>仙都鼎湖峰是黄帝炼丹觞百神飞升之地，黄帝祠宇是我国南方祭祀黄帝的重要场所，与陕西黄陵遥相呼应，形成“北陵南祠”缅怀先祖的格局。每年在清明节和重阳节分别举行民祭和公祭黄帝典礼。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113541028458.jpg"" width=""726"" height=""295""> </div>
<p>祭祀活动采用“禘礼”(古代最高的礼祭)的规格，以传统与现代、礼与乐相结合的方式进行，期 间将开展各种竞技活动、民间文艺表演和仙都文化交流等活动。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/20128211354473342.jpg"" width=""726"" height=""295""> </div></dd></dl>
<h4 class=""intro_head""><font size=""+0"">仙都风景名胜区</font>旅游推荐</h4>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>仙都风景名胜区旅游</span>遂昌金矿国家矿山公园 
</dt><dd><!-- 景区介绍 -->
<p>“江南第一矿”遂昌金矿既有古代开矿留下的黄岩坑古矿洞、永丰银场、太监府等遗址，又有现代化冶金的高科技流水线，年产黄金3万两。矿山 四周风景宜人，矿洞内部冬暖夏凉。在这里，可以参观现代黄金生产线、可以进行古矿洞探险、更可以做一回矿工，园一个真正的黄金梦。现代遂昌 金矿建于1976年，是一个集黄金采、选、冶及黄金深加工，铅锌矿、硫铁矿、萤石矿采选、精密铸造，房地产及旅游业于一体的国有独资中型企业， 隶属于杭州钢铁集团公司。是上海黄金交易所在108家会员单位之一，总资产1.6亿元。主要产品有：标准金锭、银锭、金盐、小金条、金银摆件、精 密铸件等产品。矿区景色优美，气候宜人，曾被誉为“花园式矿山”、“江南第一金矿”，并被列入市爱国主义教育基地。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113544460512.jpg"" width=""726"" height=""295""> </div>
<dl class=""intro_information""><!-- 简介信息 -->
<dt><span>仙都风景名胜区旅游</span>南尖岩 
</dt><dd><!-- 景区介绍 -->
<p>南尖岩景区是遂昌主要旅游资源集聚区之一。主要由天柱峰、神坛峰、千丈岩、小石林、神龟探海等多处奇峰异石构成的地貌景观；霞归瑶池、九 级瀑布、龙门飞瀑等构成的水体景观；竹海、林海、针阔混交林、古松为主的植物160多科，动物1100多种构成的生物景观；景区海拔1100-1626米， 最高气温不超过35℃，空气清新，富含负氧离子，全年平均有。雾日约 200 天，形成了奇独的云海、日落、长虹、雪景、雾淞、冰挂等天象景观；景 区独特的地型地貌，经历代勤劳的人民耕耘，造就了近2000亩高山梯田景观。景区所在地石笋头村民居土木建筑独特，民风纯朴，乡土气息浓郁，当 年粟裕将军率领红军还曾在这里开展过游击战争，是遂昌县的红色根据地之一，文化积淀深厚。</p>
<div><img style=""FILTER: ; WIDTH: 726px; HEIGHT: 295px"" title="""" border=""0"" hspace=""0"" alt="""" src=""http://upload.17u.com/uploadfile/2012/08/21/6/201282113541192239.jpg"" width=""726"" height=""295""> </div></dd></dl>
<dl class=""intro_information""><!-- 简介信息 --></dl>
<h4 class=""intro_head""><font size=""+0"">仙都风景名胜区</font>温馨提示</h4>
<ul class=""list_square"">
<li>为保证游览质量，住宿游客自备车辆请停在宾馆停车场，禁止在景区内任意行驶。 
</li><li>文明游览，爱护景区生态环境、旅游设施等公共资源。 
</li><li>夏季紫外线照射较强，注意防晒，带好防晒保湿用品。 
</li><li>注意安全，不在设有危险标志和安全警示牌的区域游览。 
</li><li>套票包含仙都里面的六个景点门票（三天内门票有效） </li></ul></dd></dl>
	</div>
</div>
<div id=""traffic"" class=""traffic"">
	<div class=""title"" id=""jiaotong"">
		<h2 class=""title_sp_01"">仙都风景名胜区交通指南</h2>
	</div>
	<div class=""traffic_content"">
			<!--地图-->
			<div id=""electronMap"" class=""mapBox"">
				<iframe frameborder=""0"" scrolling=""no"" src=""http://www.17u.cn/scenery/scenerymapforlist.aspx?sceneryid=2851&amp;pagetype=1"" width=""738"" height=""344""></iframe>
				<!-- css中设定了固定宽高 -->
			</div>
		<div class=""drive_way"">从上海到浙江仙都可坐火车到缙云火车站。出站走近二百米到三叉路口，向右转是去县城，一直往下是往鼎湖峰。在此地可乘过路车到鼎湖峰，不用到县城。出站后也可直接雇面包车(20元)到鼎湖峰。 　　 到鼎湖峰方向的车很多，十几分钟就有一辆。也可乘到壶镇的车，但在鼎湖峰前面的岔路口就要下车，往里还要走一段路。所以最好乘到铁城(芙蓉峡)的中巴，先到铁城或先到鼎湖峰下车均可。到铁城是三块半，到鼎湖峰二块。在景区可花40元左右(淡季价)包一辆残疾车一天，然后就可以随心所欲地玩了。晚上可乘火车离开，下午5：30，7：30，9：30都有火车。地的治安也不错。</div>
	</div>
</div>
		<div id=""experience"" class=""experience"">
			<div class=""title"" id=""yanke"">
				<h2 class=""title_sp_01"">仙都风景名胜区实地体验</h2>
			</div> 
			<div class=""info_yanke"">
					<div class=""ykArticle"">
						<div class=""ykArticle_r"">
							<h3>
								<a href=""http://www.17u.com/blog/article/672101.html"" title=""【验客】缙云仙都：小赤壁"" target=""_blank"">【验客】缙云仙都：小赤壁</a>
								<p class=""yk_bonus"">
									<span class=""yk_bonusSp01"">¥<span class=""cl_bold"">100</span></span><span class=""yk_bonusSp02""></span>
								</p>
								<span class=""yk_publish"">15958ijycaw发表</span>
							</h3>
							<p class=""ykArticle_p02"">
								  
离开了朱潭山，等了十几分钟的仙都旅游公交车，前往我此行的第4个要去的景点小赤壁。
从朱潭山坐仙都旅游公交车到小赤壁是1.50元。
不久我就到了小赤壁的入口，但是小赤壁景区的入口并没有任何标志和明显指示。
而是写着仙都度假村。 
我问售票员小赤壁从哪里进去……
								<span class=""yk_more"">
									<a href=""http://www.17u.com/blog/article/628720.html"" target=""_blank"" title=""【验客】【验客】常州行:中华恐龙园"">[详情]</a>
								</span>
							</p>
						</div>
							<div class=""ykArticle_d"">
								<div class=""rollBox"">
									<div class=""leftButton"" id=""leftButton_0""></div>
									<div class=""Cont"" id=""ISL_Cont_0"">
										<div class=""ScrCont"">
											<div id=""List1_0"" class=""ykList"">
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110151750758.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110151815324.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110151848647.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110151937536.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152047647.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152061860.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152115314.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152250758.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152314313.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152547647.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152537546.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152671070.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152714313.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110152771071.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110160282181.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110151682182.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110160150768.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110160361860.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110160515324.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110160061870.jpg""></div>
												<div><img alt="""" src=""http://upload.17u.com/uploadfile/2011/06/01/6/20116110160647646.jpg""></div>
											</div>
										</div>
									</div>
									<div class=""rightButton"" style=""display: block; "" id=""rightButton_0""></div>
								</div>
							</div>
					</div>
			</div>
		</div>
<div class=""commend"">
		<div class=""title"" id=""dianping"">
			<h2 class=""title_sp_01"">仙都风景名胜区门票预订点评</h2>
		</div>
		<div class=""commend_content"">
			<ul class=""new_ul"">
				<li rel=""0"" class=""hover_at"" onclick=""sort(0)"">全部点评(849)</li>
				<li rel=""1"" onclick=""sort(1)"">好评(755)</li>
				<li rel=""2"" onclick=""sort(2)"">中评(91)</li>
				<li rel=""3"" onclick=""sort(3)"">差评(3)</li>
			</ul>
			<div class=""list"" id=""commentlist"">
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">15268gvuaij</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">中评</li>
									<li class=""sj"">发表时间：2012.07.30</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>订票还是比较方便。短信也能快速传到。</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>每个景区较分散。若没有自驾车，想全部完遍需两日行程。售票员态度不错。能给人建议行程的安排不浪费时间及金钱。</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">13735lcooyv</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">好评</li>
									<li class=""sj"">发表时间：2012.07.12</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>很不错的服务，工作人员很热情</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>很方便取票，价格也比普通的优惠，不错不错！</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">13735lcooyv</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">好评</li>
									<li class=""sj"">发表时间：2012.07.12</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>服务很不错，工作人员很耐心！</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>很方便取票，价格也比普通的优惠，不错不错！</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">坯子权</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">中评</li>
									<li class=""sj"">发表时间：2012.07.07</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>对于同程网的订票这一块，我还是很满意的，就是这个景区的实际情况，希望可以真实性！</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>芙蓉峡，一开始以为和鼎湖峰一样，是个山清水秀的地方，到了才知道，就是个小山村，无语死了。。。售票点都没有建好，都没有什么设施，觉得这个门票有点上当的感觉，强烈建议同程网的工作人员，是不是可以实地去考察一下，在描述景区！</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">坯子权</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">好评</li>
									<li class=""sj"">发表时间：2012.07.07</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>同程网，自从发现这个网址，我就一直在上面订票，方便，不过有一点我需要提出来，有些景区根本不符合上面的描述，让我们很困扰！</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>鼎湖峰的景点确实不错，有山有水，因为本人喜欢摄影，所以。。。是个值得一去的地方！里面的那个什么黄帝祭祀，太商业化了，不过这是中国大部分景区的通病！</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">皱纹</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">好评</li>
									<li class=""sj"">发表时间：2012.07.06</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>在同程订票，方便快捷又实惠，以后旅游还是会选择同程网订票订房的。</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>整个景区空气清新，特别是鼎湖峰景区，奇石矗立，值得一游。。</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">13788nswkzg</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">中评</li>
									<li class=""sj"">发表时间：2012.07.05</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>同程网服务很好 信息更新很及时</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>景色一般 不如南尖岩好 只去了鼎湖峰和芙蓉峡 没多大意思</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">13788nswkzg</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">中评</li>
									<li class=""sj"">发表时间：2012.07.05</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>同程网服务很好 信息更新很及时</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>景色一般 芙蓉峡没什么好去的 鼎湖峰还是可以看一下 爬个小山</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">15901lqxgkm</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">中评</li>
									<li class=""sj"">发表时间：2012.07.03</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>预定比较方便，最好能预定当天的门票就更方便、更好了。</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>景区感觉还算不错，仙都的风景还算不错。值得一去。</dd>
								</dl>
						</div>
						<div class=""list_commend"">
								<ul class=""con1"">
									<li class=""tit"">同程会员：</li>
									<li class=""yh"">13957jzxuke</li>
									<li class=""fj"">仙都风景名胜区</li>
									<li class=""pj"">差评</li>
									<li class=""sj"">发表时间：2012.06.30</li>
								</ul>
								<dl class=""con2"">
									<dt>点评同程：</dt><dd>取票比较方便,而且价格也实惠,非常满意.</dd>
								</dl>
								<dl class=""con2"">
									<dt>点评景区：</dt><dd>景区大门足足找了半个小时,景点也不怎么好.</dd>
								</dl>
						</div>
			</div>
			<!--分页-->
			<div class=""page"">
			</div>
			<div id=""pageNum_title"" class=""pager""><span class=""page_num"">共85页</span><div class=""page_link""><span class=""first_page01 border_gray"">首页</span><span class=""previous_page01 border_gray"">上一页</span><span class=""on_page border_gray"">1</span><a class=""choose_page border_gray"" href=""javascript:void(0)"">2</a><span class=""more_page"">...</span><a class=""choose_page border_gray"" href=""javascript:void(0)"">84</a><a class=""choose_page border_gray"" href=""javascript:void(0)"">85</a><a class=""next_page02 border_gray"" href=""javascript:void(0)"">下一页</a><a class=""last_page02 border_gray"" href=""javascript:void(0)"" pagenum=""85"">末页</a></div></div>
		</div>
	</div>
</div>";
            #endregion

            #region 模拟2个ruleset

            //两个条件
            BaseRule rule1 = new BeginEndRule("<div id=\"jqlast_maincontent\" class=\"jqlast_main_title\"><h1>", "</h1>", false, false, true, true);
            rule1.RuleNo = 10;
            rule1.Name = "标题rule";
            RuleSet ruleset = new RuleSet();
            ruleset.Name = "标题";
            ruleset.Rules.Add(rule1);
            ruleset.Code = "title";

            //第二个set
            BaseRule rule2 = new BeginEndRule("<span class=\"grade\">", "</span>", false, false, true, true);
            rule2.RuleNo = 10;
            rule2.Name = "等级rule";
            RuleSet ruleset2 = new RuleSet();
            ruleset2.Name = "等级";
            ruleset2.Code = "level";
            ruleset2.Rules.Add(rule2);

            //第三个set
            string regexExp = @"id=""se_title_\d+"">.*?<span>(?<t_name>.*?)</span>.*?""parGd"">.?(?<t_price1>\d+)</span>.*?""Mne"">.</span>(?<price2>\d+)</dt>";
            BaseRule rule3 = new RegexRule(regexExp);
            rule3.RuleNo = 10;
            rule3.Name = "价格rule";
            RuleSet ruleset3 = new RuleSet();
            ruleset3.Name = "价格";
            ruleset3.Code = "price";
            ruleset3.Rules.Add(rule3);

            RuleAssembly assm = new RuleAssembly();
            assm.CodeName = "Ass";
            ruleset.SetNo = 10;
            ruleset2.SetNo = 11;
            ruleset3.SetNo = 12;
            assm.RuleSets.Add(ruleset);
            assm.RuleSets.Add(ruleset2);
            assm.RuleSets.Add(ruleset3);

            #endregion

            //Assert.AreEqual("仙都风景名胜区$#$AAAA$#$",
            //    assm.FilterUsingAssembly(content, false));
            //Assert.AreEqual("{title:\"仙都风景名胜区\"$#$level:\"AAAA\"$#$}",
            //    assm.FilterUsingAssembly(content, true));

            //Assert.AreEqual("仙都风景名胜区$#$AAAA$#$",
            //    assm.FilterUsingAssembly(content2, false));
            //Assert.AreEqual("{title:\"仙都风景名胜区\"$#$level:\"AAAA\"$#$}",
            //    assm.FilterUsingAssembly(content2, true));

            Assert.AreEqual("仙都风景名胜区$#$AAAA$#$倪翁洞||10||8||&&套票||130||104||&&$#$",
                assm.FilterUsingAssembly(content3, false));
            //Assert.AreEqual("{title:\"仙都风景名胜区\"$#$level:\"AAAA\"$#$}",
            //    assm.FilterUsingAssembly(content3, true));
        }

        [Test]
        public void FilterUsingRuleSetTest() { 
        
        }
    }
}
