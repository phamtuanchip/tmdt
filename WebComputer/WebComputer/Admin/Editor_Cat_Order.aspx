<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Editor_Cat_Order.aspx.cs" Inherits="WebComputer.Admin.Editor_Cat_Order" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["NewsCatOrderManager"].ToString()%></td>
            </tr>
            <tr>
                <td align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="CMSNews_Cat_Order" runat="server"></td>                        
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="Update_NewsCatOrder" runat="server" OnClientClick="javascript:checkSubmit(this.form)" OnClick="Update_NewsCatOrder_Click" />
                    <input type="button" id="Back_Order" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>                
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
