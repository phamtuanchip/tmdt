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
using Bussiness;
using Entity;

namespace WebComputer.Home
{
    public partial class ProcessOrder : System.Web.UI.Page
    {
        public Bussiness.Function objfun = new Function();
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Entity.Entities objentity = new Entities();
        public Bussiness.Function objFunc = new Function();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show_Cart();
            }
        }

        protected void Process_Order()
        {
            #region insert vào bảng order trước
            #endregion
            bool ch  = insert_orders();
            if (ch == true)
            {


                #region khi đã insert vào bảng orders xong, lấy được order_id của hóa đơn đang thao tác thì insert tiếp vào bảng orderDetails
                #endregion
                insert_orderDetails();

                #region sau khi quá trình mua hàng hoàn thành thì xóa toàn bộ sản phẩm khỏi giỏ hàng.
                #endregion

                Session.RemoveAll();
            }
            else 
            {
                Label1.Text = "Khong dat hang duoc";
            }

        }

        protected bool insert_orders()
        {
            try
            {
                DataTable dt = (DataTable)Session["order"];

                SqlCommand comm = new SqlCommand("usp_insertOrder", objConn.SqlConn());
                comm.CommandType = CommandType.StoredProcedure;


                comm.Parameters.AddWithValue("@username", dt.Rows[0]["user_name"].ToString());
                comm.Parameters.AddWithValue("@Email", dt.Rows[0]["email"].ToString());
                comm.Parameters.AddWithValue("@Address", dt.Rows[0]["address"].ToString());
                comm.Parameters.AddWithValue("@Phone", dt.Rows[0]["tel"].ToString());
                comm.Parameters.AddWithValue("@DeliveryName", dt.Rows[0]["deliveryName"].ToString());
                comm.Parameters.AddWithValue("@DeliveryAddress", dt.Rows[0]["deliveryaddress"].ToString());

                comm.Parameters.AddWithValue("@Status_ID", 0);
                comm.Parameters.AddWithValue("@OrderDate", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                comm.Parameters.AddWithValue("@Total", Convert.ToDecimal(Session["sum"].ToString()));
                comm.Parameters.AddWithValue("@Status", 0);

                comm.Connection.Open();
                comm.ExecuteNonQuery();
                return true;
                //comm.Connection.Close();

            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi! Thao tác lại là ok";
                return false;
            }
            
        }

        protected void insert_orderDetails()
        {
            try
            {
                int id = get_order_id();

                DataTable objDT = (DataTable)Session["cart"];

                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    SqlCommand comm = new SqlCommand("usp_insertOrderDetails", objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@OrderID", id);
                    comm.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(objDT.Rows[i]["Price"].ToString()));
                    comm.Parameters.AddWithValue("@Quantity", Convert.ToInt32(objDT.Rows[i]["Quantity"].ToString()));
                    comm.Parameters.AddWithValue("@Discount", 1);
                    comm.Parameters.AddWithValue("@ProductID", Convert.ToInt32(objDT.Rows[i]["Product_ID"].ToString()));

                    comm.Connection.Open();
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Thao tác lại là Ok";
            }
        }

        protected int get_order_id()
        {
            try
            {
                int order_id = 0;
                // SqlConnection con = new SqlConnection("Server=. ; DataBase=Webcomputer; Integrated Security = yes");

                string strSql = "select max(OrderID) from TB_Order";
                SqlCommand comn = new SqlCommand(strSql, objConn.SqlConn());
                //con.Open();
                comn.Connection.Open();
                SqlDataReader read = comn.ExecuteReader();
                while (read.Read())
                {
                    order_id = Convert.ToInt32(read.GetInt32(0));
                }
                //con.Close();
                comn.Connection.Close();

                return order_id;
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Thao tác lại là ok";
                return 0;
            }
        }


        protected void Show_Cart()
        {
            try
            {
                //int tientra;
                DataTable dt = (DataTable)Session["order"];
                lblCus_name.Text = dt.Rows[0]["fullname"].ToString();
                lblCus_tel.Text = dt.Rows[0]["tel"].ToString();
                lblDelivery.Text = dt.Rows[0]["delivery"].ToString();
                //tientra = Convert.ToInt32(dt.Rows[0]["pay"]);
                //lblPay.Text = objfun.ChangeTypeMoney(tientra.ToString());
                lblPay.Text = dt.Rows[0]["pay"].ToString();
                lblDeliveryAddress.Text = dt.Rows[0]["deliveryaddress"].ToString();

                DataTable objDT = new DataTable();
                objDT = (DataTable)Session["cart"];

                rptShowCart.DataSource = objDT;
                rptShowCart.DataBind();
                //int demo;
                //lblTotal.Text = Convert.ToString(Session["sum"]) + " (VND)";
                //demo = Convert.ToInt32(Session["sum"]);
                //lblTotal.Text =  objfun.ChangeTypeMoney(demo.ToString())+" VNĐ";
                lblTotal.Text = objfun.ChangeTypeMoney(objEntities.SplitString(Session["sum"].ToString()));
                double test = Convert.ToDouble(objEntities.SplitString(Session["sum"].ToString()));
                this.lblDocso.Text = objfun.DocSo(test);
            }
            catch (Exception ce)
            {
                this.lblMessager.Text = "Có vấn đề rồi. Thao tác lại là Ok";
            }
        }

        protected void btnDelOrder_Click(object sender, ImageClickEventArgs e)
        {
            btnDelOrder.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn muốn hủy hóa đơn không?!');");
            Session.Remove("cart");
            Response.Redirect("Default.aspx");
        }

        protected void btnKhangDinh_Click(object sender, ImageClickEventArgs e)
        {
            Process_Order();
            btnKhangDinh.Attributes.Add("onclick", "javascript:return alert('Đã hoàn thành việc mua hàng !');");
            Response.Redirect("Default.aspx");
        }
    }
}
