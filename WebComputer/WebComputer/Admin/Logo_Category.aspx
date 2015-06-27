<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Logo_Category.aspx.cs" Inherits="WebComputer.Admin.Logo_Category" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

<table id="HPLogoCat" width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
           <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0" id="TABLE1" onclick="return TABLE1_onclick()">
                <tr>
                    <td class="Title" style="height:22px" align="left" colspan="2"><%=Lang["LogoCategoryManager"].ToString()%></td>
                </tr>
                <tr>
                    <td>
                    <asp:GridView ID="GV_LogoCategory" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label id="l1" runat="server"><%=Lang["Text_Order"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
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
                                <HeaderStyle Width="24%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["CategoryName"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <a class="leftMenuAdmin" href="LogoCat_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>">
                                        <%#DataBinder.Eval(Container.DataItem, "CatName")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField>
                                <HeaderStyle Width="20%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["URL"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "PagePath")%> <br />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField>
                                <HeaderStyle Width="14%" CssClass="SubTitle" Height="20px"/>
                                <HeaderTemplate>
                                    <asp:Label ID="l123" runat="server"><%=Lang["Status"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="center" CssClass="ListContent" Height="20px"/>
                                <ItemTemplate>
                                     <%#(bool)Eval("Active") ? Lang["Active"].ToString() : "<font color='#FF0000'>" + Lang["unActive"].ToString() + "</font>"%>                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="10%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["Hidden"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <%#(bool)Eval("LBRandom") ? Lang["Random"].ToString() : Lang["Static"].ToString()%>                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="15%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <asp:Label ID="l2" runat="server"><%=Lang["NumberLogo"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "LBNumber")%>
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="l34" runat="server"><%=Lang["edit"].ToString()%></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <a class="leftMenuAdmin" href="LogoCat_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>">
                                        <img src="/Images/Admin/edit_u.gif" alt=" Sửa " style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px"/>
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"].ToString()%>">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign ="Center" />
                                <ItemTemplate>    
                                    <!--input type="checkbox"  value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>"-->
                                    <input type='<%#(Eval("Cat_Id").ToString()=="1" || Eval("Cat_Id").ToString()=="2")?"hidden":"checkbox" %>'  value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Cat_Id")%>">
                                </ItemTemplate>
                            </asp:TemplateField>                
                        </Columns>
                        <EmptyDataRowStyle Width="100%" />
                        <EmptyDataTemplate>
                            <asp:Label ID="l11" runat="server" CssClass="ListContent" Height="20px"><%=Lang["EOF"].ToString()%></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height:20" align="left" colspan="2">
                        <asp:Button CssClass="button" ID="Submit_CatLogo_AddNew" runat="server" OnClick="Submit_CatLogo_AddNew_Click" />   
                        <asp:Button CssClass="button" ID="Submit_CatLogo_Delete" runat="server" OnClientClick="return checkDelete(this.form)" OnClick="Submit_CatLogo_Delete_Click" />
                        <asp:Button CssClass="button" ID="bntback" runat="server" Text="Quay lại" OnClientClick="javascript:history.go(-1);" />
                    </td>
                </tr>
           </table>
        </td>
    </tr>
</table>   
</asp:Content>
