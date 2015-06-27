<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gallery_View.aspx.cs" Inherits="WebComputer.Admin.Gallery_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["LibraryImageView"].ToString()%></td>
            </tr>
            <tr>
                <td align="center">
                    <table width="98%" border="0" cellpadding="3" cellspacing="2">
                        <tr>
                            <td id="CMSLibraryImage_View" runat="server"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="LibraryImage_Edit" runat="server" OnClick="LibraryImage_Edit_Click" />
                    <input type="button" id="Back_View" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
