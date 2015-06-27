<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="PreviewOrder.aspx.cs" Inherits="WebComputer.Home.PreviewOrder" Title="Welcome to Chien Yen Computer" %>
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
        if (document.getElementById("<%=txtAddress.ClientID%>").value=="")
        {
             alert("Địa Chỉ không được để trống !");
             document.getElementById("<%=txtAddress.ClientID%>").focus();
             return false;
        }
        if (document.getElementById("<%=txtTel.ClientID%>").value=="")
        {
             alert("Số điện thoại không được để trống !");
             document.getElementById("<%=txtTel.ClientID%>").focus();
             return false;
        }
       
        if (document.getElementById("<%=txtDeliveryAddress.ClientID%>").value=="")
        {
             alert("Địa chỉ giao hàng không được để trống !");
             document.getElementById("<%=txtTel.ClientID%>").focus();
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
</script>

<table width="100%" border="0" cellpadding="3" cellspacing="0" style="border: 1px solid #CCCCCC">
    <tr>
        <td colspan="4" class="font_menu_ta">
            Thông tin người mua
        </td>
    </tr>
    <tr>
        <td style="height: 9px; width: 191px; text-align: right; margin-top: 5px">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">
            Tên khách hàng: </span>
        </td>
        <td colspan="3" style="text-align: left;">
            <asp:TextBox ID="txtName" runat="server" Width="343px" Height="19px"></asp:TextBox>
        </td>    
    </tr>
    <tr>
        <td style="width: 191px; text-align: right;">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">
            Địa chỉ: </span></td>
        <td colspan="3" style="text-align: left;">
            <asp:TextBox ID="txtAddress" runat="server" Width="343px" Height="19px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 191px; text-align: right;">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">
            Email: </span></td>
        <td colspan="3" style="text-align: left;">
            <asp:TextBox ID="txtEmail" runat="server" Width="243px" Height="19px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 191px; text-align: right;">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">
            Số điện thoại: </span></td>
        <td colspan="3" style="text-align: left;">
            <asp:TextBox ID="txtTel" runat="server" Width="143px" Height="19px"></asp:TextBox>
            <br />
            
        </td>
    </tr>
    <tr>
        <td style="width: 191px; text-align: right;">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">&nbsp;</span></td>
        <td colspan="3" style="text-align: left;">
            &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Thông tin người nhận"></asp:Label><br />
            </td>
    </tr>
     <tr>
        <td style="width: 191px; text-align: right;">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">&nbsp;<asp:Label
                ID="lblName" runat="server" Text="Người nhận:"></asp:Label>
            </span></td>
        <td colspan="3" style="text-align: left;">
            &nbsp;<br />
            <asp:TextBox ID="txtDeliveryName" runat="server" Width="143px" Height="19px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 191px; text-align: right;">
            <span style="font-size: 10pt; font-family: Tahoma; font-weight: bold">
                <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ giao hàng :"></asp:Label>&nbsp;</span></td>
        <td colspan="3" style="text-align: left;">
            &nbsp;<br />
            <asp:TextBox ID="txtDeliveryAddress" runat="server" Width="366px" Height="19px"></asp:TextBox></td>
    </tr>
    <tr>
     
    <td colspan="4" class="font_menu_ta">
        Giao Hàng & Thanh Toán
    </td>
    </tr>
    <tr>
        <td colspan="2" style="font-weight: bold; font-size: small; text-align: center;border-bottom: 1px solid #CCCCCC;border-right: 1px solid #CCCCCC;">
            Hình Thức Giao Hàng</td>
        <td colspan="2" style="font-weight: bold; font-size: small; text-align: center;border-bottom: 1px solid #CCCCCC; width: 50%;">
            Hình Thức Thanh Toán</td>
    </tr>
    <tr>
        <td colspan="2" style="border-right: 1px solid #CCCCCC;">
            <p>
                <asp:RadioButton ID="rdgiaohangtantay" runat="server" Text="Giao Hàng Tận Tay" Checked="true" GroupName="HinhThucGiaoHang"/><br />
                <asp:RadioButton ID="rdGiaohangquabuudien" runat="server" Text="Giao Hàng Qua Bưu Điện" GroupName="HinhThucGiaoHang" /><br />
                <asp:RadioButton ID="rdChuyenPhatNhanh" runat="server" Text="Chuyển Phát Nhanh" GroupName="HinhThucGiaoHang" /><br />
                <asp:RadioButton ID="rdGiaohangcaptop" runat="server" Text="Giao Hàng Cấp Tốc" GroupName="HinhThucGiaoHang" /><br />
            </p>
        </td>
        <td colspan="2" style="width: 358px">
            <p>
                <asp:RadioButton ID="rdThanhToanTrucTiep" runat="server" Text="Thanh Toán Trực Tiếp" GroupName="HinhThucThanhToan" /><br />
                <asp:RadioButton ID="rdNhanVienGiaoHangThuTien" runat="server" Text="Nhân Viên Giao Hàng Thu Tiền" Checked="true" GroupName="HinhThucThanhToan"/><br />
                <asp:RadioButton ID="rdChuyenKhoan" runat="server" Text="Chuyển Khoản" GroupName="HinhThucThanhToan" /><br />
                <asp:RadioButton ID="rdGuiQuaBuuDien" runat="server" Text="Gửi Qua Bưu Điện" GroupName="HinhThucThanhToan" /><br />
            </p>
        </td>
    </tr>
    
    <tr>
        <td colspan="4" align="center" style="border-top:1px Gray Solid;">
            <asp:ImageButton ID="btnPreviewOrder" runat="server" ImageUrl="~/images/view_order.jpg" OnClick="btnPreviewOrder_Click" OnClientClick="return validate();" />
        </td>
    </tr>
</table>
</asp:Content>
