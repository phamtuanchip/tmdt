<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="LibraryImage_Popup.aspx.cs" Inherits="WebComputer.Admin.LibraryImage_Popup" Title="Untitled Page" %>
<%@ Register Assembly="AtlasControlToolkit" Namespace="AtlasControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc1" %>

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>G3_C0605M Fpt - Aptech Ha noi</title>
    <link href="/css/StyleSheetAdmin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
	function do_insertImage(w,Thumb_W,Photo, ImageID)
    {
        if(w==0)
        {
	        window.opener.do_InsertImgEditor(w,Thumb_W,Photo, ImageID);
	        window.close();
	    }
	    else
	    {
	        window.opener.do_InsertImgEditorColor(w,Thumb_W,Photo, ImageID);
	        window.close();
	    }
	}	
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ScriptManager ID="ScriptManager1" runat="server">
    </cc1:ScriptManager>
    <cc1:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">    
        <tr>
            <td>
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                 <tr>
                    <td>
                        <asp:Panel ID="PTitle" runat="server" Width="100%">
                            <table width="100%" id="Table1" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="Title" align="left" style="width: 95%"><%=Lang["SearchInfo"].ToString()%></td>
                                    <td class="Title" align="right" style="cursor: hand">
                                        <asp:Image ID="LampnColspan" runat="server" ImageUrl="/images/Admin/expand_blue.jpg" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PSearchArea" CssClass="collapsePanel" runat="server" Width="100%" Height="0">
                            <table width="100%" id="Table2" runat="server" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["CatImage"].ToString()%>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDL_CatId" runat="server">
                                        </asp:DropDownList>                                       
                                    </td>
                                </tr>  
                                <tr>
                                    <td align="left" class="ListContent" style="width:23%; height:20px">
                                        <%=Lang["SearchInfo"].ToString()%>
                                    </td>
                                    <td style="width: 75%" align="left">
                                        <asp:TextBox CssClass="textbox" ID="txtSearch" runat="server" Width="350px"></asp:TextBox>
                                    </td>
                                </tr>                                                                                              
                                <tr>
                                    <td colspan="2" class="Footer" align="left">
                                        <asp:Button CssClass="button" ID="bntSearch" runat="server" Text="Tìm kiếm" OnClick="bntSearch_Click"/>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <br />
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">           
                <tr>
                    <td class="Title" style="height:22px" align="left"><%=Lang["LibraryImages"].ToString()%></td>
                </tr>            
                <tr>
                    <td align="center">
                        <asp:DataList ID="DL_Images" DataKeyField="ID" RepeatColumns="4" runat="server">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <table width="20%" border="0" cellpadding="3" cellspacing="2">
                                <tr>
                                    <td style="background-color: #EFF0F3" colspan="2" align="center">
                                    
                                        <a href="JavaScript:do_insertImage('<%=w%>','<%#Eval("Thumb_W")%>','<%#objEntities.GetPathLibraryImage()%><%#Eval("PhotoID")%>','<%#Eval("ID")%>');">
                                            <img width="<%#Eval("Thumb_W")%>" src='<%=objEntities.GetPathLibraryImage()%><%#Eval("PhotoID") + "_T.jpg"%>' alt='Xem chi tiết <%#Eval("Description")%>' style="border: 0px" />
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px; width: 10%; background-color: #EFF0F3" align="center">
                                        <input type="checkbox" value="delete" name="chbDelete<%#Eval("ID")%>">
                                    </td>
                                    <td style="height: 20px; width: 75%; background-color: #EFF0F3; padding-left: 5px" align="left">
                                        <a href="LibraryImage_Edit.aspx?id=<%#Eval("ID")%>" title="Sửa thông tin ảnh" class="leftMenuAdmin"><%#Eval("Description")%></a>
                                    </td>                                
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
                                <td style="width:30%">
                                </td>
                                <td style="width:70%" align="right">
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
    </div>
    </ContentTemplate>
    </cc1:UpdatePanel>
    <cc1:CollapsiblePanelExtender ID="LampnCollSpan" runat="server">
        <cc1:CollapsiblePanelProperties SuppressPostBack="true" ImageControlID="LampnColspan"
            CollapsedImage="/Images/Admin/expand.jpg" ExpandedImage="/Images/Admin/collapse.jpg"
            Collapsed="true" TargetControlID="PSearchArea" CollapseControlID="PTitle" ExpandControlID="PTitle">
        </cc1:CollapsiblePanelProperties>
    </cc1:CollapsiblePanelExtender>
    </form>
    
</body>
</html>

