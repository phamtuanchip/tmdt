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
    public partial class MemberGroup_Edit : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        
        protected Hashtable Lang = new Hashtable();
        private string strAllowFunctions = "membergroup_edit";
        private string strFunctionName = "Sửa nhóm thành viên";
        private int gropu_id;
        private string isChecked = string.Empty;
        private bool[] Permission = new bool[5];
        private int[] Function_Id = new int[5];
        private int[] Function_Group_Id = new int[5];
        private string[] bcheck = new string[5];

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("MemberGroup_Manager");
            this.MemberGroupEdit.Text = Lang["edit"].ToString();
            this.Back_Edit.Value = Lang["Return"].ToString();
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                gropu_id = int.Parse(objEntities.SafeString(Request.QueryString["id"].ToString()));
            }
            else
                gropu_id = 0;

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    if (!IsPostBack)
                        this.CMSMemberGroup_Edit.InnerHtml = MemberGroups_Edit();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string MemberGroups_Edit()
        {
            StringBuilder tbl = new StringBuilder();

            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_MemberGroupId", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Group_Id", gropu_id);
            comm.Connection.Open();
            drd = comm.ExecuteReader(CommandBehavior.CloseConnection);
            if (drd.Read())
            {
                tbl.Append("<input type='hidden' name='Group_ID' value='" + gropu_id + "'>");
                tbl.Append("<table width='98%' border='0' cellspacing='0' cellpadding='0' align='center' style='border: 1px solid; border-color: #BBBBBB'>");
                tbl.Append("    <tr>");
                tbl.Append("        <th colspan='2' class='Title' height='20' width='100%' align='left'>");
                tbl.Append(Lang["GroupInfo"]);
                tbl.Append("        </th>");
                tbl.Append("    <tr>");

                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' class='create_title'>");
                tbl.Append(Lang["GroupName"]);
                tbl.Append("        </td>");
                tbl.Append("        <td align='left'>");
                tbl.Append("            <input class='textbox' maxlength='50' type='textbox' size='41' name='GroupName' value='" + drd.GetString(1).ToString() + "')>");
                tbl.Append("        </td>");
                tbl.Append("    <tr>");

                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' class='create_title'>");
                tbl.Append(Lang["Description"].ToString());
                tbl.Append("        </td>");
                tbl.Append("        <td align='left'>");
                tbl.Append("            <textarea class='textbox' maxlength='255' cols='30' rows='3' name='GroupDesc'>" + drd.GetString(2).ToString() + "</textarea>");
                tbl.Append("        </td>");
                tbl.Append("    <tr>");

                tbl.Append("    <tr>");
                tbl.Append("        <td align='left' class='create_title'>");
                tbl.Append(Lang["Active"]);
                tbl.Append("        </td>");
                tbl.Append("        <td align='left'>");
                if (drd.GetBoolean(3))
                {
                    this.isChecked = "checked";
                }
                else
                { this.isChecked = string.Empty; }
                tbl.Append("<input type='checkbox' name='Active' value='yes'" + this.isChecked + ">");
                tbl.Append("        </td>");
                tbl.Append("    <tr>");

                tbl.Append("</table>");
                tbl.Append("<br />");
                tbl.Append("<table width='98%' border='0' cellspacing='0' cellpadding='0' align='center' style='border: 1px solid; border-color: #BBBBBB'>");
                tbl.Append("<tr>");
                tbl.Append("    <th colspan='7' class='Title' height='20' width='100%' align='left'>");
                tbl.Append(Lang["PermisionForGroup"]);
                tbl.Append("    </th>");
                tbl.Append("</tr>");

                tbl.Append("<tr>");
                //====================================Function Name=======================================                
                SqlDataReader drd_;
                SqlCommand comm_ = new SqlCommand("Get_FunctionName", objConn.SqlConn());
                comm_.CommandType = CommandType.StoredProcedure;
                comm_.Connection.Open();
                drd_ = comm_.ExecuteReader(CommandBehavior.CloseConnection);
                tbl.Append("    <td class='member_title'>");
                tbl.Append(Lang["NameGroup"]);
                tbl.Append("    </td>");
                while (drd_.Read())
                {
                    tbl.Append("<td class='member_title'>");
                    tbl.Append(drd_.GetString(0).ToString());
                    tbl.Append("</td>");
                }
                drd_.Close();
                drd_.Dispose();
                comm_.Connection.Close();
                comm_.Connection.Dispose();
                //==================================End Function Name=====================================
                tbl.Append("</tr>");
                //===================================Function Group=======================================
                comm_ = new SqlCommand("Get_FunctionGroup", objConn.SqlConn());
                comm_.CommandType = CommandType.StoredProcedure;
                comm_.Connection.Open();
                drd_ = comm_.ExecuteReader(CommandBehavior.CloseConnection);
                while (drd_.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Permission[i] = false;
                        bcheck[i] = string.Empty;
                    }

                    tbl.Append("<tr>");
                    tbl.Append("    <td align='left' width='40%' height='20'>");
                    tbl.Append("        <input type='hidden' name=\"group" + drd_.GetInt32(0).ToString() + "\" value='1'>");
                    tbl.Append("        <a href='JavaScript:checkAllGroupItem(" + drd_.GetInt32(0).ToString() + ",document.aspnetForm.group" + drd_.GetInt32(0).ToString() + ")' class='member_list'>" + drd_.GetString(1).ToString() + "</a>");
                    tbl.Append("    </td>");
                    //======================================================================                    
                    SqlDataReader drd_sub;
                    SqlCommand comm_sub = new SqlCommand("Get_Function", objConn.SqlConn());
                    comm_sub.CommandType = CommandType.StoredProcedure;
                    comm_sub.Parameters.AddWithValue("@Group_Id", drd_.GetInt32(0).ToString());
                    comm_sub.Connection.Open();
                    drd_sub = comm_sub.ExecuteReader(CommandBehavior.CloseConnection);
                    while (drd_sub.Read())
                    {
                        int ID = drd_sub.GetInt32(4) - 1;
                        Permission[ID] = true;
                        Function_Group_Id[ID] = drd_.GetInt32(0);
                        Function_Id[ID] = drd_sub.GetInt32(0);
                        //---------------------------------------------------------------------
                        SqlDataReader drd_sub_;
                        SqlCommand comm_sub_ = new SqlCommand("Get_GroupFunction", objConn.SqlConn());
                        comm_sub_.CommandType = CommandType.StoredProcedure;
                        comm_sub_.Parameters.AddWithValue("@Group_Id", gropu_id);
                        comm_sub_.Parameters.AddWithValue("@Function_ID", drd_sub.GetInt32(0).ToString());
                        comm_sub_.Connection.Open();
                        drd_sub_ = comm_sub_.ExecuteReader(CommandBehavior.CloseConnection);

                        if (drd_sub_.Read())
                        {
                            bcheck[ID] = " checked ";
                        }
                        drd_sub_.Close();
                        drd_sub_.Dispose();
                        comm_sub_.Connection.Close();
                        comm_sub_.Connection.Dispose();
                        //---------------------------------------------------------------------
                    }
                    drd_sub.Close();
                    drd_sub.Dispose();
                    comm_sub.Connection.Close();
                    comm_sub.Connection.Dispose();
                    //======================================================================
                    for (int i = 0; i < 5; i++)
                    {
                        if (Permission[i])
                        {
                            tbl.Append("<td align='center' width='10%' height='20'>");
                            tbl.Append("<input type='checkbox' name='chbFunc" + Function_Id[i].ToString() + "' value='check' id='" + Function_Group_Id[i] + "' " + bcheck[i] + ">");
                            tbl.Append("</td>");
                        }
                        else
                        {
                            tbl.Append("<td align='center' width='10%' height='20'>");
                            tbl.Append("&nbsp;");
                            tbl.Append("</td>");
                        }
                    }
                }
                drd_.Close();
                drd_.Dispose();
                comm_.Connection.Close();
                comm_.Connection.Dispose();
                tbl.Append("    </tr>");
                //=================================End Function Group=====================================                
                tbl.Append("</table>");
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
            return tbl.ToString();
        }
        protected void MemberGroupEdit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    UpdateMemberGroup();
                    Response.Redirect("MemberGroup_List.aspx");
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void UpdateMemberGroup()
        {
            int toResult = 0;
            bool boolActive = false;
            string strGroupName = objEntities.SafeString(objEntities.RequestForm("GroupName"));
            string strGroupDesc = objEntities.SafeString(objEntities.RequestForm("GroupDesc"));
            string myActive = objEntities.SafeString(objEntities.RequestForm("Active"));
            if (myActive != null)
            {
                boolActive = true;
            }
            SqlCommand comm = new SqlCommand("Update_MemberGroup", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Group_Id", gropu_id);
            comm.Parameters.AddWithValue("@GroupName", strGroupName);
            comm.Parameters.AddWithValue("@GroupDesc", strGroupDesc);
            comm.Parameters.AddWithValue("@Active", (bool)boolActive);
            try
            {
                comm.Connection.Open();
                toResult = comm.ExecuteNonQuery();
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
            if (toResult == -1)
            {
                objConn.WriteActionLog(strFunctionName, Session["AdminID"].ToString(), strGroupName);
                //==========================Delete Group Function===================================
                SqlCommand comm_group = new SqlCommand("Delete_GroupFunction", objConn.SqlConn());
                comm_group.CommandType = CommandType.StoredProcedure;
                comm_group.Parameters.AddWithValue("@Group_ID", gropu_id);
                try
                {
                    comm_group.Connection.Open();
                    comm_group.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
                finally
                {
                    comm_group.Connection.Close();
                    comm_group.Connection.Dispose();
                }
                //========================End Delete Group Function=================================
                foreach (string item in HttpContext.Current.Request.Form)
                {
                    if (item.Substring(0, 6) == "chbFun")
                    {
                        int intFunction_ID = Int32.Parse(item.Substring(7, item.Length - 7));
                        comm_group = new SqlCommand("Insert_GroupFunction", objConn.SqlConn());
                        comm_group.CommandType = CommandType.StoredProcedure;
                        comm_group.Parameters.AddWithValue("@Function_ID", intFunction_ID);
                        comm_group.Parameters.AddWithValue("@Group_ID", gropu_id);
                        try
                        {
                            comm_group.Connection.Open();
                            comm_group.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }
                        finally
                        {
                            comm_group.Connection.Close();
                            comm_group.Connection.Dispose();
                        }
                    }
                }
            }
        }
    }
}
