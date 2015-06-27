<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PaymentOrder.aspx.cs" Inherits="WebComputer.Admin.PaymentOrder" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="width:100%;height:auto;border:0p;">
    <tr>
        <td align="left" style="width:100%;" class="Title">Danh Sách Phiếu Chi</td>
    </tr>
    <tr>
        <td  align="center"><asp:Label ForeColor="red" runat="server" ID="lblError"></asp:Label> </td>
    </tr>
    <tr>
        <td  style="height:25px;"></td>
    </tr>
    <tr>
        <td>
            <asp:GridView Width="100%" runat="server" ID="grvMain" AutoGenerateColumns="false">
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
                        <HeaderStyle Width="10%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="ProvName" runat="server">Tên nhà cung cấp</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate >                                        
                           <%#DataBinder.Eval(Container.DataItem, "ProvName")%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField> 

                      <asp:TemplateField>
                        <HeaderStyle Width="10%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="ResonID" runat="server">Lý do chi</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           <%#DataBinder.Eval(Container.DataItem, "ReasonPayment")%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField>
                        <HeaderStyle Width="10%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="Quatity" runat="server">Số tiền trả</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           <%#objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Quantity", "{0:#}").ToString())%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField> 
                     <asp:TemplateField>
                        <HeaderStyle Width="10%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="EmployeeID" runat="server">Nhân viên lập</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           <%#DataBinder.Eval(Container.DataItem, "Employee")%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField>
                        <HeaderStyle Width="10%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="CreatdateID" runat="server">Ngày lập</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           <%#DataBinder.Eval(Container.DataItem, "CreatedDate")%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField>
                                       
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center" class="Button"><asp:Button runat="server" ID="btnAddPaymentOrder" Text="Thêm phiếu chi" OnClick="btnAddPaymentOrder_Click" /> </td>
    </tr>
</table>
</asp:Content>
