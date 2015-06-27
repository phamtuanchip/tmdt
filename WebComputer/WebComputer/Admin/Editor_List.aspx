<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Editor_List.aspx.cs" Inherits="WebComputer.Admin.Editor_List" Title="Untitled Page" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">                
                <tr>
                    <td>
                        <asp:Panel ID="PTitle" runat="server" Width="100%">
                            <table width="100%" id="Table1" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="Title" align="left" style="width: 95%"><%=Lang["SearchInfo"].ToString()%></td>
                                    <td class="Title" align="right" style="cursor: hand">
                                        <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%" Height="0">
                            <table width="100%" id="Table2" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        <%=Lang["Status"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td id="CMSStatus_Id" runat="server"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr> 
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        <%=Lang["CatName"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td id="CMSNews_Cat_Root" runat="server"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                  
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["SearchInfo"].ToString()%>
                                    </td>
                                    <td style="width: 75%" align="left">
                                        &nbsp;<asp:TextBox CssClass="textbox" ID="txtSearch" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">                                        
                                    </td>
                                    <td style="width: 75%" align="left">
                                        <asp:RadioButton ID="SearchIn" Checked="true" Text="Tìm theo tiêu đề" runat="server"
                                            GroupName="SearchFollow" /><br />
                                        <asp:RadioButton ID="SearchIn01" Text="Tìm theo tiêu đề và tóm tắt" runat="server"
                                            GroupName="SearchFollow" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["FromDate"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd">
                                        <input type="text" readonly="readonly" name="FromDate" size="20" class="textbox" />
                                        <script type="text/javascript">
                                            if (!document.layers)
                                            {
                                                document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.FromDate, aspnetForm.FromDate, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                                            }				
                                        </script>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["ToDate"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd">
                                        <input type="text" readonly="readonly" name="ToDate" size="20" class="textbox" />
                                        <script type="text/javascript">
                                            if (!document.layers)
                                            {
                                                document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.ToDate, aspnetForm.ToDate, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                                            }
                                        </script>
                                    </td>
                                </tr>
                                <tr><td style="height: 3px" colspan="2"></td></tr>
                                <tr>
                                    <td colspan="2" class="Footer" align="left">
                                        <asp:Button CssClass="button" ID="bntSearch" runat="server" OnClick="bntSearch_Click"/>
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
                    <td class="Title" style="height:22px" align="left"><%=Lang["NewsListManager"].ToString()%></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GV_News_List" runat="server" AllowPaging="true" OnPageIndexChanging="GV_News_List_PageIndexChanging" AutoGenerateColumns="false" Width="100%" PageSize="20">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Stt" runat="server"><%=Lang["No"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            
                                <asp:TemplateField>
                                    <HeaderStyle Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server"><%=Lang["TitleSubject"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <a href="Editor_View.aspx?id=<%#DataBinder.Eval(Container.DataItem, "News_Id")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "Subject")%>
                                        </a>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" Width="18%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server"><%=Lang["CategoryName"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>&nbsp;                                        
                                        <%#DataBinder.Eval(Container.DataItem, "CatName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server"><%=Lang["Status"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        &nbsp;<%#DataBinder.Eval(Container.DataItem, "StatusName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProDate" runat="server"><%=Lang["Author"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Author")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="12%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProDate" runat="server"><%=Lang["CreatedDate"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
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
                                    <a href="Editor_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "News_Id")%>" class="leftMenuAdmin">
                                        <img alt="Sửa nội dung" src="/Images/Admin/edit_u.gif" style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"News_Id")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="leftMenuAdmin" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height: 20" align="left">
                        <asp:Button CssClass="button" ID="News_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="News_Delete_Click" />
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
