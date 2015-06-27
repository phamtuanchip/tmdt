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
    public partial class Gallery_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        public Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "gallery_edit";
        private string strFunctionName = "Sửa thông tin ảnh";
        private int intCat_id = 0;
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("LibraryImages_Manager");
            LibraryImage_Edit.Text = Lang["edit"].ToString();
            Reset_Form.Value = Lang["reset"].ToString();
            Back_Edit.Value = Lang["back"].ToString();
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
                        GetGallery();
                        DDL_CatId.InnerHtml = wrNewsCatRoot(1);
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }

        protected void GetGallery()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_Gallery_Image", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ID", id);
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.intCat_id = int.Parse(drd["Cat_Id"].ToString());
                this.txtDesc.Text = drd["Description"].ToString();
                this.IDImg.ImageUrl = objEntities.GetPathLibraryImage() + drd["PhotoID"].ToString() + "_T.jpg";
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
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
                    if (intCat_id == Cat_Id)
                        strSelected = " selected ";
                    tbl.Append("        <option value='" + Cat_Id + "' " + strSelected + ">" + strCatName + "</option>");
                    if (objBusinessLogic.FindChildNode(Cat_Id, dt))
                    {
                        varSpace = "";
                        tbl.Append(objBusinessLogic.Create_Select_Tree(Cat_Id, dt, intCat_id, varSpace));
                    }
                }
            }
            tbl.Append("            </select>");

            return tbl.ToString();
        }

        protected void LibraryImage_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateGallery();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateGallery()
        {
            int intCat_Id = 0;
            string boolIsLeaf = "";
            if (Request.Form["SNewsCat"].ToString() != null && Request.Form["SNewsCat"].ToString() != "")
            {
                intCat_Id = int.Parse(objEntities.SafeString(Request.Form["SNewsCat"].ToString()));
            }

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

            SqlCommand comm = new SqlCommand("Update_Gallery", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ID", id);
            comm.Parameters.AddWithValue("@Description", strDesc);
            comm.Parameters.AddWithValue("@Cat_Id", intCat_Id);
            try
            {
                comm.Connection.Open();
                if (comm.ExecuteNonQuery() == -1)
                    this.objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strDesc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Gallery_list.aspx");
            }
        }
    }
}
