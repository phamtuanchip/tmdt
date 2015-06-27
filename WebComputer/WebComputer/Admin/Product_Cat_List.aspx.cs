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
using System.Text;
using Entity;
using Bussiness;


namespace WebComputer.Admin
{
    public partial class Product_Cat_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "productcat_list";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
            this.Product_Cat_AddNew.Text = Lang["AddNew"].ToString();
            this.Product_Cat_Order.Text = Lang["ProductCatOrder"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    CMSProduct_Cat_List.InnerHtml = ProductCatList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string ProductCatList()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_CatProduct", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;

            DataTable dt = new DataTable();
            adt.Fill(dt);

            tbl.Append(" <table width='100%' border='0' cellspacing='3' cellpadding='2' style='border-collapse:collapse'>");
            tbl.Append("    <tr>");
            tbl.Append("        <td height='20' align='left'>");
            string varSpace = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == 0)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    bool boolActive = (bool)dt.Rows[i]["Active"];
                    tbl.Append(wrCatProduct(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (objBusinessLogic.FindChildNode(intCat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(Create_CatProduct_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append(" </table>");

            return tbl.ToString();
        }
        #region Tree product
        public string Create_CatProduct_Tree(int Cat_Id, DataTable dt, string varSpace)
        {
            varSpace += "&nbsp;&nbsp;&nbsp;&nbsp";
            StringBuilder tbl = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == Cat_Id)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    bool boolActive = (bool)dt.Rows[i]["Active"];
                    tbl.Append(wrCatProduct(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (objBusinessLogic.FindChildNode(intCat_Id, dt))
                    {
                        tbl.Append(Create_CatProduct_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            return tbl.ToString();
        }
        public string wrCatProduct(int Cat_Id, int Parent, string CatName, bool Active, string varSpace)
        {
            StringBuilder tbl = new StringBuilder();
            string strCatName = string.Empty;
            if (Active == false)
                strCatName = "<span style='color:#FF0000'>" + CatName + "</span>";
            else
                strCatName = CatName;
            if (Parent == 0)
                tbl.Append("<img border='0' src='/Images/Admin/note.gif' width='8' height='12' align='absbottom'>&nbsp;<strong>" + strCatName + "</strong>");
            else
                tbl.Append(varSpace + "-&nbsp;" + strCatName);
            tbl.Append("&nbsp;&nbsp;&nbsp;<a href='Product_Cat_Edit.aspx?id=" + Cat_Id + "' title='Sửa danh mục " + CatName + "'><img src='/images/Admin/edit_u.gif' border='0'></a>");
            tbl.Append("&nbsp;&nbsp;&nbsp;<a href=\"JavaScript:if(confirm('Bạn có muốn xóa không?')){location.href='Product_Cat_Delete.aspx?id=" + Cat_Id + "'};\" title='Xóa danh mục " + CatName + "'><img src='/Images/Admin/delete.gif' border='0'></a>");
            tbl.Append("<br />");
            return tbl.ToString();
        }

        #endregion
        #region Event Click
        protected void Product_Cat_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Cat_AddNew.aspx");
        }
        protected void Product_Cat_Order_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Cat_Order.aspx");
        }
        #endregion
    }
}