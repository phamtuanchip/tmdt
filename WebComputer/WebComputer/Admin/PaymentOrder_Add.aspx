<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PaymentOrder_Add.aspx.cs" Inherits="WebComputer.Admin.PaymentOrder_Add" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
        <tr>
            <td colspan="4" align ="left" class="Title">Thêm Phiếu Chi</td>
        </tr>
        <tr>
            <td colspan="4"><asp:Label runat="server" ForeColor="red" ID="lblError"></asp:Label> </td>
        </tr>
        <tr>
            <td ><asp:Label runat="server"  ID="lbl" Text="Nhân viên lập:"></asp:Label> </td>
            <td align="left"><asp:Label runat="server" ID="lblEmployee"></asp:Label> </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td style="width:25%"><b></b>Nhà cung cấp:</td>
            <td style="width:25%" align="left"><asp:DropDownList runat="server" ID="ddlProvName" AutoPostBack="True" DataTextField="ProvName" DataValueField="ProvID" OnSelectedIndexChanged="ddlProvName_SelectedIndexChanged"></asp:DropDownList> </td>
            <td style="width:25%"><asp:Label runat="server" ID="lblTotalArrears" Visible="false"></asp:Label> </td>
            <td style="width:25%" align="left"><asp:Label runat="server" ID="lblTotal" Visible="false"></asp:Label> </td>
        </tr>
        <tr>
            <td>Số tiền trả:</td>
            <td  align="left"><asp:TextBox  runat="server" ID="txtQuantity"></asp:TextBox></td>
            <td>Ngày tạo:</td>
            <td align="left"><asp:Label runat="server" ID="lblCreatedDate"></asp:Label> </td>
        </tr>
        <tr>
            <td>Lý do trả tiền:</td>
            <td align="left"><asp:TextBox runat="server" ID="txtReasonPayment" TextMode="MultiLine" Columns="17" Rows="5"></asp:TextBox> </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="button"><asp:Button runat="server" ID="btnAddPaymentOrder" Text="Thêm phiếu chi" Visible="false" OnClick="btnAddPaymentOrder_Click" /> <asp:Button runat ="server" ID="btnAddPayment" Visible="false" Text="Thêm phiếu chi" OnClick="btnAddPayment_Click" /> </td>
           
            
        </tr>   
    </table>
</asp:Content>
