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
    public partial class Member_AddNew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "member_addnew";
        private string strFunctionName = "Thêm mới thành viên";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Member_Manager");
            this.Members_AddNew.Text = Lang["AddNew"].ToString();
            this.Back_AddNew.Value = Lang["Return"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.MemberGroupList();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void MemberGroupList()
        {
            this.DDL_GroupMember.Items.Add(new ListItem("[Chọn nhóm thành viên]", "0"));
            for (int i = 0; i < objBusinessLogic.CreateDataTable("Get_MemberGroupList").Rows.Count; i++)
            {
                this.DDL_GroupMember.Items.Add(new ListItem(objBusinessLogic.CreateDataTable("Get_MemberGroupList").Rows[i]["GroupName"].ToString(), objBusinessLogic.CreateDataTable("Get_MemberGroupList").Rows[i]["Group_ID"].ToString()));
            }
        }
        protected void Members_AddNew_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    InsertMember();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertMember()
        {
            bool boolActive = false;
            int intMemberGroup_Id = int.Parse(objEntities.SafeString(this.DDL_GroupMember.SelectedValue));
            string strUsername = objEntities.SafeString(this.txtUserName.Text);
            string strPassword = objEntities.EncodePassword(objEntities.SafeString(this.txtPassword.Text), "");
            if (this.chkIsActive.Checked)
                boolActive = true;
            string strFullName = objEntities.SafeString(this.txtFullName.Text);
            string strAddress = objEntities.SafeString(this.txtAddress.Text);
            int intSex = int.Parse(objEntities.SafeString(this.DDL_Sex.SelectedValue));
            string strCompany = objEntities.SafeString(this.txtCompany.Text);
            string strPosition = objEntities.SafeString(this.txtPosi.Text);
            string strEmail = objEntities.SafeString(this.txtEmail.Text);
            string strTel = objEntities.SafeString(this.txtTel.Text);
            string strMobi = objEntities.SafeString(this.txtMobi.Text);
            string strFax = objEntities.SafeString(this.txtFax.Text);
            SqlCommand comm = new SqlCommand("Insert_Member", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@UserName", strUsername);
            comm.Parameters.AddWithValue("@Password", strPassword);
            comm.Parameters.AddWithValue("@FullName", strFullName);
            comm.Parameters.AddWithValue("@Sex", intSex);
            comm.Parameters.AddWithValue("@Position", strPosition);
            comm.Parameters.AddWithValue("@Email", strEmail);
            comm.Parameters.AddWithValue("@Phone", strTel);
            comm.Parameters.AddWithValue("@Mobile", strMobi);
            comm.Parameters.AddWithValue("@Fax", strFax);
            comm.Parameters.AddWithValue("@Address", strAddress);
            comm.Parameters.AddWithValue("@Company", strCompany);
            comm.Parameters.AddWithValue("@Group_ID", intMemberGroup_Id);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            try
            {
                comm.Connection.Open();
                comm.ExecuteNonQuery();
                objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strUsername);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                Response.Redirect("Member_List.aspx");
            }
        }
    }
}
