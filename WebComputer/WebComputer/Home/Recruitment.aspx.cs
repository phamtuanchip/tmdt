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


namespace WebComputer.Home
{
    public partial class Recruitment : System.Web.UI.Page
    {
        protected StringBuilder tbl = new StringBuilder();
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        int catid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["catid"] != null && Request.QueryString["catid"].ToString() != "")
            //{
            //    catid = int.Parse(objEntities.SafeString(Request.QueryString["catid"].ToString()));
            //    CMSRecruitment.InnerHtml = Recruitments(catid);
            //}
            //else
            //{
            //    CMSRecruitment.InnerHtml = RecruitmentDefault();
            //}
            CMSRecruitment.InnerHtml = Recruitments(4);
        }
        protected string Recruitments(int intCatID)
        {
            SqlDataReader drd_ = null;
            SqlCommand comm_ = null;
            string sql = "Select * From TB_Recruitments where Recruit_id= '" + intCatID + "'";
            comm_ = new SqlCommand(sql, objConn.SqlConn());
            comm_.CommandType = CommandType.Text;
            try
            {
                comm_.Connection.Open();
                drd_ = comm_.ExecuteReader();
                while (drd_.Read())
                {
                    tbl.Append("<table border=\"0\" width=\"100%\" style=\"border:0px solid #C0C0C0\">");
                    tbl.Append("             <tr>");
                    tbl.Append("                 <td align='left' nowrap class=\"titleModule\" style=\"padding-left:0px\">");
                    tbl.Append("<font style=\"color: #000000;\">" + drd_["RecruitmentTitle"].ToString().ToUpper() + "</font>");
                    tbl.Append("                 </td>");
                    tbl.Append("             </tr>");
                    tbl.Append("<tr>");
                    tbl.Append("<td align=\"left\" style=\"padding-left:3px; padding-right:3px\">");
                    tbl.Append("<b>Từ ngày : ");
                    tbl.Append(objEntities.FormatDateTimeVN(drd_["StartDate"].ToString()));
                    tbl.Append("</b><br>");
                    tbl.Append("<b>Đến ngày : ");
                    tbl.Append(objEntities.FormatDateTimeVN(drd_["EndDate"].ToString()));
                    tbl.Append("</b><br>");
                    tbl.Append(drd_["RecruitmentDesc"].ToString());
                    tbl.Append("</td>");
                    tbl.Append("</tr>");
                    tbl.Append("</table>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + ex.StackTrace);
            }
            finally
            {
                comm_.Connection.Close();
                comm_.Connection.Dispose();
            }
            return tbl.ToString();
        }
        protected string RecruitmentDefault()
        {
            SqlDataReader drd_ = null;
            SqlCommand comm_ = null;
            string sql = "Select top 1 Recruit_id,RecruitmentTitle,RecruitmentDesc,StartDate,EndDate,Web_Id,Cat_Id  From TB_Recruitments where Language_ID = 1 order by Recruit_id";
            comm_ = new SqlCommand(sql, objConn.SqlConn());
            comm_.CommandType = CommandType.Text;
            try
            {
                comm_.Connection.Open();
                drd_ = comm_.ExecuteReader();
                while (drd_.Read())
                {
                    tbl.Append("<table border=\"0\" width=\"100%\" style=\"border:0px solid #C0C0C0\">");
                    tbl.Append("             <tr>");
                    tbl.Append("                 <td align='left' nowrap class=\"titleModule\" style=\"padding-left:0px\">");
                    tbl.Append("<font style=\"color: #000000;\">" + drd_["RecruitmentTitle"].ToString().ToUpper() + "</font>");
                    tbl.Append("                 </td>");
                    tbl.Append("             </tr>");
                    tbl.Append("<tr>");
                    tbl.Append("<td align=\"left\" style=\"padding-left:3px; padding-right:3px\">");
                    tbl.Append("<b>Từ ngày : ");
                    tbl.Append(objEntities.FormatDateTimeVN(drd_["StartDate"].ToString()));
                    tbl.Append("</b><br>");
                    tbl.Append("<b>Đến ngày : ");
                    tbl.Append(objEntities.FormatDateTimeVN(drd_["EndDate"].ToString()));
                    tbl.Append("</b><br>");
                    tbl.Append(drd_["RecruitmentDesc"].ToString());
                    tbl.Append("</td>");
                    tbl.Append("</tr>");
                    tbl.Append("</table>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + ex.StackTrace);
            }
            finally
            {
                comm_.Connection.Close();
                comm_.Connection.Dispose();
            }
            return tbl.ToString();
        }
    }
}
