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
    public partial class NewsDetails : System.Web.UI.Page
    {
        public int NewsID;
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewsID = Convert.ToInt32(Request.QueryString["NewsID"]);
                ShowNewsDetails();
                ShowNewsOld();
            }
        }

        public void ShowNewsDetails()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand smd = new SqlCommand("Get_NewsDetails", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Parameters.AddWithValue("@NewsID", NewsID);

            smd.Connection.Open();
            sda.SelectCommand = smd;
            sda.Fill(dts);

            this.dtRepeater.DataSource = dts;
            this.dtRepeater.DataBind();

            smd.Connection.Close();
            smd.Dispose();
        }

        public void ShowNewsOld()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand smd = new SqlCommand("Get_OldNews", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Parameters.AddWithValue("@NewsID", NewsID);

            smd.Connection.Open();
            sda.SelectCommand = smd;
            sda.Fill(dts);

            this.dtList.DataSource = dts;
            this.dtList.DataBind();

            smd.Connection.Close();
            smd.Dispose();
        }
    }
}
