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
    public partial class StaticalProvider : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BU_Provider objProv = new BU_Provider();
        public Bussiness.BusinessLogic objBusi = new BusinessLogic();
        protected Hashtable Lang = new Hashtable();
        public DataTable datatb;
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;
        //private string strAllowFunctions = "ReportList";


        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Provider_Manager");
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                //if (objBusi.Permission(this.strAllowFunctions) == true)
                //{
                    this.Get_All_Provider();
                //}
                //else
                //{
                //    Response.Redirect("EOFPermission.aspx");
                //}
            }
           
        }

        #region Hiển thị thông tin chung của nhà cung cấp
        private void Get_All_Provider()
        {
            datatb = new DataTable();
            datatb = objProv.SelectAllProviderReport();
            this.GridView_ReportProvider.DataSource = datatb;
            this.GridView_ReportProvider.DataBind();
        }
        #endregion

        #region Hàm hiển thị tổng số nhà cung cấp
        public void ShowSumProvider()
        {
            datatb = new DataTable();
            datatb = objProv.SelectSumProvider();
            this.GridView_ReportProvider.DataSource = datatb;
            this.GridView_ReportProvider.DataBind();
        }
        #endregion

        #region Hàm hiển thị nhà cung cấp có công nợ lớn nhất
        public void ShowProvDebtMax()
        {
            datatb = new DataTable();
            datatb = objProv.SelectMaxDebtProvider();
            this.GridView_ReportProvider.DataSource = datatb;
            this.GridView_ReportProvider.DataBind();
        }

        #endregion

        #region Hàm hiển thị nhà cung cấp có công nợ nhỏ nhất
        public void ShowProvDebtMin()
        {
            datatb = new DataTable();
            datatb = objProv.SelectMinDebtProvider();
            this.GridView_ReportProvider.DataSource = datatb;
            this.GridView_ReportProvider.DataBind();
        }
        #endregion

        #region Hàm hiển thị tổng các sản phẩm của nhà cung cấp
        public void ShowTotalProInProvider()
        {
            datatb = new DataTable();
            datatb = objProv.SelectTotalProductInProvider();
            this.GridView_ReportProvider.DataSource = datatb;
            this.GridView_ReportProvider.DataBind();

        }
        #endregion

        



        public void ChartingShow()
        {

            //sqlcom = new SqlCommand("pr_Timnhacungcapcocongnolonnhat", this.objConn.SqlConn());
            //sqlcom.CommandType = CommandType.StoredProcedure;
            //sqldap = new SqlDataAdapter(sqlcom);
            //dts = new Admin.Report.Provider.DataSet_ProviderReport();
            //sqldap.Fill(dts, "test");
            //datatb = new DataTable();
            //datatb = dts.Tables["test"];
            //Admin.Report.Provider.CrystalReport_Provider rpt = new WebComputer.Admin.Report.Provider.CrystalReport_Provider();
            //rpt.SetDataSource(datatb);
            //CrystalReportViewer1.ReportSource = rpt;
        }
        protected void btn_ReportProvider_Click(object sender, EventArgs e)
        {
            if (this.DropDownList_ReportProvider.SelectedIndex == 0)
            {
                this.lbl_Messager.Text = "Bạn chưa chọn tiêu chí thống kê";
                this.DropDownList_ReportProvider.Focus();
            }
            else if (this.DropDownList_ReportProvider.SelectedIndex == 1)
            {
                ShowSumProvider();
            }
            else if (this.DropDownList_ReportProvider.SelectedIndex == 2)
            {
                ShowProvDebtMax();
               // ChartingShow();
            }
            else if (this.DropDownList_ReportProvider.SelectedIndex == 3)
            {
                ShowProvDebtMin();
            }
            else if (this.DropDownList_ReportProvider.SelectedIndex == 4)
            {
                ShowTotalProInProvider();
            }

        }

    }
}
