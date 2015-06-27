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


namespace WebComputer
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private string MBLeft_Control = "~/Control/Admin/Left.ascx";
        private string MBFooter_Control = "~/Control/Admin/Footer.ascx";
        protected Entity.Entities objEntities = new Entity.Entities();
        
        public string strDateTime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.strDateTime = objEntities.FullDateTimeVN(System.DateTime.Now);
            this.MBLeft.Controls.Add(LoadControl(MBLeft_Control));
            this.MBFooter.Controls.Add(LoadControl(MBFooter_Control));
        }
    }
}
