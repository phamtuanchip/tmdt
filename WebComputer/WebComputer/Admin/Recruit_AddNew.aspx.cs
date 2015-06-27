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
    public partial class Recruit_AddNew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "recruit_addnew";
        private string strFunctionName = "Thêm mới thông tin tuyển dụng";
        private string strFromDate, strEnddate;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("RECRUIT_Manager");
            Recruit_AddNews.Text = Lang["add_new"].ToString();
            Reset_Form.Value = Lang["reset_form"].ToString();
            Back_AddNew.Value = Lang["back"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    objBusinessLogic.GetLanguage(DDL_Language);
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void Recruit_AddNews_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertRecruit();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertRecruit()
        {
            if (HttpContext.Current.Request.Form["FromDatePublic"] != null)
            {

                strFromDate = objEntities.SafeString(HttpContext.Current.Request.Form["FromDatePublic"].ToString());
            }
            if (HttpContext.Current.Request.Form["EndDatePublic"] != null)
            {
                strEnddate = objEntities.SafeString(HttpContext.Current.Request.Form["EndDatePublic"].ToString());
            }

            bool boolActive = false;
            int intLanguage_id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            int intCat_Id = int.Parse(objEntities.SafeString(DDL_CatId.SelectedValue));
            string strRecruitTitle = objEntities.SafeString(tbRecruitmentTitle.Text);
            string strContent = objEntities.SafeString(Content.Value);
            if (cbActive.Checked)
                boolActive = true;

            SqlCommand comm = new SqlCommand("Insert_Recruit", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@RecruitmentTitle", strRecruitTitle);
            comm.Parameters.AddWithValue("@RecruitmentDesc", strContent);
            comm.Parameters.AddWithValue("@StartDate", strFromDate);
            comm.Parameters.AddWithValue("@EndDate", strEnddate);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@Language_Id", intLanguage_id);
            comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strRecruitTitle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Recruit_List.aspx");
            }
        }
    }
}
