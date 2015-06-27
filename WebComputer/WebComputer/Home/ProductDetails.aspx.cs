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
    public partial class ProductDetails : System.Web.UI.Page
    {
        public int pid;
        protected string strProductImage = string.Empty;
        public string strQuantity = string.Empty;
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objFunc = new Function();
        //public int pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProId"] != null && Request.QueryString["ProId"].ToString() != "")
            {
                pid = int.Parse(objEntities.SafeString(Request.QueryString["ProId"].ToString()));
                if (!IsPostBack)
                {
                    ShowProductDetails();
                    ShowImage();
                    //Session["Pid"] = pid;
                }
            }




            //if (!IsPostBack)
            //{
            //    pid = Convert.ToInt32((Request.QueryString["ProId"]));
            //    ShowProductDetails();
            //    ShowImage();
            //    Session["Pid"] = pid;
            //}
        }

        public void ShowProductDetails()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Product_ByID", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            //comm.CommandType = CommandType.Text;
            //comm.CommandText = "select * from tb_Product where Product_ID = "+pid+"";
            comm.Parameters.Add("@Pid",SqlDbType.Int);
            comm.Parameters["@Pid"].Value = pid;
            comm.Connection.Open();
            comm.ExecuteNonQuery();
           // string quantity = (string)comm.ExecuteScalar().ToString();
            //adt.SelectCommand = comm;
            adt = new SqlDataAdapter(comm);
            adt.Fill(dts,"test");
            DataTable dt = new DataTable();
            dt = dts.Tables["test"];
           // string abc = dt.Rows[0]["Product_QuatityOut"].ToString();
            if (dt.Rows[0]["Product_QuatityOut"].ToString().Equals("0"))
            {
                strQuantity = "Hết hàng";
            }
            else
            {
                strQuantity = "Còn hàng";
            }


            ///strQuantity = quantity;
            this.rptDetails.DataSource = dt;
            this.rptDetails.DataBind();

            adt.Dispose();
            dts.Clear();
            dts.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }

        public void ShowImage()
        {
            SqlDataReader drd;
            SqlCommand smd = new SqlCommand("Get_Images_Product_Details", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Parameters.AddWithValue("@Pid", pid);

            smd.Connection.Open();
            drd = smd.ExecuteReader();

            if (drd.Read())
            {
                this.strProductImage = drd["PhotoID"].ToString();
            }
            drd.Close();
            smd.Connection.Close();
            smd.Connection.Dispose();
        }

        public void Show5Product()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand smd = new SqlCommand("Get_5_Product", objConn.SqlConn());
            smd.CommandType = CommandType.StoredProcedure;
            smd.Parameters.AddWithValue("@Pid", pid);
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
