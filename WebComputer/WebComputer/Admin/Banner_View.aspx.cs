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
    public partial class Banner_View : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        int id = 0;
        private string strAllowFunctions = "banner_list,banner_edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("BANNER_Manager");
            this.EditBanner.Text = Lang["edit"].ToString();
            this.Back_Edit.Value = Lang["back"].ToString();
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
                    HPBanner_View.InnerHtml = this.BannerView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        private string BannerView()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataReader drd;
            SqlCommand comdrd = new SqlCommand("Get_Banner", objConn.SqlConn());
            comdrd.CommandType = CommandType.StoredProcedure;
            comdrd.Connection.Open();
            comdrd.Parameters.AddWithValue("@Banner_Id", id);
            drd = comdrd.ExecuteReader();
            if (drd.Read())
            {
                tbl.Append(" <table width='100%' border='0' cellpadding='0' cellspacing='0'>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("            <img src='" + this.objEntities.GetPathBanner() + drd["ImageName"].ToString() + "' border='0'>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("        <table width='100%' border='0' cellpadding='3' cellspacing='2'>");
                tbl.Append("            <tr>");
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Ngày post: </font>" + drd["CreatedDate"].ToString() + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Khích thước ảnh: </font>" + drd["Width"].ToString() + "x" + drd["Height"].ToString() + "</td>");
                tbl.Append("            </tr>");
                tbl.Append("            <tr>");
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Ngày bắt đầu: </font>" + drd["BannerStartDate"].ToString() + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Ngày kết thúc: </font>" + drd["BannerEndDate"].ToString() + "</td>");
                tbl.Append("            </tr>");

                string strActive = string.Empty;
                bool boolActive = (bool)drd["Active"];
                if (boolActive)
                    strActive = "Hoạt động";
                else
                    strActive = "<font color='#FF0000'>Không hoạt động</font>";

                string strCatName = string.Empty;
                int intBanner_Id = int.Parse(drd["Banner_Id"].ToString());
                string SQL = "SELECT CB.CatName FROM TB_Cat_BannerDetail AS CBD INNER JOIN TB_Cat_Banner AS CB ON CBD.Cat_Id = CB.Cat_Id WHERE CBD.Banner_Id = " + intBanner_Id;
                if (intBanner_Id != 0)
                {
                    SqlDataReader drd_Banner;
                    SqlCommand commdrd_Banner = new SqlCommand(SQL, objConn.SqlConn());
                    commdrd_Banner.CommandType = CommandType.Text;
                    commdrd_Banner.Connection.Open();
                    drd_Banner = commdrd_Banner.ExecuteReader();
                    while (drd_Banner.Read())
                    {
                        strCatName += drd_Banner["CatName"].ToString() + ", ";
                    }
                    drd_Banner.Close();
                    commdrd_Banner.Connection.Close();
                    commdrd_Banner.Connection.Dispose();
                    if (strCatName != string.Empty)
                        strCatName = strCatName.Substring(0, strCatName.Length - 2);
                }

                tbl.Append("            <tr>");
                tbl.Append("                <td colspan='3' align='left' class='ListContent'><font style='font-weight: bold'>Trang hiển thị: </font>" + strCatName + "</td>");
                tbl.Append("            </tr>");
                tbl.Append("            <tr>");
                tbl.Append("                <td colspan='3' align='left' class='ListContent'><font style='font-weight: bold'>Trạng thái: </font>" + strActive + "</td>");
                tbl.Append("            </tr>");
                tbl.Append("        </table>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append(" </table>");
                comdrd.Connection.Close();
                comdrd.Connection.Dispose();
            }
            return tbl.ToString();
        }
        protected void EditBanner_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banner_Edit.aspx?id=" + id);
        }
    }
}
