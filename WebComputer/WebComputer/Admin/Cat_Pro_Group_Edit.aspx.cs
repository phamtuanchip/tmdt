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
    public partial class Cat_Pro_Group_Edit : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public BU_Cat_Product objBuCat = new BU_Cat_Product();
        public BU_Cat_Pro_Group objBuCatGroup = new BU_Cat_Pro_Group();

        protected Hashtable Lang = new Hashtable();
        public string strFromDate, strEnddate;
        int id;
        private string strAllowFunctions = "Cat_Pro_Group_Edit";
        private string strFunctionName = "Sửa thông tin loại sản phẩm";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");

            this.btn_CatProGroup_Edit.Text = Lang["edit"].ToString();
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
                        objBusinessLogic.GetCatProduc(this.DDL_CatId);
                        CatProGroup_EditView();

                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }

        public void btn_CatProGroup_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateCatProductGroup();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        public void CatProGroup_EditView()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_CatProGroup", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@SubCatId", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.tbCatProGroupTitle.Text = drd["SubName"].ToString();
                this.Content_CatProGroup.Value = drd["SubDes"].ToString();
                if ((bool)drd["Active"])
                {
                    this.cbActive.Checked = true;
                }
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                this.DDL_CatId.SelectedValue = drd["Cat_ID"].ToString();
                //strFromDate = drd["CreateDate"].ToString();

            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }


        protected void UpdateCatProductGroup()
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
                int intCatPro_id = int.Parse(objEntities.SafeString(this.DDL_CatId.SelectedValue));
                string strCatPro_name = objEntities.SafeString(this.tbCatProGroupTitle.Text);
                string strContent = objEntities.SafeString(this.Content_CatProGroup.Value);
                if ((bool)cbActive.Checked)
                {
                    boolActive = true;
                }
                test = objBuCatGroup.UpdateCatProGroup(id, strCatPro_name, strContent, boolActive, intLanguage_Id, intCatPro_id);
                this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strCatPro_name);
            
            }
            catch (Exception ce)
            {
                Response.Redirect("EOFPermission.aspx");
                throw new Exception(ce.Message.ToString());
                
            }
            finally
            {
                Response.Redirect("Cat_Pro_Group_List.aspx");
            }

        }
    }
}
