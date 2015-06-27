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
    public partial class Logo_Edit : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        public string strLogoStartDate, strLogoEndDate;
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
        //protected void CompanyList()
        //{
        //    string SQL = "SELECT * FROM TB_Company ORDER BY CompanyName";
        //    this.DDL_ComId.Items.Add(new ListItem(" Hãy chọn công ty ", ""));
        //    for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
        //    {
        //        this.DDL_ComId.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["CompanyName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Com_Id"].ToString()));
        //    }
        //}
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
                //this.DDL_ComId.SelectedValue = drd["Com_Id"].ToString();
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



    }

