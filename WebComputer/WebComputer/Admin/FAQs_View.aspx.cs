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
    public partial class FAQs_View : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();
        protected Hashtable Lang = new Hashtable();
        private int id;
        public string strQuestion = string.Empty;
        public string strAnswer = string.Empty;
        public string strQ_User = string.Empty;
        public string strQ_Email = string.Empty;
        public string strAuthor = string.Empty;
        public string dtCreateDate;
        public string dtAnswerDate;
        public bool Active;
        public int intLang;
        private string strAllowFunctions = "FAQ_List,FAQ_Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("FAQs_Manager");
            this.FAQs_Edit.Text = Lang["edit"].ToString();
            this.Back_FAQs.Value = Lang["back"].ToString();
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
                    FAQsView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        private void FAQsView()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_FAQs", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Faqs_id", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.strQuestion = drd["Question"].ToString();
                this.strAuthor = drd["Author"].ToString();
                this.strAnswer = drd["Answer"].ToString();
                this.strQ_User = drd["Q_User"].ToString();
                this.strQ_Email = drd["Q_Email"].ToString();
                this.intLang = int.Parse(drd["Language_Id"].ToString());
                this.Active = (bool)drd["Active"];
                if (drd["CreatedDate"].ToString() != null)
                    this.dtCreateDate = drd["CreatedDate"].ToString();
                if (drd["AnswerDate"].ToString() != null)
                    this.dtAnswerDate = drd["AnswerDate"].ToString();
            }
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void FAQs_Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("FAQs_Edit.aspx?id=" + this.id);
        }
    }
}
