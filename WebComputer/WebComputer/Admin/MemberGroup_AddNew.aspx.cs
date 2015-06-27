using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class MemberGroup_AddNew : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        private Entity.Entities objEntities = new Entity.Entities();
        private Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        protected Hashtable Lang = new Hashtable();
        private string isChecked = string.Empty;
        private bool[] Permission = new bool[5];
        private int[] Function_Id = new int[5];
        private int[] Function_Group_Id = new int[5];
        private string[] bcheck = new string[5];

        private string strAllowFunctions = "membergroup_addnew";
        private string strFunctionName = "Thêm mới nhóm thành viên";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = objEntities.GetLanguage("MemberGroup_Manager");
            this.MemberGroupAddNew.Text = Lang["AddNew"].ToString();
            this.Back_AddNew.Value = Lang["Return"].ToString();

            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    this.CMSMemberGroup.InnerHtml = MemberGroups_AddNew();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected string MemberGroups_AddNew()
        {
            StringBuilder tbl = new StringBuilder();
            tbl.Append("<table width='98%' border='0' cellspacing='0' cellpadding='0' align='center' style='border: 1px solid; border-collapse:collapse; border-color: #BBBBBB'>");
            tbl.Append("    <tr>");
            tbl.Append("        <th colspan='2' class='Title' height='20' width='100%' align='left'>");
            tbl.Append(this.Lang["AddMemberGroup"]);
            tbl.Append("        </th>");
            tbl.Append("    </tr>");
            tbl.Append("    <tr>");
            tbl.Append("        <td class='ListContent' align='left' width='30%'>");
            tbl.Append("<b>" + this.Lang["GroupName"].ToString() + "</b>");
            tbl.Append("        </td>");
            tbl.Append("        <td width='70%' align='left'>");
            tbl.Append("            <input class='textbox' maxlength='50' type='textbox' size='41' name='GroupName'>");
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append("    <tr>");
            tbl.Append("        <td class='ListContent' align='left' width='30%'>");
            tbl.Append("<b>" + this.Lang["Description"].ToString() + "</b>");
            tbl.Append("        </td>");
            tbl.Append("        <td width='70%' align='left'>");
            tbl.Append("            <textarea class='textbox' maxlength='255' cols='30' rows='3' name='GroupDesc'></textarea>");
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append("    <tr>");
            tbl.Append("        <td class='ListContent' align='left' width='30%'>");
            tbl.Append("<b>" + this.Lang["Active"].ToString() + "</b>");
            tbl.Append("        </td>");
            tbl.Append("        <td width='70%' align='left'>");
            tbl.Append("            <input type='checkbox' name='Active' value='yes' checked>");
            tbl.Append("        </td>");
            tbl.Append("    </tr>");
            tbl.Append("</table>");
            tbl.Append("<br>");
            tbl.Append("<table width='98%' border='0' cellspacing='0' cellpadding='0' align='center' style='border: 1px solid; border-collapse:collapse; border-color: #BBBBBB'>");
            tbl.Append("    <tr>");
            tbl.Append("        <th class='Title' colspan='6' height='20' width='100%' align='left'>");
            tbl.Append(this.Lang["PermisionForGroup"].ToString());
            tbl.Append("        </th>");
            tbl.Append("    </tr>");
            tbl.Append("    <tr>");
            //====================================Function Name=======================================
            SqlDataReader drd;
            SqlCommand comm = new SqlCommand("Get_FunctionName", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            drd = comm.ExecuteReader(CommandBehavior.CloseConnection);
            tbl.Append("    <td class='member_title'>");
            tbl.Append(Lang["NameGroup"]);
            tbl.Append("    </td>");
            while (drd.Read())
            {
                tbl.Append("<td class='member_title'>");
                tbl.Append(drd.GetString(0).ToString());
                tbl.Append("</td>");
            }
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
            //==================================End Function Name=====================================
            tbl.Append("    </tr>");
            //===================================Function Group=======================================
            comm = new SqlCommand("Get_FunctionGroup", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection.Open();
            drd = comm.ExecuteReader(CommandBehavior.CloseConnection);
            while (drd.Read())
            {
                for (int i = 0; i < 5; i++)
                {
                    Permission[i] = false;
                    bcheck[i] = string.Empty;
                }

                tbl.Append("<tr>");
                tbl.Append("    <td align='left' width='40%' height='20'>");
                tbl.Append("        <input type='hidden' name=\"group" + drd.GetInt32(0).ToString() + "\" value='1'>");
                tbl.Append("        <a href='JavaScript:checkAllGroupItem(" + drd.GetInt32(0).ToString() + ",document.aspnetForm.group" + drd.GetInt32(0).ToString() + ")' class='member_list'>" + drd.GetString(1).ToString() + "</a>");
                tbl.Append("    </td>");
                //======================================================================
                SqlDataReader drd_sub;
                SqlCommand comm_sub = new SqlCommand("Get_Function", objConn.SqlConn());
                comm_sub.CommandType = CommandType.StoredProcedure;
                comm_sub.Parameters.AddWithValue("@Group_Id", drd.GetInt32(0).ToString());
                comm_sub.Connection.Open();
                drd_sub = comm_sub.ExecuteReader(CommandBehavior.CloseConnection);
                while (drd_sub.Read())
                {
                    int ID = drd_sub.GetInt32(4) - 1;
                    Permission[ID] = true;
                    Function_Group_Id[ID] = drd.GetInt32(0);
                    Function_Id[ID] = drd_sub.GetInt32(0);
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
                        tbl.Append("<input type='checkbox' name='chbFunc" + Function_Id[i].ToString() + "' value='check' id='" + Function_Group_Id[i] + "'>");
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
            drd.Close();
            drd.Dispose();
            comm.Connection.Close();
            comm.Connection.Dispose();
            //=================================End Function Group=====================================
            tbl.Append("    </tr>");
            tbl.Append("</table>");
            return tbl.ToString();
        }
        protected void MemberGroupAddNew_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script language='javascript'>alert('Bạn phải đăng nhập / You must login');location.href='Login.aspx?ReturnUrl=MEMBERGROUP_addnew.aspx';</script>");
            }
            else
            {
                if (objBusinessLogic.Permission(this.strAllowFunctions) == true)
                {
                    InsertMemberGroup();
                }
                else
                {
                    Response.Redirect("EOFPermission.aspx");
                }
            }
        }
        protected void InsertMemberGroup()
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
            SqlCommand comm = new SqlCommand("Insert_MemberGroup", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
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
                string sqlMax = "Select Max(Group_ID) as maxGroupID From TB_Member_Group";
                SqlDataReader myRd;
                SqlCommand comm_sub = new SqlCommand(sqlMax, objConn.SqlConn());
                comm_sub.Connection.Open();
                myRd = comm_sub.ExecuteReader(CommandBehavior.CloseConnection);
                if (myRd.Read())
                {
                    int intGroupIDMax = myRd.GetInt32(0);
                    foreach (string item in HttpContext.Current.Request.Form)
                    {
                        if (item.Substring(0, 6) == "chbFun")
                        {
                            int intFunction_ID = Int32.Parse(item.Substring(7, item.Length - 7));
                            SqlCommand comm_group = new SqlCommand("Insert_GroupFunction", objConn.SqlConn());
                            comm_group.CommandType = CommandType.StoredProcedure;
                            comm_group.Parameters.AddWithValue("@Function_ID", intFunction_ID);
                            comm_group.Parameters.AddWithValue("@Group_ID", intGroupIDMax);
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
                Response.Write("<script language='javascript'>alert('Thêm mới thành công'); location.href='MEMBERGROUP_list.aspx';</script>");
            }
        }
    }
}
