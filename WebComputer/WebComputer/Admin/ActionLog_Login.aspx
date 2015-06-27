<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActionLog_Login.aspx.cs" Inherits="WebComputer.Admin.ActionLog_Login" Title="Untitled Page" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc1" %>

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
                                        <td class="Title" align="left" style="width: 95%">
                                            <%=Lang["SearchInfo"].ToString()%>
                                        </td>
                                        <td class="Title" align="right" style="cursor: hand">
                                            <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%"
                                Height="0">
                                <table width="100%" id="Table2" runat="server" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                            <%=Lang["UserName"].ToString()%>
                                        </td>
                                        <td align="left" class="SpacerTd" style="width: 77%">
                                            <asp:TextBox CssClass="textbox" ID="txtUserName" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                            <%=Lang["IpAddRess"].ToString()%>
                                        </td>
                                        <td style="width: 77%" class="SpacerTd" align="left">
                                            <asp:TextBox CssClass="textbox" ID="txtIP" runat="server" Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
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
                                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
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
                                    <tr>
                                        <td style="height: 3px" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="Footer" align="left">
                                            <asp:Button CssClass="button" ID="ActionLoginSearch" runat="server" OnClick="ActionLoginSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left">
                            <%=Lang["ActionLogAction"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UpdatePanel ID="UpdatePN" runat="server">
                                <ContentTemplate>
                                    <asp:GridView Width="100%" ID="GV_ActionLogin" runat="server" OnPageIndexChanging="GV_ActionLogin_PageIndexChanging"
                                        AutoGenerateColumns="false" AllowPaging="True" PageSize="25">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle Height="18px" Width="5%" CssClass="SubTitle" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Stt" runat="server"><%=Lang["No"].ToString()%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle Height="18px" Width="25%" CssClass="SubTitle" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Username" runat="server"><%=Lang["LoginDate"].ToString()%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    &nbsp;<%#DataBinder.Eval(Container.DataItem, "ActionDateTime") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle Height="18px" Width="20%" CssClass="SubTitle" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Group" runat="server"><%=Lang["UserName"].ToString()%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    &nbsp;<%#DataBinder.Eval(Container.DataItem, "UserName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle Height="18px" Width="25%" CssClass="SubTitle" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Group" runat="server"><%=Lang["IpAddRess"].ToString()%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    &nbsp;<%#DataBinder.Eval(Container.DataItem, "Ip") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle Height="18px" Width="25%" CssClass="SubTitle" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Group" runat="server"><%=Lang["Action"].ToString()%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle CssClass="leftMenuAdmin" Height="18px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    &nbsp;<%#((bool)Eval("Status")) ? Lang["Complete"].ToString() : "<font color='red'>" + Lang["UnComplete"].ToString() + "</font>"%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle Font-Underline="True" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </cc1:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 20" align="left">
                            <input id="bntLogin_Delete" class="button" type="button" value='<%=strLogin_Delete %>'
                                onclick='JavaScript:openwindow1("ActionLogin_Delete.aspx","420","140");' />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <cc1:CollapsiblePanelExtender ID="CollSpan" runat="server">
        <cc1:CollapsiblePanelProperties SuppressPostBack="true" ImageControlID="CollSpan"
            CollapsedImage="/Images/Admin/expand.jpg" ExpandedImage="/Images/Admin/collapse.jpg"
            Collapsed="true" TargetControlID="PSearchArea" CollapseControlID="PTitle" ExpandControlID="PTitle">
        </cc1:CollapsiblePanelProperties>
    </cc1:CollapsiblePanelExtender>
</asp:Content>
