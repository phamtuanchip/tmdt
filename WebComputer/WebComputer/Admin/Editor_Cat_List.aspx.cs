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
    public partial class Editor_Cat_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "newscat_list";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            this.News_Cat_AddNew.Text = Lang["AddNew"].ToString();
            this.News_Cat_Order.Text = Lang["NewsCatOrder"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    CMSNews_Cat_List.InnerHtml = NewsCatList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string NewsCatList()
        {
            StringBuilder tbl = new StringBuilder();

            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_CatNews", objConn.SqlConn());
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
                    tbl.Append(objBusinessLogic.wrCatNews(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (objBusinessLogic.FindChildNode(intCat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_CatNews_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append(" </table>");

            return tbl.ToString();
        }
        protected void News_Cat_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editor_Cat_AddNew.aspx");
        }
        protected void News_Cat_Order_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editor_Cat_Order.aspx");
        }
    }
}
