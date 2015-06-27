<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CartShow.aspx.cs" Inherits="WebComputer.Home.CartShow" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" border="0" align="center">
    <tr>
        <td>
            <asp:Label ID="lblMessager" runat="server" ForeColor="Red"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <table cellpadding="7" cellspacing="0" border="0" align="center" style="border:1px Solid Gray;width: auto;">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Update_Delete_Item">
                    <HeaderTemplate>
                        <tr style="background-color:Lime;font-size:small;">
                            <td class="font_menu_ta">Tên Sản Phẩm</td>
                            <td class="font_menu_ta">Giá</td>
                            <td class="font_menu_ta">Số Lượng</td>
                            <td class="font_menu_ta" colspan="2">Chức Năng</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color:white;">
                            <td style="width: 230px;text-align:center;color:Black;font-weight:bold;border-right:1px solid Gray;border-bottom:1px solid Gray">
                                <asp:Label ID="lblTitle" Text='<%# DataBinder.Eval(Container.DataItem,"ProductName")%>' runat="server"></asp:Label>
                            </td>
                            <td style="width: 50px;text-align:center;color:Black;font-weight:bold;border-right:1px solid Gray;border-bottom:1px solid Gray">
                                <asp:Label ID="lblPrice" Text='<%# objFunc.ChangeTypeMoney(objentity.SplitString(DataBinder.Eval(Container,"DataItem.Price","{0:#}").ToString()))%>' runat="server"></asp:Label>
                                
                            </td>
                            <td style="width: 70px;text-align:center;border-right:1px solid Gray;border-bottom:1px solid Gray">
                                <asp:TextBox ID="txtQuantity" runat="server" Width="40" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity")%>'></asp:TextBox>
                            </td>
                            <td style="text-align:center;font-weight:bold;border-right:1px solid Gray;border-bottom:1px solid Gray">
                                <asp:LinkButton ID="btnUpdateQuantity" Text="Cập Nhật" runat="server" CommandName="edit"></asp:LinkButton>
                            </td>
                            <td style="text-align:center;font-weight:bold;border-bottom:1px solid Gray">
                                <asp:LinkButton ID="btnDelete" Text="Hủy" runat="server" CommandName="del"></asp:LinkButton>
                            </td>
                        </tr>   
                    </ItemTemplate> 
                </asp:Repeater>
            <tr>
                <td style="color:Red; font-family:Tahoma; font-weight:bold; font-size: small; text-align:right;" colspan="4">
                    Tổng Tiền : <asp:Label ID="lblSum" runat="server"></asp:Label> (VNĐ)
                </td>
                <td>
                    <span style="color:Black;font-family:Tahoma;font-weight:bold;font-size:medium;text-align:right;">
                    </span>
                </td>
            </tr>
    </table>
            <div style="margin-top: 10px; text-align: center">
                <asp:ImageButton ID="btnContinue_Shopping" runat="server" ImageUrl="../images/contine.jpg" OnClick="btnContinue_Shopping_Click" />
                <%--<asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="../images/checkout.jpg" OnClick="btnSubmit_Click" />--%>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </div>
        </td>
    </tr>
    <tr>
                  <td colspan="2"><p align="center" class="ml3">Hướng dẫn trước khi thanh toán </p>
                      <p class="style3" >1. Bạn có thể thay đổi hoặc thêm bớt số lượng hàng mà bạn chọn bằng cách nhập số lượng hàng mà bạn muốn mua vào ô <font color="#ff0000">S&#7889; l&#432;ợng</font> và sau đó click chuột vào nút <font color="#ff0000">Cộng lại</font> để máy tính tự động tính toán lại số tiền bạn phải trả. Còn nếu trong giỏ hàng của bạn có mặt hàng nào đó bạn không muốn mua nữa, bạn click vào nút <font color="#ff0000">Hủy</font>, khi đó trong giỏ hàng sẽ không còn mặt hàng đó nữa</p>
                      <p class="style3" >2. Nếu bạn cảm thấy tất cả các loại hàng mình đã chọn trong giỏ không vừa ý, bạn có thể bỏ tất cả chúng bằng cách click vào nút <font color="#ff0000">Hủy b&#7887;</font> để xóa tất cả hàng đã chọn. Nếu tiếp tục mua hàng, bạn click vào nút <font color="#ff0000">Tiếp tục mua </font>.</p>
                      <p class="style3" >3. Sau khi bạn đã chọn và xem lại tất cả mặt hàng đã mua bọn click vào nút <span class="style6">Thanh toán</span> để vào mục thanh toán tiền.</p>
                      <p align="center" class="ml3">Một số thông tin về thanh toán tiền</p>
                      <p  class="style3"> 1. Sau khi bạn đã đặt hàng tại <font color ="blue">Công ty Máy tính Chiển Yến </font> trên hệ thống mua hàng này, nhân viên bán hàng sẽ liên hệ trực tiếp với người đặt hàng để trao đổi cách thanh toán tiền và thời gian bàn giao hàng.</p>
                      <p  class="style3">2. Khách hàng có thể chọn phương thức thanh toán trực tuyến qua ngân lượng bằng cách chọn vào nút thanh toán.</p>
                      <p  class="style3">3. Sau khi bạn đã đặt mua hàng tại đây nếu trong vòng 2-3 ngày chúng tôi không liên hệ được với người đặt hàng thì chúng tôi sẽ xóa đơn đặt hàng.</p>
                      </td>
     </tr>
</table> 
</asp:Content>
