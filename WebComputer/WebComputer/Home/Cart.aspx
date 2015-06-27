<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebComputer.Home.Cart" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td colspan="2" align="center"><span style="font-family:Arial;font-size:16px;font-weight:bold">Đặt mua sản phẩm</span></td>
    </tr>
    
    <tr>
        <td><span style="font-family:Arial;font-size:11px;font-weight:bold;color:Red">Tên sản phẩm:</span></td>
        <td><asp:Label ID="lblName" runat="server" CssClass="title"></asp:Label></td>
        
     </tr>
     <tr>
        <td><span style="font-family:Arial;font-size:11px;font-weight:bold;color:Red">Giá:</span></td>
        <td><asp:Label ID="lblCost" runat="server"></asp:Label>
            <span style="color: #ff0000">VNĐ</span></td>
     </tr>
     <tr>
        <td><span style="font-family:Arial;font-size:11px;font-weight:bold;color:Red">Số lượng đặt mua:</span></td>
        <td>
            <asp:TextBox ID="txtCount" runat="server"></asp:TextBox></td>
        
    </tr>
    <tr>
        <td  align="center"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
    </tr>
    <tr>
        <td><div style="color:Red;font-style:italic;"> <asp:Literal ID="Literal1" runat="server"></asp:Literal></div></td>
    </tr>
</table>
</asp:Content>
