﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Provider_List.aspx.cs" Inherits="WebComputer.Admin.Provider_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                <tr>
                    <td class="Title" style="height:22px" align="left">Danh sách nhà cung cấp</td>
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
                                    <a href="Provider_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ProvID")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "ProvName")%>                                                                          
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                    <HeaderStyle Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">WebSite</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate >                                        
                                            <%#DataBinder.Eval(Container.DataItem, "Website")%>                                                                          
                                    </ItemTemplate>
                                </asp:TemplateField>           
                                
                                 
                                
                                <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Sửa</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                    <a href="Provider_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ProvID")%>" class="leftMenuAdmin">
                                        <img alt="Sửa nội dung" src="/Images/Admin/edit_u.gif" style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="Chọn tất cả">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"ProvID")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="leftMenuAdmin" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height: 20" align="left">
                     <asp:Button CssClass="button" ID="Prov_Add" runat="server" OnClick="Prov_Add_Click" />
                        <asp:Button CssClass="button" ID="Provider_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="Provider_Delete_Click" Text="Xóa" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
