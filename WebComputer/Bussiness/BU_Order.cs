using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Bussiness
{
    public class BU_Order
    {
        #region public variable
        public DataTable dt;
        public DataAccess da;
        public SqlCommand cmd;
        public DataSet ds;
        public SqlDataAdapter sda;
        #endregion
        #region SelectAll
        public DataTable SelectAll()
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectAll_Order", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "Order");
                return ds.Tables["Order"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SearchOrder(int OrderID, string OrderDate)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SearchByOrderID_Order", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID",SqlDbType.Int);
                cmd.Parameters["@OrderID"].Value = OrderID;

                cmd.Parameters.Add("@OrderDate",SqlDbType.DateTime);
                cmd.Parameters["@OrderDate"].Value = OrderDate;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "Search");
                return ds.Tables["Search"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SearchOrderID(int OrderID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SearchOrderBy_OrderID", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID",SqlDbType.Int);
                cmd.Parameters["@OrderID"].Value = OrderID;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchOrderID");
                return ds.Tables["SearchOrderID"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SearchOrderDate(string OrderDate)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SearchOrderBy_OrderDate", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                cmd.Parameters["@OrderDate"].Value = OrderDate;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchOrderDate");
                return ds.Tables["SearchOrderDate"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        #endregion

    }
}
