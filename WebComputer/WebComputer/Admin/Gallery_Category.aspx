<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gallery_Category.aspx.cs" Inherits="WebComputer.Admin.Gallery_Category" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2">Danh mục Gallery</td>
            </tr>
            <tr>
                <td align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="CMSLibrary_CatImage_List" runat="server"></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="Library_CatImage_AddNew" runat="server" OnClick="Library_CatImage_AddNew_Click" />
                </td>                
            </tr>
        </table>
        </td>
    </tr>
</table> 
</asp:Content>
