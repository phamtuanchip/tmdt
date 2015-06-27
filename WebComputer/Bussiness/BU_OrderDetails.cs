using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace Bussiness
{
    public class BU_OrderDetails
    {
        #region public variable
        public DataTable dt;
        public DataAccess da;
        public SqlCommand cmd;
        public DataSet ds;
        public SqlDataAdapter sda;
        //public int OrderID;
        #endregion
        public BE_OrderDetails SelectOrderDetails(int OrderID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Select_OrderDetails", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("OrderID",OrderID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "OrderDetails");
                DataTable dTable = new DataTable();
                dTable = ds.Tables["OrderDetails"];
                BE_OrderDetails BEOrderdetails = new BE_OrderDetails(dTable.Rows[0]);
                return BEOrderdetails;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SelectOneOrderDetails(int OrderID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectOne_OrderDetails", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("OrderID",OrderID);
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

        public BE_OrderDetails TotalOrderDetails(int OrderID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Total_OrderDetails", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("OrderID", OrderID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "TotalOrderDetails");
                DataTable dTable = new DataTable();
                dTable = ds.Tables["TotalOrderDetails"];
                BE_OrderDetails BEOrderdetails = new BE_OrderDetails(dTable.Rows[0]);
                return BEOrderdetails;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public bool UpdateStatusOrder(int OrderID,bool Status)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Update_Order",da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID",SqlDbType.Int);
                cmd.Parameters["@OrderID"].Value = OrderID;
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Value = Status;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;

                //sqlcom = new SqlCommand("Update_CatPro", this.objConn.SqlConn());
                //sqlcom.CommandType = CommandType.StoredProcedure;
                ////comm.Parameters.Add("@Cat_Id",SqlDbType.NVarChar);
                //sqlcom.Parameters.AddWithValue("@Cat_Id", catid);
                ////comm.Parameters.Add("@CatName", SqlDbType.NVarChar);
                //sqlcom.Parameters.AddWithValue("@CatName", catname);
                //sqlcom.Parameters.AddWithValue("@CatDes", catdes);
                //sqlcom.Parameters.AddWithValue("@Active", check);
                //sqlcom.Parameters.AddWithValue("@Language_Id", language);
                //sqlcom.Parameters.AddWithValue("@StartDate", date);
                //sqlcom.Connection.Open();
                //sqlcom.ExecuteNonQuery();
                //test = true;
                
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }
        }
    }
}

