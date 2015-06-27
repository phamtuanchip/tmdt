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
    public partial class Library_CatImage_Delete : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "librarycatimage_delete";
        private string strFunctionName = "Xóa thông tin danh mục ảnh";
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
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
                    this.DeleteLibraryCatImage();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteLibraryCatImage()
        {
            //=============Delete file=====================================
            string SQL = "SELECT PhotoID FROM TB_Images WHERE Cat_Id =" + id;
            SqlDataReader drd;
            SqlCommand comm_drd = new SqlCommand(SQL, this.objConn.SqlConn());
            comm_drd.Connection.Open();
            drd = comm_drd.ExecuteReader(CommandBehavior.CloseConnection);
            while (drd.Read())
            {
                string strPhotoID = drd["PhotoID"].ToString() + ".jpg";
                string strPhotoID_T = drd["PhotoID"].ToString() + "_T.jpg";
                string strCheckImg = drd["PhotoID"].ToString() + ".jpg";
                if (strPhotoID != string.Empty && strPhotoID != null)
                {
                    string strPathPhotoID = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strPhotoID;
                    string strPathPhotoID_T = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strPhotoID_T;
                    string strCheckPath = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strCheckImg;
                    if (File.Exists(strCheckPath) == true)
                    {
                        objEntities.Delete_Files(strPathPhotoID);
                        objEntities.Delete_Files(strPathPhotoID_T);
                    }
                }
            }
            drd.Close();
            drd.Dispose();
            comm_drd.Connection.Close();
            comm_drd.Connection.Dispose();
            //===========Edn Delete file===================================
            //===========Delete Database===================================
            SqlCommand comm = new SqlCommand("Delete_Cat_Image", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cat_Id", id);
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
            Response.Redirect("LibraryCatImage_List.aspx");
            //===========End Delete Database===============================
        }
    }
}
