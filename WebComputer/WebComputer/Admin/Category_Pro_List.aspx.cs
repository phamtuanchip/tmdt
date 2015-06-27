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
    public partial class Category_Pro : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        private Bussiness.BU_Cat_Product objCategory = new BU_Cat_Product();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "Category_Pro_List";
        private string strAllowFunctions_delete = "Category_Pro_Delete";
        private string strFunctionName = "Xóa loại sản phẩm";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
            this.CatPro_AddNew.Text = Lang["Category_Pro_AddNew"].ToString();
            this.ProCat_Delete.Text = Lang["Category_Pro_Delete"].ToString();
            
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    CategoryList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void CategoryList()
        {
            DataTable datatb = new DataTable();
            datatb = objCategory.SelectAllCatPro();
            this.GV_CatPro.DataSource = datatb;
            this.GV_CatPro.DataBind();
        }

        protected void CatPro_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category_Pro_Add.aspx");
        }
        protected void ProCat_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    try
                    {

                        objCategory.DeleteCatPro();
                    }
                    catch(SqlException ce)
                    {
                        //this.lbl_Erro.Text = "Không thể xóa được bản ghi này!";
                        this.lbl_Erro.Text = "không thể xóa bản ghi này"+""+ ce.ToString();
                        
                    }

                    this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), string.Empty);
                    this.CategoryList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
       
    }
}
