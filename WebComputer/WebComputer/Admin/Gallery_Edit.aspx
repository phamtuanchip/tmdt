<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gallery_Edit.aspx.cs" Inherits="WebComputer.Admin.Gallery_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <%=Lang["LibraryImageEdit"].ToString()%>
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
                            <asp:Image CssClass="textbox" ID="IDImg" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="LibraryImage_Edit" runat="server" CssClass="button" OnClick="LibraryImage_Edit_Click" />
                            <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
