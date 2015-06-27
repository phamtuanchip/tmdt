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
    public partial class Editor_Cat_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "newscat_edit";
        private string strFunctionName = "Sửa danh mục tin tức";
        private int id = 0;
        private int Parent_Id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            this.NewsCat_Edit.Text = Lang["edit"].ToString();
            this.Reset_Form.Value = Lang["reset"].ToString();
            this.Back_Edit.Value = Lang["Return"].ToString();
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
                        objBusinessLogic.GetLanguage(this.DDL_Language);
                        GetCatNews();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GetCatNews()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_CatNews", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", id);
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_Language.SelectedValue = drd["Language_Id"].ToString();
                this.txtCatName.Text = drd["CatName"].ToString();
                if ((bool)drd["Active"] == true)
                    this.cbActive.Checked = true;
                if ((bool)drd["OnHomePage"] == true)
                    this.cbOnHomePage.Checked = true;
                Parent_Id = int.Parse(drd["Parent"].ToString());
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
            //============================================//
            int Lang_ID = 0;
            if (this.DDL_Language.SelectedValue != "")
            {
                Lang_ID = int.Parse(this.DDL_Language.SelectedValue);
            }
            CMSNews_Cat_Root.InnerHtml = wrNewsCatRoot(Lang_ID);
            //============================================//
        }
        protected void CatRoot_SelectIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Language.SelectedItem.Value.ToString() == "")
            {
                CMSNews_Cat_Root.Visible = false;
            }
            else
            {
                CMSNews_Cat_Root.Visible = true;
                CMSNews_Cat_Root.InnerHtml = wrNewsCatRoot(int.Parse(DDL_Language.SelectedValue));
            }
        }
        protected string wrNewsCatRoot(int intLang)
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_CatNews_Language", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Language_Id", intLang);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SNewsCat' size='1'>");
            tbl.Append("                <option value='0'>[" + Lang["var_Text_ParentCat"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strSelected = string.Empty;
                    if (Parent_Id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "' " + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, Parent_Id, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        protected void NewsCat_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateCatNews();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateCatNews()
        {
            int intParent = 0;
            bool boolActive = false;
            bool boolOnHomePage = false;
            string strCatName = objEntities.SafeString(this.txtCatName.Text);
            int intLanguage_Id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            if (Request.Form["SNewsCat"] != null && Request.Form["SNewsCat"].ToString() != "")
            {
                intParent = int.Parse(objEntities.SafeString(Request.Form["SNewsCat"].ToString()));
            }
            if (this.cbActive.Checked)
                boolActive = true;
            if (this.cbOnHomePage.Checked)
                boolOnHomePage = true;
            if (id != intParent)
            {
                SqlCommand Comm = new SqlCommand("Update_Cat_News", this.objConn.SqlConn());
                Comm.Connection.Open();
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.AddWithValue("@Cat_Id", id);
                Comm.Parameters.AddWithValue("@CatName", strCatName);
                Comm.Parameters.AddWithValue("@Parent", intParent);
                Comm.Parameters.AddWithValue("@Active", (bool)boolActive);
                Comm.Parameters.AddWithValue("@OnHomePage", (bool)boolOnHomePage);
                Comm.Parameters.AddWithValue("@Language_Id", intLanguage_Id);

                try
                {
                    if (Comm.ExecuteNonQuery() == -1)
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
                    Comm.Connection.Close();
                    Comm.Connection.Dispose();
                    Response.Redirect("Editor_Cat_List.aspx");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'>alert('" + Lang["EOFParent"].ToString() + "');history.go(-1);</script>");
            }
        }
    }
}
