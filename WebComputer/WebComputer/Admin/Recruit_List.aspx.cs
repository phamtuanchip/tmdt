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
    public partial class Recruit_List : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "recruit_list";
        private string strAllowFunctions_delete = "recruit_delete";
        private string strFunctionName = "Xóa thông tin tuyển dụng";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("RECRUIT_Manager");
            Recruit_AddNew.Text = Lang["add_new"].ToString();
            Recruit_Delete.Text = Lang["delete"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.RecruitList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void RecruitList()
        {
            this.GV_Recruit.DataSource = objBusinessLogic.Execute_Store("Get_All_Recruit");
            this.GV_Recruit.DataBind();
        }
        protected void Recruit_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recruit_AddNew.aspx");
        }
        protected void Recruit_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    this.DeleteRecruit();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteRecruit()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intRecruit_Id = int.Parse(item.Substring(9, item.Length - 9));
                        SqlCommand comm = new SqlCommand("Delete_Recruit", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Recruit_Id", intRecruit_Id);
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
                    }
                }
            }
            this.RecruitList();
        }
    }
}
