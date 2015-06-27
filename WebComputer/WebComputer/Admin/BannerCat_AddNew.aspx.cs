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
    public partial class BannerCat_AddNew : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        protected string strAllowFunctions = "bannercat_addnew";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.AddNew_BannerCat.Text = Lang["add_new"].ToString();
            this.Reset_Form.Value = Lang["reset_form"].ToString();
            this.Back_AddNew.Value = Lang["back"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.LangList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
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
        protected void AddNew_BannerCat_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertCatBanner()
        {
            bool boolActive;
            string strFunctionName = "Thêm mới danh mục banner";
            int intLang = int.Parse(this.objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = this.objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = this.objEntities.SafeString(this.tbPagePath.Text);
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Insert_Cat_Banner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@Language_ID", intLang);
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
