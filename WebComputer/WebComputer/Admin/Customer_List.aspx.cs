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
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Customer_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        private string strFunctionName = "Xóa thông tin khách hàng";
        private string strAllowFunctions_delete = "Customer_Delete";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Get_All_Customer();
        }
        private void Get_All_Customer()
        {
            this.GV_Customer_List.DataSource = objBusinessLogic.CreateDataTable("Get_All_Customer", false);
            this.GV_Customer_List.DataBind();
        }
        protected void GV_Customer_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Customer_List.PageIndex = e.NewPageIndex;
            this.Get_All_Customer();
        }
        protected void Customer_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    DeleteCustomer();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteCustomer()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intNews_Id = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Delete_Customer", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Customer_Id", intNews_Id);
                        try
                        {
                            comm.Connection.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }
                        finally
                        {
                            comm.Connection.Close();
                            comm.Connection.Dispose();
                        }
                        this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), string.Empty);
                        //===========End Delete Database===============================
                    }
                }
            }
            this.Get_All_Customer();
        }
        protected void OffCustomer()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intCustomerID = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Off_Customer", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@CustomerID", intCustomerID);
                        try
                        {
                            comm.Connection.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }
                        finally
                        {
                            comm.Connection.Close();
                            comm.Connection.Dispose();
                        }
                        this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), string.Empty);
                        //===========End Delete Database===============================
                    }
                }
            }
            this.Get_All_Customer();
        }
        protected void StartProduct()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intCustomerId = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Start_Customer", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@CustomerID", intCustomerId);
                        try
                        {
                            comm.Connection.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }
                        finally
                        {
                            comm.Connection.Close();
                            comm.Connection.Dispose();
                        }
                        this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), string.Empty);
                        //===========End Delete Database===============================
                    }
                }
            }
            this.Get_All_Customer();
        }
        protected void Customer_Start_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    StartProduct();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void Customer_Off_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    OffCustomer();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }

        }
    }
}
