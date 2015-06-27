<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member_ChangePassword.aspx.cs" Inherits="WebComputer.Admin.Member_ChangePassword" Title="Untitled Page" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Change Password</title>
    <link href="/StyleSheet/StyleSheetAdmin.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnPanelInPut" runat="server" Width="100%">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #C0C0C0">
                    <tr>
                        <th class="Title" align="left" colspan="2">
                            <%=Lang["ChangePass"].ToString()%>
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 5px; padding-left: 5px; width:30%">
                            <%=Lang["OldPass"].ToString()%>
                        </td>
                        <td align="left" style="padding-top: 5px; padding-left: 5px; width:70%">
                            <asp:TextBox CssClass="textbox" ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn phải nhập mật khẩu cũ"
                                ControlToValidate="txtOldPass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 5px; padding-left: 5px">
                            <%=Lang["NewPass"].ToString()%>
                        </td>
                        <td align="left" style="padding-top: 5px; padding-left: 5px">
                            <asp:TextBox CssClass="textbox" ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPass"
                                ErrorMessage="Bạn phải nhập mật khẩu mới"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 5px; padding-left: 5px">
                            <%=Lang["ReTypeNewPass"].ToString()%>
                        </td>
                        <td align="left" style="padding-top: 5px; padding-left: 5px">
                            <asp:TextBox CssClass="textbox" ID="txtRePassNew" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRePassNew"
                                ErrorMessage="Bạn phải nhập lại mật khẩu mới"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPass"
                                ControlToValidate="txtRePassNew" ErrorMessage="Nhập lại mật khẩu mới không đúng"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnPanelResult" runat="server" Width="100%">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:140; border: 1px solid #C0C0C0">
                    <tr>
                        <th class="Title" align="left">
                            <%=Lang["ChangePass"].ToString()%>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Result" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th class="Title" align="left" colspan="2">
                        <asp:Button CssClass="button" ID="Save_ChangePass" runat="server" OnClick="Save_ChangePass_Click" />
                        <input class="button" id="Close_ChangePass" runat="server" type="button" value='<%=strClose %>' onclick="window.close()" />
                    </th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

