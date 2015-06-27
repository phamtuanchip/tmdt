<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer_Detail.aspx.cs" Inherits="WebComputer.Admin.Customer_Detail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                            Thông tin chi tiết khách hàng
                        </td>
                    </tr>
                    
                                     
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            Tên khách hàng
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="txt_customer" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            Tên đăng nhập
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="txtusername" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                            
                        </td>
                    </tr>
                      <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                            Mật khẩu
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="txtPasword" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                            
                        </td>
                    </tr>
           
                    
                      <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px">Địa chỉ</td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="txt_Address" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
                <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px">Điện thoại</td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="txt_Phone" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
                  <tr>
                <td align="left" class="ListContent" style="width:23%; height:36px">Hòm thư</td>
                <td align="left" class="SpacerTd" style="width:77%; height: 36px;">
                    <asp:TextBox ID="txt_mail" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                  
                </td>
            </tr>
                    
                    
                    <tr>
                        <td colspan="2" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">
                          
                            <input type="button" id="Back_Edit" runat="server" class="button" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
