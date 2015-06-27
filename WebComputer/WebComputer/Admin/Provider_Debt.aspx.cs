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
    public partial class Provider_Debt : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Bussiness.Function objfun = new Function();
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "Product_debt";
       // private string strFunctionName = "Xóa thông tin nhà cung cấp";
       // private string strAllowFunctions_delete = "Provider_Delete";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Provider_Manager");
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.Get_All_Provider();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
            //this.Prov_Add.Text = Lang["Prov_Add"].ToString();
            //this.Provider_Delete.Text = Lang["Prov_Delete"].ToString();
            
        }
        private void Get_All_Provider()
        {
            this.GV_Prov_List.DataSource = objBusinessLogic.CreateDataTable("sp_selectProvdebt", false);
            this.GV_Prov_List.DataBind();
        }
        protected void GV_Prov_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Prov_List.PageIndex = e.NewPageIndex;
            this.Get_All_Provider();
        }
       
      

        
    }
}
