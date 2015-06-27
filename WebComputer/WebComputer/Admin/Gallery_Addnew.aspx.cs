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
    public partial class Gallery_Addnew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "gallery_addnew";
        private string strFunctionName = "Thêm mới ảnh";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            LibraryImage_AddNew.Text = Lang["add_new"].ToString();
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
                    DDL_CatId.InnerHtml = wrNewsCatRoot(1);
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }


        protected string wrNewsCatRoot(int intLang)
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_All_CatLibraryImages_Language_Add", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Language_Id", intLang);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select  name ='SNewsCat' size='1' runat='server'>");
            tbl.Append("                <option value='0'>[" + Lang["var_Text_ParentCat"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strSelected = string.Empty;
                    tbl.Append("        <option value='" + Cat_Id + "'>" + strCatName + "</option>");
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


        protected void LibraryImage_AddNew_Click(object sender, EventArgs e)
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
        protected void UpdateIs(int intCat_Id)
        {
            string SQL_Cat = "Update TB_Cat_Gallery Set IsLeaf = 1 WHERE Cat_Id =" + intCat_Id;
            SqlCommand comm_drd = new SqlCommand(SQL_Cat, objConn.SqlConn());
            comm_drd.CommandType = CommandType.Text;
            comm_drd.Connection.Open();
            comm_drd.ExecuteNonQuery();
            comm_drd.Connection.Close();
            comm_drd.Connection.Dispose();
        }
        protected void InsertLibraryImage()
        {
            string boolIsLeaf = "";

            int intCat_Id;
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
            if (Request.Form["SNewsCat"].ToString() != null && Request.Form["SNewsCat"].ToString() != "")
            {
                intCat_Id = int.Parse(objEntities.SafeString(Request.Form["SNewsCat"].ToString()));
            }
            else
                intCat_Id = 0;

            if (intCat_Id != 0)
            {
                string SQL_Cat = "SELECT Parent FROM TB_Cat_Gallery WHERE Cat_Id =" + intCat_Id;
                SqlDataReader drd;
                SqlCommand comm_drd = new SqlCommand(SQL_Cat, objConn.SqlConn());
                comm_drd.CommandType = CommandType.Text;
                comm_drd.Connection.Open();
                drd = comm_drd.ExecuteReader();
                if (drd.Read())
                {
                    boolIsLeaf = drd["Parent"].ToString();
                }
                drd.Close();
                comm_drd.Connection.Close();
                comm_drd.Connection.Dispose();
            }
            if (boolIsLeaf == "0")
            {
                Response.Write("<script language='JavaScript'>alert('" + Lang["Error_ChoiceCatId"].ToString() + "');history.go(-1);</script>");
                Response.End();
            }
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
                        SqlCommand comm = new SqlCommand("Insert_GalleryImage", this.objConn.SqlConn());
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
                            {
                                this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strDateTime);
                                UpdateIs(intCat_Id);
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
                            Response.Redirect("Gallery_List.aspx");
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
