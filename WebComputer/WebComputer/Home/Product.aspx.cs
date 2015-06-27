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
    public partial class Product : System.Web.UI.Page
    {
        public int subID;
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objFunc = new Function();
        public string checkout_url = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SubId"] != null && Request.QueryString["SubId"].ToString() != "")
            {
                subID = int.Parse(objEntities.SafeString(Request.QueryString["SubId"].ToString()));
                if (!IsPostBack)
                {
                    subID = Convert.ToInt32((Request.QueryString["SubId"]));
                    ProductList();
                    //Session["Pid"] = pid;
                }
            }
        }
        protected void data(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView r = (DataRowView)e.Item.DataItem;
                nganluong nl = new nganluong();
                string return_url = "http://www.beppro.vn/ThanhYou.aspx";
                string receiver = "beppro.vn@gmail.com";
                string transaction_info = "";
                string order_code = "ID2200";
                string price = r["Product_Price"].ToString();
                checkout_url = nl.buildCheckoutUrl(return_url, receiver, transaction_info, order_code, price);
                ((Literal)e.Item.FindControl("Literal2")).Text = "  <a href=\"" + checkout_url + "\" title=\"\"><img src=\"https://www.nganluong.vn/data/images/buttons/3.gif\"  title=\"\"/></a>";
            }
        }

        public void ProductList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Product_by_Sub", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@SubCatID", subID);
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
