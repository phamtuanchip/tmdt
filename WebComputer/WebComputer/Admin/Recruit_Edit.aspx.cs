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
    public partial class Recruit_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        public string strFromDate, strEnddate;
        int id;
        private string strAllowFunctions = "recruit_edit";
        private string strFunctionName = "Sửa thông tin tuyển dụng";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("RECRUIT_Manager");
            this.Recruits_Edit.Text = Lang["edit"].ToString();
            this.Reset_Form.Value = Lang["reset_form"].ToString();
            this.Back_Edit.Value = Lang["back"].ToString();
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
                    if (!Page.IsPostBack)
                    {
                        objBusinessLogic.GetLanguage(this.DDL_Language);
                        this.RecruitEditView();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void RecruitEditView()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Recruit", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Recruit_Id", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                this.DDL_CatId.SelectedValue = drd["Cat_Id"].ToString();
                this.tbRecruitmentTitle.Text = drd["RecruitmentTitle"].ToString();
                this.Content.Value = drd["RecruitmentDesc"].ToString();
                strFromDate = drd["StartDate"].ToString();
                strEnddate = drd["EndDate"].ToString();
                if ((bool)drd["Active"])
                    this.cbActive.Checked = true;
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void Recruits_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateRecruit();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateRecruit()
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
            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            int intCat_Id = int.Parse(objEntities.SafeString(this.DDL_CatId.SelectedValue));
            string strtbRecruitmentTitle = objEntities.SafeString(tbRecruitmentTitle.Text);
            string strContent = objEntities.SafeString(Content.Value);
            if ((bool)cbActive.Checked)
                boolActive = true;

            SqlCommand comm = new SqlCommand("Update_Recruit", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Recruit_Id", id);
            comm.Parameters.AddWithValue("@RecruitmentTitle", strtbRecruitmentTitle);
            comm.Parameters.AddWithValue("@RecruitmentDesc", strContent);
            comm.Parameters.AddWithValue("@StartDate", strFromDate);
            comm.Parameters.AddWithValue("@EndDate", strEnddate);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@Language_Id", intLanguage_Id);
            comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strtbRecruitmentTitle);
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
