<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EOFPermission.aspx.cs" Inherits="WebComputer.Admin.EOFPermission" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
        <tr>
            <th class="Title" align="left">
                <%=Lang["Note"].ToString()%>
            </th>
        </tr>
        <tr>
            <td>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="color: #FF0000">
                <b>
                    <%=Lang["NotPermisstion"].ToString()%>
                </b>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
