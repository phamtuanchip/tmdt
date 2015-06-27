<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Provider_Report.aspx.cs" Inherits="WebComputer.Admin.StaticalProvider" Title="Thống kê nhà cung cấp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                <tr>
                    <td class="Title" style="height:22px" align="left">Thống kê nhà cung cấp sản phẩm</td>
                </tr>
                <tr>
                        <td style="height: 13px">
                            <table border = "0" width = "100%">
                                <tr>
                                    <td style="width: 88px; height: 26px">Tiêu chí thống kê:</td>
                                    <td style="height: 26px">
                                        <asp:DropDownList ID="DropDownList_ReportProvider" runat="server" Width="334px">
                                            <asp:ListItem Value="0">--Chọn ti&#234;u ch&#237; thống k&#234; --</asp:ListItem>
                                            <asp:ListItem Value="1">Tổng số c&#225;c nh&#224; cung cấp</asp:ListItem>
                                            <asp:ListItem Value="2">Nh&#224; cung cấp c&#243; c&#244;ng nợ lớn nhất</asp:ListItem>
                                            <asp:ListItem Value="3">Nh&#224; cung cấp c&#243; c&#244;ng nợ nhỏ nhất</asp:ListItem>
                                            <asp:ListItem Value="4">Nh&#224; cung cấp c&#243; nhiều sản phẩm nhất</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 60px; height: 26px">
                                        <asp:Button ID="btn_ReportProvider" runat="server" Text="Thống kê" OnClick="btn_ReportProvider_Click" />
                                   
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan = "3">
                                        <asp:Label ID="lbl_Messager" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                     
                
                </tr>
                <tr>
                    <td class="Title" style="height:22px" align="left">Danh sách nhà cung cấp</td>
                </tr>
                 <tr>
                    <td>
                      <asp:GridView ID="GridView_ReportProvider" runat="server" Width="100%">
                      </asp:GridView>
                       
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="3">
                         <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" DisplayToolbar="False" EnableDatabaseLogonPrompt="False"
                            EnableParameterPrompt="False" />
                    </td>
                </tr>
         </table>
        </td>
    </tr>
   
   </table>
</asp:Content>
