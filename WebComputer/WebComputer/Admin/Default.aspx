<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebComputer.Admin.Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #C0C0C0">
    <tr>
        <th class="Title" align="left"><%=Lang["WebsiteManagerSys"] %></th>
    </tr>
    <tr>
        <td><br /><br /><br /></td>
    </tr>
    <tr>
        <td><b><%=Lang["AppNameInside"] %></b></td>
    </tr>
    <%--<tr>
        <td class="Copyright"><%=Lang["CopyRight"]%></td>
    </tr>
    <tr>
        <td class="Copyright"><%=Lang["TelFax"]%></td>
    </tr>--%>
    <tr><td><br /><br /><br /></td></tr>
</table>
</asp:Content>
