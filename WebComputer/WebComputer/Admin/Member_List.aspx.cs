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
    public partial class Member_List : System.Web.UI.Page
    {

        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "member_list";
        private string strAllowFunction_Delete = "member_delete";
        private string strFunctionName = "Xoá thành viên";
        private int intGroup_Id = 0;
        private string strUsername = string.Empty;
        private int intActive = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Member_Manager");
            this.Member_AddNew.Text = Lang["AddNew"].ToString();
            this.Member_Delete.Text = Lang["delete"].ToString();
            this.MemberSearch.Text = Lang["Search"].ToString();

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
                        this.MemberGroupList();
                        this.GetMemberList();
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void MemberGroupList()
        {
            this.DDL_GroupMember.Items.Add(new ListItem("[Tất cả]", "0"));
            for (int i = 0; i < objBusinessLogic.CreateDataTable("Get_MemberGroupList").Rows.Count; i++)
            {
                this.DDL_GroupMember.Items.Add(new ListItem(objBusinessLogic.CreateDataTable("Get_MemberGroupList").Rows[i]["GroupName"].ToString(), objBusinessLogic.CreateDataTable("Get_MemberGroupList").Rows[i]["Group_ID"].ToString()));
            }
        }
        protected void GetMemberList()
        {
            DataSet dts = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand("Get_MemberList", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Group_Id", intGroup_Id);
            comm.Parameters.AddWithValue("@UserName", strUsername);
            comm.Parameters.AddWithValue("@Active", intActive);
            comm.Connection.Open();
            adt.SelectCommand = comm;
            adt.Fill(dts);
            this.GV_MemberList.DataSource = dts;
            this.GV_MemberList.DataBind();
            dts.Clear();
            adt.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void Member_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_AddNew.aspx");
        }
        protected void Member_Delete_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunction_Delete) == true)
                {
                    this.DeleteMember();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void DeleteMember()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Substring(0, 9) == "chbDelete")
                {
                    string strUsename = objEntities.SafeString(item.Substring(9, item.Length - 9));
                    SqlCommand comm = new SqlCommand("Delete_Member", this.objConn.SqlConn());
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Username", strUsename);
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
                    this.GetMemberList();
                }
            }
        }
        protected void MemberSearch_Click(object sender, EventArgs e)
        {
            this.intGroup_Id = int.Parse(objEntities.SafeString(this.DDL_GroupMember.SelectedValue));
            this.strUsername = objEntities.SafeString(this.txtSearch.Text);
            this.intActive = int.Parse(objEntities.SafeString(this.DDL_Status.SelectedValue));
            this.GetMemberList();
        }
    }
}
