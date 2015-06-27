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
using Entity;
using Bussiness;

namespace WebComputer.Home
{
    public partial class Contact : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objFunc = new Function();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Contact_AddNew_Click(object sender, EventArgs e)
        {
            string Email_Contact = objEntities.GetValueWebConfig("EmailPath", true);
            string strFullName = this.txtFullName.Text;
            string strAdress = this.txtAddress.Text;
            string strPhone = this.txtPhone.Text;
            string strEmail = this.txtEmail.Text;
            string strContent = this.txtContent.Value;
            string strToEmail = string.Empty;
            string strBody = string.Empty;
            strBody = " <table width='100%' border='0' cellspacing='0' cellpadding='0'>";
            strBody = strBody + "   <tr>";
            strBody = strBody + "       <td width='20%'><font style='font-family: Arial; font-size: 8pt; font-weight: bold'>Họ và tên: </font></td>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: none'>" + strFullName + "</font></td>";
            strBody = strBody + "   </tr>";
            strBody = strBody + "   <tr>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: bold'>Địa chỉ: </font></td>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: none'>" + strAdress + "</font></td>";
            strBody = strBody + "   </tr>";
            strBody = strBody + "   <tr>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: bold'>Số điện thoại: </font></td>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: none'>" + strPhone + "</font></td>";
            strBody = strBody + "   </tr>";
            strBody = strBody + "   <tr>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: bold'>Địa chỉ email: </font></td>";
            strBody = strBody + "       <td><font style='font-family: Arial; font-size: 8pt; font-weight: none'>" + strEmail + "</font></td>";
            strBody = strBody + "   </tr>";
            strBody = strBody + "   <tr>";
            strBody = strBody + "       <td colspan='2'><font style='font-family: Arial; font-size: 8pt; font-weight: bold'>Ý kiến: </font></td>";
            strBody = strBody + "   </tr>";
            strBody = strBody + "   <tr>";
            strBody = strBody + "       <td colspan='2'><font style='font-family: Arial; font-size: 8pt; font-weight: none'>" + strContent + "</font></td>";
            strBody = strBody + "   </tr>";
            strBody = strBody + " </table>";
            objEntities.sendMail(strEmail, Email_Contact, "Thông tin liên hệ: " + strFullName, strBody);
            Response.Write("<script language=\"javascript\">alert('Cảm ơn bạn đã gửi ý kiến đóng góp tới chúng tôi!');location.href='/Home/';</script>");
        }
    }
}
