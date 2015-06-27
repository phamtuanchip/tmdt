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
namespace WebComputer.Admin
{
    public partial class OrderBillDetails : System.Web.UI.Page
    {
        public Bussiness.Function objfun = new Function();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        private string strAllowFunctions = "OrderBillDetail";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!IsPostBack)
                    {
                        BindData();
                        BindGrid();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
       
        }
        private void BindData()
        {
            if (Request.QueryString["BillID"] != null)
            {
                En_Bill BEBill = new En_Bill();
                BUBill bill = new BUBill();
                BEBill = bill.SelectOneBill(Convert.ToInt32(Request.QueryString["BillID"]));
                if (BEBill != null)
                {
                    lblBuyDate.Text = BEBill._BuyDate.ToString();
                    lblEmployee.Text = BEBill._Employee.ToString();
                    //lblProvName.Text = BEBill._ProvName.ToString();
                    lblTotal.Text = objfun.ChangeTypeMoney(BEBill._Total.ToString());
                    lblToPay.Text = objfun.ChangeTypeMoney(BEBill._Topay.ToString());
                    //lblRemain.Text = BEBill._Remain.ToString();
                }
            }
        }
        private void BindGrid()
        {
            if (Request.QueryString["BillID"] != null)
            {
                DataTable dTable = new DataTable();
                BUBill bill = new BUBill();
                dTable = bill.SelectOneBillToBillDetails(Convert.ToInt32(Request.QueryString["BillID"]));
                if (dTable.Rows.Count > 0)
                {
                    grvMain.DataSource = dTable;
                    grvMain.DataBind();
                }
            }
           
        }
    }
}
