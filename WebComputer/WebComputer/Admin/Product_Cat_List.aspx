<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product_Cat_List.aspx.cs" Inherits="WebComputer.Admin.Product_Cat_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["CatProductManager"].ToString()%></td>
            </tr>
            <tr>
                <td align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="CMSProduct_Cat_List" runat="server"></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="Product_Cat_AddNew" runat="server" OnClick="Product_Cat_AddNew_Click" />
                    <asp:Button CssClass="button" ID="Product_Cat_Order" runat="server" OnClick="Product_Cat_Order_Click" />
                </td>                
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
