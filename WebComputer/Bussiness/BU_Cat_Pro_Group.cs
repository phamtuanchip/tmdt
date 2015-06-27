using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Bussiness
{
    public class BU_Cat_Pro_Group
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;

        public DataTable SelectAllCatProGroup()
        {
            try
            {
                sqlcom = new SqlCommand("Get_All_SubCategory", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "testcat");
                return dts.Tables["testcat"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        public void DeleteCatPro()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intCatPro_Id = int.Parse(item.Substring(9, item.Length - 9));
                        SqlCommand comm = new SqlCommand("Delete_CatProGroup", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@SubCatPro_Id", intCatPro_Id);
                        try
                        {
                            comm.Connection.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ce)
                        {
                            ce.ToString();
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
        public bool UpdateCatProGroup(int SubCatID, string catname, string catdes, bool check, int language, int catid)
        {
            bool test = false;
            try
            {
                sqlcom = new SqlCommand("Update_CatProGroup", this.objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@SubCatID", SubCatID);
                sqlcom.Parameters.AddWithValue("@SubName", catname);
                sqlcom.Parameters.AddWithValue("@SubDes", catdes);
                sqlcom.Parameters.AddWithValue("@Active", check);
                sqlcom.Parameters.AddWithValue("@Language_Id", language);
               //sqlcom.Parameters.AddWithValue("@StartDate", date);
                sqlcom.Parameters.AddWithValue("@Cat_Id", catid);
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                test = false;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                sqlcom.Connection.Close();
                sqlcom.Connection.Dispose();

            }
            return test;
        }

        //public void CatProGroup_EditView()
        //{
        //    SqlDataReader drd;
        //    SqlCommand comm = new SqlCommand("Get_CatProGroup", this.objConn.SqlConn());
        //    comm.CommandType = CommandType.StoredProcedure;
        //    comm.Parameters.AddWithValue("@SubCatId", id);
        //    comm.Connection.Open();
        //    drd = comm.ExecuteReader();
        //    if (drd.Read())
        //    {
        //        this.tbCatProGroupTitle.Text = drd["SubName"].ToString();
        //        this.Content_CatProGroup.Value = drd["SubDes"].ToString();
        //        if ((bool)drd["Active"])
        //        {
        //            this.cbActive.Checked = true;
        //        }
        //        this.DDL_Language.SelectedValue = drd["language_id"].ToString();
        //        this.DDL_CatId.SelectedValue = drd["Cat_ID"].ToString();
        //        strFromDate = drd["CreateDate"].ToString();

        //    }
        //    drd.Close();
        //    drd.Dispose();
        //    comm.Connection.Close();
        //    comm.Connection.Dispose();
        //}

    }
}
