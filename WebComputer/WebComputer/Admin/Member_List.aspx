<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Member_List.aspx.cs" Inherits="WebComputer.Admin.Member_List" Title="Untitled Page" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">                
                <tr>
                    <td>
                        <asp:Panel ID="PTitle" runat="server" Width="100%">
                            <table id="Table1" width="100%" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="Title" align="left" style="width: 95%"><%=Lang["SearchInfo"].ToString()%></td>
                                    <td class="Title" align="right" style="cursor: hand">
                                        <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%" Height="0">
                            <table width="100%" id="Table2" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        <%=Lang["GroupName"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <asp:DropDownList ID="DDL_GroupMember" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>                                  
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["UserName"].ToString()%>
                                    </td>
                                    <td style="width: 77%" align="left">
                                        &nbsp;<asp:TextBox CssClass="textbox" ID="txtSearch" runat="server" Width="180px"></asp:TextBox>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["Status"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd">
                                        <asp:DropDownList ID="DDL_Status" runat="server">
                                            <asp:ListItem Value="-1">[Tất cả]</asp:ListItem>
                                            <asp:ListItem Value="1">Hoạt động</asp:ListItem>
                                            <asp:ListItem Value="0">Không hoạt động</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr><td style="height: 3px" colspan="2"></td></tr>
                                <tr>
                                    <td colspan="2" class="Footer" align="left">
                                        <asp:Button CssClass="button" ID="MemberSearch" runat="server" OnClick="MemberSearch_Click"/>
                                    </td>
                                </tr>                                
                            </table>
                        </asp:Panel>
                    </td>
                </tr>                
            </table>
        </td>
    </tr>
    <tr><td style="height: 15px"></td></tr>
    <tr>
        <td>
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                <tr>
                    <td class="Title" style="height:22px" align="left"><%=Lang["MemberList"].ToString()%></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView Width="100%" ID="GV_MemberList" runat="server" AutoGenerateColumns="false">
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
                                    <HeaderStyle Height="18px" Width="15%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Username" runat="server"><%=Lang["UserName"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <a href="Member_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "UserName")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="30%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Group" runat="server"><%=Lang["GroupName"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        &nbsp;<%#DataBinder.Eval(Container.DataItem, "GroupName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Group" runat="server"><%=Lang["Position"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        &nbsp;<%#DataBinder.Eval(Container.DataItem, "Position")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="15%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Group" runat="server"><%=Lang["Status"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#((bool)Eval("Active")) ? Lang["Active"].ToString() : "<font color='red'>" + Lang["UnActive"].ToString() + "</font>"%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="11%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Group" runat="server"><%=Lang["CreateDate"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#objEntities.FormatDateTimeVN(DataBinder.Eval(Container.DataItem, "CreateDate").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" Height="18px" />
                                    <HeaderTemplate>
                                        <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                    </HeaderTemplate>
                                    <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <input type='<%#(Eval("Username").ToString().ToLower()=="admin")?"hidden":"checkbox" %>'  value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"UserName")%>">
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height: 20" align="left">
                        <asp:Button CssClass="button" ID="Member_AddNew" runat="server" OnClick="Member_AddNew_Click" />
                        <asp:Button CssClass="button" ID="Member_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="Member_Delete_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<cc1:CollapsiblePanelExtender ID="LampnCollSpan" runat="server">
    <cc1:CollapsiblePanelProperties SuppressPostBack="true" ImageControlID="LampnColspan"
        CollapsedImage="/Images/Admin/expand.jpg" ExpandedImage="/Images/Admin/collapse.jpg"
        Collapsed="true" TargetControlID="PSearchArea" CollapseControlID="PTitle" ExpandControlID="PTitle">
    </cc1:CollapsiblePanelProperties>
</cc1:CollapsiblePanelExtender>
</asp:Content>
