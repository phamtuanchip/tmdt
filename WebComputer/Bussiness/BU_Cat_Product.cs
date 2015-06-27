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
    public class BU_Cat_Product
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;
        public string Erro;
        public DataTable SelectAllCatPro()
        {
            try
            {
                sqlcom = new SqlCommand("pr_selectAllCatePro", objConn.SqlConn());
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
                        SqlCommand comm = new SqlCommand("Delete_CatPro", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@CatPro_Id", intCatPro_Id);
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
        public bool UpdateCatPro(int catid,string catname, string catdes, bool check, int language, DateTime date)
        {
            bool test = false;
            try
            {
                sqlcom = new SqlCommand("Update_CatPro", this.objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                //comm.Parameters.Add("@Cat_Id",SqlDbType.NVarChar);
                sqlcom.Parameters.AddWithValue("@Cat_Id", catid);
                //comm.Parameters.Add("@CatName", SqlDbType.NVarChar);
                sqlcom.Parameters.AddWithValue("@CatName", catname);
                sqlcom.Parameters.AddWithValue("@CatDes", catdes);
                sqlcom.Parameters.AddWithValue("@Active", check);
                sqlcom.Parameters.AddWithValue("@Language_Id", language);
                sqlcom.Parameters.AddWithValue("@StartDate", date);
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


    }
}

