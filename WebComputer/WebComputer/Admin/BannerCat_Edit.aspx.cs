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
using System.IO;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class BannerCat_Edit : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        protected int id = 0;
        private string strAllowFunctions = "bannercat_edit";
        private string strFunctionName = "Sửa thông tin danh mục banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            Edit_BannerCat.Text = Lang["edit"].ToString();
            ResetForm.Value = Lang["reset_form"].ToString();
            Back_AddNew.Value = Lang["back"].ToString();
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
                        this.LangList();
                        GetCatBanner();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }

        }
        protected void GetCatBanner()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_CatBanner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                this.tbCatName.Text = drd["CatName"].ToString();
                this.tbPagePath.Text = drd["PagePath"].ToString();
                this.cbActive.Checked = (bool)drd["Active"];
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void LangList()
        {
            string SQL = "SELECT * FROM TB_Languages ORDER BY Language_ID";
            this.DDL_Language.Items.Add(new ListItem(" Hãy chọn ngôn ngữ ", ""));
            for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
            {
                this.DDL_Language.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["LanguageName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Language_ID"].ToString()));
            }
        }
        protected void Edit_BannerCat_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateCatBanner()
        {
            bool boolActive;
            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = objEntities.SafeString(this.tbPagePath.Text);
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Update_Cat_Banner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@Language_ID", intLanguage_Id);
            try
            {
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strCatName);
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
                Response.Redirect("Banner_Category.aspx");
            }
        }
    }
}
