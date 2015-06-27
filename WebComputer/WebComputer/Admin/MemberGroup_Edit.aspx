<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MemberGroup_Edit.aspx.cs" Inherits="WebComputer.Admin.MemberGroup_Edit" Title="Untitled Page" ValidateRequest ="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript"></script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="CMSMemberGroup_Edit" runat="server"></td>
        </tr>
        <tr>
            <td align="center">
                <table width="98%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="Title" align="left">
                            <asp:Button CssClass="button" ID="MemberGroupEdit" runat="server" OnClientClick="return checkAddNew(this.form);" OnClick="MemberGroupEdit_Click" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
