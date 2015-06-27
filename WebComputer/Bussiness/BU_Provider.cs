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
    public class BU_Provider
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;

        public DataTable SelectAllProvider()
        {
            try
            {
                sqlcom = new SqlCommand("pr_selectAllProvider", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "testprov");
                return dts.Tables["tesprov"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }

        public void DeleteProvider()
        {
            foreach (string item in HttpContext.Current.Request.Form)
            {
                if (item.Length > 9)
                {
                    if (item.Substring(0, 9) == "chbDelete")
                    {
                        int intProviderId = int.Parse(item.Substring(9, item.Length - 9));
                        SqlCommand comm = new SqlCommand("Delete_Provider", this.objConn.SqlConn());
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@ProvId", intProviderId);
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
                    }
                }
            }
        }
        public bool UpdateProvider(int ProvId, string ProvName, string ProvDes, bool check, int language, string Address, string Phone, string Website)
        {
            bool test = false;
            try
            {
                sqlcom = new SqlCommand("Update_Provider", this.objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@ProvId", ProvId);
                sqlcom.Parameters.AddWithValue("@ProvName", ProvName);
                sqlcom.Parameters.AddWithValue("@ProvDes", ProvDes);
                sqlcom.Parameters.AddWithValue("@Active", check);
                sqlcom.Parameters.AddWithValue("@Language_Id", language);
               // sqlcom.Parameters.AddWithValue("@StartDate", date);
                sqlcom.Parameters.AddWithValue("@Address",Address);
                sqlcom.Parameters.AddWithValue("@Phone", Phone);
                sqlcom.Parameters.AddWithValue("@Website", Website);
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

        #region Hiển thị thông tin nhà cung cấp khi thống kê
        public DataTable SelectAllProviderReport()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectAllProviderReport", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "prov");
                return dts.Tables["prov"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Hiển thị tổng số nhà cung cấp
        public DataTable SelectSumProvider()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SlectTongsoprovider", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "Sumprov");
                return dts.Tables["Sumprov"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Hiển thị nhà cung cấp có công nợ lớn nhất
        public DataTable SelectMaxDebtProvider()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Timnhacungcapcocongnolonnhat", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "MaxdebtProv");
                return dts.Tables["MaxdebtProv"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Hiển thị nhà cung cấp có công nợ nhỏ nhất
        public DataTable SelectMinDebtProvider()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectMinProviderDebt", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "MindebtProv");
                return dts.Tables["MindebtProv"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Hiển thị tổng sản phẩm của nhà cung cấp
        public DataTable SelectTotalProductInProvider()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Tongsanphamcuanhacungcap", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "TotalProv");
                return dts.Tables["TotalProv"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

    }
}
