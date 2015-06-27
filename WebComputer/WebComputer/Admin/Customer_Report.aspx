<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer_Report.aspx.cs" Inherits="WebComputer.Admin.Customer_Report" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0" id="TABLE1" onclick="return TABLE1_onclick()">
                <tr>
                    <td class="Title" style="height:22px" align="left">Danh sách khách hàng</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView_Customer" runat="server" Width="100%">
                        </asp:GridView>
                    </td>
                </tr>
         
            </table>
        </td>
    </tr>
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0" id="TABLE2" onclick="return TABLE1_onclick()">
                <tr>
                    <td colspan ="3" class="Title" style="height:22px" align="left">Thống kê khách hàng</td>
                </tr>
                <tr>
                    <td style="height: 24px">
                       Chọn tiêu chí thống kê:
                    </td>
                    <td style="height: 24px">
                        <asp:DropDownList ID="DropDownList_CusReport"  runat="server" Width="277px">
                            <asp:ListItem Value="0">..::: Chọn ti&#234;u ch&#237; thống k&#234; :::..</asp:ListItem>
                            <asp:ListItem Value="1">Tổng kh&#225;ch h&#224;ng đ&#227; mua</asp:ListItem>
                            <asp:ListItem Value="2">Kh&#225;ch h&#224;ng mua h&#224;ng nhiều nhất</asp:ListItem>
                            <asp:ListItem Value="3">Kh&#225;ch h&#224;ng mua sản phẩm c&#243; gi&#225; trị lớn nhất</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="height: 24px">
                        <asp:Button ID="Btn_ReportCus" runat="server" Text="Thống kê" OnClick="Btn_ReportCus_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan = "3">
                       
                        <asp:Label ID="Lbl_Messager" runat="server" ForeColor="Red"></asp:Label>
                        
                        
                    </td>
                </tr>
         
            </table>
        </td>
    </tr>
    <tr>
        <td >
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0" id="TABLE3" onclick="return TABLE1_onclick()">
                <tr>
                    <td class="Title" style="height:22px" align="left">Kết quả thống kê</td>
                </tr>
                <tr>
                    <td style="height: 24px">
               
                       
                        <asp:GridView ID="Dtg_Report_Customer" runat="server" Width = "100%">
                        </asp:GridView>
                       
                       
                    </td>
                    
                </tr>
         
            </table>
        </td>
    </tr>
</table>
</asp:Content>
