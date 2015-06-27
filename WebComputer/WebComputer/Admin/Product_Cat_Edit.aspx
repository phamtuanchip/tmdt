<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product_Cat_Edit.aspx.cs" Inherits="WebComputer.Admin.Product_Cat_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td colspan="2" class="Title" style="height: 22px; width: 75%" align="left">
                            Sửa loại sản phẩm
                        </td>                        
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        Ngôn ngữ
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <cc_cat:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList CssClass="textbox" ID="DDL_Language" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CatRoot_SelectIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_DDL_Language" runat="server" ControlToValidate="DDL_Language" ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </cc_cat:UpdatePanel>                            
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        Loại
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <cc_cat:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td id="CMSProduct_Cat_Root" runat="server"></td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </cc_cat:UpdatePanel>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                       Tên loại
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <asp:TextBox CssClass="textbox" ID="txtCatName" runat="server" Columns="35"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_CatName" runat="server" ControlToValidate="txtCatName" ErrorMessage="Tên danh mục không thể trống!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>                    
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        Hoạt động
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <asp:CheckBox ID="cbActive" CssClass="textbox" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="ListContent" style="width: 23%; height: 20px">
                                        Trang chủ
                                    </td>
                                    <td align="left" class="SpacerTd" style="width: 77%">
                                        <asp:CheckBox ID="cbOnHomePage" CssClass="textbox" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>                        
                    </tr>                                                           
                    <tr>
                        <td colspan="2" style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="ProductCat_Edit" runat="server" CssClass="button" OnClick="ProductCat_Edit_Click" />
                            <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
