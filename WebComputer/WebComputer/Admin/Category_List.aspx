<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Category_List.aspx.cs" Inherits="WebComputer.Admin.Category_List" %>
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
                                    <td class="Title" align="left" style="width: 95%">Thông tin tìm kiếm</td>
                                    <td class="Title" align="right" style="cursor: hand">
                                        <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" />
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 521px">
                                <tr>
                                    <td style="width: 357px; height: 11px">
                                        Thông tin tìm kiếm</td>
                                    <td style="width: 164px; height: 11px">
                                        Điều kiện tìm kiếm</td>
                                    <td style="width: 197px; height: 11px">
                                        Ký Tự</td>
                                    <td style="width: 197px; height: 11px">
                                        Tìm Kiếm</td>
                                </tr>
                                <tr>
                                    <td style="width: 357px">
                                        <asp:DropDownList ID="DDL_GroupMember" runat="server" Width="149px">
                                        </asp:DropDownList></td>
                                    <td style="width: 164px">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="139px">
                                        </asp:DropDownList></td>
                                    <td style="width: 197px">
                                        <asp:TextBox CssClass="textbox" ID="txtSearch" runat="server" Width="180px"></asp:TextBox></td>
                                    <td style="width: 197px">
                                        <asp:Button CssClass="button" ID="MemberSearch" runat="server" OnClick="MemberSearch_Click"/></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%" Height="0">
                            <table width="100%" id="Table2" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 22px">
                                       
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%; height: 22px;">
                                        &nbsp;</td>
                                </tr>                                  
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                      
                                    </td>
                                    <td style="width: 77%" align="left">
                                        &nbsp;
                                    </td>
                                </tr>                                
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:23px">
                                    </td>
                                    <td align="left" class="SpacerTd" style="height: 23px">
                                    </td>
                                </tr>
                                <tr><td style="height: 3px" colspan="2"></td></tr>
                                <tr>
                                    <td colspan="2" class="Footer" align="left">
                                        &nbsp;</td>
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
                    <td class="Title" style="height:22px; width: 633px;" align="left">Danh sách loại</td>
                </tr>
                <tr>
                    <td style="width: 633px">
                        <asp:GridView Width="100%" ID="GV_MemberList" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="5%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Stt" runat="server">Mã số</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Group" runat="server">Mã loại</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        &nbsp;<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="15%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Username" runat="server">Tên loại</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <a href="Member_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "CatName")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "CatName")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                     <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="15%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Username" runat="server">Mô tả</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <a href="Member_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "CatName")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "CatDes")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField>
                                    <HeaderStyle Height="18px" Width="8%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Username" runat="server">Trạng thái</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle Height="18px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <a href="Member_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Status")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                           
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" Height="18px" />
                                    <HeaderTemplate>
                                        <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                    </HeaderTemplate>
                                    <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <input type='<%#(Eval("CategoryID").ToString().ToLower()=="admin")?"hidden":"checkbox" %>'  value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"CategoryID")%>">
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height: 20; width: 633px;" align="left">
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
