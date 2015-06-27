using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Bussiness;
using Entity;

namespace WebComputer.Control.User
{
    public partial class Left : System.Web.UI.UserControl
    {
        String StrSubID = "";
        String StrCatID = "";
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
       // public Bussiness.DataAccess objConn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            TreeView1.Nodes.Clear();
            this.lbl_luottruycap.Text = count_truycap().ToString();
            if (Request.QueryString["SubId"] != null && Request.QueryString["SubId"].ToString() != "")
            {
                StrSubID = objEntities.SafeString(Request.QueryString["SubId"].ToString());
                if (!string.IsNullOrEmpty(StrSubID))
                {
                    getCatID();
                }
            }
            if (Request.QueryString["CatId"] != null && Request.QueryString["CatId"].ToString() != "")
            {
                StrCatID = objEntities.SafeString(Request.QueryString["SubId"].ToString());
                if (!string.IsNullOrEmpty(StrSubID))
                {
                    getCatID();
                }
            }
            PopulateCategories();
            


            //TreeView1.Nodes.Clear();
            //StrSubID = Request["SubId"];
            //if (!string.IsNullOrEmpty(StrSubID))
            //{
            //    getCatID();
            //}
            //else
            //{
            //    StrCatID = Request["CatId"];
            //    if (!string.IsNullOrEmpty(StrCatID))
            //    {

            //    }
            //}
            //PopulateCategories();
           // demnguoitruycap();
            //ShowSPNew();
        }
        #region Đếm người truy cập
        public string count_online()
        {
            string l = "";
            try
            {


                l += Application["ActiveUsers"].ToString();
            }
            catch
            {

            }
            return l;
        }
        public string count_truycap()
        {
            string l = "";
            try
            {
                l += Application["Access"].ToString();
            }
            catch
            {

            }
            return l;
        }
        #endregion
        void getCatID()
        {
            try
            {

                SqlCommand cm = new SqlCommand("Select Cat_ID from TB_SubCategory where SubCatID = " + StrSubID + "", objConn.SqlConn());
                cm.Connection.Open();
                StrCatID = ((int)cm.ExecuteScalar()).ToString();
               // DBConnection.Close();
                cm.Connection.Close();

               
            }
            catch (Exception ce)
            {
                Response.Write("<script language='javascript'>alert('Loi~');</script>"+ce.ToString());
            }
        }

        void PopulateCategories()
        {
            SqlCommand sqlQuery = new SqlCommand(
                "Select Cat_ID, CatName from TB_Cat_Product");
            DataSet resultSet;
            resultSet = RunQuery(sqlQuery);
            if (resultSet.Tables.Count > 0)
            {
                foreach (DataRow row in resultSet.Tables[0].Rows)
                {
                    TreeNode NewNode = new
                        TreeNode(row["CatName"].ToString(),
                        row["Cat_ID"].ToString());
                    //NewNode.PopulateOnDemand = true;
                    if (row["Cat_ID"].ToString().Equals(StrCatID) && !string.IsNullOrEmpty(StrCatID))
                    {
                        NewNode.Expand();
                    }
                    else
                    {
                        NewNode.Collapse();
                    }
                    NewNode.SelectAction = TreeNodeSelectAction.Expand;
                    PopulateSubCategories(NewNode);
                    //node.ChildNodes.Add(NewNode);
                    TreeView1.Nodes.Add(NewNode);

                }
            }
        }

        void PopulateSubCategories(TreeNode node)
        {
            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.CommandText = "Select Cat_ID, SubCatID, SubName From TB_SubCategory " +
                " Where Cat_ID = @Cat_ID";
            sqlQuery.Parameters.Add("@Cat_ID", SqlDbType.Int).Value = node.Value;
            DataSet resultSet;
            resultSet = RunQuery(sqlQuery);
            DataSet ResultSet = RunQuery(sqlQuery);
            if (resultSet.Tables.Count > 0)
            {
                foreach (DataRow row in resultSet.Tables[0].Rows)
                {

                    TreeNode NewNode;
                    if (row["SubCatID"].ToString().Equals(StrSubID) && !string.IsNullOrEmpty(StrSubID))
                    {
                        NewNode = new
                        TreeNode(row["SubName"].ToString(), row["SubCatID"].ToString(), "", "../../Home/Product.aspx?CatId=" + row["Cat_ID"] + "&SubId=" + row["SubCatID"].ToString() + "", "_parent");

                        NewNode.SelectAction = TreeNodeSelectAction.Expand;
                    }
                    else
                    {
                        NewNode = new
                        TreeNode(row["SubName"].ToString(), row["SubCatID"].ToString(), "", "../../Home/Product.aspx?CatId=" + row["Cat_ID"] + "&SubId=" + row["SubCatID"].ToString() + "", "_parent");

                        NewNode.SelectAction = TreeNodeSelectAction.Expand;

                    }

                    // node.PopulateOnDemand = true;
                    node.ChildNodes.Add(NewNode);
                }
            }
        }

        //public void ShowSPNew()
        //{
        //    DataSet dts = new DataSet();
        //    SqlDataAdapter adt = new SqlDataAdapter();
        //    SqlCommand comm = new SqlCommand("ShowSPNew", objConn.SqlConn());
        //    comm.CommandType = CommandType.StoredProcedure;

        //    comm.Connection.Open();
        //    adt.SelectCommand = comm;
        //    adt.Fill(dts);

        //    this.dtList.DataSource = dts;
        //    this.dtList.DataBind();
        //}

        private DataSet RunQuery(SqlCommand sqlQuery)
        {
            //string connectionString = "Server=.;Database=Webcomputer;UID=sa;PWD=sa";
            //SqlConnection DBConnection =
            //    new SqlConnection(connectionString);
            
            SqlDataAdapter dbAdapter = new SqlDataAdapter();
            dbAdapter.SelectCommand = sqlQuery;
          //  sqlQuery.Connection = DBConnection; objConn.SqlConn();
            sqlQuery.Connection = objConn.SqlConn();
            DataSet resultsDataSet = new DataSet();
            try
            {
                dbAdapter.Fill(resultsDataSet);
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('Unable to connect to SQL Server.');</script>");
            }
            return resultsDataSet;
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.DropDownList1.SelectedIndex == 0)
        //    {
        //        this.lblMessager.Text = "Hãy chọn Website!";
        //    }
        //    else if (this.DropDownList1.SelectedIndex == 1)
        //    {
        //        this.lblMessager.Text = "Hãy chọn Website!";
        //    }


        //}
        //public void demnguoitruycap()
        //{
        //    int demo;
        //    demo = CountVisitedCouter();
        //    this.Luottruycap.Text = demo.ToString();
        //}
        protected int CountVisitedCouter()
        {
            int output_ = 0;
            SqlCommand comm = new SqlCommand("GET_COUNT_VISITED", objConn.SqlConn());
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                comm.Connection.Open();
                output_ = (int)comm.ExecuteScalar();
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
            return output_;
        }
        public string wrNewsImages(int Language_ID)
        {
            string strImage = string.Empty;
            if (Language_ID != 0)
            {
                string SQL = "select top 4 * from TB_Product as p inner join TB_Images as i on p.LeadImage = i.ID where p.Language_ID =" + Language_ID+" order by P.Product_ID desc";
                SqlDataReader drd;
                SqlCommand comm = new SqlCommand(SQL, objConn.SqlConn());
                comm.CommandType = CommandType.Text;
                comm.Connection.Open();
                drd = comm.ExecuteReader();
                while (drd.Read())
                {
                    if (strImage == string.Empty)
                        strImage = "<a href='../../Home/ProductDetails.aspx?ProId=" + drd["Product_Id"].ToString() + "'> <img src='" + objEntities.GetPathLibraryImage() + drd["PhotoID"].ToString() + "_T.jpg" + "' width='130'  border='0' alt='Chi tiết'> </a>";
                    else
                        strImage += "<br />" + "<a href='../../Home/ProductDetails.aspx?ProId=" + drd["Product_Id"].ToString() + "'> <img src='" + objEntities.GetPathLibraryImage() + drd["PhotoID"].ToString() + "_T.jpg" + "' width='130'  border='0' alt='Chi tiết'> </a>";
                }
                drd.Close();
                comm.Connection.Close();
                comm.Connection.Dispose();
            }
            return strImage;
        }
    }
}