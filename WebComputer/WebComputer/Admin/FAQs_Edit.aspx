<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FAQs_Edit.aspx.cs" Inherits="WebComputer.Admin.FAQs_Edit" Title="Untitled Page" ValidateRequest="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <%=Lang["FAQsEdit"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["Language"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:DropDownList ID="DDL_Lang" runat="server" CssClass="textbox">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_DDL_Lang" ControlToValidate="DDL_Lang"
                                runat="server" ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["User_id"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtQ_User" runat="server" Columns="35" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="height: 20px">
                            <%=Lang["Email"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtQ_Email" runat="server" Columns="35" CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQ_Email"
                                ErrorMessage="Bạn chưa nhập địa chỉ Email ?"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtQ_Email"
                                ErrorMessage="Email chưa đúng định dạng" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="height: 20px">
                            <%=Lang["Text_Author"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtAuthor" runat="server" Columns="35" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="height: 20px">
                            <%=Lang["VideoActive"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:CheckBox ID="txtActive" runat="server" CssClass="textbox" />
                        </td>
                    </tr>
                    <tr>
                        <th align="left" class="Title" colspan="2">
                            <%=Lang["content"].ToString()%>
                        </th>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="ListContent" style="height: 20px">
                            <%=Lang["Question"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Columns="50" Rows="3"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_txtQuestion" runat="server"
                                ControlToValidate="txtQuestion" ErrorMessage="Câu hỏi không thể trống!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="ListContent" style="height: 20px">
                            <%=Lang["Answer"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <FCKeditorV2:FCKeditor ID="Content" EditorAreaCSS="textbox" runat="server" BasePath="/FCKeditor/"
                                Height="230px" ToolbarSet="Basic" Width="98%">
                            </FCKeditorV2:FCKeditor>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="FAQ_Edit" runat="server" CssClass="button" OnClick="FAQ_Edit_Click" />
                            <input type="reset" id="ResetForm" runat="server" class="button" value="Reset" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
