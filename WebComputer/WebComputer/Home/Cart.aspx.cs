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
using System.Data.SqlClient;

using Bussiness;
using Entity;


namespace WebComputer.Home
{
    public partial class Cart : System.Web.UI.Page
    {
       public  SqlDataAdapter adt;

        public System.Data.DataTable objDT;
        public System.Data.DataRow objDR;
        public int pid;
        public string _costvar;
        public string _namevar;
        public decimal _price=0;

        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objfunc = new Function();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["ProID"] != null && Request.QueryString["ProID"].ToString() != "")
            //{
            //    pid = Convert.ToInt32(objEntities.SafeString(Request.QueryString["ProID"].ToString()));
            //    //if (!IsPostBack)
            //    //{
            //        ShowCart();
            //        MakeCart();
            //    //}
            //}


            pid = Convert.ToInt32(Request.QueryString["ProID"]);
            ShowCart();
            MakeCart();
        }

        public void ShowCart()
        {
            DataSet dts = new DataSet();
            SqlCommand comm = new SqlCommand("Get_Product_ByID", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Pid", pid);
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            adt = new SqlDataAdapter(comm);
           // adt.SelectCommand = comm;
            adt.Fill(dts);
            DataTable dt = new DataTable();
            dt = dts.Tables[0];

            lblName.Text = dt.Rows[0]["Product_Name"].ToString();
            lblCost.Text = objfunc.ChangeTypeMoney(objEntities.SplitString(dt.Rows[0]["Product_Price"].ToString()));
            _namevar = dt.Rows[0]["Product_Name"].ToString();
            //_costvar = dt.Rows[0]["Product_Price"].ToString();
            _price = Convert.ToDecimal(dt.Rows[0]["Product_Price"].ToString());


        }

        public void MakeCart()
        {
            if (Session["cart"] == null)
            {
                objDT = new DataTable("Cart");
                objDT.Columns.Add("ID");
                objDT.Columns["ID"].AutoIncrement = true;
                objDT.Columns["ID"].AutoIncrementSeed = 1;

                objDT.Columns.Add("ProductName");
                objDT.Columns.Add("Price");
                objDT.Columns.Add("Quantity");
                objDT.Columns.Add("Total");
                objDT.Columns.Add("Product_ID");

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
                decRunningTotal = decRunningTotal + (Convert.ToDecimal(objDr["Price"]) * Convert.ToInt32(objDr["Quantity"]));

            }
            return decRunningTotal;
        }

        public void AddToCart(string namevar, string costvar, int _pid)
        {
            
            objDT = (DataTable)Session["cart"];
            string product_name = namevar;

            Common cls = new Common();
            int indexOfItem = cls.IsExistItemInShoppingCart(namevar, objDT);

            if (indexOfItem != -1)
            {
                objDT.Rows[indexOfItem]["Quantity"] = Convert.ToInt32(objDT.Rows[indexOfItem]["Quantity"]) + Convert.ToInt32(txtCount.Text);
            }
            else
            {
                objDR = objDT.NewRow();
                objDR["ProductName"] = product_name;
                //objDR["Price"] = _costvar;
                objDR["Price"] = _price;
                //objDR["Product_ID"] = Session["Pid"];
                objDR["Product_ID"] = pid;
                objDR["Quantity"] = txtCount.Text;
                objDR["Total"] = (Convert.ToDecimal(objDR["Price"]) * Convert.ToInt32(objDR["Quantity"]));
                objDT.Rows.Add(objDR);
            }


            Session["cart"] = objDT;
            Session["sum"] = GetItemTotal();


        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ValidateWebForm.IsNumber(txtCount.Text.Trim()) == false)
            {
                Literal1.Text = "Số lượng phải là 1 số nguyên !";
            }
            else
            {
                int _quantity = Convert.ToInt32(txtCount.Text.Trim());
                int _pid = Convert.ToInt32(objEntities.SafeString(Request.QueryString.Get("ProId").ToString()));
                string strSql = "select Product_QuatityOut from TB_Product where Product_ID = '" + _pid + "'";
                SqlDataAdapter adt = new SqlDataAdapter(strSql, objConn.SqlConn());
                DataSet dts = new DataSet();
                adt.Fill(dts);


                int _countQuantity = Convert.ToInt32(dts.Tables[0].Rows[0]["Product_QuatityOut"]);
                int _UntilQuantity = 0;

                //if (Session["cart"] != null)
                //{
                objDT = (DataTable)Session["cart"];

             
                       
                            AddToCart(_namevar, _costvar, _pid);
                            Response.Redirect("CartShow.aspx");
                            
             

                //}
            }
        }
    }
    }