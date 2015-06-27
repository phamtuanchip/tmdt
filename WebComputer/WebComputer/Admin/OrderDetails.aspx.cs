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
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        public bool status;
        public Bussiness.Function objfun = new Function();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        private string strAllowFunctions = "Order_Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!IsPostBack)
                    {
                        BindGrid();
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
           
          
        }
        private void BindData()
        {
            if (Request.QueryString["OrderID"] != null)
            {
                BU_OrderDetails BUOrderdetails = new BU_OrderDetails();
                BE_OrderDetails BEOrderdetails = BUOrderdetails.SelectOrderDetails(Convert.ToInt32(Request.QueryString["OrderID"]));
                if (BEOrderdetails != null)
                {
                    lblOrderID.Text = BEOrderdetails.OrderID.ToString();
                    lblOrderDate.Text = BEOrderdetails.OrderDate.ToString("dd/MM/yyyy");
                    lblFullName.Text = BEOrderdetails.FullName.ToString();
                    lblEmail.Text = BEOrderdetails.Email.ToString();
                    lblAddress.Text = BEOrderdetails.Address.ToString();
                    lblPhoneNo.Text = BEOrderdetails.Phone.ToString();
                    lblrecAddress.Text = BEOrderdetails.DeliveryAddress.ToString();
                    //lblrecEmail.Text = BEOrderdetails.EmailReceiver.ToString();
                    lblrecFullName.Text = BEOrderdetails.DeliveryName.ToString();
                    //lblredPhoneNo.Text = BEOrderdetails.PhoneReceiver;
                    lblTotal.Text = objfun.ChangeTypeMoney(BEOrderdetails.Total.ToString());

                    //if (BEOrderdetails.Method == 0)
                    //{
                    //    lblMethod.Text = "chuyển khoản";
                    //}
                    //else if (BEOrderdetails.Method == 1)
                    //{
                    //    lblMethod.Text = "Thanh toán khi giao hàng";
                    //}
                    if (BEOrderdetails.Status == true)
                    {
                        rblStatus.Visible = false;
                        btnUpdateStatusOrder.Visible = false;
                        lblStatusOrder.Text = "đã xử lý";

                    }
                    else if (BEOrderdetails.Status == false)
                    {

                        rblStatus.Visible = true;
                        lblStatusOrder.Text = "chưa xử lý";
                    }
                }
            }
        }
        private void BindGrid()
        {
            if (Request.QueryString["OrderID"] != null)
            {
                DataTable dTable = new DataTable();
                BU_OrderDetails BUOrderDetails = new BU_OrderDetails();
                dTable = BUOrderDetails.SelectOneOrderDetails(Convert.ToInt32(Request.QueryString["OrderID"]));
                grvMain.DataSource = dTable;
                grvMain.DataBind();
            }
        }
        protected void btnUpdateStatusOrder_Click(object sender, EventArgs e)
        {
            BU_OrderDetails BUOrderdetails = new BU_OrderDetails();
            if (rblStatus.Checked == true)
            {
                bool ch = BUOrderdetails.UpdateStatusOrder(Convert.ToInt32(lblOrderID.Text), true);
                if (ch == true)
                {
                    Response.Redirect("~/Admin/Order_List.aspx");
                }
                else
                {
                    lblError.Text = "Cập nhập trạng thái hóa đơn không thành công";
                }
            }
        }

    }
}
