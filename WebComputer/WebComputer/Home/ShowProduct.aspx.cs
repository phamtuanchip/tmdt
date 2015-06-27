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

using Entity;
using Bussiness;

namespace WebComputer.Home
{
    public partial class ShowProduct : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objFunc = new Function();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductList();
            }
        }

        public void ProductList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("ShowProduct", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);

            CollectionPager1.PageSize = 10;
            CollectionPager1.PageNumbersDisplay = SiteUtils.PageNumbersDisplayType.Results;
            CollectionPager1.DataSource = dts.Tables[0].DefaultView;
            CollectionPager1.BindToControl = dtList;

            this.dtList.DataSource = CollectionPager1.DataSourcePaged;
            this.dtList.DataBind();
        }
    }
}
