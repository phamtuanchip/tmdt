<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Member_Edit.aspx.cs" Inherits="WebComputer.Admin.Member_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <th class="Title" align="left" colspan="2">
                            <%=Lang["EditMember"].ToString()%>
                        </th>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd" style="width: 23%">
                            <%=Lang["GroupName"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:DropDownList ID="DDL_GroupMember" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["UserName"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox CssClass="textbox" ID="txtUserName" runat="server" Columns="40" ReadOnly="True"></asp:TextBox>                            
                            <input id="bntChangePass" class="button" type="button" value='<%=strChangPass %>' onclick='JavaScript:openwindow1("Member_ChangePassword.aspx?id=<%=strUser%>","600","200");' />
                        </td>
                    </tr>                    
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Active"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:CheckBox ID="chkIsActive" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th class="Title" align="left" colspan="2">
                            <%=Lang["OtherInfo"].ToString()%>
                        </th>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["FullName"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtFullName" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Address"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtAddress" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Sex"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:DropDownList ID="DDL_Sex" runat="server">
                                <asp:ListItem Value="1">Nam</asp:ListItem>
                                <asp:ListItem Value="0">Nữ</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Company"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtCompany" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Position"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtPosi" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 24px" class="SpacerTd">
                            <%=Lang["Email"].ToString()%>
                        </td>
                        <td align="left" style="height: 24px" class="SpacerTd">
                            <asp:TextBox ID="txtEmail" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Bạn chưa nhập địa chỉ Email ?"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Email chưa đúng định dạng!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Tel"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtTel" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Mobile"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtMobi" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="SpacerTd">
                            <%=Lang["Fax"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <asp:TextBox ID="txtFax" runat="server" Columns="40" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr><td colspan="2" style="height:5px"></td></tr>
                    <tr>
                        <th colspan="2" class="Title" align="left">
                            <asp:Button ID="Members_Edit" CssClass="button" runat="server" OnClick="Members_Edit_Click" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </th>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
