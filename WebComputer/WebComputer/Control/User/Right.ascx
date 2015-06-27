<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right.ascx.cs" Inherits="WebComputer.Control.User.Right" %>
<table width="100%" cellspacing="0" cellpadding="0" border="0">
	<tr valign="top">
    	<td>
    	    <asp:ImageButton ID="btnDownload" runat="server" ImageUrl="~/Images/download.png" OnClick="btnDownload_Click" />
    	</td>
    </tr>
    <tr>
    	<td><div class="space"></div></td>
    </tr>
  <tr>
    <td height="auto" style="border: 1px solid #666666">
   	  <div class="font_menu_ta">Giỏ hàng của bạn</div>
            <div> <asp:ImageButton ID="shopping_cart" runat="server" ImageUrl="~/images/shopping_cart.jpeg" OnClick="ShoppingCart"/></div>
    </td>
    </tr>
    <tr>
    	<td><div class="space"></div></td>
    </tr>
    <tr>
        <td align="center" style="border: 1px solid #666666">
        	<div class="font_menu_ta">Liên kết - Quảng cáo</div>
            <table border="0">
                <asp:DataList ID="dtList" runat="server" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a target="_blank" href="<%#DataBinder.Eval(Container.DataItem, "LogoURL")%>">
                                    <img src="<%=objEntities.GetPathLogo()%><%#DataBinder.Eval(Container.DataItem, "ImageName")%>" alt="<%#DataBinder.Eval(Container.DataItem, "LogoURL")%>" style="border: 0px" />
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList></table>
        </td>
    </tr>
</table>