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
using System.Text;
using System.IO;
using System.Xml;

namespace WebComputer.Admin
{
    public partial class Product_Edit : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "Product_Edit";
        private string strFunctionName = "Sửa sản phẩm";
        private int id = 0;
        protected int ProductImage = 0;
        private int intCat_Id = 0;
        protected string strProductImage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Product_Manager");
            this.Products_Edit.Text = Lang["edit"].ToString();
            this.Reset_Form.Value = Lang["reset"].ToString();
            this.Back_Edit.Value = Lang["Return"].ToString();
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
                        this.ShowStatus();
                       // this.ShowProvider();
                        this.objBusinessLogic.GetLanguage(this.DDL_Language);
                        this.ProductEditView();
                        this.GetLibraryImages();
                        
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void ProductEditView()
        {
            string strCheck = string.Empty;
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Product", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Product_Id", id);

            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.txtSubject.Text = drd["Product_ID"].ToString();
                this.Brief.Text = drd["Product_Name"].ToString();
                this.Textintro.Text = drd["Product_Intro"].ToString();
                this.TextCashby.Text = drd["Product_Price"].ToString();
                this.Text_Quatity.Text = drd["Product_QUatityOut"].ToString();
                this.DDCashby.SelectedValue = drd["Cashby"].ToString();
                this.DDL_Status.SelectedValue = drd["Status_Id"].ToString();
                //this.DLL_Provider.SelectedValue = drd["HangID"].ToString();
                this.DDL_Language.SelectedValue = drd["Language_Id"].ToString();
                this.Content.Value = drd["Content"].ToString();
                this.intCat_Id = int.Parse(drd["SubCatID"].ToString());
                if (drd["LeadImage"].ToString() != "0")
                {
                    this.ProductImage = int.Parse(drd["LeadImage"].ToString());
                    this.strProductImage = objBusinessLogic.wrImages(ProductImage, objEntities.GetPathLibraryImage());
                }

                if ((bool)drd["Hot_Product"])
                    this.cbProductHot.Checked = true;
                else
                    this.cbProductHot.Checked = false;

                if ((bool)drd["onHomePage"])
                    this.cbProductOnHomePage.Checked = true;
                else
                    this.cbProductOnHomePage.Checked = false;
            }
            //============================================//
            //Neu ton tai tin lien quan thi hien thi.
            int Lang_ID;
            if (this.DDL_Language.SelectedValue != "")
            {
                Lang_ID = int.Parse(this.DDL_Language.SelectedValue);
                CMSProduct_Cat_Root.Visible = true;
                CMSProduct_Cat_Root.InnerHtml = wrProductCatRoot(Lang_ID);
            }
            else
            {
                Lang_ID = 0;
            }
            //============================================//            
            drd.Close();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void ShowStatus()
        {
            DataTable tableStatus = new DataTable();
            tableStatus = objBusinessLogic.CreateDataTable("Get_Status_Product");
            this.DDL_Status.Items.Add(new ListItem(this.Lang["SelectStatus"].ToString(), ""));
            for (int i = 0; i < tableStatus.Rows.Count; i++)
            {
                this.DDL_Status.Items.Add(new ListItem(tableStatus.Rows[i]["Status_Name"].ToString(), tableStatus.Rows[i]["Status_ID"].ToString()));
            }
        }
        //protected void ShowProvider()
        //{
        //    DataTable tableProvider = new DataTable();
        //    tableProvider = objBusinessLogic.CreateDataTable("Get_Root_Provider");
        //    this.DLL_Provider.Items.Add(new ListItem(this.Lang["ProviderChoicedetail"].ToString(), ""));
        //    for (int i = 0; i < tableProvider.Rows.Count; i++)
        //    {
        //        this.DLL_Provider.Items.Add(new ListItem(tableProvider.Rows[i]["ProvName"].ToString(), tableProvider.Rows[i]["ProvID"].ToString()));
        //    }
        //}
        protected string wrProductCatRoot(int intLang)
        {
            StringBuilder tbl = new StringBuilder();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Root_ProductCat_Language", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Language_Id", intLang);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dt);

            string varSpace = string.Empty;
            tbl.Append("            <select name='SCat_Id' size='1'>");
            tbl.Append("                <option value=''>[" + Lang["ProductCatChoice"].ToString() + "]</option>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Parent"].ToString()) == 0)
                {
                    string strCatName = dt.Rows[i]["SubName"].ToString();
                    int Cat_Id = int.Parse(dt.Rows[i]["SubCatID"].ToString());
                    string strSelected = string.Empty;
                    if (intCat_Id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "'" + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, intCat_Id, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }
        protected void CatRoot_SelectIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Language.SelectedItem.Value.ToString() == "")
            {
                CMSProduct_Cat_Root.Visible = false;
            }
            else
            {
                CMSProduct_Cat_Root.Visible = true;
                CMSProduct_Cat_Root.InnerHtml = wrProductCatRoot(int.Parse(DDL_Language.SelectedValue));
            }
        }
        #region Update Product
        protected void Products_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateProduct();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }

        protected void UpdateProduct()
        {
            int intProductImage;
            int intCat_Id;
            decimal dTextCashby;
            int intIsLeaf = 0;
            bool boolHost = false;
            bool boolHomePage = false;
            int intLanguage_Id = int.Parse(objEntities.SafeString(this.DDL_Language.SelectedValue));
            string strSubject = this.txtSubject.Text;
            string strProductname = this.Brief.Text;
            string strTextintro = this.Textintro.Text;
            int intCasby = Convert.ToInt16(DDCashby.SelectedValue);
            //double intQuatiy = Convert.ToDouble(this.Text_Quatity.Text);
            if (TextCashby.Text.ToString() != String.Empty)
            {
                dTextCashby = Convert.ToDecimal(TextCashby.Text.ToString());
            }
            else
            {
                dTextCashby = 0;
            }
            if (Request.Form["LeadImage"].ToString() != null && Request.Form["LeadImage"].ToString() != "")
            {
                intProductImage = int.Parse(objEntities.SafeString(Request.Form["LeadImage"].ToString()));
            }
            else
                intProductImage = 0;
            if (Request.Form["SCat_Id"].ToString() != null && Request.Form["SCat_Id"].ToString() != "")
            {
                intCat_Id = int.Parse(objEntities.SafeString(Request.Form["SCat_Id"].ToString()));
            }
            else
                intCat_Id = 0;
            int intStatus = int.Parse(objEntities.SafeString(this.DDL_Status.SelectedValue));
            //int intProvider = int.Parse(objEntities.SafeString(this.DLL_Provider.SelectedValue));
           
            if (this.cbProductHot.Checked)
                boolHost = true;
            if (this.cbProductOnHomePage.Checked)
                boolHomePage = true;
            string strContent = objEntities.SafeString(this.Content.Value);


            //================Check Cat_Id==========================
            if (intCat_Id != 0)
            {
                string SQL_Cat = "SELECT Parent FROM TB_Cat_Product WHERE Parent =" + intCat_Id;
                SqlDataReader drd;
                SqlCommand comm_drd = new SqlCommand(SQL_Cat, objConn.SqlConn());
                comm_drd.CommandType = CommandType.Text;
                comm_drd.Connection.Open();
                drd = comm_drd.ExecuteReader();
                if (drd.Read())
                {
                    intIsLeaf = Convert.ToInt16(drd["Parent"].ToString());
                }
                drd.Close();
                comm_drd.Connection.Close();
                comm_drd.Connection.Dispose();
            }
            if (intIsLeaf != 0)
            {
                Response.Write("<script language='JavaScript'>alert('" + Lang["Error_ChoiceCatId"].ToString() + "');history.go(-1);</script>");
                Response.End();
            }

            //==============End Check Cat_Id========================
            SqlCommand comm = new SqlCommand("Update_Product", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Product_ID", id);
            comm.Parameters.AddWithValue("@SubCatID", intCat_Id);
            comm.Parameters.AddWithValue("@Status_ID", intStatus);
            comm.Parameters.AddWithValue("@Language_ID", intLanguage_Id);
          //  comm.Parameters.AddWithValue("@Provider_ID", intProvider);
            comm.Parameters.AddWithValue("@Product_Name", strProductname);
            comm.Parameters.AddWithValue("@Product_Intro", strTextintro);
            comm.Parameters.AddWithValue("@Product_Price", dTextCashby);
            //comm.Parameters.AddWithValue("@Product_Quatity", intQuatiy);
            comm.Parameters.AddWithValue("@HotProduct", (bool)boolHost);
            comm.Parameters.AddWithValue("@OnHomePage", (bool)boolHomePage);
            comm.Parameters.AddWithValue("@Cashby", intCasby);
            comm.Parameters.AddWithValue("@Author", Session["AdminID"].ToString());
            comm.Parameters.AddWithValue("@LeadImage", intProductImage);
            comm.Parameters.AddWithValue("@Content", strContent);

            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                {
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strSubject);
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
                Response.Redirect("Product_List.aspx");
            }

        }
        #endregion
        #region Live show
        protected void GetLibraryImages()
        {
            StringBuilder tbl = new StringBuilder();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_Update_Library_Image_Product", this.objConn.SqlConn());
            comm.Parameters.AddWithValue("@Product_ID", id);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            DataSet ds = new DataSet();
            try
            {
                adt.Fill(ds);
                PagedDataSource paged = new PagedDataSource();
                paged.DataSource = ds.Tables[0].DefaultView;

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
        #endregion
        #region Upload images
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
                        WidthToResize = objEntities.GetWidthToResizeProduct();
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
                        SqlCommand comm = new SqlCommand("Insert_LibraryImage_Product_", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@PhotoID", strDateTime);
                        comm.Parameters.AddWithValue("@Product_ID", id);
                        comm.Parameters.AddWithValue("@Thumb_W", WidthToResize);
                        comm.Parameters.AddWithValue("@Thumb_H", ImgHeight_Thumb);
                        comm.Parameters.AddWithValue("@Full_Size", FileSize);
                        comm.Parameters.AddWithValue("@Full_W", ImgWidth);
                        comm.Parameters.AddWithValue("@Full_H", ImgHieght);
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
                            GetLibraryImages();
                        }
                    }
                    else
                        Response.Write("<script language='JavaScript'>alert('" + Lang["Error_ImgUpload"].ToString() + WidthToResize + Lang["to"].ToString() + MaxWidth + Lang["pixels"].ToString() + "');history.go(-1);</script>");
                }
            }
            else
                Response.Write("<script language='JavaScript'>alert('" + Lang["Error_SizeImage"].ToString() + "');history.go(-1);</script>");
        }
        #endregion
        #region Delete Library Product
        protected void LibraryImage_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
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
                        string SQL = "SELECT PhotoID FROM TB_Product_Images WHERE Id =" + intID;
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
                        SqlCommand comm = new SqlCommand("Delete_Product_Image", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@ID", intID);
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
                        //===========End Delete Database===============================
                    }
                }
            }
            GetLibraryImages();
        }
        #endregion
    }
}
