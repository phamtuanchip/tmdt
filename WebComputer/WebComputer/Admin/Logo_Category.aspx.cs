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
    public partial class Logo_Category : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        
        //protected System.Web.UI.WebControls.GridView GV_LogoCategory = new System.Web.UI.WebControls.GridView();
        //protected System.Web.UI.WebControls.Button Submit_CatLogo_AddNew = new System.Web.UI.WebControls.Button();
        //protected System.Web.UI.WebControls.Button Submit_CatLogo_Delete = new System.Web.UI.WebControls.Button();

        private string strAllowFunctions = "logocat_list";
        private string strAllowFunctions_Delete = "Logocat_delete";
        private string strFunctionName = "Xóa danh mục logo";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            this.Submit_CatLogo_AddNew.Text = Lang["add_new"].ToString();
            this.Submit_CatLogo_Delete.Text = Lang["delete"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.ListCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        public void ListCatLogo()
        {
            this.GV_LogoCategory.DataSource = this.objBusinessLogic.Execute_Store("Get_Category_Logo");
            this.GV_LogoCategory.DataBind();
        }
        protected void Submit_CatLogo_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_Delete) == true)
                {
                    this.DeleteCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void Submit_CatLogo_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogoCat_AddNew.aspx");
        }
        public void DeleteCatLogo()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intCatLogo_id = Int32.Parse(item.Substring(9, item.Length - 9));
                    SqlCommand comm = new SqlCommand("Delete_Cat_Logo", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Cat_Id", intCatLogo_id);
                    try
                    {
                        comm.Connection.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message.ToString());
                    }
                    finally
                    {
                        comm.Connection.Close();
                        comm.Connection.Dispose();
                    }
                    this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), string.Empty);
                    this.ListCatLogo();
                }
            }
        }
       
        //protected void Submit_CatLogo_AddNew_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Submit_CatLogo_Delete_Click(object sender, EventArgs e)
        //{

        //}
    }
}
