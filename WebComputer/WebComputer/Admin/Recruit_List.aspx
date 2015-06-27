<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recruit_List.aspx.cs" Inherits="WebComputer.Admin.Recruit_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["RecruitManager"].ToString()%></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView Width="100%" ID="GV_Recruit" AutoGenerateColumns="false" runat="server">
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
                                <HeaderStyle Width="48%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["RecruitTitle"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <a href="Recruit_View.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Recruit_id")%>" class="leftMenuAdmin">
                                        <%#DataBinder.Eval(Container.DataItem, "RecruitmentTitle")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="17%" CssClass="SubTitle" Height="20%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["CreateDate"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                <%#objEntities.FormatDateTimeVN(DataBinder.Eval(Container.DataItem, "CreateDate").ToString())%>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server"><%=Lang["edit"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                    <a href="Recruit_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Recruit_Id")%>" class="leftMenuAdmin">
                                        <img alt="Sửa nội dung" src="/Images/Admin/edit_u.gif" style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Recruit_id")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle Width="100%" CssClass="ListContent" />
                        <EmptyDataTemplate>
                            <%=Lang["EOF"].ToString()%>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="Recruit_AddNew" runat="server" OnClick="Recruit_AddNew_Click" />
                    <asp:Button CssClass="button" ID="Recruit_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="Recruit_Delete_Click" />
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
