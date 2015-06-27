<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebComputer.Home.Login" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" style="border:1px solid #CCCCCC">
    <tr>
        <td colspan="2" style="color: Red; text-align: center"><strong>Xin vui lòng đăng nhập trước khi sử dụng chức năng này</strong> </td>
    </tr>
    <tr>
        <td style="width: 50%" valign="top">
            <table border="0" cellpadding="0" cellspacing="0" style="border-right: 1px solid #CCCCCC">
                <tr>
                    <td style="padding: 28px 0 0 10px">
                        Bằng việc tạo ra một tài khoản tại hệ thống của chúng tôi bạn sẽ được hưởng các tiện ích và dịch vụ tốt nhất, quá trình đặt mua sản phẩm được tiến hành nhanh và chính xác hơn. 
                        Ngoài ra bạn còn có thể sử dụng toàn bộ tiện ích trên hệ thống website.
                    </td>
                </tr>
                <tr align="right">
                    <td style="padding-top: 10px; padding-right: 7px"><asp:ImageButton ID="btnRegister" runat="server" ImageUrl="~/images/create_acc.jpg" OnClick="btnRegister_Click" /></td>
                </tr>
            </table>
        </td>
        <td style="width: 50%">
            <table width="100%" cellspacing="0" cellpadding="4">
                <tr>
                    <td style="width: 194px; font-weight: bold">Tên truy cập: </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtUser" runat="server" Width="196px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 194px; font-weight: bold">Mật khẩu: </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtPass" runat="server" Width="196px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr align="left">
                    <td>
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="../images/login.jpg" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr align="left">
                    <td align="right" class="style1" style="width: 194px; height: 24px;"></td>
                    <td style="color: Red"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
