<%@ Page Language="C#" MasterPageFile="~/User2.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="WebComputer.Home.NewsDetails" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Repeater ID="dtRepeater" runat="server">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <div class="font_tintuc"><%#DataBinder.Eval(Container, "DataItem.Subject") %></div>
                            </td>                            
                        </tr>
                        <tr>
                            <td>
                                <p class="lead"><%#DataBinder.Eval(Container, "DataItem.Brief") %></p>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <p><%#DataBinder.Eval(Container, "DataItem.Content") %></p>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td style="height: 20px"></td>
    </tr>
    <tr>
        <td>
            <div style="font-family: Arial; font-style: normal; font-variant: normal; font-weight: bold; font-size: 12px; font-size-adjust: none; font-stretch: normal; -x-system-font: none; color: rgb(138, 0, 0); line-height: 22px; float: left; padding-right: 3px;">
                Các tin khác
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <ul style="margin: 0 0 30px 33px">
            <asp:DataList ID="dtList" runat="server" RepeatDirection="Vertical">
                <ItemTemplate>
                    <li><a href="NewsDetails.aspx?NewsID=<%#DataBinder.Eval(Container, "DataItem.News_ID")%>"><%#DataBinder.Eval(Container, "DataItem.Subject")%></a> 
                                    (<%#DataBinder.Eval(Container, "DataItem.CreateDate") %>)</li>
                </ItemTemplate>
            </asp:DataList>
            </ul>
        </td>
    </tr>
</table>
</asp:Content>
