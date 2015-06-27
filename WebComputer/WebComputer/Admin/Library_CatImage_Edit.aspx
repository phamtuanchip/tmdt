<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Library_CatImage_Edit.aspx.cs" Inherits="WebComputer.Admin.Library_CatImage_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height: 22px" align="left" colspan="2">
                    <%=Lang["LibraryCatImageEdit"].ToString()%>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["Language"].ToString()%>
                </td>
                <td align="left" class="SpacerTd" style="width: 77%">
                    <asp:DropDownList CssClass="textbox" ID="DDL_Language" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language" ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["CatName"].ToString()%>
                </td>
                <td align="left" class="SpacerTd" style="width: 77%">
                    <asp:TextBox CssClass="textbox" ID="txtCatName" runat="server" Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV_CatName" runat="server" ControlToValidate="txtCatName" ErrorMessage="Tên danh mục không thể trống!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" class="ListContent" style="width: 23%; height: 20px">
                    <%=Lang["Active"].ToString()%>
                </td>
                <td align="left" class="SpacerTd" style="width: 77%">
                    <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height:22px" align="left" colspan="2">
                    <asp:Button ID="Library_CatImages_Edit" runat="server" CssClass="button" OnClick="Library_CatImages_Edit_Click" />
                    <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset"/>
                    <input type="button" id="Back_CatImage_Edit" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
