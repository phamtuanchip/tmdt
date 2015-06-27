<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Logo_View.aspx.cs" Inherits="WebComputer.Admin.Logo_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["Logo_View"].ToString()%></td>
            </tr>
            <tr>
                <td align="center">
                <table width="70%" border="0" cellpadding="3" cellspacing="2">
                    <tr>
                        <td id="HPLogo_View" runat="server"></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td class='Title' style='height:22px' align='left'>
                    <asp:Button ID='EditLogo' runat='server' CssClass='button' OnClick="EditLogo_Click"/>
                    <input type='button' id='Back_Edit' runat='server' class='button' onclick='javascript:history.go(-1)'/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
