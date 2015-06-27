<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product_Edit.aspx.cs" Inherits="WebComputer.Admin.Product_Edit" Title="Untitled Page" ValidateRequest ="false" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc_product" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="/Js/Function.js"></script>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
        <table width="98%" border="0" cellpadding="0" cellspacing="1" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px; width: 75%" align="left"><%=Lang["ProductAddNew"].ToString()%></td>
                <td class="Title" style="height:22px" align="left"><%=Lang["ProductImage"].ToString()%></td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" colspan="2" class="ListContent" style="width: 100%; height: 20px; font-weight: bold">
                                <%=Lang["Product_Code"].ToString()%> <br />
                                <asp:textbox id="txtSubject" ReadOnly="true" runat="server" ></asp:textbox >
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" class="ListContent" style="width: 100%; height: 20px; font-weight: bold">
                                <%=Lang["Product_Name"].ToString()%> <br />
                                <asp:textbox  id="Brief" Columns="35" runat="server" ></asp:textbox>
                            </td>
                        </tr> 
                        <tr>
                            <td align="left" colspan="2" class="ListContent" style="width: 100%; height: 20px; font-weight: bold">
                                <%=Lang["Product_Des"].ToString()%> <br />
                                <asp:textbox  id="Textintro" Columns="35" TextMode="MultiLine" Rows="3" runat="server" ></asp:textbox>
                            </td>
                        </tr> 
                        <tr>
                            <td align="left" class="ListContent" style="width: 30%; height: 20px; font-weight: bold">
                                <%=Lang["Product_Price"].ToString()%> <br />
                                <asp:textbox  id="TextCashby" Columns="35" runat="server" ></asp:textbox>                                  
                            </td>
                             <td align="left" class="ListContent" style="width: 70%; height: 20px; font-weight: bold">
                                <br /><asp:DropDownList ID="DDCashby" runat="server">
                                    <asp:ListItem Selected="True" Value="1">[-- VNĐ --]</asp:ListItem>
                                    <asp:ListItem Value="2">[-- USD --]</asp:ListItem>
                                    <asp:ListItem Value="3">[-- EURO --]</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr> 
                        <tr>
                         <td align="left" class="ListContent" style="width: 30%; height: 20px; font-weight: bold">
                                <%=Lang["Product_Quatity"].ToString()%> <br />
                                <asp:textbox  id="Text_Quatity" ReadOnly="true" Columns="35" runat="server" ></asp:textbox>                                  
                            </td>
                        </tr>
                        
                        
                        
                    </table>
                </td>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="top">
                                <a href="JavaScript:openwindow('LibraryImage_Popup.aspx?w=0',770,500);" title="<%=Lang["ChoiceImage"].ToString()%>"><img src="/Images/Admin/insertimagefromgallery.gif" style="border: 0px" alt="" /></a>
                                <%
                                    if (ProductImage != 0)
                                    {
                                        Response.Write(" <span id='spanDeleteIcon'>");
                                        Response.Write("    <a href=\"JavaScript:removeLeadImage()\"><img src=\"/Images/Admin/delete.gif\" border='0'></a>");
                                        Response.Write(" </span>");
                                    }
                                    else
                                        Response.Write("<span id='spanDeleteIcon'></span>");
                                %>                                                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divImg"><%=strProductImage%></div>
                                <input type="hidden" name="LeadImage" value=<%=ProductImage%> />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>  
            <tr>
                <td colspan="2" style="height: 5px"></td>
            </tr>
            <tr>
                <td colspan="2" class="Title" style="height:22px; width: 70%" align="left"><%=Lang["OtherInfo"].ToString()%></td>                                
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td  align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["Status"].ToString()%>                                
                            </td>
                            <td align="left" class="SpacerTd" style="width: 77%">
                                <asp:DropDownList ID="DDL_Status" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["Language"].ToString()%>
                            </td>
                            <td align="left" class="SpacerTd" style="width: 77%">
                                <cc_product:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="textbox" ID="DDL_Language" runat="server" OnSelectedIndexChanged="CatRoot_SelectIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>                                        
                                    </ContentTemplate>
                                </cc_product:UpdatePanel>                            
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["CatName"].ToString()%>
                            </td>
                            <td align="left" class="SpacerTd" style="width: 77%">
                                <cc_product:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td id="CMSProduct_Cat_Root" runat="server"></td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc_product:UpdatePanel>
                            </td>
                        </tr>     
                                     
                        <tr>
                            <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["HostProduct"].ToString()%></td>
                            <td align="left" class="SpacerTd" style="width:77%">
                                <asp:CheckBox ID="cbProductHot" CssClass="textbox" runat="server" />                   
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["OnHomePage"].ToString()%></td>
                            <td align="left" class="SpacerTd" style="width:77%">
                                <asp:CheckBox ID="cbProductOnHomePage" CssClass="textbox" runat="server" /><br />                   
                            </td>
                        </tr>
                    </table>
                </td>                
            </tr>              
        </table>
        </td>
    </tr>
    
    <tr>
     <td align="center">
        <table width="98%" border="0" cellpadding="0" cellspacing="1" style="border: 1px solid #c0c0c0">
            <tr>
                <td colspan="2" style="height: 5px">
                    <asp:Panel ID="PTitle" runat="server" Width="100%">
                            <table width="100%" id="Table1" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="Title" align="left">
                                        <%=Lang["Liveshowimages"].ToString()%>
                                    </td>
                                    <td class="Title" align="right" style="cursor: hand">
                                        <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%" Height="0">
                            <table width="100%" id="Table2" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <cc_product:UpdatePanel ID="IDGallery" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="DL_Images" DataKeyField="ID" RepeatColumns="4" runat="server">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <table width="20%" border="0" cellpadding="3" cellspacing="2">
                                                        <tr>
                                                            <td style="background-color: #EFF0F3"  align="center" >
                                                                <img width="180" src='<%=objEntities.GetPathLibraryImage()%><%#Eval("PhotoID") + "_T.jpg"%>' style="border: 0px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 20px; width: 10%; background-color: #EFF0F3" align="center">
                                                                <input type="checkbox" value="delete" name="chbDelete<%#Eval("ID")%>">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>                                                
                                                </asp:DataList>    
                                            </ContentTemplate>
                                        </cc_product:UpdatePanel>                       
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:30%">
                                                    <cc_product:UpdatePanel ID="PUpload" runat="server">
                                                        <ContentTemplate>
                                                            <asp:FileUpload runat="server" ID="fuImg" /><asp:RequiredFieldValidator ControlToValidate="fuImg" ID="RequiredFieldValidator1"  runat="server" ErrorMessage="Ảnh Upload không để trống"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </cc_product:UpdatePanel>
                                                </td>
                                                <td style="width:70%" align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>           
                                <tr>
                                    <td class="Title" style="height:22px" align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:30%">
                                                    <asp:Button ID="LibraryImage_AddNew" Text="Upload" runat="server" CssClass="button" OnClick="LibraryImage_AddNew_Click" />
                                                    <asp:Button ID="LibraryImage_Delete" Text="Xóa ảnh" runat="server" CssClass="button" OnClick="LibraryImage_Delete_Click" OnClientClick="return checkDelete(this.form)"  />
                                                </td>
                                                <td style="width:70%" align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                    
                            </table>
                        </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="Title" style="height:22px; width: 70%" align="left"><%=Lang["Content"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" valign="top" class="ListContent" style="height:20px"></td>
                <td align="left" class="SpacerTd">
                    <fckeditorv2:fckeditor id="Content" EditorAreaCSS="textbox" runat="server" basepath="/FCKeditor/" Height="450px" Width="98%"></fckeditorv2:fckeditor>
                </td>
            </tr>
            <tr>
                <td class="Title" style="height: 22px" align="left" colspan="2">
                    <asp:Button ID="Products_Edit" runat="server" CssClass="button"  OnClientClick="return checkSubmitToAddNewsProduct(this.form);" OnClick="Products_Edit_Click" />
                    <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                    <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
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
