<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Logo_Edit.aspx.cs" Inherits="WebComputer.Admin.Logo_Edit" Title="Untitled Page" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["Edit_Logo"].ToString()%></td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1">
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["Language"].ToString()%>
                            </td>
                            <td align="left" class="SpacerTd" style="width: 77%">
                                <cc1:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="textbox" AutoPostBack="true" ID="DDL_Language" runat="server"
                                            OnSelectedIndexChanged="DDL_Language_SelectIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language"
                                            ErrorMessage="Bạn phải chọn ngôn ngữ"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </cc1:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["logoCatName"].ToString()%>
                            </td>
                            <td align="left" class="ListContent">
                                <cc1:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:ListBox CssClass="textbox" ID="LB_CatLogo" runat="server" SelectionMode="Multiple" Visible="false"></asp:ListBox>
                                    </ContentTemplate>
                                </cc1:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["TypeLogo"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:DropDownList CssClass="textbox" ID="DDL_TypeLogo" runat="server">
                                    <asp:ListItem Text=" -- Chọn loại logo quảng cáo -- " Value=""></asp:ListItem>
                                    <asp:ListItem Text="Quảng cáo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Công ty khác" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV_DDL_TypeLogo" CssClass="ListContent" ControlToValidate="DDL_TypeLogo" runat="server" ErrorMessage="Loại quảng cáo logo không thể trống!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["TypeLink"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDL_TypeLink" CssClass="textbox" runat="server">
                                    <asp:ListItem Text=" -- Chọn kiểu liên kết -- " Value=""></asp:ListItem>
                                    <asp:ListItem Text="Liên kết trong trang" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Liên kết ngoài trang" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV_DDL_TypeLink" ControlToValidate="DDL_TypeLink" CssClass="ListContent" runat="server" ErrorMessage="Kiểu liên kết logo không thể trống!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["Location"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDL_Location" CssClass="textbox" runat="server">
                                    <asp:ListItem Text=" -- Chọn vị trí đặt logo  -- " Value=""></asp:ListItem>
                                    <asp:ListItem Text="Menu trái" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Menu phải" Value="1"></asp:ListItem>
                                </asp:DropDownList>                                        
                                <asp:RequiredFieldValidator ID="RFV_DDL_Location" ControlToValidate="DDL_Location" CssClass="ListContent" runat="server" ErrorMessage="Vị trí đặt logo không thể trống!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["Company"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDL_ComId" CssClass="textbox" runat="server">                                            
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["LogoName"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tbLogoName" CssClass="textbox" runat="server" Columns="35"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["LogoPath"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tbLogoURL" CssClass="textbox" runat="server" Columns="35"></asp:TextBox>
                                <font class="ListContent"><%=Lang["Example"].ToString()%></font>
                                <asp:RequiredFieldValidator ID="RFV_tbLogoURL" ControlToValidate="tbLogoURL" CssClass="ListContent" runat="server" ErrorMessage="Đường dẫn logo không thể trống!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["LogoDesc"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tbLogoDesc" CssClass="textbox" runat="server" Columns="45"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["LogoStartDate"].ToString()%>
                            </td>
                            <td align="left">
                                <input type="text" readonly="readonly" value='<%=strLogoStartDate %>' name="FromDatePublic" size="20" class="textbox" />

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
                                <%=Lang["LogoEndDate"].ToString()%>
                            </td>
                            <td align="left">
                                <input type="text" readonly="readonly" value='<%=strLogoEndDate %>' name="EndDatePublic" size="20" class="textbox" />

                                        <script type="text/javascript">
                    if (!document.layers)
                    {
                    document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.EndDatePublic, aspnetForm.EndDatePublic, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                    }
				//-->
                                        </script>
                                <asp:CheckBox ID="cbExpried" CssClass="textbox" runat="server" /><font class="ListContent"><%=Lang["UnExpried"].ToString()%></font>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["FileUpload"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:Image ID="ImgFile" CssClass="textbox" runat="server" />    
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["Active"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                            </td>
                        </tr>
                    </table>                
                </td>
            </tr>
            <tr>
                <td class="Title" style="height:22px" align="left">                            
                    <asp:Button ID="Edit_Logo" runat="server" CssClass="button" OnClick="Edit_Logo_Click" />
                    <input type="reset" id="ResetForm" runat="server" class="button" />
                    <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
