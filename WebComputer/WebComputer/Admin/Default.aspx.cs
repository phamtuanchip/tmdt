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

namespace WebComputer.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        private Entity.Entities objLang = new Entity.Entities();
        protected Hashtable Lang = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objLang.GetLanguage("Default_Manager");
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx';</script>");
            }
        }
    }
}
