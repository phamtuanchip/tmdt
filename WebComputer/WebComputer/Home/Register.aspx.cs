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
    public partial class Register : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand comm = new SqlCommand("Insert_Customer", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@UserName", objEntities.SafeString(txtUserName.Text));
            comm.Parameters.AddWithValue("@Pass", objEntities.SafeString(txtPassWord.Text));
            comm.Parameters.AddWithValue("@FullName", objEntities.SafeString(txtName.Text));
            comm.Parameters.AddWithValue("@Address", objEntities.SafeString(txtAddress.Text));
            comm.Parameters.AddWithValue("@Email", txtEmail.Text);
            comm.Parameters.AddWithValue("@Phone", txtTel.Text);
            comm.Parameters.AddWithValue("@LanguageID", 1);
            comm.Parameters.AddWithValue("@StatusID", 1);

            Session["user"] = txtUserName.Text;

            try
            {
                comm.Connection.Open();
                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Write("Insert ok man");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("CartShow.aspx");
            }
        }
    }
}
