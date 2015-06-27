<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebComputer.Home.Register" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    function validate()
    {
        if (document.getElementById("<%=txtName.ClientID%>").value=="")
        {
             alert("Tên không được để trống !");
             document.getElementById("<%=txtName.ClientID%>").focus();
             return false;
        }
        if (document.getElementById("<%=txtUserName.ClientID%>").value=="")
        {
             alert("Tên tài khoản không được để trống !");
             document.getElementById("<%=txtUserName.ClientID%>").focus();
             return false;
        }
        if (document.getElementById("<%=txtPassWord.ClientID%>").value=="")
        {
             alert("Mật Khẩu không được để trống !");
             document.getElementById("<%=txtPassWord.ClientID%>").focus();
             return false;
        }
        if (document.getElementById("<%=txtAddress.ClientID%>").value=="")
        {
             alert("Địa Chỉ không được để trống !");
             document.getElementById("<%=txtAddress.ClientID%>").focus();
             return false;
        }
        if(document.getElementById("<%=txtEmail.ClientID %>").value=="")
        {
            alert("Email không được để trống !");
            document.getElementById("<%=txtEmail.ClientID %>").focus();
            return false;
        }
        var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
        var emailid=document.getElementById("<%=txtEmail.ClientID %>").value;
        var matchArray = emailid.match(emailPat);
        if (matchArray == null)
        {
            alert("Sai định dạng Email. Vui lòng nhập lại !");
            document.getElementById("<%=txtEmail.ClientID %>").focus();
            return false;
        }
        return true;
    }
    
    function Check_UserName()
    {
        alert("Tên tài khoản này đã có người sử dụng ! Vui lòng chọn tên khác !");
        document.getElementById("<%=txtUserName.ClientID %>").focus();
        return false;
    }
</script>
<table border="0" cellpadding="3" cellspacing="3" style="border: 1px solid #999999; width: 100%">
    <tr>
        <td colspan="2" class="font_menu_ta" align="left">Đăng kí mới</td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right; font-weight: bold">Tên truy cập: </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                ErrorMessage="*" ValidationGroup="Group1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right; font-weight: bold">Mật khẩu: </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtPassWord" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2"><hr style="color: #999999;width: 80%; text-align: center" /></td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right; font-weight: bold">Tên khách hàng: </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                ErrorMessage="*" ValidationGroup="Group1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right; font-weight: bold">Địa chỉ: </td>
        <td style="text-align: left"><asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right; font-weight: bold">Email: </td>
        <td style="text-align: left"><asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right; font-weight: bold">Số điện thoại: </td>
        <td style="text-align: left"><asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right"></td>
        <td style="text-align: left">
            <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/register.jpg" OnClientClick="return validate();" OnClick="btnSubmit_Click" />
            <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/images/reset.jpg" />
        </td>
    </tr>
</table>
</asp:Content>
