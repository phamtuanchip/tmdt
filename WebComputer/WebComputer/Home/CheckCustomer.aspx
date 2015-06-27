<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CheckCustomer.aspx.cs" Inherits="WebComputer.Home.CheckCustomer" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="5" cellspacing="0" style="width: auto;">
    <tr>
        <td><p>Cảm ơn quý khách đã mua hàng của WebComputer !</p></td>
    </tr>        
    <tr>
        <td><p><asp:Label ID="lblLogin" Text="Nếu qúy khách đã là thành viên của chúng tôi thì mời quý khách" runat="server"></asp:Label> <a href="Login.aspx">Đăng Nhập</a>
        <br /><asp:Label ID="lblNone" Text="Nếu quý khách không muốn trở thành thành viên của chúng tôi và chỉ muốn mua hàng thì hãy kích" runat="server"></asp:Label> <a href="">vào đây</a>
        <br /><asp:Label ID="lblRegister" Text="Nếu quý khách muốn trở thành thành viên của chúng tôi, vui lòng" runat="server"></asp:Label> <a href="Register.aspx">Đăng Ký</a></p></td>
    </tr>             
</table>
</asp:Content>
