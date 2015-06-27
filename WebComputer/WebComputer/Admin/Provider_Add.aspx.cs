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
    public partial class Provider_Add : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "Provider_Add";
        private string strFunctionName = "Thêm mới nhà cung cấp";
       // private string strFromDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Provider_Manager");
            this.Prov_Add.Text = Lang["Prov_Add"].ToString(); 
            this.Reset_Form.Value = Lang["reset"].ToString();
            this.Back_Add.Value = Lang["Return"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    objBusinessLogic.GetLanguage(DDL_Language);
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void Prov_Add_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertProvider();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertProvider()
        {
            //if (HttpContext.Current.Request.Form["FromDatePublic"] != null)
            //{

            //    strFromDate = objEntities.SafeString(HttpContext.Current.Request.Form["FromDatePublic"].ToString());
            //}
            bool boolActive = false;
            int intLanguage_id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            string strProvName = objEntities.SafeString(this.txt_ProvName.Text);
            string strContent = objEntities.SafeString(this.Description.Text);
            string strAddress = objEntities.SafeString(this.txt_Address.Text);
            string strPhone = objEntities.SafeString(this.txt_Phone.Text);
            string strWebsite = objEntities.SafeString(this.txt_Website.Text);
            if (cbActive.Checked)
                boolActive = true;

            SqlCommand comm = new SqlCommand("Insert_Provider", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ProvName", strProvName);
            comm.Parameters.AddWithValue("@ProvDes", strContent);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@Language_Id", intLanguage_id);
           // comm.Parameters.AddWithValue("@StartDate", strFromDate);
            comm.Parameters.AddWithValue("@Address", strAddress);
            comm.Parameters.AddWithValue("@Phone", strPhone);
            comm.Parameters.AddWithValue("@Website", strWebsite);

            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strProvName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Provider_List.aspx");
            }
        }
    }
}
