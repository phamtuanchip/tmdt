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

namespace WebComputer.Control.User
{
    public partial class Right : System.Web.UI.UserControl
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowLogo();
        }

        public void ShowLogo()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("ShowLogo", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);

            this.dtList.DataSource = dts;
            this.dtList.DataBind();
        }

        protected void ShoppingCart(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CartShow.aspx");
        }

        protected void btnDownload_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();

            Response.AddHeader("content-disposition", "attachment; filename=Baogia.xls");

            Response.Charset = "";

            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);

            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Export_to_Excel", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);

            GridView g = new GridView();
            g.DataSource = dts;
            g.DataBind();

            g.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());

            Response.End();
        }
    }
}