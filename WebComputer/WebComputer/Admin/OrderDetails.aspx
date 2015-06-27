<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="WebComputer.Admin.OrderDetails" Title="Chi tiết hóa đơn xuất" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" width="98%" cellpadding="0" cellspacing="0" style="border:1px solid #c0c0c0">
    <tr>
         <td class="Title" style="height: 22px" align="left" colspan="2">
         <asp:Label ID="Label2" runat="server"></asp:Label>Chi tiết hóa đơn mua hàng</td>
       
    </tr>
    <tr>
        <td>
    <table style="width:70%;height:auto;border:0px;padding:4px;">
        <tr>
        <td style="width:33%" align="left">Mã hóa đơn:<asp:Label runat="server" ID="lblOrderID"></asp:Label></td>
        <td style="width:33%"></td>
        <td style="width:135px">Ngày đặt:<asp:Label runat="server" ID="lblOrderDate"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="3"></td>
    </tr>
    <tr>
        <td colspan="3" align="left"><b>Thông tin người đặt hàng:</b></td>
    </tr>
    <tr>
        <td align="right" style="height: 15px">Họ và Tên:</td>
        <td align="left" style="height: 15px">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblFullName"></asp:Label></td>
        <td style="height: 15px; width: 135px;"></td>
    </tr>
    <tr>
        <td align="right">Email:</td>
        <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblEmail"></asp:Label> </td>
        <td style="width: 135px"></td>
    </tr>
    <tr>
        <td align="right">Địa chỉ:</td>
        <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAddress"></asp:Label></td>
        <td style="width: 135px"></td>
    </tr>
    <tr>
        <td align="right">Điện thoại:</td>
        <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPhoneNo"></asp:Label></td>
        <td style="width: 135px"></td>
    </tr>
    <tr>
        <td colspan="3" align="left"><b>Thông tin người nhận hàng:</b></td>
    </tr>
    <tr>
        <td align="right">Họ và Tên:</td>
        <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblrecFullName"></asp:Label></td>
        <td style="width: 135px"></td>
    </tr>
    <tr>
        <td align="right" style="height: 15px">Địa chỉ:</td>
        <td align="left" style="height: 15px">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblrecAddress"></asp:Label></td>
        <td style="height: 15px; width: 135px;"></td>
    </tr>
    <tr>
        <td align="left" colspan="3"><b>Thông tin mua hàng:</b></td>
    </tr>
    
   
    <tr>
        <td colspan="3" align="left"></td>
    </tr>
    <tr>
        <td colspan="3" align="center" style="width:100%;">
            <asp:GridView Width="100%" runat="server" ID ="grvMain" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Mã hóa đơn">
                        <HeaderStyle HorizontalAlign="Center" CssClass="SubTitle" />
                         <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate><%#DataBinder.Eval(Container.DataItem,"OrderID") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã hàng">
                        <HeaderStyle HorizontalAlign="Center" CssClass="SubTitle" />
                         <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate><%#DataBinder.Eval(Container.DataItem,"Product_ID") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên hàng">
                        <HeaderStyle HorizontalAlign="Center" CssClass="SubTitle" />
                         <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate><%#DataBinder.Eval(Container.DataItem,"Product_Name") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số lượng">
                        <HeaderStyle HorizontalAlign="Center" CssClass="SubTitle" />
                         <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                              <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Quantity", "{0:#}").ToString())%> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Đơn giá">
                        <HeaderStyle HorizontalAlign="Center" CssClass="SubTitle" />
                         <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate><%#DataBinder.Eval(Container.DataItem,"UnitPrice") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giảm giá">
                        <HeaderStyle HorizontalAlign="Center" CssClass="SubTitle" />
                         <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate><%#DataBinder.Eval(Container.DataItem,"Discount") %></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
        <tr>
            <td align="left" colspan="2">Trạng thái hóa đơn:           
            <asp:Label runat="server" ID="lblStatusOrder"></asp:Label>
            <asp:RadioButton ID="rblStatus" runat="server" Text="Xử lý" /></td>
            <td align="right">Tổng tiền:<asp:Label runat="server" ID="lblTotal" Width="20%" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Button runat="server" ID="btnUpdateStatusOrder" Text="Cập nhật trạng thái hóa đơn" OnClick="btnUpdateStatusOrder_Click" /></td>
        </tr>
        <tr>
            <td colspan="3" align="center"><asp:Label runat="server" ID="lblError" ForeColor="Red" Width="280px"></asp:Label></td>
        </tr>
</table>
    </Td>
    </tr>
    </table>
</asp:Content>
