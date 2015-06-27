<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Editor_View.aspx.cs" Inherits="WebComputer.Admin.Editor_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>    
        <td>
        <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
            <tr>
                <td class="Title" style="height:22px; width: 70%" align="left"><%=Lang["NewsView"].ToString()%></td>
            </tr>
            <tr>
                <td align="center">
                    <table width="80%" cellspacing="3" cellpadding="3" border="0">
                        <tr>
                            <td align="left" class="style_cat"><%=strCatName%></td>
                        </tr>
                        <tr>
                            <td align="left" class="style_time">cập nhập: <%=strCreateDate%></td>
                        </tr>
                        <tr>
                            <td align="left" class="style_subject"><%=strSubject %></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="0" align="left" border="0" style="margin-right:2px; padding-left: 2px">
		                            <tr>
		                                <td>
		                                    <%=strImage %>
		                                </td>
		                            </tr>
		                        </table>
		                        <p class="style_brief"><%=strBrief %></p>		                                                
                            </td>
                        </tr>    
                        <tr>
                            <td align="left" class="style_content"><%=strContent %></td>
                        </tr>                    
                        <tr>
                            <td align="right" class="style_author"><%=strAuthor%></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td colspan="2" style="height:5px"></td></tr>
            <tr>
                <td class="Title" style="height: 20" align="left">
                    <asp:Button CssClass="button" ID="News_Edit" runat="server" OnClick="News_Edit_Click" />
                    <input type="button" id="Back_View" runat="server" class="button" onclick="javascript:history.go(-1)"/>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Content>
