<%@ Page Language="C#" MasterPageFile="~/User2.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="WebComputer.Home.News" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <div class="font_tintuc"><%=strName%></div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="dtList" runat="server" RepeatDirection="Vertical" Width="100%">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid rgb(204, 204, 204); padding-top: 4px; padding-bottom: 4px;">
                                <div class="news_subject">
                                    <a href="NewsDetails.aspx?NewsID=<%#DataBinder.Eval(Container, "DataItem.News_ID")%>"><%#DataBinder.Eval(Container, "DataItem.Subject")%></a> 
                                    (<%#DataBinder.Eval(Container, "DataItem.CreateDate") %>)
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-top: 1px solid #CCCCCC">
                                    <tr>
                                        <td width="100" valign="top">
                                            <a href="NewsDetails.aspx?NewsID=<%#DataBinder.Eval(Container, "DataItem.News_ID")%>">
                                                <img src="../Uploads/LibraryImages/<%#DataBinder.Eval(Container, "DataItem.PhotoID")%>_T.jpg" />
                                            </a>
                                        </td>
                                        <td valign="top">
                                            <div class="news_brief">
                                                <%#DataBinder.Eval(Container, "DataItem.Brief")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="float: right">
                                            <a class="news_con" href="NewsDetails.aspx?NewsID=<%#DataBinder.Eval(Container, "DataItem.News_ID")%>">Xem tiếp</a> <img src="../images/ten.gif"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px"></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
</asp:Content>
