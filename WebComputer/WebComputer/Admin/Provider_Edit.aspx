<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Provider_Edit.aspx.cs" Inherits="WebComputer.Admin.Provider_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <%=Lang["Prov_Eidt"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 24px">
                            <%=Lang["Language"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%; height: 24px;">
                            <asp:DropDownList ID="DDL_Language" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_Lang" runat="server" ControlToValidate="DDL_Language"
                                ErrorMessage="Hãy chọn ngôn ngữ!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                     
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            <%=Lang["ProviderName"].ToString()%>
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="txt_ProName" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_ProvName" runat="server"
                                ControlToValidate="txt_ProName" ErrorMessage="Tên nhà cung cấp không được để trống!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px"><%=Lang["ProviderAddress"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="txt_Address" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_ProviderAddress" runat="server" ControlToValidate="txt_Address" ErrorMessage="Địa chỉ nhà cung cấp không thể trống!"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px"><%=Lang["ProviderPhone"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="txt_Phone" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_ProviderPhone" runat="server" ControlToValidate="txt_Phone" ErrorMessage="Điện thoại nhà cung cấp không thể trống!"></asp:RequiredFieldValidator>
                </td>
            </tr>
                  <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px"><%=Lang["ProviderWebsite"].ToString()%></td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="txt_Website" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="ListContent" ID="RFV_ProviderWebsite" runat="server" ControlToValidate="txt_Website" ErrorMessage="Website nhà cung cấp không thể trống!"></asp:RequiredFieldValidator>
                </td>
            </tr>
                    
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                          
                        </td>
                        <td align="left">
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
                            <%=Lang["Discription"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="ListContent" style="height: 20px">
                        </td>
                        <td align="left" class="SpacerTd">
                            
                             <asp:TextBox runat ="server" ID ="Description" Height="85px" TextMode="MultiLine" Width="378px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            <asp:Button ID="btn_Provider_Edit" runat="server" CssClass="button" OnClick="btn_Provider_Edit_Click" />
                            <input type="reset" id="Reset_Form" runat="server" class="button" value="Reset" />
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
