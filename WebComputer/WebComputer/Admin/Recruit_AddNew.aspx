<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recruit_AddNew.aspx.cs" Inherits="WebComputer.Admin.Recruit_AddNew" Title="Untitled Page" ValidateRequest ="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2"><%=Lang["RecruitAddNew"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["Language"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%">
                    <asp:DropDownList ID="DDL_Language" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language" ErrorMessage="Hãy ch?n ngôn ng?!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["CatIntroduce"].ToString()%>
                </td>
                <td align="left" class="SpacerTd">                                    
                    <asp:DropDownList CssClass="textbox" ID="DDL_CatId" runat="server">
                        <asp:ListItem Value="">Ch?n danh m?c</asp:ListItem>
                        <asp:ListItem Value="1">Tuy?n d?ng Mi?n B?c</asp:ListItem>
                        <asp:ListItem Value="2">Tuy?n d?ng Mi?n Trung</asp:ListItem>
                        <asp:ListItem Value="3">Tuy?n d?ng Mi?n Nam</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFV_DDL_CatId" CssClass="ListContent" runat="server" ControlToValidate="DDL_CatId" ErrorMessage="Danh m?c không th? tr?ng!"></asp:RequiredFieldValidator>                                    
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["RecruitTitle"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%">
                    <asp:TextBox ID="tbRecruitmentTitle" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_RecruitmentTitle" runat="server" ControlToValidate="tbRecruitmentTitle" ErrorMessage="Tiêu ?? tuy?n d?ng không th? tr?ng!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["StartDate"].ToString()%>
                </td>
                <td align="left">
                    <input type="text" readonly="readonly" name="FromDatePublic" size="20" class="textbox" />

                                <script type="text/javascript">
                    if (!document.layers)
                    {
                    document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.FromDatePublic, aspnetForm.FromDatePublic, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                    }
				//-->
                                </script>                                       
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["EndDate"].ToString()%>
                </td>
                <td align="left">
                    <input type="text" readonly="readonly" name="EndDatePublic" size="20" class="textbox" />

                                <script type="text/javascript">
                    if (!document.layers)
                    {
                    document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.EndDatePublic, aspnetForm.EndDatePublic, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                    }
				//-->
                                </script>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["Active"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%">
                    <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                </td>
            </tr>
            <tr><td style="height: 5px" colspan="2"></td></tr>
            <tr>
                <td align="left" class="Title" colspan="2"><%=Lang["Content"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" valign="top" class="ListContent" style="height:20px"></td>
                <td align="left" class="SpacerTd">
                    <fckeditorv2:fckeditor id="Content" EditorAreaCSS="textbox" runat="server" basepath="/FCKeditor/" Height="450px" Width="98%"></fckeditorv2:fckeditor>
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2">
                    <asp:Button ID="Recruit_AddNews" runat="server" CssClass="button" OnClick="Recruit_AddNews_Click" />
                    <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset"/>
                    <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>

</asp:Content>
