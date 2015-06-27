<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderBill_Add.aspx.cs" Inherits="WebComputer.Admin.OrderBill_Add" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #c0c0c0">
        <tr>
            <td class="Title" align="left" colspan="4">Thêm Hoá Đơn Nhập</td>
        </tr>
        <tr>
            <td colspan="4" style="height:25px;"><asp:Label runat="server" ID="lblError" ForeColor="Red" Width="344px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td style="width:25%;">
            Nhân viên:
            </td>
            <td style="width:25%;" align="left"><asp:TextBox runat="server" ID="txtEmployee" CssClass="textbox" Enabled="False"></asp:TextBox></td>
            <td style="width:25%;">Ngày lập:</td>
            <td style="width:171px;"><asp:Label runat="server" ID="lblBuyDate"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 21px">Nhà cung cấp:</td>
            <td align="left" style="height: 21px"><asp:DropDownList runat="server" ID="ddlProvName" DataTextField="ProvName" DataValueField="ProvID" OnSelectedIndexChanged="ddlProvName_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>&nbsp;<asp:HyperLink runat="server" ID = "hplAddProvider" NavigateUrl="~/Admin/Provider_Add.aspx" Text="Thêm mới"></asp:HyperLink></td>
            <td style="height: 21px"></td>
            <td style="width: 171px; height: 21px;"></td>
        </tr>
        <tr>
            <td style="height: 21px"><asp:Label runat="server" ID ="lblCat" Text="Chọn danh mục:" Visible="false"></asp:Label></td>
            <td align="left" style="height: 21px"><asp:DropDownList runat="server" ID="ddlCategory" DataTextField="CatName" DataValueField="Cat_ID" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" Visible="false" AutoPostBack="True"></asp:DropDownList></td>
            <td style="height: 21px"><asp:Label runat="server" ID="lblProduct" Visible="false" Text="Chọn sản phẩm:"></asp:Label></td>
            <td style="width: 171px; height: 21px;" align="left"><asp:DropDownList runat="server" ID="ddlProduct" DataTextField="Product_Name" DataValueField="Product_ID" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 21px;size:10px;"><asp:Label runat="server" ID="lblSubCat" Text="Chọn loại sản phẩm:" Visible="false"></asp:Label></td>
            <td align="left" style="height: 21px"><asp:DropDownList runat="server" ID="ddlSubCategory" DataTextField="SubName" DataValueField="SubCatID" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged"></asp:DropDownList></td>
            <td style="height: 21px"></td>
            <td style="height: 21px"></td>
        </tr>
        <tr>
            <td style="height: 26px"><asp:Label runat="server" ID="lblQuantity" Text="Số lượng:" Visible="False"></asp:Label></td>
            <td align="left" style="height: 26px"><asp:TextBox runat="server" ID="txtQuantity" Visible="False" CssClass="textbox" ></asp:TextBox></td>
            <td style="height: 26px"><asp:Label runat="server" ID="lblPrice" Text="Gía nhập:" Visible="False"></asp:Label></td>
            <td align="left" style="height: 26px"><asp:TextBox runat="server" ID="txtPrice" Visible="False" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="lblDescription" Visible="false" Text="Mô tả:"></asp:Label>  </td>
            <td align="left" style="height: 26px"><asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Visible="false" Rows="5"></asp:TextBox> </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 26px"><asp:Button runat="server" ID="btnAddToCard" Text="Thêm hàng" OnClick="btnAddToCard_Click" Visible="False" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <table style="border:1px Solid Gray;width:100%;height:auto;">
                    <asp:Repeater runat="server" ID="Repeater1" OnItemCommand="Update_Delete_Item">
                        <HeaderTemplate>
                            <tr style="background-color:#fff;font-size:small;">
                                <td ></td>
                                <td ></td>
                                <td align ="center" style="border-right:1px solid Gray;" ><b>Nhà cung cấp</b></td>
                                <td align ="center" style="border-right:1px solid Gray;"><b>Nhân viên lập</b></td>
                                <td align ="center" style="border-right:1px solid Gray;"><b>Tên sản phẩm</b></td>
                                <td align ="center" style="border-right:1px solid Gray;"><b>Gía</b></td>
                                <td align ="center" style="border-right:1px solid Gray;"><b>Số lượng</b></td>
                                <td align ="center" style="border-right:1px solid Gray;"><b>Ngày nhập hàng</b></td>
                                <td align ="center" ><b>Chức năng</b></td>
                                
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color:#eff0f3;font-size:small;">
                                <td><asp:Label runat="server" ID="Label3" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"ProductID") %>'></asp:Label></td>
                                <td><asp:Label runat="server" ID="Label2" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"ProvID") %>'></asp:Label></td>
                                <td style="border-right:1px solid Gray;"><asp:Label runat="server" ID="lblProvName" Text='<%#DataBinder.Eval(Container.DataItem,"ProvName") %>'></asp:Label></td>
                                <td style="border-right:1px solid Gray;"><asp:Label runat="server" ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem,"Employee") %>'></asp:Label></td>
                                <td style="border-right:1px solid Gray;"><asp:Label runat="server" ID="lblProductName" Text='<%#DataBinder.Eval(Container.DataItem,"ProductName") %>'></asp:Label></td>
                                <td style="border-right:1px solid Gray;"><asp:Label runat="server" ID="lblPriceInput" Text ='<%#DataBinder.Eval(Container.DataItem,"PriceInput") %>'></asp:Label></td>
                                <td style="border-right:1px solid Gray;"><asp:Label runat="server" ID="lblQuatity" Text='<%#DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label></td>
                                <td style="border-right:1px solid Gray;"><asp:Label runat="server" ID="lblBuyDate" Text='<%#DataBinder.Eval(Container.DataItem,"BuyDate") %>'></asp:Label></td>
                                <td><asp:LinkButton ID="btnDelete" Text="Hủy" runat="server" CommandName="del">
                                </asp:LinkButton></td>
                                
                            </tr>
                            
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>    
        </tr>
        <tr>
            <td></td>
            <td align="left" style="padding-left:10px;"><asp:Label runat="server" ID="lblTitle" Text="Tổng tiền" Visible="False"></asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="lblTotal" Visible="False" Font-Bold="True"></asp:Label></td>
            <td><asp:Label runat="server" ID="lblToPay" Text="Số tiền trả" Visible="False"></asp:Label>&nbsp;<asp:TextBox runat="server" ID="txtToPay" Visible="False" CssClass="textbox" Font-Bold="True"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td align ="right"></td>
            <td>
                <asp:Label ID="lblMoney" runat="server" ForeColor="Blue" Width="268px"></asp:Label>
            </td>    
            <td ></td>
        </tr>
        <tr>
            <td colspan="4" align="center"><asp:Button runat="server" ID="btnAddToBill" Text="Vào hoá đơn" Visible="False" OnClick="btnAddToBill_Click" /></td>    
        </tr>
    </table>

</asp:Content>
