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
    public partial class PreviewOrder : System.Web.UI.Page
    {

        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                view_info_customer();
            
            }
        }

        protected void Info_Order()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("fullname");
                dt.Columns.Add("tel");

                dt.Columns.Add("user_name");
                dt.Columns.Add("email");
                dt.Columns.Add("deliveryName");
                dt.Columns.Add("pay");
                dt.Columns.Add("address");
                dt.Columns.Add("delivery");
                dt.Columns.Add("deliveryaddress");


                DataRow dr = dt.NewRow();

                if (Session["user_name"] == null)
                {
                    dr["user_name"] = "none";
                }
                else
                {
                    dr["user_name"] = Session["user_name"];
                }
                dr["email"] = txtEmail.Text.Trim();
                dr["address"] = txtAddress.Text.Trim();
                dr["fullname"] = txtName.Text.Trim();
                dr["tel"] = txtTel.Text.Trim();
                dr["deliveryName"] = objEntities.SafeString(txtDeliveryName.Text.Trim());
                dr["deliveryaddress"] = objEntities.SafeString(txtDeliveryAddress.Text.Trim());

                //kiem tra hinh thuc giao hang
                if (rdgiaohangtantay.Checked == true)
                {
                    dr["delivery"] = "Giao Hàng Tận Tay";
                }
                else if (rdGiaohangquabuudien.Checked == true)
                {
                    dr["delivery"] = "Giao Hàng Qua Bưu Điện";
                }
                else if (rdChuyenPhatNhanh.Checked == true)
                {
                    dr["delivery"] = "Chuyển Phát Nhanh";
                }
                else if (rdgiaohangtantay.Checked == true)
                {
                    dr["delivery"] = "Giao Hàng Cấp Tốc";
                }

                //kiem tra hinh thuc thanh toan
                if (rdThanhToanTrucTiep.Checked == true)
                {
                    dr["pay"] = "Thanh Toán Trực Tiếp";
                }
                else if (rdNhanVienGiaoHangThuTien.Checked == true)
                {
                    dr["pay"] = "Nhân Viên Giao Hàng Thu Tiền";
                }
                else if (rdChuyenKhoan.Checked == true)
                {
                    dr["pay"] = "Chuyển Khoản";
                }
                else if (rdGuiQuaBuuDien.Checked == true)
                {
                    dr["pay"] = "Gửi Qua Bưu Điện";
                }

                dt.Rows.Add(dr);
                Session["order"] = dt;
            }
            catch (Exception ce)
            {
                Response.Redirect("Erros.aspx");
            }
        }

        public void view_info_customer()
        {
            try
            {
                if (Session["user_name"] != null)
                {
                    DataSet dts = new DataSet();
                    SqlDataAdapter adt = new SqlDataAdapter();
                    SqlCommand comm = new SqlCommand("Get_CustomerByName", objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@CusName", Session["user_name"].ToString());
                    comm.Connection.Open();
                    adt.SelectCommand = comm;
                    adt.Fill(dts);

                    DataTable dt = new DataTable();
                    dt = dts.Tables[0];

                    txtName.Text = dt.Rows[0]["FullName"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtTel.Text = dt.Rows[0]["Phone"].ToString();

                    comm.Connection.Close();
                    comm.Connection.Dispose();

                    txtTel.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtName.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                }

                else
                {
                    return;
                }
            }
            catch (Exception ce)
            {
                Response.Redirect("Erros.aspx");
            }
        }

        protected void btnPreviewOrder_Click(object sender, ImageClickEventArgs e)
        {
            Info_Order();
            Response.Redirect("ProcessOrder.aspx");
        }

      
    }
}
