<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Build.aspx.cs" Inherits="WebComputer.Home.Build" Title="Welcome to Chien Yen Computer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table align="center">
<tbody><tr align="left">
					<td><b>CPU - Bộ vi xử lý</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList1" runat="server" Width="370px" DataSourceID="SqlDataSource1" DataTextField="Product_Name" DataValueField="Product_Price" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut FROM TB_Product WHERE (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="28" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
					</td>
				</tr>
				<tr align="left">
					<td><b>Mainboard - Bo mạch chủ</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList2" runat="server" Width="370px" DataSourceID="SqlDataSource3" DataTextField="Product_Name" DataValueField="Product_Price" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut FROM TB_Product WHERE (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="29" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>Ram - Bộ nhớ trong</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList3" runat="server" Width="370px" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Product_Name" DataValueField="Product_Price" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged1" >
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="30" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>HDD - Ổ đĩa cứng</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList4" runat="server" Width="370px" DataSourceID="SqlDataSource4" DataTextField="Product_Name" DataValueField="Product_Price" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="31" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>ODD - Ổ đĩa quang học</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList5" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" DataSourceID="SqlDataSource5" DataTextField="Product_Name" DataValueField="Product_Price" AutoPostBack="True">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="37" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>VGA Card - Card đồ họa</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList6" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" DataSourceID="SqlDataSource6" DataTextField="Product_Name" DataValueField="Product_Price" AutoPostBack="True">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="32" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</t>
				<tr align="left">
					<td style="height: 22px"><b>Monitor - Màn hình</b></td>
					<td style="height: 22px; width: 377px;">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList7" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource7" DataTextField="Product_Name" DataValueField="Product_Price">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="33" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>Case - Vỏ máy tính</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList8" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource8" DataTextField="Product_Name" DataValueField="Product_Price">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="34" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>Power Supply - Nguồn</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList9" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource9" DataTextField="Product_Name" DataValueField="Product_Price">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="35" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>Keyboard - Bàn phím</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList10" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource10" DataTextField="Product_Name" DataValueField="Product_Price">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="36" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td style="height: 16px"><b>Mouse - Chuột máy tính</b></td>
					<td style="height: 16px; width: 377px;">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList11" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource11" DataTextField="Product_Name" DataValueField="Product_Price">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="64" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
				<tr align="left">
					<td><b>Loa máy tính</b></td>
					<td style="width: 377px">
                        &nbsp;<asp:DropDownList AppendDataBoundItems="true" ID="DropDownList12" runat="server" Width="370px" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged" DataSourceID="SqlDataSource12" DataTextField="Product_Name" DataValueField="Product_Price" AutoPostBack="True">
                        <asp:ListItem>--Chọn sản phẩm--</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionDemo %>"
                            SelectCommand="SELECT        Product_ID, Product_Name, Product_Price, SubCatID, Product_QUatityOut&#13;&#10;FROM            TB_Product&#13;&#10;WHERE        (SubCatID = @SubCatID) AND (Product_QUatityOut > 0)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="38" Name="SubCatID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
				</tr>
         <tr>
         	<td colspan="2" align="center" style="height: 31px">
            	<hr size="1" color="#666666">
            	<span id="huyen"><b>Giá: <font color="#cc0000">
                    <asp:Label ID="lblTotalPrice" runat="server" Text="Label"></asp:Label></font></b> vnđ</span></td>
         </tr> 
		<tr>
		  <td colspan="2" align="center">
              <asp:Button ID="Button2" runat="server" Text="Làm Lại" OnClick="Button2_Click" />&nbsp;
              <asp:Button ID="Button1" runat="server" Text="Thanh Toán" OnClick="Button1_Click" /></td></tr>
	</tbody>
</table>
</asp:Content>
