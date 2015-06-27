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
    public partial class LibraryImage_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "libraryimage_edit";
        private string strFunctionName = "Sửa ảnh";
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            LibraryImages_Edit.Text = Lang["edit"].ToString();
            Reset_Form.Value = Lang["reset"].ToString();
            Back_Edit.Value = Lang["back"].ToString();
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
                GetLibraryCatImages();
                GetLibraryImages();
            }
        }
        else
        {
            Response.Redirect("EOFPermission.aspx");
        }
    }
        }
        protected void GetLibraryImages()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Libary_Image", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ID", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_CatId.SelectedValue = drd["Cat_Id"].ToString();
                this.txtDesc.Text = drd["Description"].ToString();
                this.IDImg.ImageUrl = objEntities.GetPathLibraryImage() + drd["PhotoID"].ToString() + "_T.jpg";
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void GetLibraryCatImages()
        {
            string SQL = "select * from TB_Cat_Images order by CatOrder";
            this.DDL_CatId.Items.Add(new ListItem(" -- Hãy chọn danh mục ảnh -- ", ""));
            for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
            {
                this.DDL_CatId.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["CatName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Cat_Id"].ToString()));
            }
        }
        protected void UpdateLibraryImages()
        {
            int intCat_Id = int.Parse(objEntities.SafeString(DDL_CatId.SelectedValue));
            string strDesc = objEntities.SafeString(txtDesc.Text);

            SqlCommand comm = new SqlCommand("Update_LibraryImage", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ID", id);
            comm.Parameters.AddWithValue("@Description", strDesc);
            comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strDesc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("LibraryImage_List.aspx");
            }
        }
        protected void LibraryImages_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateLibraryImages();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
    }
}
