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
    public partial class CartShow : System.Web.UI.Page
    {
        public Entity.Entities objentity = new Entities();
        public Bussiness.Function objFunc = new Function();
        public string checkout_url = "";
    
        #region Variables members

        System.Data.DataTable objDT;
        TextBox txtQuantity = new TextBox();
        public string s="";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    objDT = (DataTable)Session["cart"];
                    Repeater1.DataSource = objDT;
                    Repeater1.DataBind();

                    //string s = Convert.ToString(Session["sum"]);
                    s = objentity.SplitString(Session["sum"].ToString());

                    //int demo = Convert.ToInt32(Session["sum"]);
                    //(s == "")
                    if (s == "")
                    {
                        //lblSum.Text = "0";
                        lblSum.Text = 0.ToString();
                    }
                    else
                    {
                        //lblSum.Text = s;
                        lblSum.Text = objFunc.ChangeTypeMoney(s.ToString());
                    }
                }
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Làm đúng thao tác là được";
            }
            Bussiness.nganluong nl = new nganluong();
            
            string return_url = "http://www.beppro.vn/ThanhYou.aspx";
            string receiver = "beppro.vn@gmail.com";
            string transaction_info = "";
            string order_code = "ID200";
            string price = s.ToString();
            checkout_url = nl.buildCheckoutUrl(return_url, receiver, transaction_info, order_code, price);
            Literal2.Text = "  <a href=\"" + checkout_url + "\" title=\"\"><img src=\"https://www.nganluong.vn/data/images/buttons/3.gif\"  title=\"\"/></a>";
        }

        public decimal GetItemTotal()
        {
            try
            {
                int intCounter;
                decimal decRunningTotal = 0;
                DataRow objDr;

                for (intCounter = 0; intCounter < objDT.Rows.Count; )
                {
                    objDr = objDT.Rows[intCounter];
                    decRunningTotal = decRunningTotal + (Convert.ToDecimal(objDr["Price"]) * Convert.ToInt32(objDr["Quantity"]));
                }
                return decRunningTotal;
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Làm đúng thao tác là được";
                return 0;
            }
        }

        protected void Update_Delete_Item(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edit")
                {
                    objDT = (DataTable)Session["cart"];
                    foreach (RepeaterItem ri in Repeater1.Items)
                    {
                        txtQuantity = (TextBox)ri.FindControl("txtQuantity");
                        if (txtQuantity != null)
                        {
                            Label lblTitle = (Label)ri.FindControl("lblTitle");

                            UpdateCart(lblTitle.Text, Convert.ToInt32(txtQuantity.Text), objDT);
                        }
                    }

                    Session["cart"] = objDT;
                    Repeater1.DataSource = objDT;
                    Repeater1.DataBind();

                    lblSum.Text = "" + Get_Total().ToString("#,###,0");
                    Session["sum"] = Convert.ToDecimal(Get_Total());
                    Bussiness.nganluong nl = new nganluong();
                    string return_url = "http://www.beppro.vn/ThanhYou.aspx";
                    string receiver = "beppro.vn@gmail.com";
                    string transaction_info = "";
                    string order_code = "ID200";
                    string price =Session["sum"].ToString();
                    checkout_url = nl.buildCheckoutUrl(return_url, receiver, transaction_info, order_code, price);
                    Literal2.Text = "  <a href=\"" + checkout_url + "\" title=\"\"><img src=\"https://www.nganluong.vn/data/images/buttons/3.gif\"  title=\"\"/></a>";
                    //Session["total"] = lblSum.Text;
                }

                else
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

                    lblSum.Text = "" + Get_Total().ToString("#,###,00") + " (VNĐ)";
                    Session["sum"] = Convert.ToDecimal(lblSum.Text);
                }
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Làm đúng thao tác là được";
                //return 0;
            }
        }

        protected void UpdateCart(string title, int quantity, DataTable dt)
        {
                     
                foreach (DataRow dr in dt.Rows)
                {
                    if (title == dr["ProductName"].ToString())
                    {
                        dr["Quantity"] = quantity;
                        break;
                    }
                }
            
        }

        protected decimal Get_Total()
        {
            try
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
                        Total = Total + (Convert.ToDecimal(dr["price"]) * Convert.ToInt32(dr["quantity"]));
                    }
                }

                return Total;
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Làm đúng thao tác là được";
                return 0;
            }
        }

        protected void btnContinue_Shopping_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["UserName"] != null)
            {
                Response.Redirect("PreviewOrder.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
         }
    }
}
