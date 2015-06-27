<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderBillDetails.aspx.cs" Inherits="WebComputer.Admin.OrderBillDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
        <tr>
            <td class="Title" align="left" colspan="2">Hóa đơn nhập chi tiết</td>
        </tr>
        <tr>
            <td colspan="2" style="height:25px;"></td>
        </tr>
        <tr>
            <td style="height:30px;padding-left:10px;width:50%;"><b>Người lập:</b>&nbsp;&nbsp;<asp:Label runat="server" ID="lblEmployee" ></asp:Label></td> 
                      
            <td align="left"><b>Ngày lập:</b>&nbsp;&nbsp;<asp:Label runat="server" ID="lblBuyDate"></asp:Label></td>           
        </tr>
        <tr>
            <td style="padding-left:10px;"><b></b><asp:Label runat="server" ID="lblProvName"></asp:Label> </td>
            <td align="left"><b>Tổng tiên:</b>&nbsp;<asp:Label runat="server" ID="lblTotal" Font-Bold="True"></asp:Label> </td>
        </tr>
        <tr>
            <td style="height:30px; padding-left:10px; height: 15px;">&nbsp;&nbsp;<b>Đã trả:</b>
                <asp:Label runat="server" ID="lblToPay" Font-Bold="True"></asp:Label> </td>
            <td align="left" style="height: 15px"><b></b>&nbsp;<asp:Label runat="server" ID="lblRemain"></asp:Label> </td>
        </tr>
        <tr>
            <td style=" height:30px;" colspan="2"></td>
        </tr>
        <tr>
            <td style=" height:30px;" colspan="2" align="center">
                <asp:GridView runat="server" ID="grvMain" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                    
                    
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" Height="20px" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Stt" runat="server">Stt</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <HeaderStyle Width="8%" Height="20%" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Mã hóa đơn</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="8%"  />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "BillID")%>
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>     
                    
                                <asp:TemplateField>
                                    <HeaderStyle Width="8%" Height="20px" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Tên nhà cung cấp</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="left" Width="8%"  />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "ProvName")%>
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>    
                    
                                   <asp:TemplateField>
                                    <HeaderStyle Width="8%" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Mã sản phẩm</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="8%"  />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Product_ID")%>
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>    
                        
                                  <asp:TemplateField>
                                    <HeaderStyle Width="8%" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Tên sản phẩm</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="left" Width="8%"  />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Product_Name")%>
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>   
                        
                                <asp:TemplateField>
                                    <HeaderStyle Width="8%" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Đơn giá nhập</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="8%"  />
                                    <ItemTemplate>
                                        
                                        <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:#}").ToString())%> 
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                
                                  <asp:TemplateField>
                                    <HeaderStyle Width="8%" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Số lượng</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="8%"  />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Quatity")%>
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                    
                        
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style ="height:50%"></td>
        </tr>
        <tr>
            <Td  colspan = "2" class="Title"></Td>
        </tr>
    </table>
</asp:Content>
