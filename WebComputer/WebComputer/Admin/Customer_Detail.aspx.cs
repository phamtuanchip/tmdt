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
    public partial class Customer_Detail : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        int id;
        private string strAllowFunctions = "Customer_Edit";
        //private string strFunctionName = "Sửa thông tin nhà cung cấp";
        protected Hashtable Lang = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Back_Edit.Value = "Return";

            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                id = int.Parse(objEntities.SafeString(Request.QueryString["id"].ToString()));
            }

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!Page.IsPostBack)
                    {
                       
                        Customer_EditView();

                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }


        public void Customer_EditView()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Customer", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CustomerID", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.txt_customer.Text = drd["FullName"].ToString();
                this.txtusername.Text = drd["Username"].ToString();
                this.txtPasword.Text = drd["Password"].ToString();
                this.txt_Address.Text = drd["UserName"].ToString();
                this.txt_mail.Text = drd["email"].ToString();
                //if ((bool)drd["Active"])
                //{
                //    this.cbActive.Checked = true;
                //}
              //  this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                //this.DDL_CatId.SelectedValue = drd["ProvID"].ToString();
                // strFromDate = drd["CreateDate"].ToString();
                this.txt_Address.Text = drd["Address"].ToString();
                this.txt_Phone.Text = drd["Phone"].ToString();
                //this.txt_Website.Text = drd["Website"].ToString();



            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }






    }
}
