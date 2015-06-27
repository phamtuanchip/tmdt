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
using Bussiness;
using System.Data.SqlClient;
using Entity;


namespace WebComputer.Admin
{
    public partial class PaymentOrder_Add : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        #region public variable
        DataTable dTable = new DataTable();
        BUBill objBill = new BUBill();
        BUPaymentOrder objPayment = new BUPaymentOrder();
        private string strAllowFunctions = "PaymentAdd";
        #endregion
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
                        lblCreatedDate.Text = DateTime.Now.ToString();
                        this.lblEmployee.Text = Session["AdminID"].ToString();
                        BindProvNameToDDL();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
           
           
        }
        private void BindProvNameToDDL()
        {
            dTable = objBill.SelectProvName();
            ddlProvName.DataSource = dTable;
            ddlProvName.DataBind();
        }

        protected void ddlProvName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvName.SelectedValue != "0")
            {
                dTable = objPayment.CheckExistProvID(Convert.ToInt32(ddlProvName.SelectedValue));
                if (dTable.Rows.Count > 0)
                {
                    btnAddPaymentOrder.Visible = true;
                    dTable = objPayment.GetTotalByProvID(Convert.ToInt32(ddlProvName.SelectedValue));
                    if (dTable.Rows.Count > 0)
                    {
                        lblTotalArrears.Visible = true;
                        lblTotal.Visible = true;
                        if (dTable.Rows[0][0] != null)
                        {
                            if (Convert.ToInt32(dTable.Rows[0][0]) > 0)
                            {
                                lblTotalArrears.Visible = true;
                                lblTotal.Visible = true;
                                lblTotalArrears.Text = "Tổng dư có:";
                                lblTotal.Text = dTable.Rows[0][0].ToString();

                            }
                            else if (Convert.ToInt32(dTable.Rows[0][0]) < 0)
                            {
                                lblTotalArrears.Visible = true;
                                lblTotal.Visible = true;
                                lblTotalArrears.Text = "Tổng dư nợ:";
                                int a = Convert.ToInt32(dTable.Rows[0][0]);
                                decimal total = Convert.ToDecimal(Math.Abs(a));
                                lblTotal.Text = total.ToString();
                            }
                            else
                            {
                                lblTotalArrears.Visible = true;
                                lblTotal.Visible = true;
                                lblTotalArrears.Text = "Tổng dư có:";
                                lblTotal.Text = "0.00";
                            }
                        }
                        else
                        {
                            lblTotalArrears.Visible = true;
                            lblTotal.Visible = true;
                            lblTotalArrears.Text = "Tổng dư nợ:";
                            lblTotal.Text = "0";
                        }
                    }
                    else
                    {
                        lblTotal.Text = "";
                    }
                }
                else
                {
                    btnAddPayment.Visible = true;
                    lblTotalArrears.Visible = false;
                    lblTotal.Visible = false;
                }
            }
            
        }

        protected void btnAddPaymentOrder_Click(object sender, EventArgs e)
        {
            if (ddlProvName.SelectedValue == "0")
            {
                lblError.Text = "Bạn chưa chọn nhà cung cấp!!!";
            }
            else
            {
                bool ch = objPayment.InsertPaymentOrder(txtReasonPayment.Text, Convert.ToDecimal(txtQuantity.Text), lblEmployee.Text, Convert.ToInt32(ddlProvName.SelectedValue));
                if (ch == true)
                {
                    Response.Redirect("~/Admin/PaymentOrder.aspx");
                }
                else
                {
                    lblError.Text = "Thêm phiếu chi không thành công!!!";
                }
            }


        }

        protected void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (ddlProvName.SelectedValue == "0")
            {
                lblError.Text = "Bạn chưa chọn nhà cung cấp!!!";
            }
            else
            {
                bool ch = objPayment.InsertPaymentOrder(txtReasonPayment.Text, Convert.ToDecimal(txtQuantity.Text), lblEmployee.Text, Convert.ToInt32(ddlProvName.SelectedValue));
                if (ch == true)
                {
                    Response.Redirect("~/Admin/PaymentOrder.aspx");
                }
                else
                {
                    lblError.Text = "Thêm phiếu chi không thành công!!!";
                }
            }
        }
    }
}
