<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cat_Pro_Group_List.aspx.cs" Inherits="WebComputer.Admin.Cat_Pro_Group_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["Cat_Pro_Group_List"].ToString()%></td>
                
            </tr>
            <tr>
                <td colspan = "3">
                    <asp:Label ID="lbl_Erro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView Width="100%" ID="GV_CatPro" AutoGenerateColumns="false" runat="server" AllowPaging="true" OnPageIndexChanging="GV_CatPro_PageIndexChanging" PageSize="15">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="8%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l1" runat="server"><%=Lang["Text_Order"] %></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="20%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["Cat_Pro_Group_Name"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                <a href="Cat_Pro_Group_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "SubCatID")%>" class="leftMenuAdmin">
                                    <%#DataBinder.Eval(Container.DataItem, "SubName")%>
                                    </a>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="20%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["Cat_Pro_Name"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "CatName")%>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="40%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["Cat_Pro_Group_Des"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                
                                        <%#DataBinder.Eval(Container.DataItem, "SubDes")%>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server"><%=Lang["edit"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" HorizontalAlign ="Center" />
                                <ItemTemplate>
                                    <a href="Cat_Pro_Group_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "SubCatID")%>" class="leftMenuAdmin">
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
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"SubCatID")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle Width="100%" CssClass="ListContent" />
                        <EmptyDataTemplate>
                            
                            
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="CatProGroup_AddNew" runat="server" OnClick="CatProGroup_AddNew_Click" />
                    <asp:Button CssClass="button" ID="ProCatGroup_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="ProCatGroup_Delete_Click" />
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
