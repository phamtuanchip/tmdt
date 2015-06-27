<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MemberGroup_AddNew.aspx.cs" Inherits="WebComputer.Admin.MemberGroup_AddNew" Title="Untitled Page" ValidateRequest ="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellpadding="0" cellspacing="0">    
        <tr>
            <td id="CMSMemberGroup" runat="server"></td>
        </tr>        
        <tr>
            <td align="center">
                <table width="98%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="Title" align="left">
                            <asp:Button CssClass="button" ID="MemberGroupAddNew" runat="server" OnClientClick="return checkAddNew(this.form);" OnClick="MemberGroupAddNew_Click" />
                            <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>        
    </table>
</asp:Content>
