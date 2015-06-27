<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Category_Pro_List.aspx.cs" Inherits="WebComputer.Admin.Category_Pro" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left">Danh sách loại sản phẩm</td>
                
            </tr>
            <tr>
                <td colspan ="3">
                    <asp:Label ID="lbl_Erro" runat="server" Width="184px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView Width="100%" ID="GV_CatPro" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="8%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l1" runat="server">Số thứ tự</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="12%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server">Danh mục</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "CatName")%>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="48%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server">Chi tiết</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <a href="Category_Pro_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Cat_ID")%>" class="leftMenuAdmin">
                                        <%#DataBinder.Eval(Container.DataItem, "CatDes")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Sửa</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" HorizontalAlign ="Center" />
                                <ItemTemplate>
                                    <a href="Category_Pro_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Cat_ID")%>" class="leftMenuAdmin">
                                        <img alt="Sửa nội dung" src="/Images/Admin/edit_u.gif" style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center"/>
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Cat_ID")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                       
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="CatPro_AddNew" runat="server" OnClick="CatPro_AddNew_Click" />
                    <asp:Button CssClass="button" ID="ProCat_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="ProCat_Delete_Click" />
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
