<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderBill_List.aspx.cs" Inherits="WebComputer.Admin.OrderBill_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
        <tr>
            <td class="Title" align="left">Danh Sách Hóa Đơn Nhập</td>
        </tr>
        <tr>
            <td align="left">&nbsp;&nbsp;Tìm kiếm theo 
                <asp:DropDownList runat="server" ID="ddlSearch">
                    <asp:ListItem Selected="True" Value="0">--chọn--</asp:ListItem>
                    <asp:ListItem Value="1">Ng&#224;y lập </asp:ListItem>
                    <asp:ListItem Value="2">M&#227; ho&#225; đơn</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
                <asp:Button runat="server" ID="btnSearch" Text="tìm kiếm" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td style="height:10px;"></td>
        </tr>
        <tr>
            <td align="center"><asp:Label ForeColor="red" runat="server" ID="lblError"></asp:Label> </td>
        </tr>
        <tr>
            <td style="height:15px;"></td>
        </tr>
        <tr>
            <td style ="height:70%">Danh sách chi tiết</td>
        </tr>
        <tr>
            <td>
                <asp:GridView runat="server" Width="100%" ID="grvMain" AutoGenerateColumns="false">
                    <Columns>
                    
                     <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="lblStt" runat="server">Stt</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                       </asp:TemplateField>
                    
                       <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmployee" runat="server">Người lập</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Employee")%>
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <a href="OrderBillDetails.aspx?BillID=<%#DataBinder.Eval(Container.DataItem, "BillID")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "Employee")%>
                                        </a>                                        
                                    </ItemTemplate>
                        </asp:TemplateField> 
                                         
                       
                        <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmployee" runat="server">Ngày lập</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "BuyDate")%>
                                    </ItemTemplate>
                                    
                        </asp:TemplateField> 
                       
                        <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmployee" runat="server">Tổng tiền</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                    </ItemTemplate>
                                    
                        </asp:TemplateField>
                       
                        <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmployee" runat="server">Tiền đã trả</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "ToPay")%>
                                    </ItemTemplate>
                                    
                        </asp:TemplateField>
                                        
               
                                  
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="btnAddBill" Text="Thêm hóa đơn nhập" OnClick="btnAddBill_Click" /> </td>
        </tr>
    </table>
</asp:Content>
