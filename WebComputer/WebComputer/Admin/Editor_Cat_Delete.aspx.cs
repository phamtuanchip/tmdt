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
    public partial class Editor_Cat_Delete : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "newscat_delete";
        private string strFunctionName = "Xóa danh mục tin tức";
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                id = int.Parse(objEntities.SafeString(Request.QueryString["id"].ToString()));
            }

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    DeleteCatNews();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteCatNews()
        {
            SqlCommand comm = new SqlCommand("Delete_Cat_News", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cat_Id", id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), string.Empty);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Editor_Cat_List.aspx");
            }
        }
    }
}
