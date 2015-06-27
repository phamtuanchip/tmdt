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
    public partial class Report_Other : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BU_Report_Other objOther = new BU_Report_Other();
        public Bussiness.Function objfun = new Function();
        public DataTable datatb;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            
        }

        public void ShowTotalOrderBills()
        {
           // int year;
           // year = Convert.ToInt32(this.txt_YearReport.Text);
            datatb = new DataTable();
            datatb = objOther.SelectTotalOrderBills();
            this.GridView_ReportOther.DataSource = datatb;
            this.GridView_ReportOther.DataBind();


        }
        public void ShowTotalOrderDetails()
        {
            //int year;
            // year = Convert.ToInt32(this.txt_YearReport.Text);
            datatb = new DataTable();
            datatb = objOther.SelectTotalOrder();
            this.GridView_ReportOther.DataSource = datatb;
            this.GridView_ReportOther.DataBind();

        }

        protected void btn_ThongKeKhac_Click(object sender, EventArgs e)
        {
            if (this.DropDownList_ReportOther.SelectedIndex == 0)
            {
                this.lbl_Messager.Text = "Chưa chọn tiêu chí tìm kiếm!";
                this.DropDownList_ReportOther.Focus();
            }
            //else if (this.txt_YearReport.Text == "")
            //{
            //    this.lbl_Messager.Text = "Chưa nhập năm thống kê!";
            //    this.txt_YearReport.Focus();
            //}
            else if (this.DropDownList_ReportOther.SelectedIndex == 1)
            {
                this.lbl_Messager.Text = null;
                ShowTotalOrderBills();
            }
            else if (this.DropDownList_ReportOther.SelectedIndex == 2)
            {
                this.lbl_Messager.Text = null;
                ShowTotalOrderDetails();
            }
            
        }

       
     
    }
}
