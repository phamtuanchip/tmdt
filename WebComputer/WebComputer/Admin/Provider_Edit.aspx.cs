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
    public partial class Provider_Edit : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public BU_Provider objProvider = new BU_Provider();

        //public BU_Cat_Product objBuCat = new BU_Cat_Product();
        //public BU_Cat_Pro_Group objBuCatGroup = new BU_Cat_Pro_Group();

        protected Hashtable Lang = new Hashtable();
        //public string strFromDate, strEnddate;
        int id;
        private string strAllowFunctions = "Provider_Edit";
        private string strFunctionName = "Sửa thông tin nhà cung cấp";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Provider_Manager");

            this.btn_Provider_Edit.Text = Lang["edit"].ToString();
            this.Reset_Form.Value = Lang["reset"].ToString();
            this.Back_Edit.Value = Lang["Return"].ToString();

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
                        objBusinessLogic.GetLanguage(this.DDL_Language);
                       // objBusinessLogic.GetCatProduc(this.DDL_CatId);
                        Provider_EditView();

                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }

        public void btn_Provider_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateProvider();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        public void Provider_EditView()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Provider", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ProvID", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.txt_ProName.Text = drd["ProvName"].ToString();
                this.Description.Text = drd["Description"].ToString();
                if ((bool)drd["Active"])
                {
                    this.cbActive.Checked = true;
                }
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                //this.DDL_CatId.SelectedValue = drd["ProvID"].ToString();
               // strFromDate = drd["CreateDate"].ToString();
                this.txt_Address.Text = drd["Address"].ToString();
                this.txt_Phone.Text = drd["Phone"].ToString();
                this.txt_Website.Text = drd["Website"].ToString();
               
                

            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }


        protected void UpdateProvider()
        {

            bool test = false;

            try
            {
                //if (HttpContext.Current.Request.Form["FromDatePublic"] != null)
                //{
                //    strFromDate = objEntities.SafeString(HttpContext.Current.Request.Form["FromDatePublic"].ToString());
                //}

                bool boolActive = false;
                int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
                string strProvName = objEntities.SafeString(this.txt_ProName.Text);
                string strContent = objEntities.SafeString(this.Description.Text);
                if ((bool)cbActive.Checked)
                {
                    boolActive = true;
                }
                string strAddress = objEntities.SafeString(this.txt_Address.Text);
                string strPhone = objEntities.SafeString(this.txt_Phone.Text);
                string strWebsite = objEntities.SafeString(this.txt_Website.Text);
                //test = objProvider.UpdateProvider(id, strProvName, strContent, boolActive, intLanguage_Id, Convert.ToDateTime(strFromDate),strAddress,strPhone,strWebsite);
                test = objProvider.UpdateProvider(id, strProvName, strContent, boolActive, intLanguage_Id, strAddress, strPhone, strWebsite);
                this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strProvName);

            }
            catch (Exception ce)
            {
                Response.Redirect("EOFPermission.aspx");
                throw new Exception(ce.Message.ToString());
                
            }
            finally
            {
                Response.Redirect("Provider_List.aspx");
            }

        }
    }
}
