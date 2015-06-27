using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Bussiness;
using Entity;

namespace WebComputer.Admin
{
    public partial class Product_Cat_Delete : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "productcat_delete";
        private string strFunctionName = "Xóa danh mục sản phẩm";
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
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
                    DeleteCatProduct();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteCatProduct()
        {
            SqlCommand comm = new SqlCommand("Delete_Cat_Product", objConn.SqlConn());
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
                Response.Redirect("Product_Cat_List.aspx");
            }
        }
    }
}