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
    public partial class Gallery_Category_AddNew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "gallerycat_addnew";
        private string strFunctionName = "Thêm mới danh mục Gallery";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            this.Library_CatImage_AddNew.Text = Lang["add_new"].ToString();
            this.Reset_Form.Value = Lang["reset"].ToString();
            this.Back_CatImage_AddNew.Value = Lang["back"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!IsPostBack)
                        objBusinessLogic.GetLanguage(this.DDL_Language);
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
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
            SqlCommand comm = new SqlCommand("Get_All_CatLibraryImages_Language", objConn.SqlConn());
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
                    tbl.Append("        <option value='" + Cat_Id + "'>" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, 0, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }


        protected void Library_CatImage_AddNew_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertLibraryCatImage();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertLibraryCatImage()
        {
            int intParent = 0;
            bool boolActive = false;
            int intLanguage_id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            if (cbActive.Checked)
                boolActive = true;
            string strCatName = objEntities.SafeString(txtCatName.Text);
            if (Request.Form["SNewsCat"] != null && Request.Form["SNewsCat"].ToString() != "")
            {
                intParent = int.Parse(objEntities.SafeString(Request.Form["SNewsCat"].ToString()));
            }

            SqlCommand comm = new SqlCommand("Insert_Cat_Gallery", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Parent", intParent);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@Language_Id", intLanguage_id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strCatName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Gallery_Category.aspx");
            }
        }
    }
}
