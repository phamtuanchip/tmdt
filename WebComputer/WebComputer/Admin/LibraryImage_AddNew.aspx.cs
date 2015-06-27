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
    public partial class LibraryImage_AddNew : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "libraryimage_addnew";
        private string strFunctionName = "Thêm mới ảnh";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            LibraryImages_AddNew.Text = Lang["add_new"].ToString();
            Reset_Form.Value = Lang["reset"].ToString();
            Back_AddNew.Value = Lang["back"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    GetLibraryCatImages();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
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
        protected void LibraryImages_AddNew_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    InsertLibraryImage();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertLibraryImage()
        {
            bool Flag_Upload = false;
            string strDateTime = string.Empty;
            string strDateTimeImg = string.Empty;
            int MaxWidth = 0;
            int WidthToResize = 0;
            int ImgWidth = 0;
            int ImgHieght = 0;
            int ImgHeight_Thumb = 0;
            string strNewFileName = string.Empty;
            string strPathToSave = string.Empty;
            int intCat_Id = int.Parse(objEntities.SafeString(DDL_CatId.SelectedValue));
            string strDesc = objEntities.SafeString(txtDesc.Text);
            string strFileImg = objEntities.SafeString(fuImg.PostedFile.FileName);
            long FileSize = fuImg.PostedFile.ContentLength;
            if ((FileSize != 0) && (FileSize <= 500000))
            {
                string Ext = this.fuImg.PostedFile.ContentType;
                if (Ext == "image/pjpeg")
                {
                    strDateTime = this.objEntities.FullTime();
                    if (strFileImg != string.Empty)
                    {
                        this.fuImg.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strDateTime + ".jpg");
                        strPathToSave = HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage();
                        MaxWidth = objEntities.GetMaxWidthImages();
                        WidthToResize = objEntities.GetWidthToResize();
                        Flag_Upload = objEntities.UploadImg(strDateTime, strPathToSave, WidthToResize, MaxWidth);
                        if (Flag_Upload)
                        {
                            System.Drawing.Image objImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strDateTime + ".jpg");
                            ImgWidth = objImg.Width;
                            ImgHieght = objImg.Height;
                            System.Drawing.Image objImg_Thumb = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("//") + objEntities.GetVirtualPathLibraryImage() + strDateTime + "_T.jpg");
                            ImgHeight_Thumb = objImg_Thumb.Height;
                        }
                    }

                    if (Flag_Upload)
                    {
                        //Ghi vao database
                        SqlCommand comm = new SqlCommand("Insert_LibraryImage", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@PhotoID", strDateTime);
                        comm.Parameters.AddWithValue("@Description", strDesc);
                        comm.Parameters.AddWithValue("@Thumb_W", WidthToResize);
                        comm.Parameters.AddWithValue("@Thumb_H", ImgHeight_Thumb);
                        comm.Parameters.AddWithValue("@Full_Size", FileSize);
                        comm.Parameters.AddWithValue("@Full_W", ImgWidth);
                        comm.Parameters.AddWithValue("@Full_H", ImgHieght);
                        comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
                        try
                        {
                            comm.Connection.Open();
                            if (comm.ExecuteNonQuery() == -1)
                                this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strDateTime);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }
                        finally
                        {
                            comm.Connection.Close();
                            comm.Connection.Dispose();
                            Response.Redirect("LibraryImage_List.aspx");
                        }
                    }
                    else
                        Response.Write("<script language='JavaScript'>alert('" + Lang["Error_ImgUpload"].ToString() + WidthToResize + Lang["to"].ToString() + MaxWidth + Lang["pixels"].ToString() + "');history.go(-1);</script>");
                }
            }
            else
                Response.Write("<script language='JavaScript'>alert('" + Lang["Error_SizeImage"].ToString() + "');history.go(-1);</script>");
        }
    }
}
