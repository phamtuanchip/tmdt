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
    public partial class FAQs_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "FAQ_Edit";
        private string strFunctionName = "Sửa faqs";
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("FAQs_Manager");
            this.FAQ_Edit.Text = Lang["edit"].ToString();
            this.ResetForm.Value = Lang["reset_form"].ToString();
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
                    if (!IsPostBack)
                    {
                        objBusinessLogic.GetLanguage(this.DDL_Lang);
                        FAQsEditView();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void FAQsEditView()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_FAQs", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Faqs_id", id);

            try
            {
                comm.Connection.Open();
                drd = comm.ExecuteReader();
                if (drd.Read())
                {
                    this.DDL_Lang.SelectedValue = drd["language_id"].ToString();
                    this.txtQuestion.Text = drd["Question"].ToString();
                    this.txtQ_User.Text = drd["Q_User"].ToString();
                    this.txtQ_Email.Text = drd["Q_Email"].ToString();
                    this.txtAuthor.Text = drd["Author"].ToString();
                    this.txtActive.Checked = (bool)drd["Active"];
                    this.Content.Value = drd["Answer"].ToString();
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
        protected void FAQ_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateFAQs();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateFAQs()
        {
            bool boolActive;
            int intLang = int.Parse(this.objEntities.SafeString(this.DDL_Lang.Text));
            string strQ_User = this.objEntities.SafeString(this.txtQ_User.Text);
            string strQ_Email = this.objEntities.SafeString(this.txtQ_Email.Text);
            string strAuthor = this.objEntities.SafeString(this.txtAuthor.Text);
            string strQuestion = this.objEntities.SafeString(this.txtQuestion.Text);
            string strAnswer = this.objEntities.SafeString(this.Content.Value);
            string strIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            if (this.txtActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Update_FAQs", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Faqs_Id", id);
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
