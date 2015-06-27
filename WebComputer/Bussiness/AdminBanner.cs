using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Entity;

namespace Bussiness
{
    public class AdminBanner
    {
    }

    #region Banner_Category
    public class AdminBannerCategory : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected GridView GV_BannerCategory = new GridView();
        protected Button Delete_Banner = new Button();
        protected Button AddNew_Banner = new Button();

        private string strAllowFunctions = "bannercat_list";
        private string strAllowFunctions_Delete = "bannercat_delete";
        private string strFunctionName = "Xoá danh mục banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.Delete_Banner.Text = Lang["delete"].ToString();
            this.AddNew_Banner.Text = Lang["add_new"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.ListCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void ListCatBanner()
        {
            this.GV_BannerCategory.DataSource = this.objBusinessLogic.Execute_Store("Get_Category_Banner");
            this.GV_BannerCategory.DataBind();
        }
        protected void Delete_Banner_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_Delete) == true)
                {
                    this.DeleteCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteCatBanner()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intCatBanner_id = Int32.Parse(item.Substring(9, item.Length - 9));
                    SqlCommand comm = new SqlCommand("Delete_Cat_Banner", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Cat_Id", intCatBanner_id);
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
                    this.ListCatBanner();
                }
            }
        }
        protected void AddNew_Banner_Click(object sender, EventArgs e)
        {
            Response.Redirect("BannerCat_AddNew.aspx");
        }
    }
    #endregion Banner_Category
    #region BannerCat_AddNew
    public class AdminBannerCatAddNew : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected DropDownList DDL_Language = new DropDownList();
        protected TextBox tbCatName = new TextBox();
        protected TextBox tbPagePath = new TextBox();
        protected CheckBox cbActive = new CheckBox();

        protected Button AddNew_BannerCat = new Button();
        protected HtmlInputButton Reset_Form = new HtmlInputButton();
        protected HtmlInputButton Back_AddNew = new HtmlInputButton();
        protected string strAllowFunctions = "bannercat_addnew";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.AddNew_BannerCat.Text = Lang["add_new"].ToString();
            this.Reset_Form.Value = Lang["reset_form"].ToString();
            this.Back_AddNew.Value = Lang["back"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.LangList();
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
        protected void AddNew_BannerCat_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertCatBanner()
        {
            bool boolActive;
            string strFunctionName = "Thêm mới danh mục banner";
            int intLang = int.Parse(this.objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = this.objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = this.objEntities.SafeString(this.tbPagePath.Text);
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Insert_Cat_Banner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@Language_ID", intLang);
            try
            {
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strCatName);
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
                Response.Redirect("Banner_Category.aspx");
            }
        }
    }
    #endregion BannerCat_AddNew
    #region BannerCat_Edit
    public class AdminBannerCatEdit : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected DropDownList DDL_Language = new DropDownList();
        protected TextBox tbCatName = new TextBox();
        protected TextBox tbPagePath = new TextBox();
        protected CheckBox cbActive = new CheckBox();

        protected Button Edit_BannerCat = new Button();
        protected HtmlInputButton ResetForm = new HtmlInputButton();
        protected HtmlInputButton Back_AddNew = new HtmlInputButton();
        protected int id = 0;
        private string strAllowFunctions = "bannercat_edit";
        private string strFunctionName = "Sửa thông tin danh mục banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            Edit_BannerCat.Text = Lang["edit"].ToString();
            ResetForm.Value = Lang["reset_form"].ToString();
            Back_AddNew.Value = Lang["back"].ToString();
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
                        this.LangList();
                        GetCatBanner();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }

        }
        protected void GetCatBanner()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_CatBanner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                this.tbCatName.Text = drd["CatName"].ToString();
                this.tbPagePath.Text = drd["PagePath"].ToString();
                this.cbActive.Checked = (bool)drd["Active"];
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
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
        protected void Edit_BannerCat_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateCatBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateCatBanner()
        {
            bool boolActive;
            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = objEntities.SafeString(this.tbPagePath.Text);
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Update_Cat_Banner", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@Language_ID", intLanguage_Id);
            try
            {
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strCatName);
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
                Response.Redirect("Banner_Category.aspx");
            }
        }
    }
    #endregion BannerCat_Edit
    #region Banner_List
    public class AdminBannerList : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected DataList DL_Banner = new DataList();
        protected Button Banner_AddNew = new Button();
        protected Button Delete_Banner = new Button();
        protected HyperLink lnkPrev = new HyperLink();
        protected HyperLink lnkNext = new HyperLink();
        protected Label ListPage = new Label();

        private string strAllowFunctions = "banner_list";
        private string strAllowFunctions_Delete = "banner_delete";
        private string strFunctionName = "Xóa banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("BANNER_Manager");
            this.Banner_AddNew.Text = this.Lang["add_new"].ToString();
            this.Delete_Banner.Text = this.Lang["delete"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.ListBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void ListBanner()
        {
            StringBuilder tbl = new StringBuilder();
            int TotalPage;
            int CurrentPage;
            int Pages;
            const int NumberPage = 5;
            SqlDataAdapter adt = new SqlDataAdapter("Get_All_Banner", this.objConn.SqlConn());
            DataSet ds = new DataSet();
            try
            {
                adt.Fill(ds);
                PagedDataSource paged = new PagedDataSource();
                paged.DataSource = ds.Tables[0].DefaultView;
                paged.AllowPaging = true;
                paged.PageSize = 8;
                TotalPage = paged.PageCount;
                if (Request.QueryString["Pages"] != null && Request.QueryString["Pages"].ToString() != "")
                {
                    Pages = Convert.ToInt32(objEntities.SafeString(Request.QueryString["Pages"].ToString()));
                }
                else
                    Pages = 0;

                if (Pages != 0)
                {
                    CurrentPage = Pages;
                    if (CurrentPage > TotalPage)
                        CurrentPage = TotalPage;
                }
                else
                    CurrentPage = 1;

                paged.CurrentPageIndex = CurrentPage - 1;
                if (!paged.IsFirstPage)
                    this.lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Pages=" + Convert.ToString(CurrentPage - 1);
                if (!paged.IsLastPage)
                    this.lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Pages=" + Convert.ToString(CurrentPage + 1);


                for (int i = 1; i <= TotalPage; i++)
                {
                    if (i == CurrentPage)
                    {
                        if ((i >= CurrentPage - NumberPage) && (i <= CurrentPage + NumberPage))
                            tbl.Append("[" + i + "]&nbsp;");
                    }
                    else
                    {
                        if ((i >= CurrentPage - NumberPage) && (i <= CurrentPage + NumberPage))
                            tbl.Append("<a href=" + Request.CurrentExecutionFilePath + "?Pages=" + i.ToString() + ">" + i + "</a>&nbsp;");
                    }
                }

                this.ListPage.Text = tbl.ToString();
                this.DL_Banner.DataSource = paged;
                this.DL_Banner.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + "Xẩy ra lỗi: " + ex.StackTrace);
            }
            finally
            {
                ds.Clear();
                adt.Dispose();
            }
        }
        public string Get_Language(int Language_Id)
        {
            if (Language_Id == 1)
                return "(VN)";
            else
                return "(EN)";
        }
        protected void Delete_Banner_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_Delete) == true)
                {
                    this.DeleteBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteBanner()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intBanner_id = Int32.Parse(item.Substring(9, item.Length - 9));
                    string FileImage = string.Empty;
                    string FilePath = string.Empty;
                    string SQL = "SELECT ImageName FROM TB_Banner_Infor WHERE Banner_ID =" + intBanner_id;
                    SqlDataReader drd;
                    SqlCommand commImg = new SqlCommand(SQL, objConn.SqlConn());
                    commImg.Connection.Open();
                    drd = commImg.ExecuteReader(CommandBehavior.CloseConnection);
                    if (drd.Read())
                    {
                        FileImage = drd["ImageName"].ToString();
                        if (FileImage != string.Empty)
                        {
                            FilePath = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathBanner() + FileImage;
                            if (File.Exists(FilePath) == true)
                                this.objEntities.Delete_Files(FilePath);
                        }
                    }
                    drd.Close();
                    drd.Dispose();

                    SqlCommand comm = new SqlCommand("Delete_Banner", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@banner_id", intBanner_id);
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
                    this.ListBanner();
                }
            }
        }
        protected void Banner_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banner_AddNew.aspx");
        }
    }
    #endregion Banner_List
    #region Banner_AddNew
    public class AdminBannerAddNew : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected DropDownList DDL_Language = new DropDownList();
        protected DropDownList DDL_TypeLink = new DropDownList();
        protected TextBox tbBannerName = new TextBox();
        protected TextBox tbBannerURL = new TextBox();
        protected TextBox tbBannerDesc = new TextBox();
        protected FileUpload fuImageName = new FileUpload();
        protected CheckBox cbActive = new CheckBox();
        protected CheckBox cbExpried = new CheckBox();
        protected ListBox LB_CatBanner = new ListBox();

        protected string strBannerStartDate = string.Empty;
        protected string strBannerEndDate = string.Empty;

        protected Button AddNew_Banner = new Button();
        protected HtmlInputButton ResetForm = new HtmlInputButton();
        protected HtmlInputButton Back_AddNew = new HtmlInputButton();

        private string strAllowFunctions = "banner_addnew";
        private string strFunctionName = "Thêm mơi banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.AddNew_Banner.Text = Lang["add_new"].ToString();
            this.ResetForm.Value = Lang["reset_form"].ToString();
            this.Back_AddNew.Value = Lang["back"].ToString();

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
                        this.LangList();
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
        protected void AddNew_Banner_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertBanner();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertBanner()
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
            string strImageName = objEntities.SafeString(this.fuImageName.PostedFile.FileName);
            long FileSize = this.fuImageName.PostedFile.ContentLength;

            if (FileSize != 0)
            {
                if (FileSize <= 500000)
                {
                    string Ext = this.fuImageName.PostedFile.ContentType;
                    if (Ext == "image/pjpeg" || Ext == "image/gif")
                    {
                        if (Ext == "image/pjpeg")
                        {
                            strDateTime = this.objEntities.FullTime() + ".jpg";
                        }
                        else
                        {
                            strDateTime = this.objEntities.FullTime() + ".gif";
                        }
                        if (strImageName != string.Empty)
                            this.fuImageName.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathBanner() + strDateTime);

                        System.Drawing.Image objImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathBanner() + strDateTime);
                        int ImgWidth = objImg.Width;
                        int ImgHeight = objImg.Height;

                        //Check Exists
                        if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathBanner() + strDateTime) == true)
                        {
                            //Ghi vao database
                            SqlCommand comm = new SqlCommand("Insert_Banner", this.objConn.SqlConn());
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Parameters.AddWithValue("@BannerName", strBannerName);
                            comm.Parameters.AddWithValue("@ImageName", strDateTime);
                            comm.Parameters.AddWithValue("@BannerSize", FileSize);
                            comm.Parameters.AddWithValue("@BannerURL", strBannerURL);
                            comm.Parameters.AddWithValue("@BannerStartDate", strBannerStartDate);
                            comm.Parameters.AddWithValue("@BannerEndDate", strBannerEndDate);
                            comm.Parameters.AddWithValue("@BannerExpried", (bool)boolExpried);
                            comm.Parameters.AddWithValue("@BannerDesc", strBannerDesc);
                            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
                            comm.Parameters.AddWithValue("@TypeLink", intTypeLink);
                            comm.Parameters.AddWithValue("@Width", ImgWidth);
                            comm.Parameters.AddWithValue("@Height", ImgHeight);
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
                                Response.Redirect("Banner_List.aspx");
                            }
                        }
                    }
                }
                else
                    Response.Write("<script language='JavaScript'>alert('" + Lang["Error_TypeImage"].ToString() + "');history.go(-1);</script>");
            }
            else
                Response.Write("<script language='JavaScript'>alert('" + Lang["Error_SizeImage"].ToString() + "');history.go(-1);</script>");

        }
    }
    #endregion Banner_AddNew
    #region Banner_View
    public class AdminBannerView : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected Button EditBanner = new Button();
        protected HtmlTableCell HPBanner_View = new HtmlTableCell();
        protected HtmlInputButton Back_Edit = new HtmlInputButton();
        int id = 0;
        private string strAllowFunctions = "banner_list,banner_edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("BANNER_Manager");
            this.EditBanner.Text = Lang["edit"].ToString();
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
                    HPBanner_View.InnerHtml = this.BannerView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        private string BannerView()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataReader drd;
            SqlCommand comdrd = new SqlCommand("Get_Banner", objConn.SqlConn());
            comdrd.CommandType = CommandType.StoredProcedure;
            comdrd.Connection.Open();
            comdrd.Parameters.AddWithValue("@Banner_Id", id);
            drd = comdrd.ExecuteReader();
            if (drd.Read())
            {
                tbl.Append(" <table width='100%' border='0' cellpadding='0' cellspacing='0'>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("            <img src='" + this.objEntities.GetPathBanner() + drd["ImageName"].ToString() + "' border='0'>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("        <table width='100%' border='0' cellpadding='3' cellspacing='2'>");
                tbl.Append("            <tr>");
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Ngày post: </font>" + drd["CreatedDate"].ToString() + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Khích thước ảnh: </font>" + drd["Width"].ToString() + "x" + drd["Height"].ToString() + "</td>");
                tbl.Append("            </tr>");
                tbl.Append("            <tr>");
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Ngày bắt đầu: </font>" + drd["BannerStartDate"].ToString() + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Ngày kết thúc: </font>" + drd["BannerEndDate"].ToString() + "</td>");
                tbl.Append("            </tr>");

                string strActive = string.Empty;
                bool boolActive = (bool)drd["Active"];
                if (boolActive)
                    strActive = "Hoạt động";
                else
                    strActive = "<font color='#FF0000'>Không hoạt động</font>";

                string strCatName = string.Empty;
                int intBanner_Id = int.Parse(drd["Banner_Id"].ToString());
                string SQL = "SELECT CB.CatName FROM TB_Cat_BannerDetail AS CBD INNER JOIN TB_Cat_Banner AS CB ON CBD.Cat_Id = CB.Cat_Id WHERE CBD.Banner_Id = " + intBanner_Id;
                if (intBanner_Id != 0)
                {
                    SqlDataReader drd_Banner;
                    SqlCommand commdrd_Banner = new SqlCommand(SQL, objConn.SqlConn());
                    commdrd_Banner.CommandType = CommandType.Text;
                    commdrd_Banner.Connection.Open();
                    drd_Banner = commdrd_Banner.ExecuteReader();
                    while (drd_Banner.Read())
                    {
                        strCatName += drd_Banner["CatName"].ToString() + ", ";
                    }
                    drd_Banner.Close();
                    commdrd_Banner.Connection.Close();
                    commdrd_Banner.Connection.Dispose();
                    if (strCatName != string.Empty)
                        strCatName = strCatName.Substring(0, strCatName.Length - 2);
                }

                tbl.Append("            <tr>");
                tbl.Append("                <td colspan='3' align='left' class='ListContent'><font style='font-weight: bold'>Trang hiển thị: </font>" + strCatName + "</td>");
                tbl.Append("            </tr>");
                tbl.Append("            <tr>");
                tbl.Append("                <td colspan='3' align='left' class='ListContent'><font style='font-weight: bold'>Trạng thái: </font>" + strActive + "</td>");
                tbl.Append("            </tr>");
                tbl.Append("        </table>");
                tbl.Append("        </td>");
                tbl.Append("    </tr>");
                tbl.Append(" </table>");
                comdrd.Connection.Close();
                comdrd.Connection.Dispose();
            }
            return tbl.ToString();
        }
        protected void EditBanner_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banner_Edit.aspx?id=" + id);
        }
    }
    #endregion Banner_View
    #region Banner_Edit
    public class AdminBannerEdit : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected string strBannerStartDate = string.Empty;
        protected string strBannerEndDate = string.Empty;

        protected DropDownList DDL_Language = new DropDownList();
        protected DropDownList DDL_TypeLink = new DropDownList();
        protected TextBox tbBannerName = new TextBox();
        protected TextBox tbBannerURL = new TextBox();
        protected TextBox tbBannerDesc = new TextBox();
        protected FileUpload fuImageName = new FileUpload();
        protected CheckBox cbActive = new CheckBox();
        protected CheckBox cbExpried = new CheckBox();
        protected ListBox LB_CatBanner = new ListBox();
        protected Image ImgFile = new Image();

        protected Button Edit_Banner = new Button();
        protected HtmlInputButton Reset_Form = new HtmlInputButton();
        protected HtmlInputButton Back_Edit = new HtmlInputButton();

        protected int id;
        protected string strAllowFunctions = "banner_list,banner_edit";
        private string strFunctionName = "Sửa thông tin banner";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("BANNER_Manager");
            this.Edit_Banner.Text = Lang["edit"].ToString();
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
        protected void Edit_Banner_Click(object sender, EventArgs e)
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
    #endregion Banner_Edit
}
