using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Bussiness
{
    public class BUPaymentOrder
    {
        #region public variable
        public DataTable dt;
        public DataAccess da;
        public SqlCommand cmd;
        public DataSet ds;
        public SqlDataAdapter sda;
        #endregion
        public DataTable SelectAllPaymentOrder()
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectAll_PaymentOrder", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "PaymentOrder");
                return ds.Tables["PaymentOrder"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable GetTotalByProvID(int ProvID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_GetTotal_ByProvID", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProvID",ProvID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "GetTotal");
                return ds.Tables["GetTotal"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public bool InsertPaymentOrder(string ReasonPayment,decimal Quantity,string Employee, int provid)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Insert_PaymentOrder", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReasonPayment",SqlDbType.NVarChar);
                cmd.Parameters["@ReasonPayment"].Value = ReasonPayment;
                
                cmd.Parameters.Add("@Quantity",SqlDbType.Money);
                cmd.Parameters["@Qiantity"].Value = Quantity;

                cmd.Parameters.Add("@Employee",SqlDbType.NVarChar);
                cmd.Parameters["@Employee"].Value = Employee;
                cmd.Parameters.Add("@ProvID", SqlDbType.Int);
                cmd.Parameters["@ProvID"].Value = provid;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }
        }
        public DataTable CheckExistProvID(int ProvID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_CheckExist_ProvID", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProvID", ProvID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "CheckProvID");
                return ds.Tables["CheckProvID"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
    }
}
