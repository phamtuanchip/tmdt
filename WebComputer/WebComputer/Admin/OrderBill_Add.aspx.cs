using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Bussiness;
using System.Data.SqlClient;
using Entity;
//using BussinessObject.FunctionBase;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class OrderBill_Add : System.Web.UI.Page
    {
        #region Variables members
        public System.Data.DataTable objDT;

        public System.Data.DataRow objDR;
        public int pid;
        public string _costvar;
        public string _namevar;
      
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objcheck = new Function();

        DataTable dTable = new DataTable();
        BUBill objBill = new BUBill();
        Function fn = new Function();
        #endregion

        
        public Bussiness.BusinessLogic objBusi = new BusinessLogic();
        private string strAllowFunctions = "OrderBillAdd";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusi.Permission(this.strAllowFunctions) == true)
                {
                    if (!IsPostBack)
                    {
                        txtEmployee.Text = Session["AdminID"].ToString();
                        BindProvNameToDDL();
                        BindCatNameToDDL();
                        lblBuyDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                        lblTitle.Visible = false;
                        lblTotal.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }

        }
        private void BindProvNameToDDL()
        {
            
            dTable = objBill.SelectProvName();
            ddlProvName.DataSource = dTable;
            ddlProvName.DataBind();
        }
        private void BindCatNameToDDL()
        {
            dTable = objBill.SelectCatName();
            ddlCategory.DataSource = dTable;
            ddlCategory.DataBind();
        }
        private void BindSubNameToDDL()
        {
            dTable = objBill.SelectSubCatName(Convert.ToInt32(ddlCategory.SelectedValue));
            ddlSubCategory.DataSource = dTable;
            ddlSubCategory.DataBind();
        }
        private void BindProductNameToDDL()
        {
            dTable = objBill.SelectProductName(Convert.ToInt32(ddlSubCategory.SelectedValue));
            ddlProduct.DataSource = dTable;
            ddlProduct.DataBind();
        }

        protected void ddlProvName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvName.SelectedValue != "0")
            {
                Session["ProvID"] = ddlProvName.SelectedValue;
                lblCat.Visible = true;
                ddlCategory.Visible = true;
                ddlProvName.Enabled = false;
                BindCatNameToDDL();
            }
            else
            {              
                
                lblError.Text = "Ban chua chon Nha Cung Cap";
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "0")
            {
                lblSubCat.Visible = true;
                ddlSubCategory.Visible = true;
                BindSubNameToDDL();
            }
            else
            {
                lblError.Text = "Ban chua chon Danh Muc";
            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedValue != "0")
            {
                lblProduct.Visible = true;
                ddlProduct.Visible = true;
                BindProductNameToDDL();
            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedValue != "0")
            {
                lblQuantity.Visible = true;
                txtQuantity.Visible = true;
                lblPrice.Visible = true;
                txtPrice.Visible = true;
                btnAddToCard.Visible = true;
                txtDescription.Visible = true;
                lblDescription.Visible = true;
            }
            else
            {
                lblError.Text = "Bạn chưa chọn sản phẩm";
            }
           
        }

        protected void btnAddToCard_Click(object sender, EventArgs e)
        {
            
            bool chquantity = fn.IsNumber(txtQuantity.Text);
            bool chprice = fn.IsNumber(txtPrice.Text);
           
            if (txtQuantity.Text == "")
            {
                lblError.Text = "Bạn chưa nhập số lượng";
                txtQuantity.Focus();
            }
            else if(txtPrice.Text == "")
            {
                lblError.Text = "Bạn chưa nhập giá sản phẩm";
                txtPrice.Focus();
            }
            else if (chquantity == false)
            {
                lblError.Text = "Số lượng không được nhập chữ";
                txtQuantity.Text = "";
                txtQuantity.Focus();
            }
            else if (chprice == false)
            {
                lblError.Text = "Gía sản phẩm không được nhập chữ";
                txtPrice.Text = "";
                txtPrice.Focus();
            }
            
            else
            {

                ShowCart();
                MakeCart();
                AddToCart(_namevar, _costvar);
                dTable = (DataTable)Session["cart"];
                Repeater1.DataSource = dTable;
                Repeater1.DataBind();
                lblTitle.Visible = true;
                lblTotal.Visible = true;
                lblMoney.Visible = true;
                lblToPay.Visible = true;
                txtToPay.Visible = true;
                btnAddToBill.Visible = true;
                ddlProvName.SelectedValue = (string)Session["ProvID"];
                lblTotal.Text = Session["sum"].ToString();
                double demo = Convert.ToDouble(Session["sum"]);
                this.lblMoney.Text = "Số tiền bằng chữ: "+objcheck.DocSo(demo).ToString();
                ddlCategory.SelectedValue = "0";
                ddlSubCategory.SelectedValue = "0";
                ddlProduct.SelectedValue = "0";
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
        }

        protected void insert_bill()
        {
            DataTable dt = (DataTable)Session["Bill"];

            SqlCommand comm = new SqlCommand("SP_Insert_Bills", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Total", dt.Rows[0]["Total"].ToString());          
            comm.Parameters.AddWithValue("@Employee", dt.Rows[0]["Employee"].ToString());
            comm.Parameters.AddWithValue("@ToPay", dt.Rows[0]["ToPay"].ToString());  
            //comm.Parameters.AddWithValue("@BuyDate", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            //comm.Parameters.AddWithValue("@Status", 1);
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            comm.Connection.Close();
        }
        protected void insert_BillDetails()
        {
            int id = get_bill_id();

            DataTable objDT = (DataTable)Session["cart"];

            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                SqlCommand comm = new SqlCommand("SP_Insert_BillDetails", objConn.SqlConn());
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@Product_ID", Convert.ToInt32(objDT.Rows[i]["ProductID"]));
                comm.Parameters.AddWithValue("@BillID",id );
                comm.Parameters.AddWithValue("@UnitPrice", Convert.ToInt32(objDT.Rows[i]["PriceInput"].ToString()));
                comm.Parameters.AddWithValue("@ProvID", Convert.ToInt32(objDT.Rows[i]["ProvID"]));
                comm.Parameters.AddWithValue("@Quatity", Convert.ToInt32(objDT.Rows[i]["Quantity"]));

                comm.Connection.Open();
                comm.ExecuteNonQuery();
                comm.Connection.Close();
            }
        }
        protected void Update_Delete_Item(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                objDT = (DataTable)Session["cart"];

                objDT.Rows[e.Item.ItemIndex].Delete();

                if (objDT.Rows.Count <= 0)
                {
                    //btnSubmit.Enabled = false;
                    //btnContinue_Shopping.Enabled = false;
                    Literal1.Text = "Không có sản phẩm nào trong giỏ hàng !";
                }
                Session["cart"] = objDT;

                Repeater1.DataSource = objDT;
                Repeater1.DataBind();
                //decimal moneyhd = Get_Total();
               lblTotal.Text = "" + Get_Total().ToString("#,###,00");
                //lblTotal.Text = moneyhd.ToString();
                //lblMoney.Text = objcheck.DocSo(Convert.ToDouble(moneyhd)).ToString();
                //Session["total"] = lblTotal.Text;
            }
        }
        protected decimal Get_Total()
        {
            decimal Total = 0;

            if (Session["cart"] == null)
            {
                Total = 0;
            }
            else
            {
                objDT = (DataTable)Session["cart"];

                foreach (DataRow dr in objDT.Rows)
                {
                    Total = Total + (Convert.ToDecimal(dr["PriceInput"]) * Convert.ToDecimal(dr["quantity"]));
                }
            }

            return Total;
        }
        public void ShowCart()
        {           
            //DataTable dt = new DataTable();
            //dt = objBill.SelectProductToCart(Convert.ToInt32(ddlProduct.SelectedValue));
            //lblName.Text = dt.Rows[0]["Product_Name"].ToString();
            //lblCost.Text = dt.Rows[0]["Product_Price"].ToString();
            _namevar = ddlProduct.SelectedItem.ToString();
            _costvar = txtPrice.Text;
        }
        public void ShowBill()
        { 
            DataTable dTable = (DataTable)Session["Bill"];
            txtEmployee.Text = dTable.Rows[0]["Employee"].ToString();
            lblTotal.Text = dTable.Rows[0]["Total"].ToString();
            txtToPay.Text = dTable.Rows[0]["ToPay"].ToString();
        }
        private void Info_Bill()
        {
            dTable.Columns.Add("Employee");
            dTable.Columns.Add("Total");
            dTable.Columns.Add("ToPay");
            //dTable.Columns.Add("BuyDate");
            //dTable.Columns.Add("Status");
            DataRow dr =dTable.NewRow();
            dr["Employee"] = txtEmployee.Text.Trim();
            dr["Total"] = lblTotal.Text.Trim();
            dr["ToPay"] = txtToPay.Text.Trim();
            dTable.Rows.Add(dr);
            Session["Bill"] = dTable;


        }
        protected int get_bill_id()
        {
            int bill_id = 0;
           // SqlConnection con = new SqlConnection("Server=. ; DataBase=Webcomputer; Integrated Security = yes");

            string strSql = "select max(BillID) from TB_Bills";
            SqlCommand comn = new SqlCommand(strSql, objConn.SqlConn());
            comn.Connection.Open();
            //con.Open();
            SqlDataReader read = comn.ExecuteReader();
            while (read.Read())
            {
                bill_id = Convert.ToInt32(read.GetInt32(0));
            }
            //con.Close();
            comn.Connection.Close();

            return bill_id;
        }
        public void MakeCart()
        {
            if (Session["cart"] == null)
            {
                objDT = new DataTable("Cart");
                objDT.Columns.Add("ID");
                objDT.Columns["ID"].AutoIncrement = true;
                objDT.Columns["ID"].AutoIncrementSeed = 1;
                objDT.Columns.Add("ProvName");
                objDT.Columns.Add("ProvID");
                objDT.Columns.Add("Employee");
                objDT.Columns.Add("ProductName");
                objDT.Columns.Add("ProductID");
                objDT.Columns.Add("PriceInput");
                objDT.Columns.Add("Quantity");
                objDT.Columns.Add("BuyDate");
                objDT.Columns.Add("Total");
                Session["cart"] = objDT;
            }
            else
            {
                objDT = (DataTable)Session["cart"];
            }
        }

        public decimal GetItemTotal()
        {
            int intCounter;
            decimal decRunningTotal = 0;
            DataRow objDr;

            for (intCounter = 0; intCounter < objDT.Rows.Count; intCounter++)
            {
                objDr = objDT.Rows[intCounter];
                decRunningTotal = decRunningTotal + (Convert.ToDecimal(objDr["PriceInput"]) * Convert.ToDecimal(objDr["Quantity"]));

            }
            return decRunningTotal;
        }
       
        private void UpdateQuantityProduct()
        {
            dTable = (DataTable)Session["cart"];
            DataTable dt = new DataTable();
            int quantity = 0;
            int quantityInput = 0;
            bool ch = false;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                dt = objBill.SelectQuantityProduct(Convert.ToInt32(dTable.Rows[i]["ProductID"]));
                lblError.Text = dt.Rows[0][0].ToString();
                if (lblError.Text == "")
                {
                    quantity = 0;
                    quantityInput = quantity + Convert.ToInt32(dTable.Rows[i]["Quantity"]);
                    ch = objBill.UpdateQuantityProduct(Convert.ToInt32(dTable.Rows[i]["ProductID"]), quantityInput);
                }
                else
                {
                    quantity = Convert.ToInt32(lblError.Text);
                    quantityInput = quantity + Convert.ToInt32(dTable.Rows[i]["Quantity"]);
                    ch = objBill.UpdateQuantityProduct(Convert.ToInt32(dTable.Rows[i]["ProductID"]), quantityInput);
                }
            }
        }


        public void AddToCart(string namevar, string costvar)
        {

            objDT = (DataTable)Session["cart"];
            string product_name = namevar;
                        
            Bussiness.Common cls = new Bussiness.Common();
            int indexOfItem = cls.IsExistItemInShoppingCart(namevar, objDT);

            if (indexOfItem != -1)
            {
                objDT.Rows[indexOfItem]["Quantity"] = Convert.ToInt32(objDT.Rows[indexOfItem]["Quantity"]) + Convert.ToInt32(txtQuantity.Text);
            }
            else
            {
                objDR = objDT.NewRow();
                objDR["ProvName"] = ddlProvName.SelectedItem.ToString();
                objDR["ProvID"] = ddlProvName.SelectedValue.ToString();
                objDR["Employee"] = txtEmployee.Text;
                objDR["ProductName"] = product_name;
                objDR["ProductID"] = ddlProduct.SelectedValue.ToString();
                objDR["PriceInput"] = _costvar;
                objDR["Quantity"] = txtQuantity.Text;
                objDR["BuyDate"] = lblBuyDate.Text;
                objDR["Total"] = (Convert.ToDecimal(objDR["PriceInput"]) * Convert.ToDecimal(objDR["Quantity"]));
                objDT.Rows.Add(objDR);
            }
            Session["cart"] = objDT;
            Session["sum"] = GetItemTotal();
        }

        
        #region InsertDebt
        private void InsertDebt()
        {
            int check = GetArrears();
            if (check < 0)
            {
                lblError.Text = "Số tiền trả phải nhỏ hơn tổng tiền";
            }
            else if (check > 0)
            {
                string provid = (string)Session["ProvID"];
                int billid = get_bill_id();
                //if (check > 0)
                //{
                    bool ch = objBill.InsertDebt(billid, txtDescription.Text, check.ToString(), Convert.ToInt32(ddlProvName.SelectedValue));
                //}
            }
        }
        #endregion
        protected void btnAddToBill_Click(object sender, EventArgs e)
        {
            #region Insert vao bang Bill
            bool chtopay = fn.IsNumber(txtToPay.Text);
            if (this.txtToPay.Text == "")
            {
                this.lblError.Text = "Chưa nhập số tiền trả của hóa đơn này!";
                this.txtToPay.Focus();
            }
       
            else if (chtopay == false)
            {
                lblError.Text = "Số tiền trả không được nhập chữ";
                txtToPay.Text = "";
                txtToPay.Focus();
            }
            else
            {
                Info_Bill();
                ShowBill();
                insert_bill();
                insert_BillDetails();
                UpdateQuantityProduct();
                InsertDebt();
                Session.Remove("cart");
                Response.Redirect("~/Admin/OrderBill_List.aspx");
            }
            #endregion
        }
        #region GetArrears
        private int GetArrears()
        {
            
                int total = Convert.ToInt32(lblTotal.Text);
                int topay = Convert.ToInt32(txtToPay.Text);
                int arreares = total - topay;                
                return arreares;                        
        }
        #endregion

    }
}
