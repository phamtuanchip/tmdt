<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recruit_View.aspx.cs" Inherits="WebComputer.Admin.Recruit_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <th class="Title" align="left"><%=Lang["RecruitView"].ToString()%></th>
            </tr>
            <tr>
                <td align="center">
                <table width="80%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="CMSRecruit_View" runat="server"></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="Recruit_Edit" runat="server" OnClick="Recruit_Edit_Click" />
                    <input type="button" id="Back_View" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
