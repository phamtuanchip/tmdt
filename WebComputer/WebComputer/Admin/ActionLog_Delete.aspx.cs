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
    public partial class ActionLog_Delete : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "log_delete";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("ActionLog_Manager");
            this.Delete_ActionLog.Text = Lang["delete"].ToString();

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
                        this.ActionDeleteList();
                        if (this.DDL_ActionDelete.SelectedItem.Value.ToString() == "3")
                        {
                            idFromDate.Visible = true;
                            idToDate.Visible = true;
                        }
                        else
                        {
                            idFromDate.Visible = false;
                            idToDate.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void ActionDeleteList()
        {
            this.DDL_ActionDelete.Items.Add(new ListItem("[Chọn tùy chọn xóa]", ""));
            this.DDL_ActionDelete.Items.Add(new ListItem("Xóa theo tuần xa nhất", "1"));
            this.DDL_ActionDelete.Items.Add(new ListItem("Xóa theo tháng xa nhất", "2"));
            this.DDL_ActionDelete.Items.Add(new ListItem("Xóa theo tùy chọn ngày tháng", "3"));
        }
        protected void ActionLog_SelectIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_ActionDelete.SelectedItem.Value.ToString() == "3")
            {
                idFromDate.Visible = true;
                idToDate.Visible = true;
            }
            else
            {
                idFromDate.Visible = false;
                idToDate.Visible = false;
            }
        }
        protected void Delete_ActionLog_Click(object sender, EventArgs e)
        {
            int intDDL_ActionDelete = int.Parse(objEntities.SafeString(this.DDL_ActionDelete.SelectedValue));
            string strFromDate = string.Empty;
            string strToDate = string.Empty;
            if (Request.Form["FromDate"] != null && Request.Form["FromDate"].ToString() != "")
            {
                strFromDate = objEntities.SafeString(Request.Form["FromDate"].ToString());
            }
            if (Request.Form["ToDate"] != null && Request.Form["ToDate"].ToString() != "")
            {
                strFromDate = objEntities.SafeString(Request.Form["ToDate"].ToString());
            }

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=Default.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    DeleteActionLog(intDDL_ActionDelete, strFromDate, strToDate);
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }

        }
        protected void DeleteActionLog(int intDDL_ActionDelete, string strFromDate, string strToDate)
        {
            SqlCommand comm = new SqlCommand("Delete_ActionLog", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Option", intDDL_ActionDelete);
            comm.Parameters.AddWithValue("@FromDate", strFromDate);
            comm.Parameters.AddWithValue("@ToDate", strToDate);

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

                Response.Write(" <script language='javascript'>");
                Response.Write("    function refreshParent() {");
                Response.Write("        window.opener.location.href = window.opener.location.href;");
                Response.Write("        if (window.opener.progressWindow)");
                Response.Write("        {");
                Response.Write("        window.opener.progressWindow.close()");
                Response.Write("        }");
                Response.Write("        window.close();");
                Response.Write("    }");
                Response.Write(" </script>");
                Response.Write(" <script language='javascript'>refreshParent();</script>");
            }
        }
    }
}
