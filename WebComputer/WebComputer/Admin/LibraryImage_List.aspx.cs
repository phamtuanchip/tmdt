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
    public partial class LibraryImage_List : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        public Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "libraryimage_list";
        private string strAllowFunctions_delete = "libraryimage_delete";
        private string strFunctionName = "Xóa ảnh";
        private int id = 0;
        private string strSearch = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (id == 0 || strSearch == "")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    id = int.Parse(objEntities.SafeString(Request.QueryString["id"].ToString()));
                }
                if (txtSearch.Text.Length > 0)
                {
                    if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                    {
                        strSearch = objEntities.SafeString(Request.QueryString["strSearch"].ToString());
                    }
                }
            }

            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            this.LibraryImage_AddNew.Text = Lang["add_new"].ToString();
            this.LibraryImage_Delete.Text = Lang["delete"].ToString();


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
                        GetLibraryCatImages();
                        GetLibraryImages();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GetLibraryImages()
        {
            StringBuilder tbl = new StringBuilder();
            int TotalPage;
            int CurrentPage;
            int Pages;
            const int NumberPage = 5;
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Search_LibraryImage", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            comm.Parameters.AddWithValue("@Cat_Id", id);
            comm.Parameters.AddWithValue("@strSearch", strSearch);
            adt.SelectCommand = comm;
            DataSet ds = new DataSet();
            try
            {
                adt.Fill(ds);
                PagedDataSource paged = new PagedDataSource();
                paged.DataSource = ds.Tables[0].DefaultView;
                paged.AllowPaging = true;
                paged.PageSize = 20;
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
                    this.lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Pages=" + Convert.ToString(CurrentPage - 1) + "&id=" + id + "&strSearch=" + strSearch;
                if (!paged.IsLastPage)
                    this.lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Pages=" + Convert.ToString(CurrentPage + 1) + "&id=" + id + "&strSearch=" + strSearch;


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
                            tbl.Append("<a href=" + Request.CurrentExecutionFilePath + "?Pages=" + i.ToString() + "&id=" + id + "&strSearch=" + strSearch + ">" + i + "</a>&nbsp;");
                    }
                }

                this.ListPage.Text = tbl.ToString();
                this.DL_Images.DataSource = paged;
                this.DL_Images.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                ds.Clear();
                adt.Dispose();
                comm.Connection.Close();
                comm.Connection.Dispose();
            }
        }
        protected void GetLibraryCatImages()
        {
            string SQL = "select * from TB_Cat_Images order by CatOrder";
            this.DDL_CatId.Items.Add(new ListItem(" -- Hãy chọn danh mục ảnh -- ", ""));
            for (int i = 0; i < objBusinessLogic.CreateDataTable(SQL).Rows.Count; i++)
            {
                this.DDL_CatId.Items.Add(new ListItem(objBusinessLogic.CreateDataTable(SQL).Rows[i]["CatName"].ToString(), objBusinessLogic.CreateDataTable(SQL).Rows[i]["Cat_Id"].ToString()));
            }
        }
        protected void LibraryImage_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("LibraryImage_AddNew.aspx");
        }
        protected void LibraryImage_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions_delete) == true)
                {
            this.DeleteLibraryImage();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteLibraryImage()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intID = int.Parse(item.Substring(9, item.Length - 9));
                        //=============Delete file=====================================
                        string SQL = "SELECT PhotoID FROM TB_Images WHERE Id =" + intID;
                        SqlDataReader drd;
                        SqlCommand comm_drd = new SqlCommand(SQL, this.objConn.SqlConn());
                        comm_drd.Connection.Open();
                        drd = comm_drd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (drd.Read())
                        {
                            string strPhotoID = drd["PhotoID"].ToString() + ".jpg";
                            string strPhotoID_T = drd["PhotoID"].ToString() + "_T.jpg";
                            string strCheckImg = drd["PhotoID"].ToString() + ".jpg";
                            if (strPhotoID != string.Empty)
                            {
                                string strPathPhotoID = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strPhotoID;
                                string strPathPhotoID_T = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strPhotoID_T;
                                string strCheckPath = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strCheckImg;
                                if (File.Exists(strCheckPath) == true)
                                {
                                    objEntities.Delete_Files(strPathPhotoID);
                                    objEntities.Delete_Files(strPathPhotoID_T);
                                }
                            }
                        }
                        drd.Close();
                        drd.Dispose();
                        comm_drd.Connection.Close();
                        comm_drd.Connection.Dispose();
                        //===========Edn Delete file===================================
                        //===========Delete Database===================================
                        SqlCommand comm = new SqlCommand("Delete_Image", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@ID", intID);
                        try
                        {
                            comm.Connection.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ce)
                        {
                            this.lblErro.Text = ce.ToString();
                           
                        }
                        finally
                        {
                            comm.Connection.Close();
                            comm.Connection.Dispose();
                        }
                        this.objConn.WriteActionLog(this.strFunctionName, Session["AdminID"].ToString(), string.Empty);
                        //===========End Delete Database===============================
                    }
                }
            }
            Response.Redirect("LibraryImage_List.aspx");
        }
        protected void bntSearch_Click(object sender, EventArgs e)
        {
            id = 0;
            strSearch = "";
            if (this.DDL_CatId.SelectedValue != "")
                id = int.Parse(objEntities.SafeString(this.DDL_CatId.SelectedValue));
            strSearch = objEntities.SafeString(this.txtSearch.Text);

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    GetLibraryImages();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
    }
}
