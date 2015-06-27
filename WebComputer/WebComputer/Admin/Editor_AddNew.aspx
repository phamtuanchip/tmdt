<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Editor_AddNew.aspx.cs" Inherits="WebComputer.Admin.Editor_AddNew" Title="Untitled Page" ValidateRequest="false" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc_product" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="/Js/Function.js"></script>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="1" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px; width: 75%" align="left"><%=Lang["NewsAddNew"].ToString()%></td>
                <td class="Title" style="height:22px" align="left"><%=Lang["NewsImage"].ToString()%></td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" class="ListContent" style="width: 100%; height: 20px; font-weight: bold">
                                <%=Lang["Subject"].ToString()%>
                                <br />
                                <textarea class="textbox" id="txtSubject" runat="server" cols="65" rows="1"></textarea>                                                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 100%; height: 20px; font-weight: bold">
                                <%=Lang["Brief"].ToString()%>
                                <br />
                                <textarea class="textbox" id="Brief" runat="server" cols="65" rows="3"></textarea>                                  
                            </td>
                        </tr> 
                    </table>
                </td>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="top">
                                <a href="JavaScript:openwindow('LibraryImage_Popup.aspx?w=0',770,500);" title="<%=Lang["ChoiceImage"].ToString()%>"><img src="/Images/Admin/insertimagefromgallery.gif" style="border: 0px" alt="" /></a>
                                <span id="spanDeleteIcon"></span>                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divImg"></div>
                                <input type="hidden" name="LeadImage"/>                                
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
                                                <td id="CMSNews_Cat_Root" runat="server"></td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc_product:UpdatePanel>
                            </td>
                        </tr>                        
                        <tr>
                            <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["HostNews"].ToString()%></td>
                            <td align="left" class="SpacerTd" style="width:77%">
                                <asp:CheckBox ID="cbNewsHot" CssClass="textbox" runat="server" />                   
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top: 5px; padding-left: 5px; padding-bottom: 5px;
                                width: 20%" valign="top">
                                <b>
                                    <%=Lang["RelateNews"].ToString()%>
                                </b>
                            </td>
                            <td valign="top" style="padding-top: 5px; padding-left: 5px; padding-bottom: 5px; width: 80%" colspan="2" align="left">
                                <img onclick="javascript:Relate()" style="cursor: hand" src="/Images/Admin/Relate.gif" alt="" />
                                <div id="divRelate" style="display: none">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #C0C0C0">
                                        <tr>
                                            <td colspan="3" align="left" valign="middle" style="height: 27px; background-color: #F7F8FD; background-image: url('/Images/Admin/toolbar.gif'); padding-left: 5px">
                                                <cc_product:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td id="CMSCatRelate" runat="server"></td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </cc_product:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 45%; padding-left: 5px" align="left">
                                                <div id="pEditorCatToRelate">
                                                </div>
                                            </td>
                                            <td style="width: 10%" align="center" valign="middle">
                                                <input type="button" class="button" name="btAdd" value=">>" onclick="JavaScript:AddNews();" /><br />
                                                <input type="button" class="button" name="btRemove" value="<<" onclick="JavaScript:RemoveNews();" /></td>
                                            <td style="width: 45%; padding-left: 15px" align="left">
                                                <select name="SRelateNews" size="7" ondblclick="javascript:RemoveNews();">
                                                    <option value=""><%=Lang["SelectedRelateNews"].ToString()%></option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>                
            </tr>              
        </table>
        </td>
    </tr>
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="1" style="border: 1px solid #c0c0c0">
            <tr>
                <td colspan="2" class="Title" style="height:22px; width: 70%" align="left"><%=Lang["Content"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" valign="top" class="ListContent" style="height:20px"></td>
                <td align="left" class="SpacerTd">
                    <fckeditorv2:fckeditor id="Content" EditorAreaCSS="textbox" runat="server" basepath="/FCKeditor/" Height="550px" Width="98%"></fckeditorv2:fckeditor>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 5px"></td>
            </tr>
            <tr>
                <td class="Title" style="height: 22px" align="left" colspan="2">
                    <asp:Button ID="News_AddNew" runat="server" CssClass="button" OnClientClick="return checkSubmitToAddNews(this.form);" OnClick="News_AddNew_Click" />
                    <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                    <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)" />
                </td>
            </tr> 
        </table>
        </td>
    </tr>
</table>   
</asp:Content>
