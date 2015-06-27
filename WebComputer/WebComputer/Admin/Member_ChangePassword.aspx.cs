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
    public partial class Member_ChangePassword : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entities();

        protected Hashtable Lang = new Hashtable();
        string strUsername = string.Empty;
        private string strNewPass = string.Empty;
        private string strOldPass = string.Empty;
        private string strOldPassInput = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("Member_Manager");
            this.Save_ChangePass.Text = Lang["Save"].ToString();
            this.Close_ChangePass.Value = Lang["Close"].ToString();
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                strUsername = objEntities.SafeString(Request.QueryString["id"].ToString());
            }
            this.pnPanelResult.Visible = false;
        }
        protected void Save_ChangePass_Click(object sender, EventArgs e)
        {
            if (strUsername != string.Empty)
            {
                SqlDataReader drd;
                SqlCommand comm = new SqlCommand("Get_MemberId", objConn.SqlConn());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Username", strUsername);
                try
                {
                    comm.Connection.Open();
                    drd = comm.ExecuteReader();
                    if (drd.Read())
                    {
                        this.strOldPass = drd["Password"].ToString();
                        this.strOldPassInput = objEntities.EncodePassword(objEntities.SafeString(this.txtOldPass.Text), "");
                        //So sánh mật khẩu cũ trong cơ sở dữ liệu với mật khẩu cũ được nhập vào
                        if (this.txtOldPass.Text != string.Empty && this.txtOldPass.Text != null && this.txtNewPass.Text != string.Empty && this.txtNewPass.Text != null)
                        {
                            if (this.strOldPass == this.strOldPassInput)
                            {
                                //Cập nhật mật khẩu mới
                                this.strNewPass = this.objEntities.EncodePassword(this.objEntities.SafeString(this.txtNewPass.Text).ToLower(), "");
                                SqlCommand comm_ = new SqlCommand("Update_MemberChangePassword", objConn.SqlConn());
                                comm_.CommandType = CommandType.StoredProcedure;
                                comm_.Parameters.AddWithValue("@UserName", strUsername);
                                comm_.Parameters.AddWithValue("@NewPass", strNewPass);
                                try
                                {
                                    comm_.Connection.Open();
                                    if (comm_.ExecuteNonQuery() == -1)
                                    {
                                        Response.Write("<script language='javascript'>alert('Thay đổi mật khẩu thành công.');</script>");
                                        Response.Write("<script language='javascript'>window.close();</script>");
                                    }
                                }
                                catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
                                finally
                                {
                                    comm_.Connection.Close();
                                    comm_.Connection.Dispose();
                                }
                            }
                            else
                            {
                                this.pnPanelInPut.Visible = false;
                                Response.Write("<script language='javascript'>alert('Mật khẩu cũ bạn nhập vào không đúng.');history.go(-1);</script>");
                                this.Save_ChangePass.Visible = false;
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('Bạn phải nhập mật khẩu cũ và mật khẩu mới');history.go(-1);</script>");
                        }
                    }
                    else
                    {
                        this.Result.Text = this.Lang["NotExits"].ToString();
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
                }
            }
        }
    }
}
