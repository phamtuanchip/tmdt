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
    public partial class Editor_View : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "news_list,news_edit";
        private string strPublishFunctions = "news_publish";
        private int id = 0;
        public string strCatName = string.Empty;
        public string strSubject = string.Empty;
        public string strBrief = string.Empty;
        public string strImage = string.Empty;
        public string strAuthor = string.Empty;
        public string strContent = string.Empty;
        public string strCreateDate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            this.News_Edit.Text = Lang["edit"].ToString();
            this.Back_View.Value = Lang["Return"].ToString();
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
                    NewsView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void NewsView()
        {
            int LeadImage = 0;
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_News", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@News_Id", id);
            comm.Parameters.AddWithValue("@Author", Session["AdminID"].ToString());
            if (objBusinessLogic.Permission(this.strPublishFunctions) == true)
                comm.Parameters.AddWithValue("@Style", 1);
            else
                comm.Parameters.AddWithValue("@Style", 0);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                strCatName = drd["CatName"].ToString();
                strSubject = drd["Subject"].ToString();
                strBrief = drd["Brief"].ToString();
                LeadImage = int.Parse(drd["LeadImage"].ToString());
                strImage = objBusinessLogic.wrImages(LeadImage, objEntities.GetPathLibraryImage());
                strAuthor = drd["Author"].ToString();
                strContent = drd["Content"].ToString();
                strCreateDate = objEntities.FormatDateTimeVN(drd["CreateDate"].ToString());
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void News_Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editor_Edit.aspx?id=" + id);
        }
    }
}
