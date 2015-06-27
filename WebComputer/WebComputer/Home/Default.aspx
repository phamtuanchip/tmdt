<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebComputer.Home.Default" Title="Welcome to Chien Yen Computer " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td height="auto">
            <div class="font_menu_ta" style="text-align: left;">Tin tức mới nhất</div>
        </td>
    </tr>
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #CCCCCC">
                <tr>
                    <td style="width: 200px">
                        <img src="../Uploads/LibraryImages/laptop.jpg" />
                    </td>
                    <td valign="top">
                        <asp:DataList ID="dtList" runat="server" RepeatDirection="Vertical" Width="100%">
                            <ItemTemplate>
                                <table width="100%" >
                                    <tr>
                                        <td style="border-bottom: 1px dotted #CCCCCC; padding-bottom: 3px">
                                            <img src="../images/bullet2.gif" /> <a href="NewsDetails.aspx?NewsID=<%#DataBinder.Eval(Container, "DataItem.News_ID")%>"><%#DataBinder.Eval(Container, "DataItem.Subject")%></a> 
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>   
                </tr>
                <tr>
                    <td></td>
                    <td align="right"><a class="news_con" href="ShowNews.aspx">Xem tất cả <img src="../images/ten.gif" alt=""/></a></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="space"></td>
    </tr>
    <tr>
       <td align="center">
			<a href="NewsDetails.aspx?NewsID=51">
			<img src="../Images/qc/quancao.jpg" alt="Tin hot đây" /></a>
	   </td>
    </tr>
    <tr>
        <td class="space"></td>
    </tr>
    <tr>
        <td height="auto">
            <div class="font_menu_ta" style="text-align: left;">Sản phẩm nổi bật</div>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:DataList ID="dtProduct" runat="server" RepeatDirection="Vertical" RepeatColumns="3">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="table_sp">
                                    <tr>
                                        <td class="sp_anh" valign="middle" align="center">
                                            <a href="ProductDetails.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                            <img src="../Uploads/LibraryImages/<%# DataBinder.Eval(Container.DataItem, "PhotoID") %>_T.jpg" alt="" /></a>
                                        </td>
                                        <td valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div class="sp_name">
                                                            <a href="ProductDetails.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                                            <%# DataBinder.Eval(Container, "DataItem.Product_Name") %></a>
                                                        </div>
                                                        Giá: <span style="color: Red; font-weight: bold"><%# objFunc.ChangeTypeMoney(DataBinder.Eval(Container, "DataItem.Product_Price", "{0:#}").ToString())%> VNĐ</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px">
                                                        <a href="Cart.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                                        <img src="../Images/add_cart.gif" alt="" /></a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
