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
using System.Text;
using System.IO;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Banner_Category : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "bannercat_list";
        private string strAllowFunctions_Delete = "bannercat_delete";
        private string strFunctionName = "Xoá danh mục banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.Delete_Banner.Text = Lang["delete"].ToString();
            this.AddNew_Banner.Text = Lang["add_new"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.ListCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void ListCatBanner()
        {

            this.GV_BannerCategory.DataSource = this.objBusinessLogic.Execute_Store("Get_Category_Banner");
            this.GV_BannerCategory.DataBind();
        }
        protected void Delete_Banner_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_Delete) == true)
                {
                    this.DeleteCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteCatBanner()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intCatBanner_id = Int32.Parse(item.Substring(9, item.Length - 9));
                    SqlCommand comm = new SqlCommand("Delete_Cat_Banner", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Cat_Id", intCatBanner_id);
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
                    this.ListCatBanner();
                }
            }
        }
        protected void AddNew_Banner_Click(object sender, EventArgs e)
        {
            Response.Redirect("BannerCat_AddNew.aspx");
        }
    }
}
