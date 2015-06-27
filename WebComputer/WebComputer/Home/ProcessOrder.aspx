<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ProcessOrder.aspx.cs" Inherits="WebComputer.Home.ProcessOrder" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="5" cellspacing="0" width="100%" style="border: 1px solid #CCCCCC;">
        <tr>
            <td colspan="2" class="font_menu_ta">Xem Hóa Đơn</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessager" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="color:#2170b4;font-size:large;font-weight:bold;text-align:left;border-bottom:Gray 1px solid;">
                <br />
                Bên Bán Hàng : </td>
        </tr>
        <tr>
            <td style="width: 168px; font-weight:bold; text-align: right">Tên Công Ty :</td>
            <td align="left">Công ty TNHH Chiển Yến</td>
        </tr>
        <tr>
            <td style="width: 168px;font-weight:bold; text-align: right">Địa Chỉ :</td>
            <td align="left">Ngã ba Tô Hiệu - Dân Tiến - Khoái Châu - Hưng Yên </td>
        </tr>
        <tr>
            <td style="width: 168px;font-weight:bold; text-align: right">Điện Thoại :</td>
            <td align="left">03213.713.310</td>
        </tr>
        <tr>
            <td colspan="2" style="color: #2170b4;font-size:large;font-weight:bold;text-align:left;border-bottom:Gray 1px solid;">
                <br />Bên Mua Hàng : </td>
        </tr>
        <tr>
            <td style="width: 168px;font-weight:bold; text-align: right">Tên Khách Hàng : </td>
            <td align="left"><asp:Label ID="lblCus_name" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 168px;font-weight:bold; text-align: right">Điện Thoại : </td>
            <td align="left"><asp:Label ID="lblCus_tel" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td style="width: 168px;font-weight:bold; text-align: right">Địa chỉ giao hàng : </td>
            <td align="left"><asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="color: #2170b4;font-size:large;font-weight:bold;text-align:left;border-bottom:Gray 1px solid;">
                <br />Chi Tiết Sản Phẩm</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 24px">
                <table cellpadding="0" cellspacing="0" border="0" style="width:100%;border-bottom:Gray 1px solid;">
                    <asp:Repeater ID ="rptShowCart" runat="server">
                        <HeaderTemplate>
                            <tr style="color:Blue;font-size:medium;font-weight:bold;">
                                <td>Tên sản phẩm</td>
                                <td>Giá</td>
                                <td>Số Lượng</td>
                                <%--<td>Thành Tiền</td>--%>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="font-weight:bold;">
                                
                                <td><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label></td>
                                <td><asp:Label ID="lblPrice" runat="server" Text='<%#objFunc.ChangeTypeMoney(objentity.SplitString(DataBinder.Eval(Container,"DataItem.Price","{0:#}").ToString()))%>'></asp:Label></td>
                                
                                <td><asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label></td>
                                <%--<td><asp:Label ID="lblItemTotal" runat="server" Text='<%#Eval("Total") %>'></asp:Label></td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 24px"></td>
            <td  style="color:Red;font-weight:bold;text-align:right; height: 24px;">Tổng Tiền : <asp:Label ID="lblTotal" runat="server" Text="Tổng Tiền :"></asp:Label> (VNĐ)</td>
        </tr>
        <tr>
            <td colspan="2" style="font-style:italic;color:blue" >( Số tiền bằng chữ: 
                <asp:Label ID="lblDocso" runat="server" Text=""></asp:Label> đồng )
            </td>
        </tr>
        
        <tr>
                        <td style="width: 168px;font-weight:bold;text-align: right" >Hình Thức Giao Hàng : </td>
                        <td style="color:Black;font-weight:bold; text-align: left"><asp:Label ID="lblDelivery" runat="server"></asp:Label></td>
        </tr>
        <tr>
                <td style="width: 168px;font-weight:bold;text-align: right">Hình Thức Thanh Toán : </td>
                <td style="color:Black;font-weight:bold;text-align: left"><asp:Label ID="lblPay" runat="server"></asp:Label>
                </td>
        </tr>
                
        <tr>
            <td colspan="2" align="center" style="height: 19px">
                <br />
                <asp:ImageButton ID="btnKhangDinh" runat="server" ImageUrl="../images/accept.jpg" OnClick="btnKhangDinh_Click" />
                <asp:ImageButton ID="btnDelOrder" runat="server" ImageUrl="../images/delete_order.jpg" OnClick="btnDelOrder_Click" />
                <asp:Label ID="Label1"  runat="server" ></asp:Label></td>
        </tr>
    </table>
</asp:Content>
