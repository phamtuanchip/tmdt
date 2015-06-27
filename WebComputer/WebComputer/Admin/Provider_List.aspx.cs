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
    public partial class Provider_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        protected Hashtable Lang = new Hashtable();
        private string strFunctionName = "Xóa thông tin nhà cung cấp";
        private string strAllowFunctions_delete = "Provider_Delete";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Provider_Manager");
            this.Prov_Add.Text = Lang["Prov_Add"].ToString();
            this.Provider_Delete.Text = Lang["Prov_Delete"].ToString();
            this.Get_All_Provider();
        }
        private void Get_All_Provider()
        {
            this.GV_Prov_List.DataSource = objBusinessLogic.CreateDataTable("Get_All_Provider", false);
            this.GV_Prov_List.DataBind();
        }
        protected void GV_Prov_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Prov_List.PageIndex = e.NewPageIndex;
            this.Get_All_Provider();
        }
        protected void Provider_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    DeleteProvider();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteProvider()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intNews_Id = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Delete_Provider", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Provider_Id", intNews_Id);
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
                        //===========End Delete Database===============================
                    }
                }
            }
            this.Get_All_Provider();
        }

        protected void Prov_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Provider_Add.aspx");
        }
    }
}
