<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FAQs_View.aspx.cs" Inherits="WebComputer.Admin.FAQs_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left">
                            <%=Lang["FAQsView"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center" style="padding-top: 5px; padding-bottom: 5px">
                            <table width="90%" border="0" cellspacing="2" cellpadding="1" style="border: 1px solid #C0C0C0">
                                <tr>
                                    <td align="left">
                                        <p style="margin-left: 3px; font-family: Verdana; height: 20px; font-size: 10pt;
                                            color: #494A46; font-weight: 700">
                                            <%=this.strQuestion%>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <p style="margin-left: 3px">
                                            <font style="font-family: Verdana; height: 20px; font-size: 8pt; color: #494A46;
                                                font-weight: 700">
                                                <%=Lang["CreateDate"].ToString()%>
                                                :</font><font style="margin-left: 3px; font-family: Verdana; font-size: 8pt; color: #494A46;"><%=dtCreateDate%></font></p>
                                    </td>
                                </tr>
                                <%if (dtAnswerDate != "")
                  {%>
                                <tr>
                                    <td align="left">
                                        <p style="margin-left: 3px">
                                            <font style="font-family: Verdana; height: 20px; font-size: 8pt; color: #494A46;
                                                font-weight: 700">
                                                <%=Lang["AnswerDate"].ToString()%>
                                                :</font><font style="margin-left: 3px; font-family: Verdana; font-size: 8pt; color: #494A46;"><%=dtAnswerDate%></font></p>
                                    </td>
                                </tr>
                                <%} %>
                                <%if (strQ_User != "")
                  {%>
                                <tr>
                                    <td align="left">
                                        <p style="margin-left: 3px">
                                            <font style="font-family: Verdana; height: 20px; font-size: 8pt; color: #494A46;
                                                font-weight: 700">
                                                <%=Lang["User_id"].ToString()%>
                                                :</font><font style="margin-left: 3px; font-family: Verdana; font-size: 8pt; color: #494A46;"><%=strQ_User%></font></p>
                                    </td>
                                </tr>
                                <%} %>
                                <%if (strQ_Email != "")
                  {%>
                                <tr>
                                    <td align="left">
                                        <p style="margin-left: 3px">
                                            <font style="font-family: Verdana; height: 20px; font-size: 8pt; color: #494A46;
                                                font-weight: 700">
                                                <%=Lang["Email"].ToString()%>
                                                :</font><font style="margin-left: 3px; font-family: Verdana; font-size: 8pt; color: #494A46;"><%=strQ_Email%></font></p>
                                    </td>
                                </tr>
                                <%} %>
                                <%if (strQuestion != "")
                  {%>
                                <%--<tr>
                                    <td align="left">
                                        <p style="margin-left: 3px">
                                            <font style="font-family: Verdana; height: 20px; font-size: 8pt; color: #494A46;
                                                font-weight: 700">
                                                <%=Lang["Question"].ToString()%>
                                                :</font><br />
                                            <font style="margin-left: 3px; font-family: Verdana; font-size: 8pt; color: #494A46;">
                                                <%=strQuestion%>
                                            </font>
                                        </p>
                                    </td>
                                </tr>--%>
                                <%} %>
                                <%if (strAnswer != "")
                  {%>
                                <tr>
                                    <td align="left">
                                        <p style="margin-left: 3px">
                                            <font style="font-family: Verdana; height: 20px; font-size: 8pt; color: #494A46;
                                                font-weight: 700">
                                                <%=Lang["Answer"].ToString()%>
                                                :</font><br />
                                            <font style="margin-left: 3px; font-family: Verdana; font-size: 8pt; color: #494A46;">
                                                <%=strAnswer%>
                                            </font>
                                        </p>
                                    </td>
                                </tr>
                                <%} %>
                                <%if (strAuthor != "")
                  {%>
                                <tr>
                                    <td align="right">
                                        <p style="margin-left: 3px">
                                            <font style="margin-right: 13px; font-family: Verdana; font-size: 8pt; color: #494A46;
                                                font-weight: 700;">
                                                <%=strAuthor%>
                                            </font>
                                        </p>
                                    </td>
                                </tr>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="FAQs_Edit" runat="server" CssClass="button" OnClick="FAQs_Edit_Click" />
                            <input type="button" id="Back_FAQs" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
