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
using System.Text;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Product_List : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objfun = new Function();
        StringBuilder tbl = new StringBuilder();

        public Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "Product_List";
        //private string strPublishFunctions = "product_publish";
        private string strAllowFunctions_delete = "Product_Delete";
        private string strFunctionName = "Xoá sản  phẩm";
        private int intCat_Id = 0;
        private int intStatus_Id = 0;
        private string strSearch = string.Empty;
        //private bool boolSearchIn = false;
        private string strFromDate = string.Empty;
        private string strToDate = string.Empty;

        #region Page load
        public void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
            this.Product_Delete.Text = Lang["delete"].ToString();
            this.bntSearch.Text = Lang["Search"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.CMSProduct_Cat_Root.InnerHtml = wrProductCatRoot();
                    ProductList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        #endregion
        #region Product list
        public void ProductList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_Product", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.GV_Product_List.DataSource = dts;
            this.GV_Product_List.DataBind();
            adt.Dispose();
            dts.Clear();
            dts.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        #endregion
        #region Show status product
        public string ProductStatus()
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Status_Product", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SStatus_Id' size='1'>");
            tbl.Append("                <option value=''>[" + Lang["SelectStatus"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSelected = string.Empty;
                if (intStatus_Id == int.Parse(dt.Rows[i]["Status_ID"].ToString()))
                    strSelected = " selected ";
                tbl.Append("            <option value='" + dt.Rows[i]["Status_ID"].ToString() + "' " + strSelected + ">" + dt.Rows[i]["Status_Name"].ToString() + "</option>");
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        #endregion
        #region Show category product
        public string wrProductCatRoot()
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            //SqlCommand comm = new SqlCommand("Get_All_SubProduct", objConn.SqlConn());
            SqlCommand comm = new SqlCommand("Get_All_SubProduct", objConn.SqlConn());

            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SCat_Id' size='1'>");
            tbl.Append("                <option value=''>[" + Lang["ProductCatChoice"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["SubName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["SubCatID"].ToString());
                    string strSelected = string.Empty;
                    if (intCat_Id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "' " + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, intCat_Id, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        #endregion
        #region Show changing
        protected void GV_Product_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Product_List.PageIndex = e.NewPageIndex;
            this.ProductList();
        }
        #endregion
        #region Search product
        protected void bntSearch_Click(object sender, EventArgs e)
        {

            if (Request.Form["SCat_Id"] != null && Request.Form["SCat_Id"].ToString() != "")
                intCat_Id = int.Parse(objEntities.SafeString(Request.Form["SCat_Id"].ToString()));
            strSearch = objEntities.SafeString(txtSearch.Text.ToString());

            CMSProduct_Cat_Root.InnerHtml = wrProductCatRoot();
            SearchProductList();
        }
        protected void SearchProductList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_Product_Search", objConn.SqlConn());
            comm.Parameters.AddWithValue("@SubCat_ID", intCat_Id);
            comm.Parameters.AddWithValue("@Product_Name", strSearch);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.GV_Product_List.DataSource = dts;
            this.GV_Product_List.DataBind();
            adt.Dispose();
            dts.Clear();
            dts.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        #endregion
        #region Delete product
        protected void Product_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    DeleteProduct();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteProduct()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intProduct_Id = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Delete_Product", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Product_Id", intProduct_Id);
                        try
                        {
                            comm.Connection.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ce)
                        {
                            this.lblErro.Text = "Không thể xóa bản ghi này"+ce.ToString();
                            
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
            this.ProductList();
        }
        #endregion
        #region Start product
        protected void Product_Start_Click(object sender, EventArgs e)
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
        protected void StartProduct()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intProduct_Id = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Start_Product", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Product_Id", intProduct_Id);
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
            this.ProductList();
        }
        #endregion
        #region OFF product
        protected void Product_Off_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
                    OffProduct();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void OffProduct()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    string PathProductFile = string.Empty;
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intProduct_Id = int.Parse(item.Substring(9, item.Length - 9));
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Off_Product", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@Product_Id", intProduct_Id);
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
            this.ProductList();
        }
        #endregion

        protected void Btn_AddNewProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Addnew.aspx");
        }
    }
}
