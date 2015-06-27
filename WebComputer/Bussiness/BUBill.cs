using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entity;
namespace Bussiness
{
    public class BUBill
    {
        #region public variable
        public DataTable dt;
        public DataAccess da;
        public SqlCommand cmd;
        public DataSet ds;
        public SqlDataAdapter sda;
        #endregion
        #region Method
        public DataTable SelectAllBill()
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectAll_Bill", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "Bill");
                return ds.Tables["Bill"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public En_Bill SelectOneBill(int BillID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectOne_Bill", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("BillID", BillID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "Bill");
                DataTable dTable = new DataTable();
                dTable = ds.Tables["Bill"];
                En_Bill BEBill = new En_Bill(dTable.Rows[0]);
                return BEBill;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public DataTable SelectOneBillToBillDetails(int BillID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectOneBillToBillDetails", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("BillID", BillID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "Bill");
                return ds.Tables["Bill"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SelectQuantityProduct(int ProductID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Select_QuantityProduct", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Product_ID", ProductID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "QuantityProduct");
                return ds.Tables["QuantityProduct"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public bool UpdateQuantityProduct(int ProductID, int Quantity)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Update_QuantityProduct", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Product_ID",SqlDbType.Int);
                cmd.Parameters["@Product_ID"].Value = ProductID;
                cmd.Parameters.Add("@Quantity",SqlDbType.Int);
                cmd.Parameters["@Quantity"].Value = Quantity;

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
        public DataTable SelectProvName()
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectProvName_AddBill", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "ProvName");
                return ds.Tables["ProvName"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SelectCatName()
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectCatName_ToBill", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "CatName");
                return ds.Tables["CatName"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public  DataTable SearchBill(DateTime BuyDate, int BillID)
        { 
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("Search_Bill", da.SqlConn());
                cmd.Parameters.AddWithValue("@BuyDate",BuyDate);
                cmd.Parameters.AddWithValue("@BillID",BillID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SearchBill");
                return ds.Tables["SearchBill"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
       
        public DataTable SelectSubCatName(int Cat_ID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectSubName_ToBill", da.SqlConn());
                cmd.Parameters.AddWithValue("Cat_ID",Cat_ID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "SubCatName");
                return ds.Tables["SubCatName"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SelectProductName(int SubCatID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_SelectProductName_ToBill", da.SqlConn());
                cmd.Parameters.AddWithValue("SubCatID",SubCatID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "ProductName");
                return ds.Tables["ProductName"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable SelectProductToCart(int Product_ID)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_GetProduct_BuyProductID", da.SqlConn());
                cmd.Parameters.AddWithValue("Product_ID", Product_ID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "Product");
                return ds.Tables["Product"];
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public bool InsertDebt(int billid,string debtname, string arrears, int provid)
        {
            try
            {
                da = new DataAccess();
                cmd = new SqlCommand("SP_Insert_Debt", da.SqlConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BillID",SqlDbType.Int);
                cmd.Parameters["@BillID"].Value = billid;
                cmd.Parameters.Add("@DebName", SqlDbType.NVarChar);
                cmd.Parameters["@DebName"].Value = debtname;
                cmd.Parameters.Add("@Arrears",SqlDbType.VarChar);
                cmd.Parameters["@Arrears"].Value = arrears;

                cmd.Parameters.Add("@ProvID",SqlDbType.Int);
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
        #endregion
    }
}
