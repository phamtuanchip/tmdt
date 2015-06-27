<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="WebComputer.Control.Admin.Left" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <th class="Title">
                                    <b>
                                        <%=Lang["SystemManager"]%>
                                    </b>
                                </th>
                            </tr>
                            <tr id="GroupList_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HplListMember" runat="server" NavigateUrl="/Admin/MemberGroup_list.aspx"><%=Lang["GroupList"] %></asp:HyperLink></td>
                            </tr>
                            <tr id="GroupAddnew_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink1" runat="server" NavigateUrl="/Admin/MemberGroup_addnew.aspx"><%=Lang["MemberGroupAddNew"] %></asp:HyperLink></td>
                            </tr>
                            <tr id="UserAddnew_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink5" runat="server" NavigateUrl="/Admin/Member_AddNew.aspx"><%=Lang["AdminUserAddNew"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="MemberList_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink6" runat="server" NavigateUrl="/Admin/Member_List.aspx"><%=Lang["MemberList"]%></asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink7" runat="server" NavigateUrl="/Admin/Member_YourAccount.aspx"><%=Lang["YourAccount"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="ActionLogLogin_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink9" runat="server" NavigateUrl="/Admin/ActionLog_Login.aspx"><%=Lang["ActionLogLogin"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="ActionLogAction_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink8" runat="server" NavigateUrl="/Admin/ActionLog_Action.aspx"><%=Lang["ActionLogAction"]%></asp:HyperLink></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id ="SystemManager_ID" runat ="server">
    </tr>
     <tr id="ProManager_id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["ManagerProduct"]%>
                                    </b>
                                </td>
                            </tr>
                            <tr id="Cat_Pro_List_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink11" runat="server" NavigateUrl="~/Admin/Category_Pro_List.aspx"><%=Lang["CategoryProduct"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="Cat_Pro_Group_List" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink12" runat="server" NavigateUrl="/Admin/Cat_Pro_Group_List.aspx"><%=Lang["SubCategoryList"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="Pro_List" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink19" runat="server" NavigateUrl="/Admin/Product_List.aspx"><%=Lang["ListProducts"]%></asp:HyperLink></td>
                            </tr>
                            
                            
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id = "ProductManager_ID" runat ="server">
    </tr>
     <tr id="Order_Manager_id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["OrderManager"]%>
                                    </b>
                                </td>
                            </tr>
                             <tr id="Customer_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink28" runat="server" NavigateUrl="/Admin/Customer_List.aspx"><%=Lang["Customer_List"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="Provider_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink29" runat="server" NavigateUrl="/Admin/Provider_List.aspx"><%=Lang["Provider_List"]%></asp:HyperLink></td>
                            </tr>
                             <tr id="Provider_Debt" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink30" runat="server" NavigateUrl="/Admin/Provider_Debt.aspx"><%=Lang["Provider_Deft"]%></asp:HyperLink></td>
                            </tr>
                            
                            
                                <tr id="Provider_payed" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink31" runat="server" NavigateUrl="/Admin/PaymentOrder.aspx"><%=Lang["PaymentOrder"]%></asp:HyperLink></td>
                            </tr>
                            
                            
                            
                            <tr id="Order_List" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink22" runat="server" NavigateUrl="/Admin/Order_List.aspx"><%=Lang["ListOrderCustomer"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="Order_Eidt" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink23" runat="server" NavigateUrl="/Admin/OrderBill_List.aspx"><%=Lang["ListOrderIn"]%></asp:HyperLink></td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id = "OrderManager_ID" runat ="server">
    </tr>
     <tr id="Report_Manager_id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["ManagerReport"]%>
                                    </b>
                                </td>
                            </tr>
                            <tr id="Report_Product" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink14" runat="server" NavigateUrl="/Admin/Product_Report.aspx"><%=Lang["StaticalProduct"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="Report_Order" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink15" runat="server" NavigateUrl="/Admin/Provider_Report.aspx"><%=Lang["StaticalProvider"]%></asp:HyperLink></td>
                            </tr>
                                                 
                            <tr id="Report_ProMax" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink16" runat="server" NavigateUrl="/Admin/Customer_Report.aspx"><%=Lang["StaticalCustomer"]%></asp:HyperLink></td>
                            </tr>
                             <tr id="Report_DateTime" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink18" runat="server" NavigateUrl="/Admin/Report_Other.aspx"><%=Lang["StaticalOther"]%></asp:HyperLink></td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id = "ManagerReport_ID" runat ="server">
    </tr>
    <tr id="NewsManager_Id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["AdminNewsManager"]%>
                                    </b>
                                </td>
                            </tr>
                            <tr id="NewsCatManager_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink2" runat="server" NavigateUrl="/Admin/Editor_Cat_List.aspx"><%=Lang["AdminNewsCategoryManager"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="NewsAddnew_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink3" runat="server" NavigateUrl="/Admin/Editor_AddNew.aspx"><%=Lang["AdminAddNew"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="NewsManager_List_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink4" runat="server" NavigateUrl="/Admin/Editor_List.aspx"><%=Lang["AdminNewsManager"]%></asp:HyperLink></td>
                            </tr>
                           
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="NewsManagerSpace_Id" runat="server">
    </tr>
    <tr id="BannerLogoManager_Id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left" >
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["LogoBanner"]%>
                                    </b>
                                </td>
                            </tr>
                            <tr id="LogoCat_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink113" runat="server" NavigateUrl="/Admin/Logo_Category.aspx"><%=Lang["CategoryLogo"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="LogoAddnew_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink114" runat="server" NavigateUrl="/Admin/Logo_AddNew.aspx"><%=Lang["AddNewLogo"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="LogoManager_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink115" runat="server" NavigateUrl="/Admin/Logo_List.aspx"><%=Lang["LogoManager"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="BannerCat_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink116" runat="server" NavigateUrl="/Admin/Banner_Category.aspx"><%=Lang["CategoryBanner"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="BannerAddnew_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink117" runat="server" NavigateUrl="/Admin/Banner_AddNew.aspx"><%=Lang["AddNewBanner"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="BannerManager_Id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink118" runat="server" NavigateUrl="/Admin/Banner_List.aspx"><%=Lang["BannerManager"]%></asp:HyperLink></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="DocumentManagerSpace_id" runat="server">
    </tr>
    <tr id="Manager_Gallery_id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["GalleryManager"]%>
                                     
                                    </b>
                                </td>
                            </tr>
                            <tr id="CatGallery_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink20" runat="server" NavigateUrl="/Admin/Gallery_Category.aspx"><%=Lang["CatGallery"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="AddNewCatGallry_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink25" runat="server" NavigateUrl="/Admin/Gallery_Category_AddNew.aspx"><%=Lang["CatGalleryAdd"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="GalleryList_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink26" runat="server" NavigateUrl="/Admin/Gallery_list.aspx"><%=Lang["GalleryList"]%></asp:HyperLink></td>
                            </tr> 
                            <tr id="GalleryAdd_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink27" runat="server" NavigateUrl="/Admin/Gallery_addNew.aspx"><%=Lang["GalleryAdd"]%></asp:HyperLink></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id = "Tr2_2" runat ="server">
    </tr>
     <tr id="AdminLibraryImagerList_id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["AdminLibraryImagerList"]%>
                                     
                                    </b>
                                </td>
                            </tr>
                            <tr id="CatImageList_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink33" runat="server" NavigateUrl="/Admin/LibraryCatImage_List.aspx"><%=Lang["ListLibararyImages_id"]%></asp:HyperLink></td>
                            </tr>
                             <tr id="ImageList_id" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink34" runat="server" NavigateUrl="/Admin/LibraryImage_List.aspx"><%=Lang["LibararyImages_id"]%></asp:HyperLink></td>
                            </tr>
                            </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id = "Tr11" runat ="server">
    </tr>
    <tr id="DocumentManager" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="height: 15px">
                <tr>
                    <td valign="top" align="left" >
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["IntroductionManager"]%>
                                    </b>
                                </td>
                            </tr>
                                                        
                            <tr id="Tr1" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink13" runat="server" NavigateUrl="/Admin/Document_list.aspx"><%=Lang["IntroductionManager"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="Tr9" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink17" runat="server" NavigateUrl="/Admin/Document_AddNew.aspx"><%=Lang["AddNewDocument"]%></asp:HyperLink></td>
                            </tr> 
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="BannerLogoManagerSpace_Id" runat="server">
    </tr>
    <tr id="OtherManager_Id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                <tr>
                    <td class="Title" align="left">
                        <b>
                            <%=Lang["OtherManager"]%>
                        </b>
                    </td>
                </tr>          
                <tr id="RecruitManager_Id" runat="server">
                    <td align="left" style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                        <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                            ID="HyperLink10" runat="server" NavigateUrl="/Admin/Recruit_List.aspx"><%=Lang["RecruitManager"]%></asp:HyperLink></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="OtherManagerSpace_Id" runat="server">
    </tr>
    <tr id="FAQs_Manager_id" runat="server">
        <td align="center" valign="top">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" align="left" style="height: 90px">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #BBBBBB">
                            <tr>
                                <td class="Title">
                                    <b>
                                        <%=Lang["FAQsManager"]%>
                                    </b>
                                </td>
                            </tr>
                                                        
                            <tr id="FAQs_Manager_List" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink21" runat="server" NavigateUrl="/Admin/FAQs_List.aspx"><%=Lang["FAQsManager"]%></asp:HyperLink></td>
                            </tr>
                            <tr id="FAQs_Manager_Edit" runat="server">
                                <td style="font-family: Arial; font-size: 10pt; padding-left: 3px; height: 20px" class="GridAltRow">
                                    <img src="/Images/Admin/project_icon_sm.gif" alt="" />&nbsp;<asp:HyperLink CssClass="leftMenuAdmin"
                                        ID="HyperLink24" runat="server" NavigateUrl="/Admin/FAQs_AddNew.aspx"><%=Lang["FAQsAddNew"]%></asp:HyperLink></td>
                            </tr> 
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="Faqs_Managers" runat="server">
    </tr>
</table>
