using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Entity;
using Bussiness;

namespace WebComputer.Admin
{
    public partial class Editor_Xml_Relate_News : System.Web.UI.Page
    {
        private Bussiness.DataAccess objConn = new Bussiness.DataAccess();
        protected Entity.Entities objEntities = new Entity.Entities();
        protected Bussiness.BusinessLogic objBusinessLogic = new Bussiness.BusinessLogic();
        private int EditorCat_ID = 0;
        private string szXmlRequest = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.szXmlRequest = objEntities.SafeString(Request.Form.ToString().Trim());
            if (szXmlRequest != string.Empty && szXmlRequest != "")
                EditorCat_ID = int.Parse(szXmlRequest);
            this.GetRelateNews();
        }
        protected void GetRelateNews()
        {
            if (EditorCat_ID != 0)
            {
                SqlDataReader drd = null;
                SqlCommand comm = new SqlCommand("Get_Relate_News", objConn.SqlConn());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Cat_Id", EditorCat_ID);
                try
                {
                    comm.Connection.Open();
                    drd = comm.ExecuteReader();

                    Response.Write("<select name='SRelateNewsSource' size='7' ondblclick=\"javascript:AddNews();\">");
                    while (drd.Read())
                    {
                        Response.Write("<option value='" + drd["News_ID"].ToString() + "'>" + objEntities.CutString(drd["Subject"].ToString(), 30) + "</option>");
                    }
                    Response.Write("</select>");
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
        }
    }
}
