<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ShowProduct.aspx.cs" Inherits="WebComputer.Home.ShowProduct" Title="Welcome to Chien Yen Computer" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" style="float: left" width="100%">
    <tr>
        <td height="auto" colspan="2">
            <div class="font_menu_ta"></div>
        </td>
    </tr>
    <tr style="background-color: #F7F7F7">
        <td align="left" style="padding: 2px 2px 2px 0px">
            <img src="../Images/dgrid.gif" alt="" /> <img src="../Images/dlist.gif" alt="" />
        </td>
        <td align="right" style="padding: 2px 0px 2px 2px">
            <asp:DropDownList ID="lstSearch" runat="server">
                <asp:ListItem>[Sắp xếp theo]</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="width:100%">
         <cc2:UpdatePanel ID="UpdatePN" runat="server">
          <ContentTemplate>
            <asp:DataList ID="dtList" runat="server" RepeatDirection="Vertical" Width="100%">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" class="table_sp">
                        <tr valign="middle">
                            <td class="sp_anh" valign="middle" align="center">
                                <a href="ProductDetails.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                <img src="../Uploads/LibraryImages/<%# DataBinder.Eval(Container.DataItem, "PhotoID") %>_T.jpg" alt="" /></a>
                            </td>
                            <td class="sp_descr" width="350px">
                                <div class="sp_name">
                                    <a href="ProductDetails.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                    <%# DataBinder.Eval(Container, "DataItem.Product_Name") %></a>
                                </div>
                                <div class="sp_model"><%# DataBinder.Eval(Container, "DataItem.Product_Intro") %></div>
                            </td>
                            <td width="100px">
                                <div align="right" style="padding-right: 10px">
                                    <%# objFunc.ChangeTypeMoney(DataBinder.Eval(Container, "DataItem.Product_Price", "{0:#}").ToString())%> VNĐ
                                </div>
                            </td>
                            <td align="center">
                                <a href="Cart.aspx?ProId=<%# DataBinder.Eval(Container.DataItem,"Product_ID") %>">
                                <img src="../Images/add_cart.gif" alt="" /></a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
                   </ContentTemplate>
          </cc2:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center"><cc1:CollectionPager id="CollectionPager1" runat="server"></cc1:CollectionPager></td>
    </tr>
</table>
</asp:Content>
