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
    public partial class Logo_View : System.Web.UI.Page
    {

        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "logo_list,logo_edit";
        private StringBuilder tbl = new StringBuilder();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            this.EditLogo.Text = Lang["edit"].ToString();
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
                    HPLogo_View.InnerHtml = this.LogoView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        private string LogoView()
        {
            SqlDataReader drd;
            SqlCommand comdrd = new SqlCommand("Get_Logo", objConn.SqlConn());
            comdrd.CommandType = CommandType.StoredProcedure;
            comdrd.Connection.Open();
            comdrd.Parameters.AddWithValue("@Logo_Id", id);
            drd = comdrd.ExecuteReader();
            if (drd.Read())
            {
                tbl.Append(" <table width='100%' border='0' cellpadding='0' cellspacing='0'>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("            <img src='" + this.objEntities.GetPathLogo() + drd["ImageName"].ToString() + "' border='0'>");
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
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Ngày bắt đầu: </font>" + drd["LogoStartDate"].ToString() + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Ngày kết thúc: </font>" + drd["LogoEndDate"].ToString() + "</td>");
                tbl.Append("            </tr>");

                string strLocation = string.Empty;
                string strLogoType = string.Empty;
                int intLocation = int.Parse(drd["LogoLocation"].ToString());
                if (intLocation == 0)
                    strLocation = "Menu trái";
                else
                    strLocation = "Menu phải";
                int intTypeLogo = int.Parse(drd["TypeLogo"].ToString());
                if (intTypeLogo == 1)
                    strLogoType = "Quảng cáo";
                else
                    strLogoType = "Công ty thành viên";
                string strActive = string.Empty;
                bool boolActive = (bool)drd["Active"];
                if (boolActive)
                    strActive = "Hoạt động";
                else
                    strActive = "<font color='#FF0000'>Không hoạt động</font>";

                tbl.Append("            <tr>");
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Vị trí đặt logo: </font>" + strLocation + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Kiểu logo quảng cáo: </font>" + strLogoType + "</td>");
                tbl.Append("            </tr>");

                string strCatName = string.Empty;
                int intLogo_Id = int.Parse(drd["Logo_Id"].ToString());
                string SQL = "SELECT CL.CatName FROM TB_Cat_LogoDetail AS CLD INNER JOIN TB_Cat_Logo AS CL ON CLD.Cat_Id = CL.Cat_Id WHERE CLD.Logo_Id = " + intLogo_Id;
                if (intLogo_Id != 0)
                {
                    SqlDataReader drd_Logo;
                    SqlCommand commdrd_Logo = new SqlCommand(SQL, objConn.SqlConn());
                    commdrd_Logo.CommandType = CommandType.Text;
                    commdrd_Logo.Connection.Open();
                    drd_Logo = commdrd_Logo.ExecuteReader();
                    while (drd_Logo.Read())
                    {
                        strCatName += drd_Logo["CatName"].ToString() + ", ";
                    }
                    drd_Logo.Close();
                    commdrd_Logo.Connection.Close();
                    commdrd_Logo.Connection.Dispose();
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
        protected void EditLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logo_Edit.aspx?id=" + id);
        }




    }
}
