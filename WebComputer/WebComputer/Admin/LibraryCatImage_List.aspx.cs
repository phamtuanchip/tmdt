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
    public partial class LibraryCatImage_List : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "librarycatimage_list";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            this.Library_CatImage_AddNew.Text = Lang["add_new"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    CMSLibrary_CatImage_List.InnerHtml = LibraryCatImageList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string LibraryCatImageList()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_LibraryCatImage", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;

            DataTable dt = new DataTable();
            adt.Fill(dt);

            tbl.Append(" <table width='100%' border='0' cellspacing='3' cellpadding='2' style='border-collapse:collapse'>");
            tbl.Append("    <tr>");
            tbl.Append("        <td height='20' align='left'>");
            string varSpace = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                string strCatName = dt.Rows[i]["CatName"].ToString();
                bool boolActive = (bool)dt.Rows[i]["Active"];

                if (boolActive == false)
                    strCatName = "<span style='color:#FF0000'>" + strCatName + "</span>";

                tbl.Append("<img border='0' src='/Images/Admin/note.gif' width='8' height='12' align='absbottom'>&nbsp;<strong>" + strCatName + "</strong>");
                tbl.Append("&nbsp;&nbsp;&nbsp;<a href='Library_CatImage_Edit.aspx?id=" + intCat_Id + "' title='Sửa danh mục " + dt.Rows[i]["CatName"].ToString() + "'><img src='/images/Admin/edit_u.gif' border='0'></a>");
                tbl.Append("&nbsp;&nbsp;&nbsp;<a href=\"JavaScript:if(confirm('Bạn có muốn xóa không?')){location.href='Library_CatImage_Delete.aspx?id=" + intCat_Id + "'};\" title='Xóa danh mục " + dt.Rows[i]["CatName"].ToString() + "'><img src='/Images/Admin/delete.gif' border='0'></a>");
                tbl.Append("<br />");
            }
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append(" </table>");
            return tbl.ToString();
        }
        protected void Library_CatImage_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Library_CatImage_AddNew.aspx");
        }
    }
}
