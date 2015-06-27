<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewHangSX.aspx.cs" Inherits="WebComputer.Admin.NewHangSX" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
                    <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">Thêm mới hãng sản xuất
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 24px">
                            Tên hãng
                        </td>
                         <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="txt_ProName" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                           
                        </td>
                        
                    </tr>
                                     
                    <tr>
                        <td align="left" class="ListContent" style="width: 23%; height: 20px">
                           Thông tin chi tiết hãng sản xuất
                        </td>
                        <td align="left" class="SpacerTd" style="width: 77%">
                            <asp:TextBox ID="TextBox1" Columns="60" CssClass="textbox" runat="server"></asp:TextBox>
                           
                        </td>
                    </tr>
                     <tr>
                    <td class="Title" style="height: 20" align="left">
                    
                    
                        <asp:Button ID="Hang_Add" runat="server" Text="Thêm mới" OnClick="Hang_Add_Click"/>
                    
                        <asp:Button ID="Hang_Delete" runat="server" Text="Xóa" OnClientClick="return checkDelete(this.form)" OnClick="Hang_Delete_Click" />
                    
                    
                    
                    
                   
                    </td>
                </tr>
                    
                    
                    
                    
                    
                     <tr>
                        <td class="Title" style="height: 22px" align="left" colspan="2">Danh sách hãng sản xuất
                            &nbsp;</td>
                    </tr>
                       <tr>
                        
                        <td colspan="2">
                      <asp:GridView ID="GV_Prov_List" runat="server" AllowPaging="true"  AutoGenerateColumns="false" Width="100%" PageSize="20">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="5%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Stt" runat="server">Stt</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <HeaderStyle Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">Tên nhà cung cấp</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate >                                        
                                    <a href="Provider_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "HangID")%>" class="leftMenuAdmin">
                                            <%#DataBinder.Eval(Container.DataItem, "Name")%>                                                                          
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                    <HeaderStyle Width="20%" CssClass="SubTitle" />
                                    <HeaderTemplate>
                                        <asp:Label ID="ProCode" runat="server">chi tiết</asp:Label>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate >                                        
                                            <%#DataBinder.Eval(Container.DataItem, "Des")%>                                                                          
                                    </ItemTemplate>
                                </asp:TemplateField>           
                                
                                
                                <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20%" />
                                <HeaderTemplate>
                                    <asp:Label ID="L121" runat="server">Sửa</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" />
                                <ItemTemplate>
                                    <a href="Provider_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "HangID")%>" class="leftMenuAdmin">
                                        <img alt="Sửa nội dung" src="/Images/Admin/edit_u.gif" style="border: 0px" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <input onclick="JavaScript:checkDeleteAll(this.form);" type="checkbox" name="chb_DeleteAll" title="Chọn tất cả">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem,"HangID")%>">
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="leftMenuAdmin" HorizontalAlign="Left" />
                        </asp:GridView>
                          
                        </td>
                    </tr>
    </table>
</asp:Content>
