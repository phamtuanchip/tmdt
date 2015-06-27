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
    public class BU_Report_Other
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;

        #region Thống kê tổng doanh thu sản phẩm theo năm

        public DataTable SelectTotalOrderBills()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Thongkehoadonnhap", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                //sqlcom.Parameters.AddWithValue("@year", year);
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "sum");
                return dts.Tables["sum"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion
        #region Thống kê tổng doanh thu sản phẩm theo năm

        public DataTable SelectTotalOrder()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Thongkehoadonxuat", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                //sqlcom.Parameters.AddWithValue("@year", year);
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "sum");
                return dts.Tables["sum"];
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
