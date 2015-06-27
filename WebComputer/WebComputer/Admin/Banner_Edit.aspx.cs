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
using System.IO;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Banner_Edit : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        protected string strBannerStartDate = string.Empty;
        protected string strBannerEndDate = string.Empty;
        protected int id;
        protected string strAllowFunctions = "banner_list,banner_edit";
        private string strFunctionName = "Sửa thông tin banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.Edit_Banners.Text = Lang["edit"].ToString();
            this.Reset_Form.Value = Lang["reset_form"].ToString();
            this.Back_Edit.Value = Lang["back"].ToString();
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
                        this.LangList();
                        this.EditListBanner();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void LangList()
        {
            string SQL = "SELECT * FROM TB_Languages ORDER BY Language_ID";
            this.DDL_Language.Items.Add(new ListItem(" Hãy chọn ngôn ngữ ", ""));
            for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
            {
                this.DDL_Language.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["LanguageName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Language_ID"].ToString()));
            }
        }
        protected void DDL_Language_SelectIndexChanged(object sender, EventArgs e)
        {
            //CatLogo
            if (this.DDL_Language.SelectedItem.Value.ToString() == "")
                this.LB_CatBanner.Visible = false;
            else
            {
                this.LB_CatBanner.Visible = true;
                string SQL = string.Empty;
                SQL = "SELECT Cat_Id, CatName FROM TB_Cat_Banner WHERE Language_Id =" + System.Int32.Parse(this.DDL_Language.SelectedValue);
                DataTable dataTable = new DataTable();
                dataTable = this.objBusinessLogic.CreateDataTable(SQL);
                this.LB_CatBanner.Items.Clear();
                this.LB_CatBanner.Items.Add(new ListItem(" -- Chọn danh mục logo -- ", ""));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.LB_CatBanner.Items.Add(new ListItem(dataTable.Rows[i]["CatName"].ToString(), dataTable.Rows[i]["Cat_Id"].ToString()));
                }
            }
        }
        protected void EditListBanner()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Banner", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Banner_Id", id);
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_TypeLink.SelectedValue = drd["TypeLink"].ToString();
                this.tbBannerName.Text = drd["BannerName"].ToString();
                this.tbBannerURL.Text = drd["BannerURL"].ToString();
                this.tbBannerDesc.Text = drd["BannerDesc"].ToString();
                strBannerStartDate = drd["BannerStartDate"].ToString();
                strBannerEndDate = drd["BannerEndDate"].ToString();
                this.ImgFile.ImageUrl = this.objEntities.GetPathBanner() + drd["ImageName"].ToString();
                this.DDL_Language.SelectedValue = drd["Language_Id"].ToString();

                if ((bool)drd["Active"])
                    this.cbActive.Checked = (bool)drd["Active"];
                else
                    this.cbActive.Checked = (bool)drd["Active"];
                if ((bool)drd["BannerExpried"])
                    this.cbExpried.Checked = (bool)drd["BannerExpried"];
                else
                    this.cbExpried.Checked = (bool)drd["BannerExpried"];
            }
            drd.Close();
            //============================================//
            int Lang_ID = 0;
            if (this.DDL_Language.SelectedValue != "")
            {
                Lang_ID = System.Int32.Parse(this.DDL_Language.SelectedValue);
            }
            else
            {
                Lang_ID = 0;
            }
            //---------------------------------------------
            this.LB_CatBanner.Visible = true;
            string SQL = string.Empty;
            SQL = "SELECT Cat_Id, CatName FROM TB_Cat_Banner WHERE Language_Id =" + Lang_ID;
            DataTable dataTable = new DataTable();
            dataTable = this.objBusinessLogic.CreateDataTable(SQL);
            this.LB_CatBanner.Items.Clear();
            this.LB_CatBanner.Items.Add(new ListItem(" -- Chọn danh mục logo -- ", ""));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                this.LB_CatBanner.Items.Add(new ListItem(dataTable.Rows[i]["CatName"].ToString(), dataTable.Rows[i]["Cat_Id"].ToString()));
            }
            //============================================//
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void Edit_Banners_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    EditBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void EditBanner()
        {
            bool boolActive;
            bool boolExpried;
            string strDateTime = string.Empty;
            string strCat_Id = string.Empty;

            int inLanguage_Id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            int intTypeLink = int.Parse(objEntities.SafeString(DDL_TypeLink.SelectedValue));

            string strBannerName = objEntities.SafeString(this.tbBannerName.Text);
            string strBannerURL = objEntities.SafeString(this.tbBannerURL.Text);
            string strBannerDesc = objEntities.SafeString(this.tbBannerDesc.Text);
            if (Request.Form["FromDatePublic"] != null && Request.Form["FromDatePublic"].ToString() != "")
            {
                strBannerStartDate = objEntities.SafeString(Request.Form["FromDatePublic"].ToString());
            }
            if (Request.Form["EndDatePublic"] != null && Request.Form["EndDatePublic"].ToString() != "")
            {
                strBannerEndDate = objEntities.SafeString(Request.Form["EndDatePublic"].ToString());
            }
            string strCatBanner = objEntities.SafeString(this.LB_CatBanner.Text);

            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;
            if (this.cbExpried.Checked)
                boolExpried = true;
            else
                boolExpried = false;

            for (int i = 0; i < LB_CatBanner.Items.Count; i++)
            {
                if (LB_CatBanner.Items[i].Selected)
                    strCat_Id += LB_CatBanner.Items[i].Value + ", ";
            }
            if (strCat_Id != string.Empty)
                strCat_Id = strCat_Id.Substring(0, strCat_Id.Length - 2);

            SqlCommand comm = new SqlCommand("Update_Banner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Banner_Id", id);
            comm.Parameters.AddWithValue("@BannerName", strBannerName);
            comm.Parameters.AddWithValue("@BannerURL", strBannerURL);
            comm.Parameters.AddWithValue("@BannerStartDate", strBannerStartDate);
            comm.Parameters.AddWithValue("@BannerEndDate", strBannerEndDate);
            comm.Parameters.AddWithValue("@BannerExpried", boolExpried);
            comm.Parameters.AddWithValue("@BannerDesc", strBannerDesc);
            comm.Parameters.AddWithValue("@Active", boolActive);
            comm.Parameters.AddWithValue("@TypeLink", intTypeLink);
            comm.Parameters.AddWithValue("@Language_Id", inLanguage_Id);
            comm.Parameters.AddWithValue("@strCat_Id", strCat_Id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strBannerName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Banner_list.aspx");
            }
        }
    }
}
