<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="WebComputer.Control.User.Left" %>
<table width="100%" cellspacing="0" cellpadding="0" border="0">
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service/Weather_Content.js"></script>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service/Weather.js"></script>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service//Gold_Content.js"></script>
<script type="text/javascript" language="JavaScript" src="http://vnexpress.net/Service/Forex_Content.js"></script>
	<tr>
    	<td height="auto" style="border: 1px solid #CCCCCC">
        	<div class="font_menu_ta">Danh mục chính</div>
            <div style="background-color:#98B8ED">
                <asp:TreeView ID="TreeView1" runat="server" MaxDataBindDepth="4" Width="100%" ImageSet="Arrows">
                    <ParentNodeStyle Width="100%" Font-Bold="False" />
                    <HoverNodeStyle Width="100%" Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle Width="100%" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                    <NodeStyle Width="100%" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </div>
        </td>
    </tr>
    <%--<tr>
    	<td><div class="space"></div></td>
    </tr>
    <tr>
        <td>
            <div class="font_menu_ta">S?n ph?m bán ch?y</div>
            <marquee behavior="scroll" direction="up" scrolldelay="20" scrollamount="1" onmouseout="this.start()" onmouseover="this.stop()">
                <table cellpadding="0" cellspacing="0" style="width: 100%; border: 0px solid #CCCCCC">
                    <asp:Repeater ID="dtList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><a href="ProductDetails.aspx?ProId=<%#DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                <img src="Uploads/Product/<%#DataBinder.Eval(Container.DataItem, "PhotoID") %>_T.jpg" alt="" /></a></td>
                            </tr>
                            <tr>
                                <td align="center"><div class="sp_name">
                                    <a href="ProductDetails.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                    <%# DataBinder.Eval(Container, "DataItem.Product_Name") %></a>
                                </div></td>
                            </tr>
                            <tr>
                                <td align="center">Giá: <span style="color: Red; font-weight: bold"><%# DataBinder.Eval(Container, "DataItem.Product_Price", "{0:#}")%> USD</span></td>
                            </tr>
                            <tr>
                                <td style="height: 5px;"></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </marquee>
        </td>
    </tr>--%>
    <tr>
    	<td><div class="space"></div></td>
    </tr>
    <tr>
    	<td>
        	<div class="font_menu_ta">Hỗ trợ trực tuyến</div>
            <table width="100%" cellspacing="0" cellpadding="0" border="0" style="border: 1px solid #666666">
                <tr>
                	<td align="center">
                    	<a href="ymsgr:SendIM?tieppb" title="Phòng kỹ thuật">
                        <img src="http://opi.yahoo.com/online?u=duongnguyen2812&m=g&t=2&l=us" style="border: 0px; margin-top: 10px; margin-bottom: 10px" alt=""  /></a>
                    </td>                                                            
                </tr>
                <tr>
                	<td align="center">
                    	<a href="ymsgr:SendIM?tieppb" title="phụ trách bán hàng">
                        <img src="http://opi.yahoo.com/online?u=chienyenict&m=g&t=2&l=us" style="border: 0px; margin-bottom: 10px" alt="" /></a>
                    </td>
                </tr>
                <tr>
                	<%--<td align="center">
                    	<a href="ymsgr:SendIM?tieppb0605g" title="Ch? t?ch t?p doàn">
                        <img src="http://opi.yahoo.com/online?u=tieppb0605g&m=g&t=2&l=us" style="border: 0px; margin-bottom: 10px" alt="" /></a>
                    </td>--%>
                </tr>
            </table>
        </td>
    </tr>
    
    <tr>
        <td>
            <div class="font_menu_ta">Liên kết Website</div>
            <table>
                <tr>
                    <td align="center" valign="top" style="width: 100%; padding-top:10px">
                        <select style="border-style: solid; border-width: 1px; font-family: Arial; font-size: 8.5pt;
                        width: 160px" name="select" onchange="window.open(this.options[this.selectedIndex].value,'_blank'); select.options[0].selected=true"
                        size="1">
                        <option selected="selected" value="http://www.chienyen.com.vn">Liên kết website </option>
                        <option value="http://www.phucanh.com.vn">www.phucanh.com.vn</option>
                        <option value="http://www.trananh.com.vn">www.trananh.com.vn</option>
                        <option value="http://www.maihoang.com.vn">www.maihoang.com.vn</option>
                        </select>
                     </td>
                </tr>
               
                <tr>
                    <td>
                         <asp:Label ID="lblMessager" runat="server"></asp:Label>
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
                                <label class="link-folder">Giá Vàng 9999</label>
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
                                    <label class="link-folder">Tỷ Giá</label>
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
   <!-- 
    <tr>
        <td style="height: 19px">
            <div class="font_menu_ta">truy cap: 
               <asp:Label ID="lbl_luottruycap" runat="server" ForeColor="White"></asp:Label>
				<a href="http://www.easycounter.com/">
<img src="http://www.easycounter.com/counter.php?anhtiep123456"
border="0" alt="Web Counter"></a>
<a href="http://www.easycounter.com/FreeCounter3.html"></a>
            </div>
           
        </td>
    </tr>-->

 <tr>
        <td>
			<div class="font_menu_ta">Thống kê truy cập

         	</div>
           
        </td>
    </tr>
<tr>
	<td align="center" style="height: 19px">
		<!-- Histats.com  START  -->
<a href="http://www.histats.com" target="_blank" title="page hit counter" ><script  type="text/javascript" language="javascript">
var s_sid = 694003;var st_dominio = 4;
var cimg = 402;var cwi =118;var che =80;
</script></a>
<script  type="text/javascript" language="javascript" src="http://s10.histats.com/js9.js"></script>
<noscript><a href="http://www.histats.com" target="_blank">
<img  src="http://s4.histats.com/stats/0.gif?694003&1" alt="page hit counter" border="0"></a>
</noscript>
<!-- Histats.com  END  -->
	
	</td>
</tr>
<tr>
        <td>
			<div class="font_menu_ta">Sản phẩm mới
         	</div>
           
        </td>
    </tr>

     <tr>
        <td style="background-color:#EEEFF3; padding-top:0px; padding-bottom:0px; height:80px">
            <table border="0" width="100%" id="table3" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center" valign="top" style="width: 100%; padding-left:2px">
                     <marquee direction="up" align="center" width="130" height="85px" scrollAmount="2" scrolldelay="3" onmouseover="this.stop()" onmouseout="this.start()">
                        <%=wrNewsImages(1)%>
                    </marquee>
                    </td>
                 </tr>
             </table>
         </td>  
</tr>
</table>
