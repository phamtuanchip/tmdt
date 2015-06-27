<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cat_Pro_Group_Add.aspx.cs" Inherits="WebComputer.Admin.Cat_Pro_Group_Add" Title="Untitled Page" ValidateRequest ="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2"><%=Lang["CatProAddNew"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:24px"><%=Lang["Language"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%; height: 24px;">
                    <asp:DropDownList ID="DDL_Language" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language" ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["CatProNameLis"].ToString()%>
                </td>
                <td align="left" class="SpacerTd">                                    
                    <asp:DropDownList CssClass="textbox" ID="DDL_CatId" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFV_DDL_CatId" CssClass="ListContent" runat="server" ControlToValidate="DDL_CatId" ErrorMessage="Danh mục không thể trống!"></asp:RequiredFieldValidator>                                    
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px">Tên nhóm sản phẩm</td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="tb_CatProGroup_Title" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_RecruitmentTitle" runat="server" ControlToValidate="tb_CatProGroup_Title" ErrorMessage="Tiêu đề tuyển dụng không thể trống!"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:26px"><%=Lang["Active"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%; height: 26px;">
                    <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                </td>
            </tr>
            <tr><td style="height: 5px" colspan="2"></td></tr>
            <tr>
                <td align="left" class="Title" colspan="2"><%=Lang["CatProDes"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" valign="top" class="ListContent" style="height:20px"></td>
                <td align="left" class="SpacerTd">
                    <fckeditorv2:fckeditor id="CatProGroupDes" EditorAreaCSS="textbox" runat="server" basepath="/FCKeditor/" Height="450px" Width="98%"></fckeditorv2:fckeditor>
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2">
                    <asp:Button ID="CatProGroup_AddNew" runat="server" CssClass="button" OnClick="CatProGroup_AddNew_Click" />
                    <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset"/>
                    <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
