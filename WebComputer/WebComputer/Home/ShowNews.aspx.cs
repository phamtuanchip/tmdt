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
    public partial class ShowNews : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowTinTuc();
        }

        public void ShowTinTuc()
        {
            DataSet dts = new DataSet();
            SqlCommand smd = new SqlCommand("Get_News_Desc", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;

            smd.Connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = smd;
            sda.Fill(dts);

            CollectionPager1.PageSize = 10;
            CollectionPager1.PageNumbersDisplay = SiteUtils.PageNumbersDisplayType.Results;
            CollectionPager1.DataSource = dts.Tables[0].DefaultView;
            CollectionPager1.BindToControl = dtList;

            this.dtList.DataSource = CollectionPager1.DataSourcePaged;
            this.dtList.DataBind();
        }
    }
}
