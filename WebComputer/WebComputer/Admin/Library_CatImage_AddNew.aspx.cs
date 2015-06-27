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
    public partial class Library_CatImage_AddNew : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "librarycatimage_addnew";
        private string strFunctionName = "Thêm mới thông tin danh mục ảnh";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            this.Library_CatImages_AddNew.Text = Lang["add_new"].ToString();
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
        protected void Library_CatImages_AddNew_Click(object sender, EventArgs e)
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
            bool boolActive = false;
            int intLanguage_id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            if (cbActive.Checked)
                boolActive = true;
            string strCatName = objEntities.SafeString(txtCatName.Text);

            SqlCommand comm = new SqlCommand("Insert_Cat_Image", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CatName", strCatName);
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
                Response.Redirect("LibraryCatImage_List.aspx");
            }
        }
    }
}
