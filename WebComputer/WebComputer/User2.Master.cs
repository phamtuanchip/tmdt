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

namespace WebComputer
{
    public partial class User2 : System.Web.UI.MasterPage
    {
		public Entity.Entities objEntities = new Entity.Entities();
        public string strDateTime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
			this.strDateTime = objEntities.FullDateTimeVN(System.DateTime.Now);
        }
    }
}
