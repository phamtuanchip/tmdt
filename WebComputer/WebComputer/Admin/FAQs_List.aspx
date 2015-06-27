<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FAQs_List.aspx.cs" Inherits="WebComputer.Admin.FAQs_List" Title="Untitled Page" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td>
                            <asp:Panel ID="PTitle" runat="server" Width="100%">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="Title" align="left" style="width: 95%">
                                            <%=Lang["FAQsSearchInfor"].ToString()%>
                                        </td>
                                        <td class="Title" align="right" style="cursor: hand">
                                            <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%" Height="0">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" valign="top" class="ListContent" style="width: 20%; height: 20px">
                                            <p style="margin-top: 5px">
                                                <%=Lang["str_Search"].ToString()%>
                                            </p>
                                        </td>
                                        <td align="left" class="SpacerTd" style="width: 80%">
                                            <asp:TextBox ID="strSearch" Columns="35" CssClass="textbox" runat="server"></asp:TextBox>
                                            <br />
                                            <div class="ListContent">
                                                <asp:RadioButton CssClass="textbox" ID="rbSearch1" Checked="true" GroupName="rbSearch"
                                                    runat="server" /><%=Lang["rdSearch1"].ToString()%></div>
                                            <div class="ListContent">
                                                <asp:RadioButton CssClass="textbox" ID="rbSearch" GroupName="rbSearch" runat="server" /><%=Lang["rdSearch"].ToString()%></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Title" style="height: 20" align="left" colspan="2">
                                            <asp:Button CssClass="button" ID="btSearch" runat="server" OnClick="btSearch_Click" />
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
            <td align="center">
                <table width="98%" id="FaqList" runat="server" border="0" cellpadding="0" cellspacing="0"
                    style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 20; width: 70%" align="left">
                            <%=Lang["FAQsManager"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GV_FAQs" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                                PageSize="25" OnPageIndexChanging="GV_FAQs_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                        <HeaderTemplate>
                                            <asp:Label ID="l1" runat="server"><%=Lang["Text_Order"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="45%" CssClass="SubTitle" Height="20px" />
                                        <HeaderTemplate>
                                            <asp:Label ID="l2" runat="server"><%=Lang["Question"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                        <ItemTemplate>
                                            <a class="leftMenuAdmin" href="FAQs_View.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Faqs_Id") %>">
                                                <%#DataBinder.Eval(Container.DataItem, "Question")%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="15%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="L12" runat="server"><%=Lang["Text_Status"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" />
                                        <ItemTemplate>
                                            <%#(bool)Eval("Active") ? Lang["Active"].ToString() : "<font color='#FF0000'>" + Lang["unActive"].ToString() + "</font>"%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="20%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="l3" runat="server"><%=Lang["User_id"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" />
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Q_User")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="20%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="l4" runat="server"><%=Lang["Text_Author"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" />
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Author")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="5%" CssClass="SubTitle" />
                                        <HeaderTemplate>
                                            <asp:Label ID="l34" runat="server"><%=Lang["edit"].ToString()%></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" />
                                        <ItemTemplate>
                                            <a class="leftMenuAdmin" href="FAQs_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Faqs_Id")%>">
                                                <img src="/Images/Admin/edit_u.gif" alt=" Sửa " style="border: 0px" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="10%" CssClass="SubTitle" Height="20px" />
                                        <HeaderTemplate>
                                            <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll"
                                                title="<%=Lang["check_all"]%>">
                                        </HeaderTemplate>
                                        <ItemStyle CssClass="ListContent" Height="20px" />
                                        <ItemTemplate>
                                            <input type='<%#(Eval("Faqs_Id").ToString()=="1")?"hidden":"checkbox" %>' value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Faqs_Id")%>">
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:Label CssClass="ListContent" ID="l34" runat="server"><%=Lang["Eof"].ToString()%></asp:Label>
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="leftMenuAdmin" HorizontalAlign="Left" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 20" align="left">
                            <asp:Button CssClass="button" ID="Submit_FAQs_AddNew" runat="server" OnClick="Submit_FAQs_AddNew_Click" />
                            <asp:Button CssClass="button" ID="Submit_FAQs_Delete" runat="server" OnClientClick="return checkDelete(this.form)"
                                OnClick="Submit_FAQs_Delete_Click" />
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
