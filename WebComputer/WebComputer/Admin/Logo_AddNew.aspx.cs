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
    public partial class Logo_AddNew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();

        private string strLogoStartDate, strLogoEndDate;
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

            string strLogoName = this.tbLogoName.Text;
            string strLogoURL = this.tbLogoURL.Text;
            string strLogoDesc = this.tbLogoDesc.Text;

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
}
