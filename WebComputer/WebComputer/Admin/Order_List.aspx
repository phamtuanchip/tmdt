<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Order_List.aspx.cs" Inherits="WebComputer.Admin.Order_List" Title="Danh sách hóa đơn xuất" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <table border="0" width="98%" cellpadding="0" cellspacing="0" style="border:1px solid #c0c0c0">
    <tr>
         <td class="Title" style="height: 22px" align="left" colspan="2">
         <asp:Label ID="Label2" runat="server"></asp:Label>Danh sách hóa đơn</td>
       
    </tr>
    <tr>
        <td colspan="2" style="height:20px;"></td>
    </tr>
    <tr>
        <td colspan="2" align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tìm Theo:
            <asp:DropDownList ID="ddlSearch" runat="server">
                <asp:ListItem Selected="True" Value="0">--Chọn--</asp:ListItem>
                <asp:ListItem Value="1">M&#227; h&#243;a đơn</asp:ListItem>
                <asp:ListItem Value="2">Ng&#224;y tạo</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button runat="server" ID="btnSearch" Text="Tìm hóa đơn" OnClick="btnSearch_Click" />
       </td>
    </tr>
    <tr>
        <td colspan="2" align="center"><asp:Label runat="server" ID="lblError" ForeColor="Red" Width="333px"></asp:Label> </td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="height: 112px">
            <asp:GridView runat="server" Width="100%" ID="grvMain" AutoGenerateColumns="false">
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
                        <asp:Label ID="OrderID" runat="server">Mã hóa đơn</asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate >                                        
                       <%#DataBinder.Eval(Container.DataItem, "OrderID")%>                                                                          
                    </ItemTemplate>
                </asp:TemplateField> 

                  <asp:TemplateField>
                    <HeaderStyle Width="5%" CssClass="SubTitle" />
                    <HeaderTemplate>
                        <asp:Label ID="OrderID" runat="server">Địa chỉ Email</asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate >                                       
                        <a href="OrderDetails.aspx?OrderID=<%#DataBinder.Eval(Container.DataItem, "OrderID")%>" class="leftMenuAdmin">
                              <%#DataBinder.Eval(Container.DataItem, "Email")%>   
                        </a>                                        
                                     
                    </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField>
                        <HeaderStyle Width="5%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="DateOrder" runat="server">Ngày Đặt</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           <%#DataBinder.Eval(Container.DataItem, "OrderDate")%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    
                    <asp:TemplateField>
                        <HeaderStyle Width="5%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="DateOrder" runat="server">Địa chỉ nhận</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           <%#DataBinder.Eval(Container.DataItem, "DeliveryAddress")%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField> 
                   
                     <asp:TemplateField>
                        <HeaderStyle Width="5%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="DateOrder" runat="server">Tổng Tiền</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                           
                           <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Total", "{0:#}").ToString())%>                                                                        
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                     <asp:TemplateField>
                        <HeaderStyle Width="5%" CssClass="SubTitle" />
                        <HeaderTemplate>
                            <asp:Label ID="DateOrder" runat="server">Trạng thái</asp:Label>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate >                                        
                          <%#this.GetStatus(Eval("Status"))%>                                                                          
                        </ItemTemplate>
                    </asp:TemplateField> 
                   
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>


  
</asp:Content>
