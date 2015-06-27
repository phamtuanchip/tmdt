<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionLog_Delete.aspx.cs" Inherits="WebComputer.Admin.ActionLog_Delete" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc_delete" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Page Delete</title>
    <link href = "/StyleSheet/StyleSheetAdmin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Js/Calendar.js"></script>
    <script type="text/javascript" src="/Js/Function.js"></script>
</head>
<body style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0">
    <form id="form1" runat="server">
        <cc_delete:ScriptManager ID="ScriptManager" runat="server"></cc_delete:ScriptManager>
        <div>
            <asp:Panel ID="pnPanelInPut" runat="server" Width="100%">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #C0C0C0">
                    <tr>
                        <th class="Title" align="left" colspan="2">
                            <%=Lang["DeleteActionLog"].ToString()%>
                        </th>
                    </tr>                    
                    <tr>
                        <td align="left" style="padding-top: 5px; padding-left: 5px; width:25%">
                            <%=Lang["ActionDelete"].ToString()%>
                        </td>
                        <td align="left" style="padding-top: 5px; padding-left: 5px; width:75%">
                            <cc_delete:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="textbox" ID="DDL_ActionDelete" runat="server" OnSelectedIndexChanged="ActionLog_SelectIndexChanged" AutoPostBack="true">                                        
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_DDL_ActionDelete" runat="server" ControlToValidate="DDL_ActionDelete" ErrorMessage="Chọn tuỳ chọn xoá!"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </cc_delete:UpdatePanel>                            
                        </td>
                    </tr>  
                    <tr id="idFromDate" runat="server">
                        <td align="left" class="ListContent">
                            <%=Lang["FromDate"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <input type="text" readonly="readonly" name="FromDate" size="20" class="textbox" />
                            <script type="text/javascript">
                                if (!document.layers)
                                {
                                    document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.FromDate, aspnetForm.FromDate, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                                }				
                            </script>
                        </td>
                    </tr>
                    <tr id="idToDate" runat="server">
                        <td align="left" class="ListContent" style="width:23%; height:20px">
                            <%=Lang["ToDate"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd">
                            <input type="text" readonly="readonly" name="ToDate" size="20" class="textbox" />
                            <script type="text/javascript">
                                if (!document.layers)
                                {
                                    document.write("<a style='cursor: hand' onClick='javascript:popUpCalendar(aspnetForm.ToDate, aspnetForm.ToDate, \"mm/dd/yyyy\")'><img src='/Images/admin/Calendar/Cal.gif' border='0'></a>");
                                }
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:5px"></td>
                    </tr>                  
                </table>
            </asp:Panel>            
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th class="Title" align="left" colspan="2">
                        <asp:Button CssClass="button" ID="Delete_ActionLog" runat="server" OnClick="Delete_ActionLog_Click" />                        
                    </th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
