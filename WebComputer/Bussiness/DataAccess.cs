using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Bussiness
{
    public class DataAccess : System.Web.UI.Page
    {

        #region Connection Data
        private string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["WebcomputerConnectionString"].ConnectionString.ToString();

        public SqlConnection SqlConn()
        {
            SqlConnection SqlConn = new SqlConnection(this.strConn);
            return SqlConn;
        }
        #endregion Connection Date
        #region tieppb0605g@yahoo.com
        public string strConn_
        {
            get
            {
                return strConn;
            }
            set
            {
                strConn = value;
            }
        }
        #endregion
        #region Acction Log
        public void WriteLogLogin(int LoginSuccess, string strUsername)
        {
            DateTime Dt = System.DateTime.Now;
            string testdate = "10/10/2008";

            string IP = Context.Request.ServerVariables["REMOTE_ADDR"];
            string strSQL = "Insert into TB_ActionLog (DateTime, UserName, Ip, Status, TypeLog)";
            //strSQL = strSQL + " Values('" + Dt + "',N'" + strUsername.ToString().ToUpper() + "','" + IP.ToString() + "'," + LoginSuccess + ", 0)";
            strSQL = strSQL + " Values('" + testdate + "',N'" + strUsername.ToString().ToUpper() + "','" + IP.ToString() + "'," + LoginSuccess + ", 0)";
            SqlCommand myComm = new SqlCommand(strSQL, this.SqlConn());
            try
            {
                myComm.Connection.Open();
                myComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myComm.Connection.Close();
                myComm.Connection.Dispose();
            }
        }
        #endregion Acction Log
        #region Write Acction Log
        public void WriteActionLog(string FunctionName, string UserName, string DetailInfomation)
        {
            //string Dt = System.DateTime.Now.ToString();
            DateTime Dt = System.DateTime.Now;
            string IP = Context.Request.ServerVariables["REMOTE_ADDR"];
            SqlCommand comm = new SqlCommand("Insert_ActionLog", SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@DateTime", Dt);
            comm.Parameters.AddWithValue("@ActionEx", FunctionName);
            comm.Parameters.AddWithValue("@IpAddr", IP);
            comm.Parameters.AddWithValue("@UserName", UserName);
            comm.Parameters.AddWithValue("@DetailInformation", DetailInfomation);
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
        #endregion Write Acction Log






        public DataTable CreateDataTable(string strSQL)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(strSQL, SqlConn());
            SqlConn().Open();
            DataTable table = new DataTable();
            try
            {
                Adapter.Fill(table);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                SqlConn().Close();
                SqlConn().Dispose();
            }
            return table;
        }
    }
}
