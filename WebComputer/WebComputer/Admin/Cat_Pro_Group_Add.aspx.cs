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
    public partial class Cat_Pro_Group_Add : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "Cat_Pro_Group_AddNew";
        private string strFunctionName = "Thêm mới nhóm sản phẩm";
       // private string strFromDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
            this.CatProGroup_AddNew.Text = Lang["AddNew"].ToString();
            this.Reset_Form.Value = Lang["reset"].ToString();
            this.Back_AddNew.Value = Lang["Return"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    objBusinessLogic.GetLanguage(DDL_Language);
                    objBusinessLogic.GetCatProduc(this.DDL_CatId);
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void CatProGroup_AddNew_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertCatProGroup();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertCatProGroup()
        {
            //if (HttpContext.Current.Request.Form["FromDatePublic"] != null)
            //{

            //    strFromDate = objEntities.SafeString(HttpContext.Current.Request.Form["FromDatePublic"].ToString());
            //}


            bool boolActive = false;
            int intLanguage_id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            int intCat_Id = int.Parse(objEntities.SafeString(DDL_CatId.SelectedValue));
            string strCatProGroupTitle = objEntities.SafeString(tb_CatProGroup_Title.Text);
            string strContent = objEntities.SafeString(CatProGroupDes.Value);
            int SubOrder = 1;
            int Parent = 0;
            if (cbActive.Checked)
                boolActive = true;

            SqlCommand comm = new SqlCommand("Insert_CatProGroup", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@SubName", strCatProGroupTitle);
            comm.Parameters.AddWithValue("@SubDes", strContent);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@Language_Id", intLanguage_id);
            //comm.Parameters.AddWithValue("@StartDate", strFromDate);
            comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
            comm.Parameters.AddWithValue("@SubOrder", SubOrder);
            comm.Parameters.AddWithValue("@Parent", Parent);

            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strCatProGroupTitle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Cat_Pro_Group_List.aspx");
            }
        }
    }
}
