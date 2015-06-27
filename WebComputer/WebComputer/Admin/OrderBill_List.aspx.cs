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

namespace WebComputer.Admin
{
    public partial class OrderBill_List : System.Web.UI.Page
    {
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        private string strAllowFunctions = "OrderBillLis";
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
            //BindGrid();
        }
        #region Method
        private void BindGrid()
        {
            DataTable dTable = new DataTable();
            BUBill Bill = new BUBill();
            dTable = Bill.SelectAllBill();
            grvMain.DataSource = dTable;
            grvMain.DataBind();
        }
        #endregion

        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/OrderBill_Add.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BUBill objbill = new BUBill();
            DataTable dTable = new DataTable();
            if (ddlSearch.SelectedValue == "0")
            {
                lblError.Text = "Bạn chưa chọn tiêu chí tìm kiếm";
            }
            else if (txtSearch.Text == "")
            {
                lblError.Text = "Bạn chưa nhập từ khoá cần tìm";
            }
            else
            {
                if (ddlSearch.SelectedValue == "1")
                {
                    Function fn = new Function();
                    bool ch = fn.IsDate(txtSearch.Text);
                    if (ch == true)
                    {
                        dTable = objbill.SearchBill(Convert.ToDateTime(txtSearch.Text), 1);
                        if (dTable.Rows.Count > 0)
                        {
                            lblError.Text = "";
                            grvMain.DataSource = dTable;
                            grvMain.DataBind();
                        }
                        else
                        {
                            lblError.Text = "Không có dữ liệu cần tìm";

                        }
                    }
                    else
                    {
                        lblError.Text = "Không đúng định dạng ngày tháng";
                    }
                }
                else if (ddlSearch.SelectedValue == "2")
                {
                    dTable = objbill.SearchBill(Convert.ToDateTime("12/12/2009"), Convert.ToInt32(txtSearch.Text));
                    if (dTable.Rows.Count > 0)
                    {
                        lblError.Text = "";
                        grvMain.DataSource = dTable;
                        grvMain.DataBind();
                    }
                    else
                    {
                        lblError.Text = "Không có dữ liệu cần tìm";
                    }
                }
            }
        }
    }
}
