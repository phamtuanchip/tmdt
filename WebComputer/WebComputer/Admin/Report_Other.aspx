<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report_Other.aspx.cs" Inherits="WebComputer.Admin.Report_Other" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" width="98%" cellpadding="0" cellspacing="0" style="border:1px solid #c0c0c0">
    <tr>
         <td class="Title" style="height: 22px; width: 602px;" align="left" colspan="2">
         <asp:Label ID="Label2" runat="server"></asp:Label>Thống kê khác</td>
       
    </tr>
    <tr>
        <td style="height: 13px; width: 100%;" colspan="2">
            <table border = "0" cellspacing="0" style="border: 0px solid #c0c0c0; width: 100%; height: 37px;" >
                <tr>
                    <td style="width: 88px; height: 26px">Tiêu chí thống kê:</td>
                    <td style="height: 26px; width: 120px;">
                        <asp:DropDownList ID="DropDownList_ReportOther" runat="server" Width="168px">
                            <asp:ListItem Value="0">--Chọn ti&#234;u ch&#237; thống k&#234; --</asp:ListItem>
                            <asp:ListItem Value="1">Thống k&#234; h&#243;a đơn nhập</asp:ListItem>
                            <asp:ListItem Value="2">Thống k&#234; h&#243;a đơn xuất</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 88px; height: 26px">Nhập năm bất kỳ:</td>
                    <td style="width: 55px">
                        <asp:TextBox ID="txt_YearReport" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 59px; height: 26px">
                        <asp:Button ID="btn_ThongKeKhac" runat="server" Text="Thống kê" OnClick="btn_ThongKeKhac_Click" />&nbsp;</td>
                </tr>
                <tr>
                    <td align = "center" colspan = "5" style="height: 15px">
                        <asp:Label ID="lbl_Messager" runat="server" ForeColor="Red" Width="266px"></asp:Label>
                    </td>
                </tr>
            </table>
            
        </td>
                     
                
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView_ReportOther" runat="server" Width="100%" AutoGenerateColumns="false"  PageSize="15">
                        
                        
                                  <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Stt" runat="server">Stt</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Mã sản phẩm</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <ItemTemplate >                                        
                                   
                                            <%#DataBinder.Eval(Container.DataItem, "Product_ID")%>                                                                          
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 
                                 <asp:TemplateField>
                                <HeaderStyle Width="20%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tên sản phẩm</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                
                                    <%#DataBinder.Eval(Container.DataItem, "Product_Name")%>
                                       
                                </ItemTemplate>
                            </asp:TemplateField>            
                                                        
                               
                                <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tổng số lượng</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>
                                    <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "TotalQuatity", "{0:#}").ToString())%>
                                       
                                </ItemTemplate>
                            </asp:TemplateField>    
                            
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tổng thành tiền</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>
                                    
                                       <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "TongTienXuatTheSP", "{0:#}").ToString())%> 
                                </ItemTemplate>
                            </asp:TemplateField>    
                            
                                             
                            
                            </Columns>
                        
                        
                        
                        
                        
                        
                        
                        
                      </asp:GridView>
                    </td>
                </tr>
    
</table>    
</asp:Content>
