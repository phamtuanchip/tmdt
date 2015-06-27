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
    public class Report_Product
    {
        public DataAccess objConn = new DataAccess();
        public SqlCommand sqlcom;
        public SqlDataAdapter sqldap;
        public DataSet dts;

        public DataTable SelectReportProduct()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Thongketongsanpham", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "report_pro");
                return dts.Tables["report_pro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }




        #region Thống kê tổng sản phẩm xuất
        
           public DataTable SelectProductXuatkho(int Product_ID)
        {
            try
            {
                sqlcom = new SqlCommand("pr_thongkesptongxuat", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add("@Product_ID",SqlDbType.Int);
                sqlcom.Parameters["@Product_ID"].Value = Product_ID;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "report_pro");
                return dts.Tables["report_pro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Thống kê tổng nhập sản phẩm

        public DataTable SelectProductNhapkho(int Product_ID)
        {
            try
            {
                sqlcom = new SqlCommand("pr_thongkesptongnhap", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add("@Product_ID",SqlDbType.Int);
                sqlcom.Parameters["@Product_ID"].Value = Product_ID;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "report_pro");
                return dts.Tables["report_pro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }



        #endregion

        #region Thống kê tổng sản phẩm trong kho
        #region Lấy thông tin mã sản phẩm, tên sản phẩm

        public DataTable SelectProductIDName(int Product_ID)
        {
            try
            {
                sqlcom = new SqlCommand("pr_Laythongtinsanphamtheoid", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add("@Product_ID",SqlDbType.Int);
                sqlcom.Parameters["@Product_ID"].Value = Product_ID;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "report_pro");
                return dts.Tables["report_pro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion
        #region Hàm tính tổng doanh số của từng sản phẩm

        public DataTable SelectReportTotalMoneyProduct(int Product_ID)
        {
            try
            {
                sqlcom = new SqlCommand("pr_tongdoanhsotungsanpham", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add("@Product_ID",SqlDbType.Int);
                sqlcom.Parameters["@Product_ID"].Value = Product_ID;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "report_pro");
                return dts.Tables["report_pro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }

        #endregion






        public DataTable SelectSumQuatityProduct()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Thongketongsanpham", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "sumpro");
                return dts.Tables["sumpro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }

        #endregion

        #region Thống kê sản phẩm có hóa đơn lớn nhất
        public DataTable SelectMaxProduct()
        {
            try
            {
                sqlcom = new SqlCommand("pr_MaxProduct", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "Maxpro");
                return dts.Tables["Maxpro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }

        #endregion

        #region Thống kê sản phẩm có hóa đơn nhỏ nhất
        public DataTable SelectMinOrderProduct()
        {
            try
            {
                sqlcom = new SqlCommand("pr_SelectMinOrderProduct", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "Minpro");
                return dts.Tables["Minpro"];
            }
            catch (SqlException ce)
            {
                ce.ToString();
                return null;
            }

        }
        #endregion

        #region Thống kê sản phẩm được bán nhiều nhất
        public DataTable SelectMaxSaleProduct()
        {
            try
            {
                sqlcom = new SqlCommand("pr_Thongkespbannhieunhat", objConn.SqlConn());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection.Open();
                sqlcom.ExecuteNonQuery();
                sqldap = new SqlDataAdapter(sqlcom);
                dts = new DataSet();
                sqldap.Fill(dts, "Maxprosale");
                return dts.Tables["Maxprosale"];
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
