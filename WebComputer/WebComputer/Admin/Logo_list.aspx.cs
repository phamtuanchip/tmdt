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
    public partial class Logo_list : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "logo_list";
        private string strAllowFunctions_Delete = "logo_delete";
        private string strFunctionName = "Xóa logo";

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
}
