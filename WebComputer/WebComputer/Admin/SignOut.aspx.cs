namespace Cms
{
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

    public partial class Admin_SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Session.Abandon();
                string ReturnUrl = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString();
                Response.Write("<script language='javascript'>alert('Bạn đã thoát khỏi chương trình');location.href='Login.aspx';</script>");
            }
        }
    }
}