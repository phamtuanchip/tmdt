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
using Entity;
using Bussiness;


namespace WebComputer.Admin
{
    public partial class Customer_Report : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BU_Customer objCus = new BU_Customer();
        public Bussiness.BusinessLogic objBusi = new BusinessLogic();
        public DataTable datatb;
        private string strAllowFunctions = "Customer_List";
        
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
                    ShowAllCustomer();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
           
        }
        #region Hàm hiển thị dánh sách khách hàng

        public void ShowAllCustomer()
        {
            datatb = new DataTable();
            datatb = objCus.SelectAllCustomer();
            this.GridView_Customer.DataSource = datatb;
            this.GridView_Customer.DataBind();
        }
        #endregion

        #region Hàm hiển thị tổng số lương khách hàng đã mua sản phẩm
        public void ShowTotalCustomer()
        {
            datatb = new DataTable();
            datatb = objCus.SelectTotalCustomerSale();
            this.Dtg_Report_Customer.DataSource = datatb;
            this.Dtg_Report_Customer.DataBind();
        }
        #endregion

        #region Hàm hiển thị khách hàng mua nhiều nhất
        public void ShowTotalMaxCus()
        {
            datatb = new DataTable();
            datatb = objCus.SelectTotalMaxCus();
            this.Dtg_Report_Customer.DataSource = datatb;
            this.Dtg_Report_Customer.DataBind();
        }
        #endregion 

        #region Hàm hiển thị khách hàng mua sản phẩm có giá trị lớn
        public void ShowMoneyCusSale()
        {
            datatb = new DataTable();
            datatb = objCus.SelectMoneyTotalMaxCus();
            this.Dtg_Report_Customer.DataSource = datatb;
            this.Dtg_Report_Customer.DataBind();
        }
        #endregion

        protected void Btn_ReportCus_Click(object sender, EventArgs e)
        {
            if (this.DropDownList_CusReport.SelectedIndex == 0)
            {
                this.Lbl_Messager.Text = "Bạn chưa chọn tiêu chí tìm kiếm!";
                this.DropDownList_CusReport.Focus();
            }
            else if (this.DropDownList_CusReport.SelectedIndex == 1)
            {
                this.Lbl_Messager.Text = null;
                ShowTotalCustomer();
            }
            else if (this.DropDownList_CusReport.SelectedIndex == 2)
            {
                ShowTotalMaxCus();
            }
            else if (this.DropDownList_CusReport.SelectedIndex == 3)
            {
                ShowMoneyCusSale();
            }
        }
    }
}
