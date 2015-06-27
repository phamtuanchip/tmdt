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
    public partial class LogoCat_AddNew : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Bussiness.AdminLogo objAdminLogo = new AdminLogo();
        public Entity.Entities objEntities = new Entities();
        
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "logocat_addnew";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            AddNewCatLogo.Text = Lang["add_new"].ToString();
            ResetForm.Value = Lang["reset_form"].ToString();
            Back_AddNew.Value = Lang["back"].ToString();

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
        protected void AddNewCatLogo_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertCatLogo()
        {
            bool boolLBRandom;
            bool boolActive;
            string strFunctionName = "Thêm mới danh mục logo";
            int intLang = int.Parse(this.objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = this.objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = this.objEntities.SafeString(this.tbPagePath.Text);
            string strLBNumber = this.objEntities.SafeString(this.tbLBNumber.Text);
            if (this.RB_LBRandom1.Checked)
                boolLBRandom = true;
            else
                boolLBRandom = false;
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Insert_Cat_Logo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@LBRandom", (bool)boolLBRandom);
            comm.Parameters.AddWithValue("@LBNumber", int.Parse(strLBNumber));
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
                Response.Redirect("Logo_Category.aspx");
            }
        }

        protected void DDL_Language_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
