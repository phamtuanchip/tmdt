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
    public partial class FAQs_AddNew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();

        private string strAllowFunctions = "FAQ_AddNew";
        private string strFunctionName = "Thêm mới faqs";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("FAQs_Manager");
            this.FAQ_AddNew.Text = Lang["add_new"].ToString();
            this.Back_AddNew.Value = Lang["back"].ToString();
            this.ResetForm.Value = Lang["reset_form"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!IsPostBack)
                    {
                        objBusinessLogic.GetLanguage(this.DDL_Lang);
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void FAQ_AddNew_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    InsertFAQs();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertFAQs()
        {
            bool boolActive;
            int intLang = int.Parse(this.objEntities.SafeString(this.DDL_Lang.Text));
            string strQuestion = this.objEntities.SafeString(this.txtQuestion.Text);
            string strQ_User = this.objEntities.SafeString(this.txtQ_User.Text);
            string strQ_Email = this.objEntities.SafeString(this.txtQ_Email.Text);
            string strAnswer = this.objEntities.SafeString(this.Content.Value);
            string strIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string strAuthor = this.objEntities.SafeString(this.txtAuthor.Text);
            if (this.txtActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Insert_FAQs", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Question", strQuestion);
            comm.Parameters.AddWithValue("@Q_User", strQ_User);
            comm.Parameters.AddWithValue("@Q_Email", strQ_Email);
            comm.Parameters.AddWithValue("@Answer", strAnswer);
            comm.Parameters.AddWithValue("@Language_Id", intLang);
            comm.Parameters.AddWithValue("@IP", strIP);
            comm.Parameters.AddWithValue("@Author", strAuthor);
            comm.Parameters.AddWithValue("@active", (bool)boolActive);

            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), strQuestion);
                    Response.Redirect("FAQs_List.aspx");
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
            }
        }
    }
}
