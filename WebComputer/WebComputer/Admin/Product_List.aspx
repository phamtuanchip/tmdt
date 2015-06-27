<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product_List.aspx.cs" Inherits="WebComputer.Admin.Product_List" Title="Untitled Page" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript"></script>
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
                                    <td align="left" class="ListContent" style="width: 23%; height: 31px">
                                        <%=Lang["CatName"].ToString()%>
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%; height: 31px;">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td id="CMSProduct_Cat_Root" runat="server" style="height: 11px"></td>
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
                    <td class="Title" style="height:22px" align="left"><%=Lang["ProductListManager"].ToString()%></td>
                </tr>
                <tr>
                    <td colspan ="3">
                    
                    
                    
                        <asp:Label ID="lblErro" runat="server" Text="Label"></asp:Label>
                    
                    
                    
                    
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GV_Product_List" runat="server" AllowPaging="true" OnPageIndexChanging="GV_Product_List_PageIndexChanging" AutoGenerateColumns="false" Width="100%">
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
                                    <HeaderStyle Width="8%" CssClass="SubTitle" />
                                     
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server"><%=Lang["Product_Code"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="8%"  />
                                    <ItemTemplate>
                                        <a href="Product_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Product_Id")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "Product_Id")%>
                                        </a>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server"><%=Lang["Product_Name"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemTemplate>&nbsp; 
                                    <a href="Product_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Product_Id")%>" class="leftMenuAdmin">                                       
                                        <%#DataBinder.Eval(Container.DataItem, "Product_Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" Width="13%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Tên nhóm sản phẩm</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>&nbsp;                                        
                                       <%#DataBinder.Eval(Container.DataItem, "SubName") %>
                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProDate" runat="server"><%=Lang["Product_Price"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#objfun.ChangeTypeMoney(DataBinder.Eval(Container.DataItem, "Product_Price","{0:#}").ToString())%> <%#DataBinder.Eval(Container.DataItem, "CashbyName")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="8%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProQuatity" runat="server"><%=Lang["Product_Quatity"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Product_QUatityOut", "{0:#}")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server"><%=Lang["Status"].ToString()%></asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        &nbsp;<%#DataBinder.Eval(Container.DataItem, "Status_Name")%>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="SubTitle" />
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
                                    <a href="Product_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Product_Id")%>" class="leftMenuAdmin">
                                        <img alt="Sửa nội dung" src="/Images/Admin/edit_u.gif" style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                 <ItemStyle HorizontalAlign="Center" />
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="<%=Lang["check_all"]%>">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" />
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"Product_ID")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="leftMenuAdmin" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height: 20" align="left">
                        <asp:Button CssClass="button" ID="Product_Delete" runat="server" OnClientClick="return checkDeleteProduct(this.form)" OnClick="Product_Delete_Click" />
                        <asp:Button CssClass="button" ID="Product_Start" Text="Hoạt động" runat="server" OnClientClick="return checkStartProduct(this.form)" OnClick="Product_Start_Click" />
                        <asp:Button CssClass="button" ID="Product_Off" Text="Không hoạt động" runat="server" OnClientClick="return checkStartProduct(this.form)" OnClick="Product_Off_Click" />
                        <asp:Button CssClass="button" ID="Btn_AddNewProduct" Text="Thêm mới sản phẩm" runat="server" OnClientClick="return checkStartProduct(this.form)" OnClick="Btn_AddNewProduct_Click" />
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
