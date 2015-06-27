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
    public partial class LogoCat_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();

        protected int id = 0;
        private string strAllowFunctions = "logocat_edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LOGO_Manager");
            EditCatLogo.Text = Lang["edit"].ToString();
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
                        this.GetCatLogo();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GetCatLogo()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_CatLogo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                this.tbCatName.Text = drd["CatName"].ToString();
                this.tbPagePath.Text = drd["PagePath"].ToString();
                this.tbLBNumber.Text = drd["LBNumber"].ToString();
                this.cbActive.Checked = (bool)drd["Active"];
                if ((bool)drd["LBRandom"] == true)
                    this.RB_LBRandom1.Checked = true;
                else
                    this.RB_LBRandom0.Checked = true;
            }
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
        protected void EditCatLogo_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateCatLogo()
        {

            string strFunctionName = "Sửa thông tin danh mục logo";
            bool boolActive;
            bool boolLBRandom;

            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = objEntities.SafeString(this.tbPagePath.Text);
            int intLBNumber = int.Parse(objEntities.SafeString(this.tbLBNumber.Text));
            if (this.RB_LBRandom1.Checked)
                boolLBRandom = true;
            else
                boolLBRandom = false;
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Update_Cat_Logo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@LBRandom", (bool)boolLBRandom);
            comm.Parameters.AddWithValue("@LBNumber", intLBNumber);
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
                Response.Redirect("Logo_Category.aspx");
            }
        }
    }
}
