using System;
using System.Data;
using System.Data.SqlClient;
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

namespace WebComputer.Home
{
    public partial class Default : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objFunc = new Function();

        protected void Page_Load(object sender, EventArgs e)
        {
            Show5News();
            Show9Product();
        }

        public void Show5News()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand smd = new SqlCommand("Show5News", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Connection.Open();
            sda.SelectCommand = smd;
            sda.Fill(dts);
            this.dtList.DataSource = dts;
            this.dtList.DataBind();
            sda.Dispose();
            dts.Clear();
            dts.Dispose();
            smd.Connection.Close();
            smd.Connection.Dispose();
        }

        public void Show9Product()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand smd = new SqlCommand("Show9Product", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Connection.Open();
            sda.SelectCommand = smd;
            sda.Fill(dts);
            this.dtProduct.DataSource = dts;
            this.dtProduct.DataBind();
            sda.Dispose();
            dts.Clear();
            dts.Dispose();
            smd.Connection.Close();
            smd.Connection.Dispose();
        }
    }
}
