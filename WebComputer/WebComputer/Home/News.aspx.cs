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
    public partial class News : System.Web.UI.Page
    {
        public int newsID;
        public string strName;
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newsID = Convert.ToInt32((Request.QueryString["NewsID"]));
                ShowNews();
                ShowName();
            }
        }

        public void ShowNews()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_News_byCatID", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CatID", newsID);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.dtList.DataSource = dts;
            this.dtList.DataBind();
            adt.Dispose();
            dts.Clear();
            dts.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }

        public void ShowName()
        {
            SqlDataReader drd;
            SqlCommand smd = new SqlCommand("Get_News_byCatID", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Parameters.AddWithValue("@CatID", newsID);

            smd.Connection.Open();
            drd = smd.ExecuteReader();

            if (drd.Read())
            {
                this.strName = drd["CatName"].ToString();
            }
            drd.Close();
            smd.Connection.Close();
            smd.Connection.Dispose();
        }
    }
}
