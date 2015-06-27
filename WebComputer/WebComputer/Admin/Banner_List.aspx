<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Banner_List.aspx.cs" Inherits="WebComputer.Admin.Banner_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px" align="left"><%=Lang["BannerManager"].ToString()%></td>
            </tr>
            <tr>
                    <td align="center">
                        <asp:DataList ID="DL_Banner" DataKeyField="Banner_ID" RepeatColumns="1" runat="server">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <table width="20%" border="0" cellpadding="3" cellspacing="2">
                                <tr>
                                    <td style="background-color: #EFF0F3" colspan="3" align="center">
                                        <a href="Banner_View.aspx?id=<%#Eval("Banner_ID")%>">
                                            <img width="468" src='<%=objEntities.GetPathBanner()%><%#Eval("ImageName")%>' alt='<%#Eval("BannerDesc")%>' style="border: 0px" />
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px; width: 10%; background-color: #EFF0F3" align="center">
                                        <input type="checkbox" value="delete" name="chbDelete<%#Eval("Banner_ID")%>">
                                    </td>
                                    <td style="height: 20px; width: 75%; background-color: #EFF0F3; padding-left: 5px" align="left">
                                        <a href="Banner_Edit.aspx?id=<%#Eval("Banner_ID")%>" title="Sửa thông tin logo" class="leftMenuAdmin"><%#Eval("BannerName")%></a>
                                    </td>
                                    <td style="background-color: #EFF0F3" align="center"><%#Get_Language(int.Parse(Eval("Language_Id").ToString()))%></td>
                                </tr>
                            </table>
                        </ItemTemplate>                                                
                        </asp:DataList>                           
                    </td>
                </tr>
                <tr>
                    <td class="Title" style="height:22px" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width:45%">
                                    <asp:Button ID="Banner_AddNew" runat="server" CssClass="button" OnClick="Banner_AddNew_Click" />
                                    <asp:Button ID="Delete_Banner" runat="server" CssClass="button" OnClientClick="return checkDelete(this.form)" OnClick="Delete_Banner_Click" />                                    
                                    <asp:Button CssClass="button" ID="bntback" runat="server" Text="Quay lại" OnClientClick="javascript:history.go(-1);" />
                                </td>
                                <td style="width:55%" align="right">
                                    <asp:Label ID="Label1" CssClass="button" runat="server" Text="Trang:"></asp:Label>&nbsp;<asp:HyperLink ID="lnkPrev" runat="server"><img src="/Images/Admin/home.gif" alt="Trang trước" style="border: 0px" /></asp:HyperLink>&nbsp;
                                    <asp:Label ID="ListPage" CssClass="button" runat="server"></asp:Label>
                                    <asp:HyperLink ID="lnkNext" runat="server"><img src="/Images/Admin/end.gif" alt="Trang sau" style="border: 0px" /></asp:HyperLink>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
