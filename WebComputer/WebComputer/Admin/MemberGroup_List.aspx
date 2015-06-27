<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MemberGroup_List.aspx.cs" Inherits="WebComputer.Admin.MemberGroup_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left">
                            <%=Lang["MemberGroupManager"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView Width="100%" ID="GV_MemberGroup_List" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Height="18px" Width="5%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="Stt" runat="server"><%=Lang["No"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Height="18px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex +1 %>                                                                                   
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Height="18px" Width="40%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="Stt" runat="server"><%=Lang["GroupName"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Height="18px" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <a href="MemberGroup_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Group_ID")%>" class="leftMenuAdmin">
                                                <%#DataBinder.Eval(Container.DataItem, "GroupName")%>                                             
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Height="18px" Width="15%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="Stt" runat="server"><%=Lang["Status"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#((bool)Eval("Active")) ? Lang["Active"].ToString() : "<font color='red'>" + Lang["UnActive"].ToString() + "</font>"%>                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Height="18px" Width="35%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="Stt" runat="server"><%=Lang["Comment"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            &nbsp;<%#DataBinder.Eval(Container.DataItem, "GroupDesc")%>                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                        <HeaderTemplate>
                                            <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <input type='<%#(Eval("Group_ID").ToString()=="1")?"hidden":"checkbox" %>'  value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Group_ID")%>">
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 20" align="left">
                            <asp:Button CssClass="button" ID="MemberGroup_AddNew" runat="server" OnClick="MemberGroup_AddNew_Click" />
                            <asp:Button CssClass="button" ID="MemberGroup_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="MemberGroup_Delete_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

