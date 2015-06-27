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
    public partial class Editor_Cat_Order : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();


        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "newscat_list,newscat_edit";
        private string strFunctionName = "Thiết lập thứ tự danh mục tin tức";
        private int Parent_Id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            this.Update_NewsCatOrder.Text = Lang["edit"].ToString();
            this.Back_Order.Value = Lang["Return"].ToString();
            if (Request.Form["SCat_Id"] != null && Request.Form["SCat_Id"].ToString() != "")
            {
                Parent_Id = int.Parse(objEntities.SafeString(Request.Form["SCat_Id"].ToString()));
            }

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    CMSNews_Cat_Order.InnerHtml = NewsCatOrder();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string NewsCatOrder()
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_CatNews", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append(" <table width='100%' border='0' cellspacing='3' cellpadding='2'>");
            tbl.Append("    <input name='SCat_Id' type='hidden'>");
            tbl.Append("    <input type='hidden' name='hiddenOrder'>");
            tbl.Append("    <tr>");
            tbl.Append("        <td width='25%' class='ListContent' align='left'>" + Lang["var_Text_ParentCat"].ToString() + "</td>");
            tbl.Append("        <td align='left'>");
            tbl.Append("            <select name='SNewsCat' size='1' onChange='JavaScript:changeOrderCat(this.value)'>");
            tbl.Append("                <option value='0'>[" + Lang["var_Text_ParentCat"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strSelected = string.Empty;
                    if (Parent_Id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "' " + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, Parent_Id, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");
            tbl.Append("        </td>");
            tbl.Append("    </tr>");

            dt.Clear();
            comm.Connection.Close();
            comm.Connection.Dispose();

            comm = new SqlCommand("Get_News_Cat_Parent", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Parent", Parent_Id);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            tbl.Append("    <tr>");
            tbl.Append("        <td align='center' colspan='2'>");
            tbl.Append("            <table width='90%' border='0' cellspacing='2' cellpadding='1'>");
            tbl.Append("                <tr>");
            tbl.Append("                    <td align='left'>");
            tbl.Append("                        <select name='SOrder' size='10'>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSelected = "";
                if ((int)i == 0)
                    strSelected = " selected ";
                tbl.Append("<option value='" + dt.Rows[i]["Cat_Id"].ToString() + "' " + strSelected + ">" + dt.Rows[i]["CatName"].ToString() + "</option>");
            }
            tbl.Append("                        </select>");
            tbl.Append("                    </td>");
            tbl.Append("                    <td width='85%' align='left'>");
            tbl.Append("                        <input type='button' class='textbox' value='↑' onClick='moveOptionUp(SOrder);'><br><br>");
            tbl.Append("                        <input type='button' class='textbox' value='↓' onClick='moveOptionDown(SOrder);'><br><br>");
            tbl.Append("                    </td>");
            tbl.Append("                </tr>");
            tbl.Append("            </table>");
            tbl.Append("        </td>");
            tbl.Append("    </tr>");

            dt.Clear();
            comm.Connection.Close();
            comm.Connection.Dispose();

            tbl.Append(" </table>");

            return tbl.ToString();
        }
        protected void Update_NewsCatOrder_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateNewsCatOrder();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateNewsCatOrder()
        {
            string strNewsCatOrder = string.Empty;
            if (Request.Form["hiddenOrder"] != null && Request.Form["hiddenOrder"].ToString() != "")
            {
                strNewsCatOrder = objEntities.SafeString(Request.Form["hiddenOrder"].ToString());
            }
            SqlCommand comm = new SqlCommand("Update_NewsCat_Order", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@NewsCat_Order", strNewsCatOrder);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strNewsCatOrder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Editor_Cat_List.aspx");
            }
        }
    }
}
