
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
    public partial class Login : System.Web.UI.Page
    {
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBUsinessLogic = new Bussiness.BusinessLogic();
        
        private string Footer_Control = "~/Control/Admin/Footer.ascx";
        protected Hashtable Lang = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminFooter.Controls.Add(LoadControl(Footer_Control));
            Lang = objEntities.GetLanguage("Login_Manager");
        }
        protected void bntLogin_Click(object sender, EventArgs e)
        {
            string strUsername = objEntities.SafeString(this.txtUserName.Text);
            string strPassWord = objEntities.SafeString(this.txtPassword.Text);
            objBUsinessLogic.AdminLogin(strUsername, strPassWord);            
        }
    }
}
