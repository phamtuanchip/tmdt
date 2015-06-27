<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Banner_AddNew.aspx.cs" Inherits="WebComputer.Admin.Banner_AddNew" Title="Untitled Page" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height: 22px" align="left" colspan="2"><%=Lang["BannerAddNew"].ToString()%></td>
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
                                        <asp:DropDownList CssClass="textbox" AutoPostBack="true" ID="DDL_Language" runat="server" OnSelectedIndexChanged="DDL_Language_SelectIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language"
                                            ErrorMessage="Bạn phải chọn ngôn ngữ"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </cc1:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["BannerCatName"].ToString()%>
                            </td>
                            <td align="left" class="ListContent">
                                <cc1:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:ListBox CssClass="textbox" ID="LB_CatBanner" runat="server" SelectionMode="Multiple" Visible="false"></asp:ListBox>
                                        <asp:RequiredFieldValidator ID="RFV_LB_CatBanner" CssClass="ListContent" runat="server" ControlToValidate="LB_CatBanner" ErrorMessage="Danh mục logo không thể trống!"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </cc1:UpdatePanel>
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
                                <%=Lang["BannerName"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tbBannerName" CssClass="textbox" runat="server" Columns="35"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["BannerPath"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tbBannerURL" CssClass="textbox" runat="server" Columns="35"></asp:TextBox>
                                <font class="ListContent"><%=Lang["Example"].ToString()%></font>
                                <asp:RequiredFieldValidator ID="RFV_tbBannerURL" ControlToValidate="tbBannerURL" CssClass="ListContent" runat="server" ErrorMessage="Đường dẫn logo không thể trống!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["BannerDesc"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tbBannerDesc" CssClass="textbox" runat="server" Columns="45"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["BannerStartDate"].ToString()%>
                            </td>
                            <td align="left">
                                <input type="text" readonly="readonly" value='<%=strBannerStartDate %>' name="FromDatePublic" size="20" class="textbox" />
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
                                <%=Lang["BannerEndDate"].ToString()%>
                            </td>
                            <td align="left">
                                <input type="text" readonly="readonly" value='<%=strBannerEndDate %>' name="EndDatePublic" size="20" class="textbox" />
                                <script type="text/javascript">
                                if (!document.layers)
                                {
                                document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.EndDatePublic, aspnetForm.EndDatePublic, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                                }
		                    //-->
                                </script>&nbsp;
                                <asp:CheckBox ID="cbExpried" CssClass="textbox" runat="server" /><font class="ListContent"><%=Lang["UnExpried"].ToString()%></font>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                <%=Lang["FileUpload"].ToString()%>
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="fuImageName" CssClass="textbox" runat="server" Width="350" />
                                <asp:RequiredFieldValidator ID="RFV_fuImageName" ControlToValidate="fuImageName" CssClass="ListContent" runat="server" ErrorMessage="File upload không thể trống!"></asp:RequiredFieldValidator>
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
                    <asp:Button ID="AddNew_Banner" runat="server" CssClass="button" OnClick="AddNew_Banner_Click" />
                    <input type="reset" id="ResetForm" runat="server" class="button" />
                    <input type="button" id="Back_AddNew" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
