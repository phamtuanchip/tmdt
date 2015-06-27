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
    public partial class Recruit_View : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        int id;
        private string strAllowFunctions = "recruit_list,recruit_edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("RECRUIT_Manager");
            Recruit_Edit.Text = Lang["edit"].ToString();
            Back_View.Value = Lang["back"].ToString();
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
                    CMSRecruit_View.InnerHtml = RecruitView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string RecruitView()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataReader drd;
            SqlCommand comdrd = new SqlCommand("Get_Recruit", objConn.SqlConn());
            comdrd.CommandType = CommandType.StoredProcedure;
            comdrd.Connection.Open();
            comdrd.Parameters.AddWithValue("@Recruit_Id", id);
            drd = comdrd.ExecuteReader();
            if (drd.Read())
            {
                tbl.Append(" <table width='100%' border='0' cellpadding='3' cellspacing='2'>");
                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' class='style_title'>" + drd["RecruitmentTitle"].ToString() + "</td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' class='style_datetime'>");
                tbl.Append("            <p><b>Ngày tuyển</b>: " + drd["StartDate"].ToString() + "</p>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' class='style_datetime'>");
                tbl.Append("            <p><b>Ngày kết thúc</b>: " + drd["EndDate"].ToString() + "</p>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td align='left'>");
                tbl.Append("            <p class='ListContent'>" + drd["RecruitmentDesc"].ToString() + "</p>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");

                tbl.Append(" </table>");
            }
            return tbl.ToString();
        }
        protected void Recruit_Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recruit_Edit.aspx?id=" + id);
        }
    }
}
