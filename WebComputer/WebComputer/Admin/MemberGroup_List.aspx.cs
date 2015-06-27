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
    public partial class MemberGroup_List : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "membergroup_list";
        private string strAllowFunction_Delete = "membergroup_delete";
        private string strFunctionName = "Xoá nhóm thành viên";

            

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("MemberGroup_Manager");
            this.MemberGroup_AddNew.Text = Lang["AddNew"].ToString();
            this.MemberGroup_Delete.Text = Lang["delete"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.GetMemberGroupList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void GetMemberGroupList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_MemberGroupList", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.GV_MemberGroup_List.DataSource = dts;
            this.GV_MemberGroup_List.DataBind();
            dts.Clear();
            adt.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void MemberGroup_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberGroup_AddNew.aspx");
        }
        protected void MemberGroup_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunction_Delete) == true)
                {
                    this.DeleteMemberGroupList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteMemberGroupList()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    int intGroup_id = int.Parse(item.Substring(9, item.Length - 9));
                    SqlCommand comm = new SqlCommand("Delete_MemberGroup", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Group_Id", intGroup_id);
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
                    this.GetMemberGroupList();
                }
            }
        }
    }
}
