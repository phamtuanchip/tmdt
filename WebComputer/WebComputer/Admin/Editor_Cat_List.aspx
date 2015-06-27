<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Editor_Cat_List.aspx.cs" Inherits="WebComputer.Admin.Editor_Cat_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["CatNewsManager"].ToString()%></td>
            </tr>
            <tr>
                <td align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="CMSNews_Cat_List" runat="server"></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="News_Cat_AddNew" runat="server" OnClick="News_Cat_AddNew_Click" />
                    <asp:Button CssClass="button" ID="News_Cat_Order" runat="server" OnClick="News_Cat_Order_Click" />
                </td>                
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
