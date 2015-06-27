<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LibraryCatImage_List.aspx.cs" Inherits="WebComputer.Admin.LibraryCatImage_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2"><%=Lang["AdminLibraryCatImages"].ToString()%></td>
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
