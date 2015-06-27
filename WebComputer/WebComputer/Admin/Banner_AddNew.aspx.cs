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
    public partial class Banner_AddNew : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        protected string strBannerStartDate = string.Empty;
        protected string strBannerEndDate = string.Empty;

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
}
