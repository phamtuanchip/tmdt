<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogoCat_Edit.aspx.cs" Inherits="WebComputer.Admin.LogoCat_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2"><%=Lang["LogoCatEdit"].ToString()%></td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width:23%; height:20px"><%=Lang["Language"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%">
                    <asp:DropDownList ID="DDL_Language" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language" ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="height:20px"><%=Lang["CatName"].ToString()%></td>
                <td align="left" class="SpacerTd">
                    <asp:TextBox ID="tbCatName" runat="server" CssClass="textbox" Width="200"></asp:TextBox>                    
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_CatName" runat="server" ControlToValidate="tbCatName" ErrorMessage="Tên danh mục không thể trống!"></asp:RequiredFieldValidator>          
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="height:20px"><%=Lang["URL_Cat"].ToString()%></td>
                <td align="left" class="SpacerTd">
                    <asp:TextBox ID="tbPagePath" runat="server" CssClass="textbox" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="height:20px"><%=Lang["LogoNumber"].ToString()%></td>
                <td align="left" class="SpacerTd">
                    <asp:TextBox ID="tbLBNumber" runat="server" CssClass="textbox" Width="20"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="ListContent"  ID="RFV_LBNumber" runat="server" ControlToValidate="tbLBNumber" ErrorMessage="Số lượng logo không thể trống!"></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator CssClass="ListContent" ID="REV_LBNumber" runat="server" ControlToValidate="tbLBNumber" ErrorMessage="Số lượng logo phải là số!" ValidationExpression="\d{1,3}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="height:20px"><%=Lang["LogoDisplay"].ToString()%></td>
                <td align="left" class="SpacerTd">
                    <asp:RadioButton ID="RB_LBRandom1" GroupName="RB_LBRandom" CssClass="textbox" runat="server" /><font class="ListContent"><%=Lang["DisplayRandom"].ToString()%></font>&nbsp;
                    <asp:RadioButton ID="RB_LBRandom0" GroupName="RB_LBRandom" CssClass="textbox" runat="server" /><font class="ListContent"><%=Lang["DisplayASC"].ToString()%></font>                    
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="height:20px"><%=Lang["Active"].ToString()%></td>
                <td align="left" class="SpacerTd">
                    <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2">
                    <asp:Button ID="EditCatLogo" runat="server" CssClass="button" OnClick="EditCatLogo_Click" />
                    <input type="reset" id="ResetForm" runat="server" class="button" />
                    <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
