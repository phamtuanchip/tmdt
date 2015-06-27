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
    public partial class Login : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user_name"] = txtUser.Text.Trim();
        }
        
            protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("CheckLogin", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@username",objEntities.SafeString(txtUser.Text));
            comm.Parameters.AddWithValue("@pass",objEntities.SafeString(txtPass.Text));

            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            if (dts.Tables[0].Rows.Count > 0)
            {
                if (Session["cart"] != null)
                {
                    Session["UserName"] = objEntities.SafeString(txtUser.Text);
                    Response.Redirect("PreviewOrder.aspx");
                }
                else
                {
                    Session["UserName"] = objEntities.SafeString(txtUser.Text);
                    Response.Redirect("Default.aspx");
                }
             }
            else
            {
                Literal1.Text = "Kiểm tra lại tài khoản hoặc mật khẩu";
            }

            comm.Connection.Close();
            comm.Connection.Dispose();

            
        }

        protected void btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        
    }
}

