<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="WebComputer.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Login</title>
    <link href="StyleSheet/StyleSheetAdmin.css" rel = "stylesheet" type ="text/css" /> 
</head>
<body style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 29px; height: 618px; background-image: url(/Images/Admin/bkgd_left_column.gif)"
                        valign="top">
                        <img src="../Images/Admin/bkgd_left_column.gif" alt="" />
                    </td>
                    <td style="width: 100%; height: 618px;" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" valign="top" style="background-image: url(/Images/Admin/banner_top_bkg.gif)"
                                    align="left">
                                    <img src="/Images/Admin/banner_top.gif"alt="" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 83%; height: 30px;">
                                    <img src="../Images/Admin/top_curve.gif" alt="" /></td>
                                <td style="width: 17%; background-color: #70B226; height: 30px;" align="center">
                                    <asp:HyperLink ID="HplHomePage" runat="server" NavigateUrl="/" CssClass="White">Trang chủ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left" style="padding-left: 20px">
                                    <table border="0" width="98%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 76%; height: 500px" valign="top">
                                                <table width="50%" border="0" cellspacing="0" cellpadding="2" style="border: 1px solid #c0c0c0">
                                                    <tr>
                                                        <td colspan="2" style="padding-left: 10px; height: 20px; background-image: url(/Images/Admin/projectbox_bkg.gif)">
                                                            <b>
                                                                <%=Lang["LoginSystem"]%>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left: 10px">
                                                            <%=Lang["UserName"]%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                                                ErrorMessage="Tên truy nhập ?"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left: 10px">
                                                            <%=Lang["Password"]%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                                ErrorMessage="Bạn chưa nhập mật khẩu ?"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <%--<a href="JavaScript:void(0);" onclick="JavaScript:openkb();" title="Bàn phím ảo">
                                                            <img src="/Images/Admin/keyboard.gif" style="border:0px" alt="Bàn phím ảo" /></a>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="padding-left: 10px">
                                                            <asp:Button CssClass="button" ID="bntLogin" runat="server" Text="Đăng nhập" OnClick="bntLogin_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="background-color: #959595" valign="top" id="AdminFooter" runat="server">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1; height: 618px; background-image: url(/Images/Admin/bkgd_right_column.gif)">
                        <img src="../Images/Admin/bkgd_right_column.gif" alt="" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

