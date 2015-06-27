using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Bussiness;
using Entity;


namespace WebComputer.Control.User
{
    public partial class RightNew : System.Web.UI.UserControl
    {
        //String strNewsID = ""; 
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            TreeView1.Nodes.Clear();
            PopulateCategories();
        }

        //void getNewsID()
        //{
        //    try
        //    {
        //        string connectionString = "Server=.;Database=Webcomputer;UID=sa;PWD=sa";
        //        SqlConnection DBConnection = new SqlConnection(connectionString);
        //        DBConnection.Open();
        //        SqlCommand cm = new SqlCommand("Select Cat_ID from TB_SubCategory where SubCatID = " + StrSubID + "", DBConnection);
        //        StrCatID = ((int)cm.ExecuteScalar()).ToString();
        //        DBConnection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Response.Write("<script language='javascript'>alert('Loi~');</script>");
        //    }
        //}

        void PopulateCategories()
        {
            try
            {
                string sql = "Select Cat_ID, CatName from TB_Cat_News";
                SqlCommand sqlcom = new SqlCommand(sql, objConn.SqlConn());
                sqlcom.Connection.Open();
                SqlDataAdapter sqldap = new SqlDataAdapter(sqlcom);
                DataSet dts = new DataSet();
                sqldap.Fill(dts, "test");
                if (dts.Tables.Count > 0)
                {
                    foreach (DataRow row in dts.Tables[0].Rows)
                    {
                        TreeNode NewNode = new TreeNode(row["CatName"].ToString(), row["Cat_ID"].ToString(), "", "../../Home/News.aspx?NewsID=" + row["Cat_ID"].ToString() + "", "_parent");
                        //NewNode.PopulateOnDemand = true;
                        //if (row["Cat_ID"].ToString().Equals(StrCatID) && !string.IsNullOrEmpty(StrCatID))
                        //{
                        //    NewNode.Expand();
                        //}
                        //else
                        //{
                        //    NewNode.Collapse();
                        //}
                        //NewNode.SelectAction = TreeNodeSelectAction.Expand;
                        //PopulateSubCategories(NewNode);
                        //node.ChildNodes.Add(NewNode);
                        TreeView1.Nodes.Add(NewNode);

                    }
                }
                ////SqlCommand sqlQuery = new SqlCommand("Select Cat_ID, CatName from TB_Cat_News");
                //DataSet resultSet;
                //resultSet = RunQuery(sqlQuery);
                //if (resultSet.Tables.Count > 0)
                //{
                //    foreach (DataRow row in resultSet.Tables[0].Rows)
                //    {
                //        TreeNode NewNode = new TreeNode(row["CatName"].ToString(), row["Cat_ID"].ToString(), "", "../../Home/News.aspx?NewsID=" + row["Cat_ID"].ToString() + "", "_parent");
                //        //NewNode.PopulateOnDemand = true;
                //        //if (row["Cat_ID"].ToString().Equals(StrCatID) && !string.IsNullOrEmpty(StrCatID))
                //        //{
                //        //    NewNode.Expand();
                //        //}
                //        //else
                //        //{
                //        //    NewNode.Collapse();
                //        //}
                //        //NewNode.SelectAction = TreeNodeSelectAction.Expand;
                //        //PopulateSubCategories(NewNode);
                //        //node.ChildNodes.Add(NewNode);
                //        TreeView1.Nodes.Add(NewNode);

                //    }
                //}
            }
            catch (SqlException ce)
            {
                Response.Write("<script language='javascript'>alert('Unable to connect to SQL Server.');</script>");
            }
        }



        //private DataSet RunQuery(SqlCommand sqlQuery)
        //{
        //    string connectionString = "Server=.;Database=Webcomputer;UID=sa;PWD=sa";
        //    SqlConnection DBConnection =
        //        new SqlConnection(connectionString);
        //    SqlDataAdapter dbAdapter = new SqlDataAdapter();
        //    dbAdapter.SelectCommand = sqlQuery;
        //    sqlQuery.Connection = DBConnection;
        //    DataSet resultsDataSet = new DataSet();
        //    try
        //    {
        //        dbAdapter.Fill(resultsDataSet);
        //    }
        //    catch
        //    {
        //        Response.Write("<script language='javascript'>alert('Unable to connect to SQL Server.');</script>");
        //    }
        //    return resultsDataSet;
        //}
    }
}