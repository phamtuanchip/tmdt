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
using Bussiness;
using Entity;

namespace WebComputer
{
    public partial class User : System.Web.UI.MasterPage
    {
        public Entity.Entities objEntities = new Entity.Entities();
        public string strDateTime = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.strDateTime = objEntities.FullDateTimeVN(System.DateTime.Now);
                //this.strDateTime = objEntities.FullDateTimeEN(System.DateTime.Now);
                
                if (Session["UserName"] != null)
                {
                    lblUserNameLogked.Visible = true;
                    lbtnLogOut.Visible = true;
                    lblLogin.Visible = false;
                    lblRegister.Visible = false;
                    lblUserNameLogked.Text = "Xin chào:" + Session["UserName"].ToString();
                  
                }
                else
                {
                    lblRegister.Visible = true;
                }
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            lblLogin.Visible = true;
            lblUserNameLogked.Visible = false;
            lbtnLogOut.Visible = false;
            lblRegister.Visible = true;
        }
    }
}
