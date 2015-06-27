<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebComputer.Home.Contact" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0" style="border:0px solid #DCE1ED">
    <tr>
        <td class="titleModule" align="left">THÔNG TIN LIÊN HỆ</td>
    </tr>
    <tr>
        <td align="center">
            <table width="100%" border="0" cellpadding="5" cellspacing="0">                  
                <tr>
                    <td colspan="2" class="normal" align="left">
                        <div style="color: #0D55AC; font-family: Arial; font-size: 12px">Mọi ý kiến đóng góp của quý khách xin gửi về: <b>Chiển Yến Computer</b></div>
                        - Công ty TNHH Chiển Yến - Ngã 3 Dân Tiến - Khoái Châu - Hưng Yên <br />
                        - Điện thoại: 03213 713.310 – DĐ: 0985 281.071 <br/> 
                        - Email: Support@chienyen.com.vn
                    </td>
                </tr>
                <tr><td style="height: 5px" colspan="2"></td></tr>
                <tr><td colspan="2" align="left"><div style="color: #0D55AC; font-family: Arial; font-size: 12px">Hoặc có thể liên hệ trực tuyến với chúng tôi theo mẫu sau:</div></td></tr>
                <tr><td style="height: 5px" colspan="2"></td></tr>
                <tr>
                    <td style="width: 25%" class="normal" align="left">Họ và tên</td>
                    <td align="left">
                        <asp:TextBox ID="txtFullName" Width="50%" CssClass="textbox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_FullName" CssClass="product_list_title" runat="server" ControlToValidate="txtFullName" ErrorMessage="Họ tên không thể trống!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="normal" align="left">Địa chỉ</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress" Width="90%" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal" align="left">Điện thoại</td>
                    <td align="left">
                        <asp:TextBox ID="txtPhone" Width="50%" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal" align="left">Địa chỉ email</td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" Width="50%" CssClass="textbox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_Email" CssClass="product_list_title_Isleaf" runat="server" ControlToValidate="txtEmail" ErrorMessage="Bạn chưa nhập địa chỉ Email ?"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="product_list_title_Isleaf" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email chưa đúng định dạng!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>                
                <tr>
                    <td class="normal" align="left">Ý kiến đóng góp</td>
                    <td align="left">
                        <textarea id="txtContent" cols="40" rows="7" runat="server" style="border-style: solid; border-width: 1px; border-color: #cccccc"></textarea>
                        <asp:RequiredFieldValidator ID="RFV_Content" CssClass="product_list_title_Isleaf" runat="server" ControlToValidate="txtContent" ErrorMessage="Ý kiến đóng góp không thể trống!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="normal" align="left"></td>
                    <td align="left">
                        <asp:Button ID="Contact_AddNew" runat="server" CssClass="button" Text=" Gửi " OnClick="Contact_AddNew_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
