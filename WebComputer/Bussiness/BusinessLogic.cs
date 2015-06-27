using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Entity;

namespace Bussiness
{
    public class BusinessLogic : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        //public Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();

        #region CheckLogin
        public int GetIntValue(string FieldName, string TableName, string tblName, string Condition)
        {
            int intValue;
            string objStr = string.Empty;
            objStr = "SELECT " + FieldName + " FROM " + TableName + ", " + tblName + " WHERE " + Condition;
            SqlCommand objCmd = new SqlCommand(objStr, this.objConn.SqlConn());
            objCmd.Connection.Close();
            objCmd.Connection.Open();
            SqlDataReader dr = objCmd.ExecuteReader();
            if (dr.Read())
            {
                intValue = dr.GetInt32(0);
                objCmd.Connection.Close();
                objCmd.Dispose();
                return intValue;
            }
            else
            {
                intValue = -1;
                objCmd.Connection.Close();
                objCmd.Dispose();
                return intValue;
            }
        }
        public bool isExits(string FieldName, string TableName, string tblName, string Condition)
        {
            if (this.GetIntValue("Count(" + FieldName + ") As Total", TableName, tblName, Condition) > 0)
                return true;
            else
                return false;
        }
        public void AdminLogin(string strUsername, string strPassword)
        {
            int isLoginOK = 0;
            if (isExits("UserName", "TB_Member_Members", "TB_Member_Group", "UserName='" + strUsername.ToString().ToUpper() + "' AND Password='" + objEntities.EncodePassword(strPassword, "") + "' AND TB_Member_Members.Active=1 And TB_Member_Members.Group_ID=TB_Member_Group.Group_ID ANd TB_Member_Group.Active=1") == true)
            {
                isLoginOK = 1;
                //Ghi log đăng nhập
                objConn.WriteLogLogin(isLoginOK, strUsername);
                string strSQLFunctions = "SELECT TB_Admin_Function.FunctionCode FROM (TB_Admin_Function INNER JOIN TB_Member_Group_Function ON TB_Member_Group_Function.Function_ID = TB_Admin_Function.Function_ID ) INNER JOIN TB_Member_Members ON TB_Member_Group_Function.Group_ID = TB_Member_Members.Group_ID WHERE TB_Member_Members.UserName = '" + strUsername.ToString().ToUpper() + "' AND TB_Member_Members.Active = 1";
                SqlDataReader myDrd;
                SqlCommand Comm = new SqlCommand(strSQLFunctions, objConn.SqlConn());
                Comm.Connection.Open();
                myDrd = Comm.ExecuteReader();
                while (myDrd.Read())
                {
                    if (Session["admin_User_Functions"] != null)
                    {
                        Session["admin_User_Functions"] = Context.Session["admin_User_Functions"] + "," + myDrd["FunctionCode"].ToString();
                    }
                    else
                        Session["admin_User_Functions"] = myDrd["FunctionCode"].ToString();
                }
                Comm.Connection.Close();
                Session["AdminID"] = strUsername;
                if (HttpContext.Current.Request.QueryString["ReturnUrl"] != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(Session["AdminID"].ToString(), false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(Session["AdminID"].ToString(), false);
                    HttpContext.Current.Response.Redirect("Default.aspx");
                }
            }
            else
            {
                isLoginOK = 0;
                //Ghi log đăng nhập
                objConn.WriteLogLogin(isLoginOK, strUsername);
            }
        }
        #endregion CheckLogin
        #region Check Permission
        public bool Permission(string strAllowFunctions)
        {
            bool UserAllowed = false;
            string[] MyFunctions = strAllowFunctions.Split(',');
            foreach (string i in MyFunctions)
            {
                if (Session["admin_User_Functions"] != null)
                {
                    if (Session["admin_User_Functions"].ToString().IndexOf(i) != -1)
                    {
                        UserAllowed = true;
                        break;
                    }
                    else
                    {
                        UserAllowed = false;
                    }
                }
            }
            return UserAllowed;
        }
        #endregion Check Permission
        #region DataTable
        public DataTable CreateDataTable(string strSQL)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(strSQL, objConn.SqlConn());
            objConn.SqlConn().Open();
            DataTable table = new DataTable();
            try
            {
                Adapter.Fill(table);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objConn.SqlConn().Close();
                objConn.SqlConn().Dispose();
            }
            return table;
        }
        public DataTable CreateDataTable(string Store, bool Param)
        {
            DataTable table = new DataTable();
            if (Param == false)
            {
                SqlDataAdapter Adapter = new SqlDataAdapter(Store, objConn.SqlConn());
                objConn.SqlConn().Open();
                try
                {
                    Adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    objConn.SqlConn().Close();
                    objConn.SqlConn().Dispose();
                }
            }
            return table;
        }
        #endregion DataTable
        #region Get Language
        public void GetLanguage(DropDownList DDL_Language)
        {
            DDL_Language.Items.Add(new ListItem(" Hãy chọn ngôn ngữ ", ""));
            for (int i = 0; i < CreateDataTable("Get_Language").Rows.Count; i++)
            {
                DDL_Language.Items.Add(new ListItem(CreateDataTable("Get_Language").Rows[i]["LanguageName"].ToString(), CreateDataTable("Get_Language").Rows[i]["Language_ID"].ToString()));
            }
        }
        #endregion Get Language
        public void GetCatDocument(DropDownList DDL_Document)
        {
            DDL_Document.Items.Add(new ListItem(" Hãy chọn danh mục ", ""));
            for (int i = 0; i < CreateDataTable("Get_Language").Rows.Count; i++)
            {
                DDL_Document.Items.Add(new ListItem(CreateDataTable("Get_Language").Rows[i]["CatName"].ToString(), CreateDataTable("Get_Language").Rows[i]["Cat_ID"].ToString()));
            }
        }

        public void GetCatProduc(DropDownList DDL_CatPro)
        {
            DDL_CatPro.Items.Add(new ListItem(" Hãy chọn danh mục ", ""));
            for (int i = 0; i < CreateDataTable("Get_CatProduct").Rows.Count; i++)
            {
                DDL_CatPro.Items.Add(new ListItem(CreateDataTable("Get_CatProduct").Rows[i]["CatName"].ToString(), CreateDataTable("Get_CatProduct").Rows[i]["Cat_ID"].ToString()));
            }
        }
        public void GetProvider(DropDownList DDL_Provider)
        {
            DDL_Provider.Items.Add(new ListItem(" Hãy chọn danh mục ", ""));
            for (int i = 0; i < CreateDataTable("Get_Provider").Rows.Count; i++)
            {
                DDL_Provider.Items.Add(new ListItem(CreateDataTable("Get_Provider").Rows[i]["ProvName"].ToString(), CreateDataTable("Get_Provider").Rows[i]["ProvID"].ToString()));
            }
        }

        #region Tree Category
        public bool FindChildNode(int Cat_Id, DataTable dt)
        {
            bool Flag = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)Cat_Id == int.Parse(dt.Rows[i]["Parent"].ToString()))
                    Flag = true;
            }
            return Flag;
        }
        public string Create_Select_Tree(int Cat_Id, DataTable dt, int Parent_Id, string varSpace)
        {
            varSpace += "&nbsp;&nbsp;&nbsp;&nbsp";
            StringBuilder tbl = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == Cat_Id)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    string strSelected = string.Empty;
                    if (Parent_Id == intCat_Id)
                        strSelected = " selected ";
                    tbl.Append("<option value='" + intCat_Id + "'" + strSelected + ">" + varSpace + "-&nbsp;" + strCatName + "</option>");
                    if (FindChildNode(intCat_Id, dt))
                    {
                        tbl.Append(Create_Select_Tree(intCat_Id, dt, Parent_Id, varSpace));
                    }
                }
            }
            return tbl.ToString();
        }
        #endregion Tree Category
        #region Tree Cat News
        public string Create_CatNews_Tree(int Cat_Id, DataTable dt, string varSpace)
        {
            varSpace += "&nbsp;&nbsp;&nbsp;&nbsp";
            StringBuilder tbl = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == Cat_Id)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    bool boolActive = (bool)dt.Rows[i]["Active"];
                    tbl.Append(wrCatNews(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (FindChildNode(intCat_Id, dt))
                    {
                        tbl.Append(Create_CatNews_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            return tbl.ToString();
        }
        public string wrCatNews(int Cat_Id, int Parent, string CatName, bool Active, string varSpace)
        {
            StringBuilder tbl = new StringBuilder();
            string strCatName = string.Empty;
            if (Active == false)
                strCatName = "<span style='color:#FF0000'>" + CatName + "</span>";
            else
                strCatName = CatName;
            if (Parent == 0)
                tbl.Append("<img border='0' src='/Images/Admin/note.gif' width='8' height='12' align='absbottom'>&nbsp;<strong>" + strCatName + "</strong>");
            else
                tbl.Append(varSpace + "-&nbsp;" + strCatName);
            tbl.Append("&nbsp;&nbsp;&nbsp;<a href='Editor_Cat_Edit.aspx?id=" + Cat_Id + "' title='Sửa danh mục " + CatName + "'><img src='/images/Admin/edit_u.gif' border='0'></a>");
            if ((Cat_Id == 22) || (Cat_Id == 31) || (Cat_Id == 32) || (Cat_Id == 34) || (Cat_Id == 35) || (Cat_Id == 36))
            {
                tbl.Append("");
            }
            else
            {
                tbl.Append("&nbsp;&nbsp;&nbsp;<a href=\"JavaScript:if(confirm('Bạn có muốn xóa không?')){location.href='Editor_Cat_Delete.aspx?id=" + Cat_Id + "'};\" title='Xóa danh mục " + CatName + "'><img src='/Images/Admin/delete.gif' border='0'></a>");
            }
            tbl.Append("<br />");
            return tbl.ToString();
        }
        #endregion Tree Cat News
        #region Document
        public string Create_CatDocument_Tree(int Cat_Id, DataTable dt, string varSpace)
        {
            varSpace += "&nbsp;&nbsp;&nbsp;&nbsp";
            StringBuilder tbl = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intParent = int.Parse(dt.Rows[i]["Parent"].ToString());
                if (intParent == Cat_Id)
                {
                    int intCat_Id = int.Parse(dt.Rows[i]["Cat_Id"].ToString());
                    string strCatName = dt.Rows[i]["CatName"].ToString();
                    bool boolActive = (bool)dt.Rows[i]["Active"];
                    tbl.Append(wrCatDocument(intCat_Id, intParent, strCatName, boolActive, varSpace));
                    if (FindChildNode(intCat_Id, dt))
                    {
                        tbl.Append(Create_CatNews_Tree(intCat_Id, dt, varSpace));
                    }
                }
            }
            return tbl.ToString();
        }
        public string wrCatDocument(int Cat_Id, int Parent, string CatName, bool Active, string varSpace)
        {
            StringBuilder tbl = new StringBuilder();
            string strCatName = string.Empty;
            if (Active == false)
                strCatName = "<span style='color:#FF0000'>" + CatName + "</span>";
            else
                strCatName = CatName;
            if (Parent == 0)
                tbl.Append("<img border='0' src='/Images/Admin/note.gif' width='8' height='12' align='absbottom'>&nbsp;<strong>" + strCatName + "</strong>");
            else
                tbl.Append(varSpace + "-&nbsp;" + strCatName);
            tbl.Append("&nbsp;&nbsp;&nbsp;<a href='Document_Cat_Edit.aspx?id=" + Cat_Id + "' title='Sửa danh mục " + CatName + "'><img src='/images/Admin/edit_u.gif' border='0'></a>");
            tbl.Append("&nbsp;&nbsp;&nbsp;<a href=\"JavaScript:if(confirm('Bạn có muốn xóa không?')){location.href='Document_Cat_Delete.aspx?id=" + Cat_Id + "'};\" title='Xóa danh mục " + CatName + "'><img src='/Images/Admin/delete.gif' border='0'></a>");
            tbl.Append("<br />");
            return tbl.ToString();
        }
        #endregion
        #region Exec Store
        public DataSet Execute_Store(string Proceduce_Name)
        {
            DataSet dts = new DataSet();
            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(Proceduce_Name, objConn.SqlConn());
                adt.Fill(dts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                objConn.SqlConn().Close();
                objConn.SqlConn().Dispose();
            }
            return dts;
        }
        public DataSet Exec_Store(string ProductName, string strSearch, int intSearch)
        {
            DataSet dts = new DataSet();
            try
            {
                SqlDataAdapter adt = new SqlDataAdapter("Exec " + ProductName + " @strSearch = " + objEntities.SafeString(strSearch) + ", @intSearch = " + intSearch, objConn.SqlConn());
                adt.Fill(dts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                objConn.SqlConn().Close();
                objConn.SqlConn().Dispose();
            }
            return dts;
        }
        #endregion Exec Store
        #region Write Images
        public string wrImages(int LeadImage, string PathImage)
        {
            string strImage = string.Empty;
            if (LeadImage != 0)
            {
                string SQL = "Select PhotoID From TB_Images Where ID =" + LeadImage;
                SqlDataReader drd;
                SqlCommand comm = new SqlCommand(SQL, objConn.SqlConn());
                comm.CommandType = CommandType.Text;
                comm.Connection.Open();
                drd = comm.ExecuteReader();
                if (drd.Read())
                {
                    strImage = "<img src='" + PathImage + drd["PhotoID"].ToString() + "_T.jpg" + "' border='0'>";
                }
                drd.Close();
                drd.Dispose();
                comm.Connection.Close();
                comm.Connection.Dispose();
            }
            return strImage;
        }
        #endregion Write Images
        #region Show Logo, Banner
        public string ShowLogo(int Language_Id, int Cat_Id, int Location_ID)
        {
            StringBuilder tbl = new StringBuilder();
            string strCurrentPath = System.Web.HttpContext.Current.Request.ServerVariables["URL"].ToString();
            strCurrentPath = strCurrentPath.Substring(strCurrentPath.LastIndexOf("/") + 1, strCurrentPath.Length - (strCurrentPath.LastIndexOf("/") + 1));
            string strDateTime = System.Convert.ToString(System.DateTime.Now);
            strDateTime = objEntities.FormatDateTimeEN(strDateTime);
            string sql = "select top 1 LBRandom From TB_Cat_Logo Where active=1 and (Cat_Id = " + Cat_Id + " or PagePath='" + strCurrentPath + "') ORDER BY CreatedDate DESC";

            SqlCommand comm = new SqlCommand(sql, objConn.SqlConn());
            comm.CommandType = CommandType.Text;
            SqlDataReader drd = null;
            try
            {
                comm.Connection.Open();

                drd = comm.ExecuteReader();
                if (drd != null)
                {
                    if (drd.Read())
                    {
                        int intRandom = 0;
                        if ((bool)drd["LBRandom"] == true)
                        {
                            intRandom = 1;
                        }
                        //=====================================================================
                        int intWidth = 0;
                        SqlDataReader drd_logo = null;
                        SqlCommand commLogo = new SqlCommand("Get_List_Logo", objConn.SqlConn());
                        commLogo.CommandType = CommandType.StoredProcedure;
                        commLogo.Parameters.AddWithValue("@Language_id", Language_Id);
                        commLogo.Parameters.AddWithValue("@Cat_Id", Cat_Id);
                        commLogo.Parameters.AddWithValue("@Location_ID", Location_ID);
                        commLogo.Parameters.AddWithValue("@CurrentDate", strDateTime);
                        commLogo.Parameters.AddWithValue("@PagePath", strCurrentPath);
                        commLogo.Parameters.AddWithValue("@LBRandom", intRandom);
                        try
                        {
                            commLogo.Connection.Open();
                            drd_logo = commLogo.ExecuteReader();
                            if (Location_ID == 0)
                                intWidth = 180;
                            else
                                intWidth = 180;

                            tbl.Append(" <table width='100%' cellspacing='0' cellpadding='0'>");
                            if (drd_logo != null)
                            {
                                while (drd_logo.Read())
                                {
                                    tbl.Append(" <tr>");
                                    tbl.Append("    <td align='center'>");

                                    if (int.Parse(drd_logo["TypeLink"].ToString()) == 1)
                                        tbl.Append("        <img src=\"" + objEntities.GetPathLogo() + drd_logo["ImageName"].ToString() + "\" border='0' vspace='0' hspace='0' onMouseover=\"javascript:displayStatus('" + drd_logo["LogoURL"].ToString() + "');\" onClick=\"javascript:window.open('http://" + drd_logo["LogoURL"].ToString() + "');\" style='cursor:hand;' title='" + drd_logo["LogoName"].ToString() + "'>");
                                    else if (int.Parse(drd_logo["TypeLink"].ToString()) == 0)
                                        tbl.Append("        <img src=\"" + objEntities.GetPathLogo() + drd_logo["ImageName"].ToString() + "\" border='0' vspace='0' hspace='0' onMouseover=\"javascript:displayStatus('" + drd_logo["LogoURL"].ToString() + "');\" onClick=\"javascript:location.href('" + drd_logo["LogoURL"].ToString() + "');\" style='cursor:hand;' title='" + drd_logo["LogoName"].ToString() + "'>");

                                    tbl.Append("    </td>");
                                    tbl.Append(" </tr>");

                                }
                            }
                            tbl.Append(" </table>");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString() + ex.StackTrace);
                        }
                        finally
                        {
                            //if (drd_logo != null)
                            drd_logo.Close();
                            commLogo.Connection.Close();
                            commLogo.Connection.Dispose();
                        }
                        //=====================================================================
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + ex.StackTrace);
            }
            finally
            {
                //if (drd != null)
                drd.Close();
                comm.Connection.Close();
                comm.Connection.Dispose();
            }
            return tbl.ToString();
        }
        public string ShowBanner(int Language_Id)
        {
            StringBuilder tbl = new StringBuilder();
            string strCurrentPath = System.Web.HttpContext.Current.Request.ServerVariables["URL"].ToString();
            strCurrentPath = strCurrentPath.Substring(strCurrentPath.LastIndexOf("/") + 1, strCurrentPath.Length - (strCurrentPath.LastIndexOf("/") + 1));
            string strDateTime = System.Convert.ToString(System.DateTime.Now);
            strDateTime = objEntities.FormatDateTimeEN(strDateTime);
            //=====================================================================
            SqlDataReader drd_banner;
            SqlCommand commbanner = new SqlCommand("Get_List_Banner", objConn.SqlConn());
            commbanner.CommandType = CommandType.StoredProcedure;
            commbanner.Parameters.AddWithValue("@Language_id", Language_Id);
            commbanner.Parameters.AddWithValue("@CurrentDate", strDateTime);
            commbanner.Parameters.AddWithValue("@PagePath", strCurrentPath);
            try
            {
                commbanner.Connection.Open();
                drd_banner = commbanner.ExecuteReader();

                tbl.Append(" <table border='0' width='100%' cellspacing='0' cellpadding='0'>");
                while (drd_banner.Read())
                {
                    tbl.Append(" <tr>");
                    tbl.Append("    <td align='center' valign='bottom'>");
                    if (int.Parse(drd_banner["TypeLink"].ToString()) == 1)
                        tbl.Append("        <img src=\"" + objEntities.GetPathBanner() + drd_banner["ImageName"].ToString() + "\" border='0' width='380' height='63' onMouseover=\"javascript:displayStatus('" + drd_banner["BannerURL"].ToString() + "');\" onClick=\"javascript:window.open('http://" + drd_banner["BannerURL"].ToString() + "');\" style='cursor:hand' title='" + drd_banner["BannerName"].ToString() + "'>");
                    else if (int.Parse(drd_banner["TypeLink"].ToString()) == 0)
                        tbl.Append("        <img src=\"" + objEntities.GetPathBanner() + drd_banner["ImageName"].ToString() + "\" border='0' width='380' height='63' onMouseover=\"javascript:displayStatus('" + drd_banner["BannerURL"].ToString() + "');\" onClick=\"javascript:location.href('" + drd_banner["BannerURL"].ToString() + "');\" style='cursor:hand' title='" + drd_banner["BannerName"].ToString() + "'>");
                    tbl.Append("    </td>");
                    tbl.Append(" </tr>");
                }
                tbl.Append(" </table>");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + ex.StackTrace);
            }
            finally
            {
                commbanner.Connection.Close();
                commbanner.Connection.Dispose();
            }
            //=====================================================================
            return tbl.ToString();
        }
        #endregion Show Logo, Banner
    }
}
