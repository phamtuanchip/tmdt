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
using System.Text;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Order_List : System.Web.UI.Page
    {
      
        public Bussiness.Function objfun = new Function();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        private string strAllowFunctions = "Order_List";

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
            DataTable dTable = new DataTable();
            BU_Order BUOrder = new BU_Order();
            dTable = BUOrder.SelectAll();
            grvMain.DataSource = dTable;
            grvMain.DataBind();
        }
        protected string GetStatus(object values)
        {
            if (values.Equals(true)) return "Đã xử lý";
            return "Chưa xử lý";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BU_Order BUOrder = new BU_Order();
            if (ddlSearch.SelectedValue == "0")
            {
                lblError.Text = "Bạn chưa chọn tiêu chí tìm kiếm";
            }
            else if (this.txtSearch.Text == "")
            {
                this.lblError.Text = "Chưa nhập thông tin tìm kiếm!";
                this.txtSearch.Focus();
            }
            else if (ddlSearch.SelectedValue == "1")
            {
               
                DataTable dTable = new DataTable();
                //dTable = BUOrder.SearchOrder(Convert.ToInt32(txtSearch.Text),null);                
                dTable = BUOrder.SearchOrderID(Convert.ToInt32(txtSearch.Text));
                if (dTable.Rows.Count >= 1)
                {
                    this.lblError.Text = null;
                    grvMain.DataSource = dTable;
                    grvMain.DataBind();
                }
                else
                {
                    lblError.Text = "không có dữ liệu cần tìm!!!";
                }
            }
            else if (ddlSearch.SelectedValue == "2")
            {
                
                DataTable dTable = new DataTable();
                //dTable = BUOrder.SearchOrder(int.Parse(null),txtSearch.Text);
                dTable = BUOrder.SearchOrderDate(txtSearch.Text);
                if (dTable.Rows.Count >= 1)
                {
                    this.lblError.Text = null;
                    grvMain.DataSource = dTable;
                    grvMain.DataBind();
                }
                else
                {
                    lblError.Text = "không có dữ liệu cần tìm!!!";
                }

            }
        }
    }
}
