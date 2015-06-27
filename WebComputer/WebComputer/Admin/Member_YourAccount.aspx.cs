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
    public partial class Member_YourAccount : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private Entity.Entities objEntities = new Entity.Entities();

        protected Hashtable Lang = new Hashtable();
        private string strFunctionName = "Sửa thông tin thành viên";
        private string strUsername = string.Empty;
        public string strChangPass = string.Empty;
        public string strUser = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Member_Manager");
            this.Member_Edit.Text = Lang["edit"].ToString();
            this.Back_Edit.Value = Lang["Return"].ToString();
            this.strChangPass = Lang["ChangPass"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (!IsPostBack)
                {
                    this.MemberGroupList();
                    this.GetMemberInfo();
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
        protected void GetMemberInfo()
        {
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_MemberId", this.objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Username", Session["AdminID"].ToString());
            comm.Connection.Open();
            drd = comm.ExecuteReader();
            if (drd.Read())
            {
                this.DDL_GroupMember.SelectedValue = drd["Group_Id"].ToString();
                this.txtUserName.Text = drd["UserName"].ToString();
                this.strUser = drd["UserName"].ToString();
                if ((bool)drd["Active"] == true)
                    this.chkIsActive.Checked = true;
                this.txtFullName.Text = drd["FullName"].ToString();
                this.txtAddress.Text = drd["Address"].ToString();
                this.DDL_Sex.SelectedValue = drd["Sex"].ToString();
                this.txtCompany.Text = drd["Company"].ToString();
                this.txtPosi.Text = drd["Position"].ToString();
                this.txtEmail.Text = drd["Email"].ToString();
                this.txtTel.Text = drd["Phone"].ToString();
                this.txtMobi.Text = drd["Mobile"].ToString();
                this.txtFax.Text = drd["Fax"].ToString();
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        protected void Member_Edit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                EditMember();
            }
        }
        protected void EditMember()
        {
            bool boolActive = false;
            int intMemberGroup_Id = int.Parse(objEntities.SafeString(this.DDL_GroupMember.SelectedValue));
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

            SqlCommand comm = new SqlCommand("Update_Member", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@UserName", Session["AdminID"].ToString());
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
                Response.Redirect("Member_YourAccount.aspx");
            }
        }
    }
}
