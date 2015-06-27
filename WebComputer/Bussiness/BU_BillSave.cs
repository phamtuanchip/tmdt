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
    public class BU_BillSave
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;
        public DataTable SelectProvider()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectProvider", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "billprov");
                return dts.Tables["billprov"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        public DataTable SelectSubCategory()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectSubCategory", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "subcat");
                return dts.Tables["subcat"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        public DataTable SelectProduct()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectProduct", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "product");
                return dts.Tables["product"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }

        public DataTable ShowGridviewBill()
        {
            try
            {
                sqlcom = new SqlCommand("pr_ShowBillDetail", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "bill");
                return dts.Tables["bill"];
            }
            catch (Exception ce)
            {
                ce.ToString();
                return null;
            }
        }

        



        public bool InsertIDbill(string BillID)
        {
            bool test = false;
            try
            {
                sqlcom = new SqlCommand("pr_InsertBillID", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@BillID", BillID);
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                test = true;
            }
            catch (SqlException ce)
            {
                test = false;
                throw new Exception(ce.Message.ToString());
            }
            finally
            {
                sqlcom.Connection.Close();
                sqlcom.Connection.Dispose();

            }
            return test;
            
        }

        public bool InsertBillDetail(int ProID, string BillID, string ProName, decimal price, int quatity)
        {
            
            bool test = false;
            try
            {
                sqlcom = new SqlCommand("pr_InsertBillDetails", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@Product_ID", ProID);
                sqlcom.Parameters.AddWithValue("@BillID", BillID);
                sqlcom.Parameters.AddWithValue("@ProName", ProName);
                sqlcom.Parameters.AddWithValue("@Price", price);
                sqlcom.Parameters.AddWithValue("@Quatity", quatity);
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                test = true;
             }
            catch (SqlException ce)
            {
                test = false;
                throw new Exception(ce.Message.ToString());
            }
            finally
            {
                sqlcom.Connection.Close();
                sqlcom.Connection.Dispose();

            }
            return test;
        }

        public bool DeleteIDbillDetail(int prodcutid)
        {
            
            bool test = false;
            try
            {
                sqlcom = new SqlCommand("pr_DeleteBillDetailID", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@Product_ID", prodcutid);
               
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                test = true;
             }
            catch (SqlException ce)
            {
                test = false;
                throw new Exception(ce.Message.ToString());
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
