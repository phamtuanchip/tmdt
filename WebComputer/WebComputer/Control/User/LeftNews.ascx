<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftNews.ascx.cs" Inherits="WebComputer.Control.User.RightNew" %>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service/Weather_Content.js"></script>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service/Weather.js"></script>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service//Gold_Content.js"></script>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service/Forex_Content.js"></script>
<table width="100%" cellspacing="0" cellpadding="0" border="0">
	<tr>
    	<td height="auto">
        	<div class="font_menu_ta">Danh mục tin tức</div>
            <div>
                <asp:TreeView ID="TreeView1" runat="server" MaxDataBindDepth="4" Width="100%" ImageSet="Arrows">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                    <LeafNodeStyle Font-Bold="True" />
                </asp:TreeView>
            </div>
        </td>
    </tr>
    <tr>
    	<td><div class="space"></div></td>
    </tr>
    <tr>
    	<td>
        	<div class="font_menu_ta">Hỗ trợ trực tuyến</div>
            <table width="100%" cellspacing="0" cellpadding="0" border="0" style="border: 1px solid #666666">
                <tr>
                	<td align="center">
                    	<a href="ymsgr:SendIM?duongnguyen2510" title="Trưởng phòng kỹ thuật">
                        <img src="http://opi.yahoo.com/online?u=duongnguyen2510&m=g&t=2&l=us" style="border: 0px; margin-top: 10px; margin-bottom: 10px" alt=""  /></a>
                    </td>                                                            
                </tr>
                <tr>
                	<td align="center">
                    	<a href="ymsgr:SendIM?chienyenict" title="phụ trách bán hàng">
                        <img src="http://opi.yahoo.com/online?u=chienyenict&m=g&t=2&l=us" style="border: 0px; margin-bottom: 10px" alt="" /></a>
                    </td>
                </tr>
                
            </table>
        </td>
    </tr>
    <tr>
    	<td><div class="space"></div></td>
    </tr>
    <tr>
    	<td>
        	<div class="font_menu_ta">Tỷ giá hôm nay</div>
            <table width="100%" cellspacing="0" cellpadding="0" border="0" style="border: 1px solid #666666">
                <tr>
                	<td>
                        <div class="goldprice fl">
                            <div class="fl">
                                <img class="img-icon" alt="" src="/Images/money.gif"/>
                                <label class="link-folder">Giá vàng 9999</label>
                            </div>
                            <div class="fl">
                                <div id="eGold" class="gold-price fl">
                                    <table class="tbl-goldprice" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td class="td-weather-title">Mua</td>
                                            <td id="GOLDBUY" class="td-weather-data txtr">
                                                <script type="text/javascript">
                                                    document.getElementById('GOLDBUY').innerHTML = vGoldSbjBuy;
                                                </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td-weather-title">Bán</td>
                                            <td id="GOLDSELL" class="td-weather-data txtr">
                                                <script type="text/javascript">
                                                    document.getElementById('GOLDSELL').innerHTML = vGoldSbjSell;
                                                </script>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="fl">
                                    <img class="img-icon" alt="" src="/Images/circle-chart.gif"/>
                                    <label class="link-folder">Tỷ giá</label>
                                </div>
                                <div id="eForex" class="forex-rate fl">
                                    <table class="tbl-goldprice" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td class="td-weather-title">USD</td>
                                            <td id="USD" class="td-weather-data txtr">
                                                <script type="text/javascript">
                                                    document.getElementById('USD').innerHTML = vCosts[0];
                                                </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td-weather-title">EUR
                                            </td>
                                            <td id="EUR" class="td-weather-data txtr">
                                                <script type="text/javascript">
                                                    document.getElementById('EUR').innerHTML = vCosts[10];
                                                </script>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>