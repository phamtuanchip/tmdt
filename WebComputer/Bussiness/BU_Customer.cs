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
    public class BU_Customer
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;

        #region Hiển thị danh sách nhà cung cấp
        public DataTable SelectAllCustomer()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectAllCustomer", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "cus");
                return dts.Tables["cus"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Tổng khách hàng đã mua
        public DataTable SelectTotalCustomerSale()
        {
            try
            {
                sqlcom = new SqlCommand("pr_TotalCustomerSale", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "cusSale");
                return dts.Tables["cusSale"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Hiển thị khách hàng mua nhiều nhất
        public DataTable SelectTotalMaxCus()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectTotalMaxCus", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "MaxSale");
                return dts.Tables["MaxSale"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Hiển thị khách hàng mua sản phẩm có giá trị lớn nhất
        public DataTable SelectMoneyTotalMaxCus()
        {
            try
            {
                sqlcom = new SqlCommand("pr_CusMaxSaleMoney", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "MaxMoneySale");
                return dts.Tables["MaxMoneySale"];
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
