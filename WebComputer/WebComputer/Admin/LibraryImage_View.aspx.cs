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
    public partial class LibraryImage_View : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "libraryimage_list,libraryimage_edit";
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LibraryImages_Manager");
            this.LibraryImage_Edit.Text = Lang["edit"].ToString();
            this.Back_View.Value = Lang["back"].ToString();
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
                    CMSLibraryImage_View.InnerHtml = LibraryImageView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string LibraryImageView()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataReader drd;
            SqlCommand comdrd = new SqlCommand("Get_Libary_Image", objConn.SqlConn());
            comdrd.CommandType = CommandType.StoredProcedure;
            comdrd.Connection.Open();
            comdrd.Parameters.AddWithValue("@ID", id);
            drd = comdrd.ExecuteReader();
            if (drd.Read())
            {
                tbl.Append("<table width='90%' border='0' cellpadding='3' cellspacing='2'>");
                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' style='font-family: Arial; font-size: 10pt; font-weight: bold; color: #618339'>" + drd["CatName"].ToString() + "</td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("            <a href=\"JavaScript:openImage('" + objEntities.GetPathLibraryImage() + drd["PhotoID"].ToString() + ".jpg" + "'," + drd["Full_H"].ToString() + "," + drd["Full_W"].ToString() + ");\">");
                tbl.Append("                <img border='0' src='" + objEntities.GetPathLibraryImage() + drd["PhotoID"].ToString() + "_T.jpg" + "'>");
                tbl.Append("            </a>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td align='center'>");
                tbl.Append("            <table width='80%' border='0' cellspacing='3' cellpadding='2'>");
                tbl.Append("            <tr>");
                tbl.Append("                <td  align='center' style='font-family: Arial; font-size: 8pt'>");
                tbl.Append(drd["Description"].ToString());
                tbl.Append("                </td>");
                tbl.Append("            </tr>");
                tbl.Append("            <tr>");
                tbl.Append("                <td  align='center' style='font-family: Arial; font-size: 8pt'>");
                tbl.Append("                    <font style='font-family: Arial; font-size: 8pt'>" + Lang["CreateDate"].ToString() + "<b>" + drd["CreateDate"].ToString() + "</b></font> | " + "<font style='font-family: Arial; font-size: 8pt'>" + Lang["SizeImage"].ToString() + "<b>" + drd["Full_Size"].ToString() + "kb</b></font>");
                tbl.Append("                </td>");
                tbl.Append("            </tr>");
                tbl.Append("            <tr>");
                tbl.Append("                <td  align='center' style='font-family: Arial; font-size: 8pt'>");
                tbl.Append("                    <font style='font-family: Arial; font-size: 8pt'>" + Lang["WhidthResizeImage"].ToString() + "<b>" + drd["Thumb_W"].ToString() + "kb</b></font>" + " | " + "<font style='font-family: Arial; font-size: 8pt'>" + Lang["WhidthImage"].ToString() + "<b>" + drd["Full_W"].ToString() + "kb</b></font>");
                tbl.Append("                </td>");
                tbl.Append("            </tr>");
                tbl.Append("            </table>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append("</table>");
            }
            drd.Close();
            drd.Dispose();
            comdrd.Connection.Close();
            comdrd.Connection.Dispose();
            return tbl.ToString();
        }
        protected void LibraryImage_Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("LibraryImage_Edit.aspx?id=" + id.ToString());
        }
    }
}
