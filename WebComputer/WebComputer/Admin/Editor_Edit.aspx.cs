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
    public partial class Editor_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "news_edit";
        private string strPublishFunctions = "news_publish";
        private string strFunctionName = "Sửa tin tức";
        private int id = 0;
        protected int NewsImage = 0;
        private int intCat_Id = 0;
        protected string strNewsImage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("News_Manager");
            this.News_Edit.Text = Lang["edit"].ToString();
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
                    if (!IsPostBack)
                    {
                        ShowStatus();
                        objBusinessLogic.GetLanguage(this.DDL_Language);
                        NewsEditView();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void NewsEditView()
        {
            string strCheck = string.Empty;
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_News", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@News_Id", id);
            comm.Parameters.AddWithValue("@Author", Session["AdminID"].ToString());
            if (objBusinessLogic.Permission(this.strPublishFunctions) == true)
                comm.Parameters.AddWithValue("@Style", 1);
            else
                comm.Parameters.AddWithValue("@Style", 0);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.txtSubject.Value = drd["Subject"].ToString();
                this.Brief.Value = drd["Brief"].ToString();
                this.DDL_Status.SelectedValue = drd["Status_Id"].ToString();
                this.DDL_Language.SelectedValue = drd["Language_Id"].ToString();
                this.Content.Value = drd["Content"].ToString();
                this.intCat_Id = int.Parse(drd["Cat_Id"].ToString());
                if (drd["LeadImage"].ToString() != "0")
                {
                    this.NewsImage = int.Parse(drd["LeadImage"].ToString());
                    this.strNewsImage = objBusinessLogic.wrImages(NewsImage, objEntities.GetPathLibraryImage());
                    if ((bool)drd["CheckLeadImage"])
                        strNewsImage += "<br /><input type='checkbox' value='Yes' name='CheckLeadImage' checked />&nbsp;<font class='ListContent'>Hiển thị ảnh trong nội dung tin</font>";
                    else
                        strNewsImage += "<br /><input type='checkbox' value='Yes' name='CheckLeadImage' />&nbsp;<font class='ListContent'>Hiển thị ảnh trong nội dung tin</font>";

                }

                if ((bool)drd["Hotnews"])
                    this.cbNewsHot.Checked = true;
                else
                    this.cbNewsHot.Checked = false;
            }
            //============================================//
            //Neu ton tai tin lien quan thi hien thi.
            if (CheckRelateNews())
            {
                strCheck = "<script type='text/javascript'>displayRelateNewsIfExits();</script>";
            }
            int Lang_ID;
            if (this.DDL_Language.SelectedValue != "")
            {
                Lang_ID = int.Parse(this.DDL_Language.SelectedValue);
                CMSNews_Cat_Root.Visible = true;
                CMSNews_Cat_Root.InnerHtml = wrNewsCatRoot(Lang_ID);
                CMSCatRelate.InnerHtml = wrNewsCatRootRelate(Lang_ID) + strCheck;
                ReceiveRelateNews.InnerHtml = wrRelateNewsId();
            }
            else
            {
                Lang_ID = 0;
            }
            //============================================//            
            drd.Close();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void ShowStatus()
        {
            DataTable tableStatus = new DataTable();
            tableStatus = objBusinessLogic.CreateDataTable("Get_Status");
            this.DDL_Status.Items.Add(new ListItem(this.Lang["SelectStatus"].ToString(), ""));
            for (int i = 0; i < tableStatus.Rows.Count; i++)
            {
                this.DDL_Status.Items.Add(new ListItem(tableStatus.Rows[i]["StatusName"].ToString(), tableStatus.Rows[i]["Status_ID"].ToString()));
            }
            this.CheckPermissToPublicNews();
        }
        private void CheckPermissToPublicNews()
        {
            const int intIDPublish = 3;
            if (objBusinessLogic.Permission(strPublishFunctions) != true)
            {
                this.DDL_Status.Items.Remove(this.DDL_Status.Items.FindByValue(intIDPublish.ToString()));
            }
        }
        protected string wrNewsCatRoot(int intLang)
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Root_NewsCat_Language", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Language_Id", intLang);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SCat_Id' size='1'>");
            tbl.Append("                <option value=''>[" + Lang["NewsCatChoice"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strSelected = string.Empty;
                    if (intCat_Id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "'" + strSelected + ">" + strCatName + "</option>");
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
        protected void CatRoot_SelectIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Language.SelectedItem.Value.ToString() == "")
            {
                CMSNews_Cat_Root.Visible = false;
            }
            else
            {
                CMSNews_Cat_Root.Visible = true;
                CMSNews_Cat_Root.InnerHtml = wrNewsCatRoot(int.Parse(DDL_Language.SelectedValue));
                CMSCatRelate.InnerHtml = wrNewsCatRootRelate(int.Parse(DDL_Language.SelectedValue));
            }
        }
        protected string wrNewsCatRootRelate(int intLang)
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Root_NewsCat_Language", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Language_Id", intLang);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SRelateNews_' size='1' onchange=\"javascript:change_editor_cat(this.value)\">");
            tbl.Append("                <option value=''>[" + Lang["NewsCatRelateChoice"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strSelected = string.Empty;
                    tbl.Append("        <option value='" + Cat_Id + "' " + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, 0, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        protected string wrRelateNewsId()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataReader drd = null;
            SqlCommand comm = new SqlCommand("Get_Relate_News_Id", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@News_Id", id);
            try
            {
                comm.Connection.Open();
                drd = comm.ExecuteReader();
                tbl.Append(" <select name=\"SRelateNews\" size=\"7\" ondblclick=\"javascript:RemoveNews();\">");
                tbl.Append("    <option value=''>" + Lang["SelectedRelateNews"].ToString() + "</option>");
                while (drd.Read())
                {
                    tbl.Append("<option value='" + drd["News_ID"].ToString() + "'>" + objEntities.CutString(drd["Subject"].ToString(), 30) + "</option>");
                }
                tbl.Append(" </select>");
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
            return tbl.ToString();
        }
        protected void News_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateNews();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateNews()
        {
            int intNewsImage;
            int intCat_Id;
            string strCheckLeadImage = string.Empty;
            int CheckLeadImage = 0;
            string strRelateNews_Id = string.Empty;
            bool boolIsLeaf = false;
            bool boolHost = false;
            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strSubject = objEntities.SafeString(this.txtSubject.Value);
            string strBrief = objEntities.SafeString(this.Brief.Value);
            if (Request.Form["LeadImage"].ToString() != null && Request.Form["LeadImage"].ToString() != "")
            {
                intNewsImage = int.Parse(objEntities.SafeString(Request.Form["LeadImage"].ToString()));
            }
            else
                intNewsImage = 0;
            if (Request.Form["SCat_Id"].ToString() != null && Request.Form["SCat_Id"].ToString() != "")
            {
                intCat_Id = int.Parse(objEntities.SafeString(Request.Form["SCat_Id"].ToString()));
            }
            else
                intCat_Id = 0;
            if (Request.Form["hiddenRelateNewsID"].ToString() != string.Empty && Request.Form["hiddenRelateNewsID"].ToString() != "")
            {
                strRelateNews_Id = objEntities.SafeString(Request.Form["hiddenRelateNewsID"].ToString());
            }
            if (Request.Form["CheckLeadImage"] != null)
            {
                strCheckLeadImage = objEntities.SafeString(Request.Form["CheckLeadImage"].ToString());
                if (strCheckLeadImage != string.Empty)
                    CheckLeadImage = 1;
            }
            int intStatus = int.Parse(objEntities.SafeString(this.DDL_Status.SelectedValue));
            if (this.cbNewsHot.Checked)
                boolHost = true;
            string strContent = objEntities.SafeString(this.Content.Value);
            //================Check Cat_Id==========================
            if (intCat_Id != 0)
            {
                string SQL_Cat = "SELECT IsLeaf FROM TB_Cat_News WHERE Cat_Id =" + intCat_Id;
                SqlDataReader drd;
                SqlCommand comm_drd = new SqlCommand(SQL_Cat, objConn.SqlConn());
                comm_drd.CommandType = CommandType.Text;
                comm_drd.Connection.Open();
                drd = comm_drd.ExecuteReader();
                if (drd.Read())
                {
                    boolIsLeaf = (bool)drd["IsLeaf"];
                }
                drd.Close();
                comm_drd.Connection.Close();
                comm_drd.Connection.Dispose();
            }
            if (boolIsLeaf == false)
            {
                Response.Write("<script language='JavaScript'>alert('" + Lang["Error_ChoiceCatId"].ToString() + "');history.go(-1);</script>");
                Response.End();
            }

            //==============End Check Cat_Id========================
            SqlCommand comm = new SqlCommand("Update_News", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@News_Id", id);
            comm.Parameters.AddWithValue("@Cat_ID", intCat_Id);
            comm.Parameters.AddWithValue("@Status_ID", intStatus);
            comm.Parameters.AddWithValue("@Language_ID", intLanguage_Id);
            comm.Parameters.AddWithValue("@Subject", strSubject);
            comm.Parameters.AddWithValue("@Brief", strBrief);
            comm.Parameters.AddWithValue("@Hotnews", (bool)boolHost);
            comm.Parameters.AddWithValue("@Source", string.Empty);
            comm.Parameters.AddWithValue("@Author", Session["AdminID"].ToString());
            comm.Parameters.AddWithValue("@Content", strContent);
            comm.Parameters.AddWithValue("@CheckLeadImage", CheckLeadImage);
            comm.Parameters.AddWithValue("@LeadImage", intNewsImage);
            comm.Parameters.AddWithValue("@RelateNews_Id", strRelateNews_Id);

            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strSubject);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Editor_List.aspx");
            }
        }
        protected bool CheckRelateNews()
        {
            bool boolCheck = false;
            string SQL = "select RelateNews_ID from TB_Relate_News where News_Id =" + id;
            SqlDataReader drd = null;
            SqlCommand comm = new SqlCommand(SQL, objConn.SqlConn());
            comm.CommandType = CommandType.Text;
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                boolCheck = true;
            }
            return boolCheck;
        }
    }
}
