<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Banner_Category.aspx.cs" Inherits="WebComputer.Admin.Banner_Category" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["BannerCatManager"].ToString()%></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GV_BannerCategory" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label id="l1" runat="server"><%=Lang["Text_Order"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="12%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["Language"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "LanguageName")%>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField>
                                <HeaderStyle Width="35%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["CategoryName"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <a class="leftMenuAdmin" href="BannerCat_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>">
                                        <%#DataBinder.Eval(Container.DataItem, "CatName")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField>
                                <HeaderStyle Width="25%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["URL"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "PagePath")%> <br />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField>
                                <HeaderStyle Width="15%" CssClass="SubTitle" Height="20px"/>
                                <HeaderTemplate>
                                    <asp:Label ID="l123" runat="server"><%=Lang["Status"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="center" CssClass="ListContent" Height="20px"/>
                                <ItemTemplate>
                                     <%#(bool)Eval("Active") ? Lang["Active"].ToString() : "<font color='#FF0000'>" + Lang["unActive"].ToString() + "</font>"%>                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="l34" runat="server"><%=Lang["edit"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <a class="leftMenuAdmin" href="BannerCat_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>">
                                        <img src="/Images/Admin/edit_u.gif" alt=" Sửa " style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px"/>
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"].ToString()%>">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px"/>
                                <ItemTemplate>    
                                    <input type="checkbox"  value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle Width="100%" />
                        <EmptyDataTemplate>
                            <asp:Label ID="l11" Width="100%" runat="server" CssClass="ListContent" Height="20px"><%=Lang["EOF"].ToString()%></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height:22px" align="left">
                    <asp:Button ID="AddNew_Banner" runat="server" CssClass="button" OnClick="AddNew_Banner_Click" />
                    <asp:Button ID="Delete_Banner" runat="server" CssClass="button" OnClick="Delete_Banner_Click" OnClientClick="return checkDelete(this.form)" />
                    <asp:Button CssClass="button" ID="bntback" runat="server" Text="Quay lại" OnClientClick="javascript:history.go(-1);" />
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
