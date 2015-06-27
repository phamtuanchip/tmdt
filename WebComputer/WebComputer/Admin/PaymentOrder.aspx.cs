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

namespace WebComputer.Admin
{
    public partial class PaymentOrder : System.Web.UI.Page
    {
        #region Public variable
        DataTable dTable = new DataTable();
        
        public Bussiness.BusinessLogic objBusi = new BusinessLogic();
        BUPaymentOrder BUPayment = new BUPaymentOrder();
        BUBill objBill = new BUBill();
        public Bussiness.Function objfun = new Function();
        private string strAllowFunctions = "PaymentOrder";
        #endregion
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
                        BindGrid();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }

        }
        
        private void BindGrid()
        {
             dTable = BUPayment.SelectAllPaymentOrder();
            if (dTable.Rows.Count > 0)
            {
                grvMain.DataSource = dTable;
                grvMain.DataBind();
            }
            else
            {
                lblError.Text = "Không có bản ghi nào trong dữ liệu";
            }
        }

        protected void btnAddPaymentOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/PaymentOrder_Add.aspx");
        }

        
    }
}
