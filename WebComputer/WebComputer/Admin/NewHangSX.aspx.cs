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
using System.Data.SqlClient;
using Entity;
using Bussiness;


namespace WebComputer.Admin
{
    public partial class NewHangSX : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        //protected Hashtable Lang = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Hang_Add.Text = Lang["Hang_Add"].ToString();
            //this.Hang_Delete.Text = Lang["Hang_Delete"].ToString();
            Get_All_HangSX();
        }
        private void Get_All_HangSX()
        {
            this.GV_Prov_List.DataSource = objBusinessLogic.CreateDataTable("Get_All_HangSX", false);
            this.GV_Prov_List.DataBind();
        }

      

        protected void Hang_Add_Click(object sender, EventArgs e)
        {

        }

        protected void Hang_Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
