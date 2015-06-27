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
    public partial class Gallery_Category : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "gallerycat_list";

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
            SqlCommand comm = new SqlCommand("Get_All_GalleryCatImage", objConn.SqlConn());
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
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == 0)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    bool boolActive = (bool)dt.Rows[i]["Active"];
                    tbl.Append(wrCatNews(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (objBusinessLogic.FindChildNode(intCat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(Create_CatNews_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append(" </table>");
            return tbl.ToString();
        }
        public string Create_CatNews_Tree(int Cat_Id, DataTable dt, string varSpace)
        {
            varSpace += "&nbsp;&nbsp;&nbsp;&nbsp";
            StringBuilder tbl = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == Cat_Id)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    bool boolActive = (bool)dt.Rows[i]["Active"];
                    tbl.Append(wrCatNews(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (objBusinessLogic.FindChildNode(intCat_Id, dt))
                    {
                        tbl.Append(Create_CatNews_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            return tbl.ToString();
        }
        public string wrCatNews(int Cat_Id, int Parent, string CatName, bool Active, string varSpace)
        {
            StringBuilder tbl = new StringBuilder();
            string strCatName = string.Empty;
            if (Active == false)
                strCatName = "<span style='color:#FF0000'>" + CatName + "</span>";
            else
                strCatName = CatName;
            if (Parent == 0)
                tbl.Append("<img border='0' src='/Images/Admin/note.gif' width='8' height='12' align='absbottom'>&nbsp;<strong>" + strCatName + "</strong>");
            else
                tbl.Append(varSpace + "-&nbsp;" + strCatName);
            tbl.Append("&nbsp;&nbsp;&nbsp;<a href='Gallery_Category_Edit.aspx?id=" + Cat_Id + "' title='Sửa danh mục " + CatName + "'><img src='/images/Admin/edit_u.gif' border='0'></a>");
            if ((Cat_Id == 24) || (Cat_Id == 25) || (Cat_Id == 26) || (Cat_Id == 55) || (Cat_Id == 38) || (Cat_Id == 56) || (Cat_Id == 61) || (Cat_Id == 62) || (Cat_Id == 63))
            {
                tbl.Append("");
            }
            else
            {
                tbl.Append("&nbsp;&nbsp;&nbsp;<a href=\"JavaScript:if(confirm('Bạn có muốn xóa không?')){location.href='Gallery_Category_Delete.aspx?id=" + Cat_Id + "'};\" title='Xóa danh mục " + CatName + "'><img src='/Images/Admin/delete.gif' border='0'></a>");
            }
            tbl.Append("<br />");
            return tbl.ToString();
        }

        protected void Library_CatImage_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gallery_Category_AddNew.aspx");
        }
    }
}
