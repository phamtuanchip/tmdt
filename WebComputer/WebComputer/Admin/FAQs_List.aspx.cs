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
    public partial class FAQs_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();

        private string strAllowFunctions = "FAQ_List";
        private string strAllowFunction_Delete = "FAQ_Delete";
        private string strFunctionName = "Xóa faqs";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("FAQs_Manager");
            this.Submit_FAQs_AddNew.Text = this.Lang["add_new"].ToString();
            this.Submit_FAQs_Delete.Text = this.Lang["delete"].ToString();
            this.btSearch.Text = this.Lang["FAQsSearch"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!this.Page.IsPostBack)
                        FAQsList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void FAQsList()
        {
            GV_FAQs.DataSource = this.objBusinessLogic.Execute_Store("Get_All_FAQs");
            GV_FAQs.DataBind();
        }
        protected void Submit_FAQs_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("FAQs_AddNew.aspx");
        }
        protected void Submit_FAQs_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunction_Delete) == true)
                {
                    DeleteFAQs();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GV_FAQs_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            this.GV_FAQs.PageIndex = e.NewPageIndex;
            this.FAQsList();
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
        protected void SearchResult()
        {
            int rbValue;
            string strSearch = this.objEntities.SafeString(this.strSearch.Text);
            if (this.rbSearch.Checked)
                rbValue = 1;
            else
                rbValue = 0;

            if (strSearch != string.Empty)
            {
                GV_FAQs.DataSource = this.objBusinessLogic.Exec_Store("Get_Search_FAQs", strSearch, rbValue);
            }
            else
            {
                GV_FAQs.DataSource = this.objBusinessLogic.Execute_Store("Get_All_FAQs");
            }
            GV_FAQs.DataBind();
        }
        protected void DeleteFAQs()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intFaqs_id = Int32.Parse(item.Substring(9, item.Length - 9));
                        SqlCommand comm = new SqlCommand("Delete_FAQs", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Faqs_Id", intFaqs_id);
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
            this.FAQsList();
        }
    }
}
