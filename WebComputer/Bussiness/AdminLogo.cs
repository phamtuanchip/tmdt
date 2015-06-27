using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Entity;  

namespace Bussiness
{
    public class AdminLogo
    {
    }
    #region Logo_Category
    public partial class AdminLogoCategory : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected System.Web.UI.WebControls.GridView GV_LogoCategory = new System.Web.UI.WebControls.GridView();
        protected System.Web.UI.WebControls.Button Submit_CatLogo_AddNew = new System.Web.UI.WebControls.Button();
        protected System.Web.UI.WebControls.Button Submit_CatLogo_Delete = new System.Web.UI.WebControls.Button();

        private string strAllowFunctions = "logocat_list";
        private string strAllowFunctions_Delete = "Logocat_delete";
        private string strFunctionName = "Xóa danh mục logo";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            this.Submit_CatLogo_AddNew.Text = Lang["add_new"].ToString();
            this.Submit_CatLogo_Delete.Text = Lang["delete"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.ListCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        public void ListCatLogo()
        {
            this.GV_LogoCategory.DataSource = this.objBusinessLogic.Execute_Store("Get_Category_Logo");
            this.GV_LogoCategory.DataBind();
        }
        protected void Submit_CatLogo_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_Delete) == true)
                {
                    this.DeleteCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void Submit_CatLogo_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogoCat_AddNew.aspx");
        }
        public void DeleteCatLogo()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intCatLogo_id = Int32.Parse(item.Substring(9, item.Length - 9));
                    SqlCommand comm = new SqlCommand("Delete_Cat_Logo", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Cat_Id", intCatLogo_id);
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
                    this.ListCatLogo();
                }
            }
        }
    }
    #endregion Logo_Category
    #region LogoCat_Addnew
    public partial class AdminLogoCatAddNew : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        private string strAllowFunctions = "logocat_addnew";
        protected DropDownList DDL_Language = new DropDownList();
        protected TextBox tbCatName = new TextBox();
        protected TextBox tbPagePath = new TextBox();
        protected TextBox tbLBNumber = new TextBox();
        protected RadioButton RB_LBRandom1 = new RadioButton();
        protected RadioButton RB_LBRandom0 = new RadioButton();
        protected CheckBox cbActive = new CheckBox();

        protected Button AddNewCatLogo = new Button();
        protected HtmlInputButton ResetForm = new HtmlInputButton();
        protected HtmlInputButton Back_AddNew = new HtmlInputButton();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            AddNewCatLogo.Text = Lang["add_new"].ToString();
            ResetForm.Value = Lang["reset_form"].ToString();
            Back_AddNew.Value = Lang["back"].ToString();

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
        protected void AddNewCatLogo_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertCatLogo()
        {
            bool boolLBRandom;
            bool boolActive;
            string strFunctionName = "Thêm mới danh mục logo";
            int intLang = int.Parse(this.objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = this.objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = this.objEntities.SafeString(this.tbPagePath.Text);
            string strLBNumber = this.objEntities.SafeString(this.tbLBNumber.Text);
            if (this.RB_LBRandom1.Checked)
                boolLBRandom = true;
            else
                boolLBRandom = false;
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Insert_Cat_Logo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@LBRandom", (bool)boolLBRandom);
            comm.Parameters.AddWithValue("@LBNumber", int.Parse(strLBNumber));
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
                Response.Redirect("Logo_Category.aspx");
            }
        }
    }
    #endregion LogoCat_Addnew
    #region LogoCat_Edit
    public partial class AdminLogoEdit : System.Web.UI.Page
    {

        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        protected DropDownList DDL_Language = new DropDownList();
        protected TextBox tbCatName = new TextBox();
        protected TextBox tbPagePath = new TextBox();
        protected TextBox tbLBNumber = new TextBox();
        protected RadioButton RB_LBRandom1 = new RadioButton();
        protected RadioButton RB_LBRandom0 = new RadioButton();
        protected CheckBox cbActive = new CheckBox();

        protected Button EditCatLogo = new Button();
        protected HtmlInputButton ResetForm = new HtmlInputButton();
        protected HtmlInputButton Back_AddNew = new HtmlInputButton();

        protected int id = 0;
        private string strAllowFunctions = "logocat_edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LOGO_Manager");
            EditCatLogo.Text = Lang["edit"].ToString();
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
                        this.GetCatLogo();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GetCatLogo()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_CatLogo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_Language.SelectedValue = drd["language_id"].ToString();
                this.tbCatName.Text = drd["CatName"].ToString();
                this.tbPagePath.Text = drd["PagePath"].ToString();
                this.tbLBNumber.Text = drd["LBNumber"].ToString();
                this.cbActive.Checked = (bool)drd["Active"];
                if ((bool)drd["LBRandom"] == true)
                    this.RB_LBRandom1.Checked = true;
                else
                    this.RB_LBRandom0.Checked = true;
            }
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
        protected void EditCatLogo_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateCatLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateCatLogo()
        {

            string strFunctionName = "Sửa thông tin danh mục logo";
            bool boolActive;
            bool boolLBRandom;

            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strCatName = objEntities.SafeString(this.tbCatName.Text);
            string strPagePath = objEntities.SafeString(this.tbPagePath.Text);
            int intLBNumber = int.Parse(objEntities.SafeString(this.tbLBNumber.Text));
            if (this.RB_LBRandom1.Checked)
                boolLBRandom = true;
            else
                boolLBRandom = false;
            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;

            SqlCommand comm = new SqlCommand("Update_Cat_Logo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Parameters.AddWithValue("@CatName", strCatName);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            comm.Parameters.AddWithValue("@PagePath", strPagePath);
            comm.Parameters.AddWithValue("@LBRandom", (bool)boolLBRandom);
            comm.Parameters.AddWithValue("@LBNumber", intLBNumber);
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
                Response.Redirect("Logo_Category.aspx");
            }
        }
    }
    #endregion LogoCat_Edit
    #region Logo_List
    public partial class AdminLogoList : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        private string strAllowFunctions = "logo_list";
        private string strAllowFunctions_Delete = "logo_delete";
        private string strFunctionName = "Xóa logo";

        protected DataList DL_Logo = new DataList();
        protected Button btDeleteLogo = new Button();
        protected HyperLink lnkPrev = new HyperLink();
        protected HyperLink lnkNext = new HyperLink();
        protected Label ListPage = new Label();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            this.btDeleteLogo.Text = this.Lang["delete"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.ListLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void ListLogo()
        {
            StringBuilder tbl = new StringBuilder();
            int TotalPage;
            int CurrentPage;
            int Pages;
            const int NumberPage = 5;
            SqlDataAdapter adt = new SqlDataAdapter("Get_All_Logo", this.objConn.SqlConn());
            DataSet ds = new DataSet();
            try
            {
                adt.Fill(ds);
                PagedDataSource paged = new PagedDataSource();
                paged.DataSource = ds.Tables[0].DefaultView;
                paged.AllowPaging = true;
                paged.PageSize = 12;
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
                this.DL_Logo.DataSource = paged;
                this.DL_Logo.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                ds.Clear();
                adt.Dispose();
            }
        }
        protected string GetLanguage(int Language_Id)
        {
            if (Language_Id == 1)
                return "(VN)";
            else
                return "(EN)";
        }
        protected void btDeleteLogo_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_Delete) == true)
                {
                    this.DeleteLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteLogo()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intLogo_id = Int32.Parse(item.Substring(9, item.Length - 9));
                    string FileImage = string.Empty;
                    string FilePath = string.Empty;
                    string SQL = "SELECT ImageName FROM TB_Logo_Infor WHERE Logo_Id =" + intLogo_id;
                    SqlDataReader drd;
                    SqlCommand commImg = new SqlCommand(SQL, objConn.SqlConn());
                    commImg.Connection.Open();
                    drd = commImg.ExecuteReader(CommandBehavior.CloseConnection);
                    if (drd.Read())
                    {
                        FileImage = drd["ImageName"].ToString();
                        if (FileImage != string.Empty)
                        {
                            FilePath = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLogo() + FileImage;
                            if (File.Exists(FilePath) == true)
                                this.objEntities.Delete_Files(FilePath);
                        }
                    }
                    drd.Close();
                    drd.Dispose();

                    SqlCommand comm = new SqlCommand("Delete_Logo", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@logo_id", intLogo_id);
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
                    this.ListLogo();
                }
            }
        }
    }
    #endregion Logo_List
    #region Logo_Addnew
    public partial class AdminLogoAddNew : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        private string strLogoStartDate, strLogoEndDate;

        protected DropDownList DDL_Language = new DropDownList();
        protected DropDownList DDL_TypeLogo = new DropDownList();
        protected DropDownList DDL_TypeLink = new DropDownList();
        protected DropDownList DDL_Location = new DropDownList();
        protected DropDownList DDL_ComId = new DropDownList();
        protected TextBox tbLogoName = new TextBox();
        protected TextBox tbLogoURL = new TextBox();
        protected TextBox tbLogoDesc = new TextBox();
        protected FileUpload fuImageName = new FileUpload();
        protected CheckBox cbActive = new CheckBox();
        protected CheckBox cbExpried = new CheckBox();
        protected ListBox LB_CatLogo = new ListBox();
        protected TextBox LogoStartDate = new TextBox();
        protected TextBox LogoEndDate = new TextBox();

        protected Button AddNewLogo = new System.Web.UI.WebControls.Button();
        protected HtmlInputButton ResetForm = new HtmlInputButton();
        protected HtmlInputButton Back_AddNew = new HtmlInputButton();

        private string strAllowFunctions = "logo_addnew";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            this.AddNewLogo.Text = Lang["add_new"].ToString();
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
                        //this.CompanyList();
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
        //protected void CompanyList()
        //{
        //    string SQL = "SELECT * FROM TB_Company ORDER BY CompanyName";
        //    this.DDL_ComId.Items.Add(new ListItem(" Hãy chọn công ty ", ""));
        //    for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
        //    {
        //        this.DDL_ComId.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["CompanyName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Com_Id"].ToString()));
        //    }
        //}
        protected void DDL_Language_SelectIndexChanged(object sender, EventArgs e)
        {
            //CatLogo
            if (this.DDL_Language.SelectedItem.Value.ToString() == "")
                this.LB_CatLogo.Visible = false;
            else
            {
                this.LB_CatLogo.Visible = true;
                string SQL = string.Empty;
                SQL = "SELECT Cat_Id, CatName FROM TB_Cat_Logo WHERE Language_Id =" + System.Int32.Parse(this.DDL_Language.SelectedValue);
                DataTable dataTable = new DataTable();
                dataTable = this.objBusinessLogic.CreateDataTable(SQL);
                this.LB_CatLogo.Items.Clear();
                this.LB_CatLogo.Items.Add(new ListItem(" -- Chọn danh mục logo -- ", ""));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.LB_CatLogo.Items.Add(new ListItem(dataTable.Rows[i]["CatName"].ToString(), dataTable.Rows[i]["Cat_Id"].ToString()));
                }
            }
        }
        protected void AddNewLogo_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.InsertLogo();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertLogo()
        {
            bool boolActive;
            bool boolExpried;
            string strDateTime = string.Empty;
            string strCat_Id = string.Empty;
            string strFunctionName = "Thêm mơi logo";

            int inLanguage_Id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            int intTypeLogo = int.Parse(objEntities.SafeString(DDL_TypeLogo.SelectedValue));
            int intTypeLink = int.Parse(objEntities.SafeString(DDL_TypeLink.SelectedValue));
            int intLocation = int.Parse(objEntities.SafeString(DDL_Location.SelectedValue));
            //int intCom_Id = int.Parse(objEntities.SafeString(DDL_ComId.SelectedValue));

            string strLogoName = objEntities.SafeString(this.tbLogoName.Text);
            string strLogoURL = objEntities.SafeString(this.tbLogoURL.Text);
            string strLogoDesc = objEntities.SafeString(this.tbLogoDesc.Text);

            if (HttpContext.Current.Request.Form["FromDatePublic"] != null)
            {
                strLogoStartDate = HttpContext.Current.Request.Form["FromDatePublic"].ToString();
            }
            if (HttpContext.Current.Request.Form["EndDatePublic"] != null)
            {
                strLogoEndDate = HttpContext.Current.Request.Form["EndDatePublic"].ToString();
            }

            string strCatLogo = objEntities.SafeString(this.LB_CatLogo.Text);

            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;
            if (this.cbExpried.Checked)
                boolExpried = true;
            else
                boolExpried = false;

            for (int i = 0; i < LB_CatLogo.Items.Count; i++)
            {
                if (LB_CatLogo.Items[i].Selected)
                    strCat_Id += LB_CatLogo.Items[i].Value + ", ";
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
                            this.fuImageName.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLogo() + strDateTime);

                        System.Drawing.Image objImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLogo() + strDateTime);
                        int ImgWidth = objImg.Width;
                        int ImgHeight = objImg.Height;

                        //Check Exists
                        if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLogo() + strDateTime) == true)
                        {
                            //Ghi vao database
                            SqlCommand comm = new SqlCommand("Insert_Logo", this.objConn.SqlConn());
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Parameters.AddWithValue("@LogoName", strLogoName);
                            comm.Parameters.AddWithValue("@ImageName", strDateTime);
                            comm.Parameters.AddWithValue("@LogoSize", FileSize);
                            comm.Parameters.AddWithValue("@LogoURL", strLogoURL);
                            comm.Parameters.AddWithValue("@LogoStartDate", strLogoStartDate);
                            comm.Parameters.AddWithValue("@LogoEndDate", strLogoEndDate);
                            comm.Parameters.AddWithValue("@LogoExpried", (bool)boolExpried);
                            comm.Parameters.AddWithValue("@LogoDesc", strLogoDesc);
                            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
                            comm.Parameters.AddWithValue("@TypeLogo", intTypeLogo);
                            comm.Parameters.AddWithValue("@TypeLink", intTypeLink);
                            comm.Parameters.AddWithValue("@Width", ImgWidth);
                            comm.Parameters.AddWithValue("@Height", ImgHeight);
                            comm.Parameters.AddWithValue("@LogoLocation", intLocation);
                            //comm.Parameters.AddWithValue("@Com_Id", intCom_Id);
                            comm.Parameters.AddWithValue("@Language_Id", inLanguage_Id);
                            comm.Parameters.AddWithValue("@strCat_Id", strCat_Id);
                            try
                            {
                                comm.Connection.Open();
                                if (comm.ExecuteNonQuery() == -1)
                                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strLogoName);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message.ToString());
                            }
                            finally
                            {
                                comm.Connection.Close();
                                comm.Connection.Dispose();
                                Response.Redirect("Logo_list.aspx");
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
    #endregion Logo_Addnew
    #region Logo_View
    public partial class AdminLogoView : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        private string strAllowFunctions = "logo_list,logo_edit";

        private StringBuilder tbl = new StringBuilder();
        protected HtmlTableCell HPLogo_View = new HtmlTableCell();
        protected Button EditLogo = new Button();
        protected HtmlInputButton Back_Edit = new HtmlInputButton();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Lang = objEntities.GetLanguage("LOGO_Manager");
            this.EditLogo.Text = Lang["edit"].ToString();
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
                    HPLogo_View.InnerHtml = this.LogoView();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        private string LogoView()
        {
            SqlDataReader drd;
            SqlCommand comdrd = new SqlCommand("Get_Logo", objConn.SqlConn());
            comdrd.CommandType = CommandType.StoredProcedure;
            comdrd.Connection.Open();
            comdrd.Parameters.AddWithValue("@Logo_Id", id);
            drd = comdrd.ExecuteReader();
            if (drd.Read())
            {
                tbl.Append(" <table width='100%' border='0' cellpadding='0' cellspacing='0'>");
                tbl.Append("    <tr>");
                tbl.Append("        <td>");
                tbl.Append("            <img src='" + this.objEntities.GetPathLogo() + drd["ImageName"].ToString() + "' border='0'>");
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
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Ngày bắt đầu: </font>" + drd["LogoStartDate"].ToString() + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Ngày kết thúc: </font>" + drd["LogoEndDate"].ToString() + "</td>");
                tbl.Append("            </tr>");

                string strLocation = string.Empty;
                string strLogoType = string.Empty;
                int intLocation = int.Parse(drd["LogoLocation"].ToString());
                if (intLocation == 0)
                    strLocation = "Menu trái";
                else
                    strLocation = "Menu phải";
                int intTypeLogo = int.Parse(drd["TypeLogo"].ToString());
                if (intTypeLogo == 1)
                    strLogoType = "Quảng cáo";
                else
                    strLogoType = "Công ty thành viên";
                string strActive = string.Empty;
                bool boolActive = (bool)drd["Active"];
                if (boolActive)
                    strActive = "Hoạt động";
                else
                    strActive = "<font color='#FF0000'>Không hoạt động</font>";

                tbl.Append("            <tr>");
                tbl.Append("                <td width='49%' align='left' class='ListContent'><font style='font-weight: bold'>Vị trí đặt logo: </font>" + strLocation + "</td>");
                tbl.Append("                <td width='2%'></td>");
                tbl.Append("                <td align='left' class='ListContent'><font style='font-weight: bold'>Kiểu logo quảng cáo: </font>" + strLogoType + "</td>");
                tbl.Append("            </tr>");

                string strCatName = string.Empty;
                int intLogo_Id = int.Parse(drd["Logo_Id"].ToString());
                string SQL = "SELECT CL.CatName FROM TB_Cat_LogoDetail AS CLD INNER JOIN TB_Cat_Logo AS CL ON CLD.Cat_Id = CL.Cat_Id WHERE CLD.Logo_Id = " + intLogo_Id;
                if (intLogo_Id != 0)
                {
                    SqlDataReader drd_Logo;
                    SqlCommand commdrd_Logo = new SqlCommand(SQL, objConn.SqlConn());
                    commdrd_Logo.CommandType = CommandType.Text;
                    commdrd_Logo.Connection.Open();
                    drd_Logo = commdrd_Logo.ExecuteReader();
                    while (drd_Logo.Read())
                    {
                        strCatName += drd_Logo["CatName"].ToString() + ", ";
                    }
                    drd_Logo.Close();
                    commdrd_Logo.Connection.Close();
                    commdrd_Logo.Connection.Dispose();
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
        protected void EditLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logo_Edit.aspx?id=" + id);
        }

    }
    #endregion logo_View
    #region Logo_Edit
    public class Admin_Logo_Edit : System.Web.UI.Page
    {
        private DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entities();
        private BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();

        public string strLogoStartDate, strLogoEndDate;

        protected DropDownList DDL_Language = new DropDownList();
        protected DropDownList DDL_TypeLogo = new DropDownList();
        protected DropDownList DDL_TypeLink = new DropDownList();
        protected DropDownList DDL_Location = new DropDownList();
        protected DropDownList DDL_ComId = new DropDownList();
        protected TextBox tbLogoName = new TextBox();
        protected TextBox tbLogoURL = new TextBox();
        protected TextBox tbLogoDesc = new TextBox();
        protected Image ImgFile = new Image();
        protected CheckBox cbActive = new CheckBox();
        protected CheckBox cbExpried = new CheckBox();
        protected ListBox LB_CatLogo = new ListBox();
        protected TextBox LogoStartDate = new TextBox();
        protected TextBox LogoEndDate = new TextBox();

        protected Button Edit_Logo = new Button();
        protected HtmlInputButton ResetForm = new HtmlInputButton();
        protected HtmlInputButton Back_Edit = new HtmlInputButton();

        protected int id;
        protected string strAllowFunctions = "logo_list,logo_edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LOGO_Manager");
            this.Edit_Logo.Text = Lang["edit"].ToString();
            this.ResetForm.Value = Lang["reset_form"].ToString();
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
                        //this.CompanyList();
                        this.EditListLogo();
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
        //protected void CompanyList()
        //{
        //    string SQL = "SELECT * FROM TB_Company ORDER BY CompanyName";
        //    this.DDL_ComId.Items.Add(new ListItem(" Hãy chọn công ty ", ""));
        //    for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
        //    {
        //        this.DDL_ComId.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["CompanyName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Com_Id"].ToString()));
        //    }
        //}
        protected void DDL_Language_SelectIndexChanged(object sender, EventArgs e)
        {
            //CatLogo
            if (this.DDL_Language.SelectedItem.Value.ToString() == "")
                this.LB_CatLogo.Visible = false;
            else
            {
                this.LB_CatLogo.Visible = true;
                string SQL = string.Empty;
                SQL = "SELECT Cat_Id, CatName FROM TB_Cat_Logo WHERE Language_Id =" + System.Int32.Parse(this.DDL_Language.SelectedValue);
                DataTable dataTable = new DataTable();
                dataTable = this.objBusinessLogic.CreateDataTable(SQL);
                this.LB_CatLogo.Items.Clear();
                this.LB_CatLogo.Items.Add(new ListItem(" -- Chọn danh mục logo -- ", ""));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.LB_CatLogo.Items.Add(new ListItem(dataTable.Rows[i]["CatName"].ToString(), dataTable.Rows[i]["Cat_Id"].ToString()));
                }
            }
        }
        protected void EditListLogo()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Logo", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Logo_Id", id);
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_TypeLink.SelectedValue = drd["TypeLink"].ToString();
                this.DDL_TypeLogo.SelectedValue = drd["TypeLogo"].ToString();
                this.DDL_Location.SelectedValue = drd["LogoLocation"].ToString();
                this.DDL_ComId.SelectedValue = drd["Com_Id"].ToString();
                this.tbLogoName.Text = drd["LogoName"].ToString();
                this.tbLogoURL.Text = drd["LogoURL"].ToString();
                this.tbLogoDesc.Text = drd["LogoDesc"].ToString();
                strLogoStartDate = drd["LogoStartDate"].ToString();
                strLogoEndDate = drd["LogoEndDate"].ToString();
                this.ImgFile.ImageUrl = this.objEntities.GetPathLogo() + drd["ImageName"].ToString();
                this.DDL_Language.SelectedValue = drd["Language_Id"].ToString();

                if ((bool)drd["Active"])
                    this.cbActive.Checked = (bool)drd["Active"];
                else
                    this.cbActive.Checked = (bool)drd["Active"];
                if ((bool)drd["LogoExpried"])
                    this.cbExpried.Checked = (bool)drd["LogoExpried"];
                else
                    this.cbExpried.Checked = (bool)drd["LogoExpried"];
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
            this.LB_CatLogo.Visible = true;
            string SQL = string.Empty;
            SQL = "SELECT Cat_Id, CatName FROM TB_Cat_Logo WHERE Language_Id =" + Lang_ID;
            DataTable dataTable = new DataTable();
            dataTable = this.objBusinessLogic.CreateDataTable(SQL);
            this.LB_CatLogo.Items.Clear();
            this.LB_CatLogo.Items.Add(new ListItem(" -- Chọn danh mục logo -- ", ""));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                this.LB_CatLogo.Items.Add(new ListItem(dataTable.Rows[i]["CatName"].ToString(), dataTable.Rows[i]["Cat_Id"].ToString()));
            }
            //============================================//
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void Edit_Logo_Click(object sender, EventArgs e)
        {
            bool boolActive;
            bool boolExpried;
            string strDateTime = string.Empty;
            string strCat_Id = string.Empty;
            string strFunctionName = "Sửa thông tin logo";

            int inLanguage_Id = int.Parse(objEntities.SafeString(DDL_Language.SelectedValue));
            int intTypeLogo = int.Parse(objEntities.SafeString(DDL_TypeLogo.SelectedValue));
            int intTypeLink = int.Parse(objEntities.SafeString(DDL_TypeLink.SelectedValue));
            int intLocation = int.Parse(objEntities.SafeString(DDL_Location.SelectedValue));
            //int intCom_Id = int.Parse(objEntities.SafeString(DDL_ComId.SelectedValue));

            string strLogoName = objEntities.SafeString(this.tbLogoName.Text);
            string strLogoURL = objEntities.SafeString(this.tbLogoURL.Text);
            string strLogoDesc = objEntities.SafeString(this.tbLogoDesc.Text);

            if (HttpContext.Current.Request.Form["FromDatePublic"] != null)
            {
                strLogoStartDate = HttpContext.Current.Request.Form["FromDatePublic"].ToString();
            }
            if (HttpContext.Current.Request.Form["EndDatePublic"] != null)
            {
                strLogoEndDate = HttpContext.Current.Request.Form["EndDatePublic"].ToString();
            }

            string strCatLogo = objEntities.SafeString(this.LB_CatLogo.Text);

            if (this.cbActive.Checked)
                boolActive = true;
            else
                boolActive = false;
            if (this.cbExpried.Checked)
                boolExpried = true;
            else
                boolExpried = false;

            for (int i = 0; i < LB_CatLogo.Items.Count; i++)
            {
                if (LB_CatLogo.Items[i].Selected)
                    strCat_Id += LB_CatLogo.Items[i].Value + ", ";
            }
            if (strCat_Id != string.Empty)
                strCat_Id = strCat_Id.Substring(0, strCat_Id.Length - 2);

            SqlCommand comm = new SqlCommand("Update_Logo", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Logo_Id", id);
            comm.Parameters.AddWithValue("@LogoName", strLogoName);
            comm.Parameters.AddWithValue("@LogoURL", strLogoURL);
            comm.Parameters.AddWithValue("@LogoStartDate", strLogoStartDate);
            comm.Parameters.AddWithValue("@LogoEndDate", strLogoEndDate);
            comm.Parameters.AddWithValue("@LogoExpried", boolExpried);
            comm.Parameters.AddWithValue("@LogoDesc", strLogoDesc);
            comm.Parameters.AddWithValue("@Active", boolActive);
            comm.Parameters.AddWithValue("@TypeLogo", intTypeLogo);
            comm.Parameters.AddWithValue("@TypeLink", intTypeLink);
            comm.Parameters.AddWithValue("@LogoLocation", intLocation);
            //comm.Parameters.AddWithValue("@Com_Id", intCom_Id);
            comm.Parameters.AddWithValue("@Language_Id", inLanguage_Id);
            comm.Parameters.AddWithValue("@strCat_Id", strCat_Id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strLogoName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Logo_list.aspx");
            }
        }
    }
    #endregion Logo_Edit
}
