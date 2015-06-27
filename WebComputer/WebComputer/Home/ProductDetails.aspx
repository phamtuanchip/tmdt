<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebComputer.Home.ProductDetails" Title="Welcome to Chien Yen Computer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptDetails" runat="server">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr valign="top">
                                <td style="width: 40%; padding-left: 10px">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <div class="ten_sp" style="padding-top: 8px;">
                                                    <%#Eval("Product_Name") %></div>
                                                <div style="padding-top: 5px;"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0">
                                                    <tr valign="middle">
                                                        <td class="sp_anh" align="center">
                                                            <a href="../Uploads/LibraryImages/<%=strProductImage%>.jpg" rel="lightbox" title="<%#Eval("Product_Name") %>"><img src="../Uploads/LibraryImages/<%=strProductImage%>_T.jpg" alt="" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table border="0">
                                                    <tr>
                                                        <td bordercolor="#0000FF" valign="top">
                                                            <div style="border: 1px solid rgb(204, 204, 204); height: 22px; float: left;" class="detal">
                                                	            <div style="padding-left: 3px; padding-right: 3px; padding-top: 2px;"><a href="#dtkt">Đặc tính kỹ thuật</a></div>
                                                            </div>
                                                            <div style="float: left;">&nbsp;</div>
                                                            <div style="border: 1px solid rgb(204, 204, 204); height: 22px; float: left;" class="detal">
                                                	            <div style="padding-left: 3px; padding-right: 3px; padding-top: 2px;"><a href="#splq">Sản phẩm liên quan</a></div>
                                                            </div>
                                                            <div style="float: left"></div>
                                                            <div class="clear"></div>
                                                            <div class="space_small"></div>
                                                            <div class="intro">
                                                                <%#Eval("Product_Intro") %>
                                                            </div>
                                                            <hr size="1" color="#cccccc"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Trong kho: <b><%=strQuantity%></b></td>
															<!--<td>Trong kho: </td>-->
                                                    </tr>
                                                    <tr>
                                                        <td>Giá: <span style="color: Red; font-weight: bold"><%# objFunc.ChangeTypeMoney(DataBinder.Eval(Container, "DataItem.Product_Price", "{0:#}").ToString())%> VNĐ</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="Cart.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                                            <img src="../Images/add_cart.gif" alt="" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td id="dtkt">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid rgb(204, 204, 204); margin-top: 20px">
                            <tr>
                                <td style="background-color: rgb(242, 242, 242); font-family: Tahoma; font-size: 12px; height: 20px; font-weight: bold; padding: 3px 0 3px 3px;">Thông tin chi tiết</td>
                            </tr>
                            <tr>
                                <td><%#Eval("Content") %></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td id="splq">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid rgb(204, 204, 204); margin-top: 20px">
                    <tr>
                        <td style="background-color: rgb(242, 242, 242); font-family: Tahoma; font-size: 12px; height: 20px; font-weight: bold; padding: 3px 0 3px 3px;">Sản phẩm liên quan</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataList ID="dtProduct" runat="server" RepeatDirection="Vertical">
                                <ItemTemplate>
                                    <table border="0" width="100%">
                                        <tr>
                                            <td id="link_splq"><a href="ProductDetails.aspx?ProID=<%# DataBinder.Eval(Container.DataItem , "Product_ID")%>">
                                            <%# DataBinder.Eval(Container.DataItem , "Product_Name") %>
                                            </a></td>
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