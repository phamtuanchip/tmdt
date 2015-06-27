<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gallery_Addnew.aspx.cs" Inherits="WebComputer.Admin.Gallery_Addnew" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <%=Lang["LibraryImageAddNew"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["CatImage"].ToString()%>
                        </td>
                        <td align="left" id="DDL_CatId" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["Desc"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="txtDesc" Columns="55" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["ImageUpload"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:FileUpload ID="fuImg" CssClass="textbox" Width="350" runat="server" />
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Img" runat="server" ControlToValidate="fuImg"
                                ErrorMessage="Ảnh upload không thể trống!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="LibraryImage_AddNew" runat="server" CssClass="button" OnClick="LibraryImage_AddNew_Click" />
                            <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                            <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
