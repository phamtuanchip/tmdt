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
    public partial class Cat_Pro_Group_List : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.BU_Cat_Product objCategory = new BU_Cat_Product();
        public Bussiness.BU_Cat_Pro_Group objCatGroup = new BU_Cat_Pro_Group();

        protected Hashtable Lang = new Hashtable();
        public string strAllowFunctions = "Cat_Pro_Group_List";
        public string strAllowFunctions_delete = "Category_Pro_Delete";
        public string strFunctionName = "Xóa loại sản phẩm";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
            this.CatProGroup_AddNew.Text = Lang["Cat_Pro_Group_AddNew"].ToString();
            this.ProCatGroup_Delete.Text = Lang["Cat_Pro_Group_Delete"].ToString();

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
            datatb = objCatGroup.SelectAllCatProGroup();
            this.GV_CatPro.DataSource = datatb;
            this.GV_CatPro.DataBind();
        }

        protected void CatProGroup_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cat_Pro_Group_Add.aspx");
        }
        protected void ProCatGroup_Delete_Click(object sender, EventArgs e)
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
                        objCatGroup.DeleteCatPro();
                    }
                    catch (SqlException ce)
                    {
                        this.lbl_Erro.Text = "Không xóa được!"+ce.ToString();
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

        protected void GV_CatPro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_CatPro.PageIndex = e.NewPageIndex;
            this.CategoryList();
        }
    }
}
