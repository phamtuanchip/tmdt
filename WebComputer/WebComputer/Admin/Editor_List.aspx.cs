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
using System.Text;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Editor_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "news_list";
        private string strPublishFunctions = "news_publish";
        private string strAllowFunctions_delete = "news_delete";
        private string strFunctionName = "Xoá tin tức";
        private int intCat_Id = 0;
        private int intStatus_Id = 0;
        private string strSearch = string.Empty;
        private bool boolSearchIn = false;
        private string strFromDate = string.Empty;
        private string strToDate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            this.News_Delete.Text = Lang["delete"].ToString();
            this.bntSearch.Text = Lang["Search"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.CMSStatus_Id.InnerHtml = NewsStatus();
                    this.CMSNews_Cat_Root.InnerHtml = wrNewsCatRoot();
                    NewsList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void NewsList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_News", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
            comm.Parameters.AddWithValue("@strSearch", strSearch);
            comm.Parameters.AddWithValue("@SearchIn", (bool)boolSearchIn);
            comm.Parameters.AddWithValue("@FromDate", strFromDate);
            comm.Parameters.AddWithValue("@ToDate", strToDate);
            comm.Parameters.AddWithValue("@Status_Id", intStatus_Id);
            comm.Parameters.AddWithValue("@Author", Session["AdminID"].ToString());
            if (objBusinessLogic.Permission(this.strPublishFunctions) == true)
                comm.Parameters.AddWithValue("@Style", 1);
            else
                comm.Parameters.AddWithValue("@Style", 0);

            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.GV_News_List.DataSource = dts;
            this.GV_News_List.DataBind();
            adt.Dispose();
            dts.Clear();
            dts.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected string NewsStatus()
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Status", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SStatus_Id' size='1'>");
            tbl.Append("                <option value=''>[" + Lang["SelectStatus"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSelected = string.Empty;
                if (intStatus_Id == int.Parse(dt.Rows[i]["Status_ID"].ToString()))
                    strSelected = " selected ";
                tbl.Append("            <option value='" + dt.Rows[i]["Status_ID"].ToString() + "' " + strSelected + ">" + dt.Rows[i]["StatusName"].ToString() + "</option>");
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        protected string wrNewsCatRoot()
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_CatNews", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SCat_Id' size='1'>");
            tbl.Append("                <option value=''>[" + Lang["NewsCatChoice"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strSelected = string.Empty;
                    if (intCat_Id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "' " + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, intCat_Id, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        protected void GV_News_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_News_List.PageIndex = e.NewPageIndex;
            this.NewsList();
        }
        protected void bntSearch_Click(object sender, EventArgs e)
        {
            if (Request.Form["SStatus_Id"] != null && Request.Form["SStatus_Id"].ToString() != "")
                intStatus_Id = int.Parse(objEntities.SafeString(Request.Form["SStatus_Id"].ToString()));
            if (Request.Form["SCat_Id"] != null && Request.Form["SCat_Id"].ToString() != "")
                intCat_Id = int.Parse(objEntities.SafeString(Request.Form["SCat_Id"].ToString()));
            strSearch = objEntities.SafeString(txtSearch.Text);
            if (SearchIn.Checked)
                boolSearchIn = true;
            if (Request.Form["FromDate"] != null && Request.Form["FromDate"].ToString() != "")
            {
                this.strFromDate = objEntities.SafeString(Request.Form["FromDate"].ToString());
            }
            if (Request.Form["ToDate"] != null && Request.Form["ToDate"].ToString() != "")
            {
                this.strToDate = objEntities.SafeString(Request.Form["ToDate"].ToString());
            }
            CMSStatus_Id.InnerHtml = NewsStatus();
            CMSNews_Cat_Root.InnerHtml = wrNewsCatRoot();
            NewsList();
        }
        protected void News_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    DeleteNews();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteNews()
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
                        SqlCommand comm = new SqlCommand("Delete_News", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@News_Id", intNews_Id);
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
            this.NewsList();
        }
    }
}
