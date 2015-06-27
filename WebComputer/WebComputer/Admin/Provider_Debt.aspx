<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Provider_Debt.aspx.cs" Inherits="WebComputer.Admin.Provider_Debt" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                <tr>
                    <td class="Title" style="height:22px" align="left">Danh sách công nợ nhà cung cấp</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GV_Prov_List" runat="server" AllowPaging="true" OnPageIndexChanging="GV_Prov_List_PageIndexChanging" AutoGenerateColumns="false" Width="100%" PageSize="20">
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
                                    <HeaderStyle Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Tên nhà cung cấp</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate >                                        
                                   
                                            <%#DataBinder.Eval(Container.DataItem, "ProvName")%>                                                                          
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 
                                 <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tổng tiền nợ</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                
                                    <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Total", "{0:#}").ToString())%>
                                       
                                </ItemTemplate>
                            </asp:TemplateField>            
                                                        
                               
                                <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tổng tiền đã trả</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                    <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Datra", "{0:#}").ToString())%>
                                       
                                </ItemTemplate>
                            </asp:TemplateField>    
                            
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tổng tiền trong phiếu chi</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                    
                                       <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "phieuchi", "{0:#}").ToString())%> 
                                </ItemTemplate>
                            </asp:TemplateField>    
                            
                            
                                   <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Tổng tiền còn lại</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                 
                                        <%# objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Sotienconno", "{0:#}").ToString())%> 
                                </ItemTemplate>
                            </asp:TemplateField>    
                            
                            
                            
                            </Columns>
                            <PagerStyle CssClass="leftMenuAdmin" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height: 20" align="left">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
