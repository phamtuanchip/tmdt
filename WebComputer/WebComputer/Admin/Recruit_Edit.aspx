<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recruit_Edit.aspx.cs" Inherits="WebComputer.Admin.Recruit_Edit" Title="Untitled Page" ValidateRequest ="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <%=Lang["RecruitEdit"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["Language"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:DropDownList ID="DDL_Language" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language"
                                ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["CatIntroduce"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">                                    
                            <asp:DropDownList CssClass="textbox" ID="DDL_CatId" runat="server">
                                <asp:ListItem Value="">Chọn danh mục</asp:ListItem>
                                <asp:ListItem Value="1">Tuyển dụng Miền Bắc</asp:ListItem>
                                <asp:ListItem Value="2">Tuyển dụng Miền Trung</asp:ListItem>
                                <asp:ListItem Value="3">Tuyển dụng Miền Nam</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV_DDL_CatId" CssClass="ListContent" runat="server" ControlToValidate="DDL_CatId" ErrorMessage="Danh mục không thể trống!"></asp:RequiredFieldValidator>                                    
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["RecruitTitle"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="tbRecruitmentTitle" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_RecruitmentTitle" runat="server"
                                ControlToValidate="tbRecruitmentTitle" ErrorMessage="Tiêu đề tuyển dụng không thể trống!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["StartDate"].ToString()%>
                        </td>
                        <td align="left">
                            <input type="text" readonly="readonly" value='<%=strFromDate %>' name="FromDatePublic" size="20" class="textbox" />

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
                            <%=Lang["EndDate"].ToString()%>
                        </td>
                        <td align="left">
                            <input type="text" readonly="readonly" value='<%=strEnddate %>' name="EndDatePublic" size="20" class="textbox" />

                            <script type="text/javascript">
                    if (!document.layers)
                    {
                    document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.EndDatePublic, aspnetForm.EndDatePublic, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                    }
				//-->
                            </script>

                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["Status"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="Title" colspan="2">
                            <%=Lang["Content"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="ListContent" style="height: 20px">
                        </td>
                        <td align="left" class="SpacerTd">
                            <FCKeditorV2:FCKeditor ID="Content" EditorAreaCSS="textbox" runat="server" BasePath="/FCKeditor/" Height="450px" Width="98%"></FCKeditorV2:FCKeditor>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="Recruits_Edit" runat="server" CssClass="button" OnClick="Recruits_Edit_Click" />
                            <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
