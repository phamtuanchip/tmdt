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
using Bussiness;


namespace WebComputer.Home
{
    public partial class Build : System.Web.UI.Page
    {
        public Bussiness.DataAccess objConn = new DataAccess();
        public Entity.Entities objEntities = new Entity.Entities();
        public Bussiness.BusinessLogic objBusinessLogic = new BusinessLogic();
        public Bussiness.Function objfunc = new Function();
        
        decimal _TotalPrice = 0;
        DataTable objDT;
        DataRow objDR;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotalPrice.Text = "0.0";
            //Session.Remove("cpu_price");
            //Session.Remove("main_price");
            //Session.Remove("ram_price");
            //Session.Remove("hdd_price");
            //Session.Remove("odd_price");
            //Session.Remove("vga_price");
            //Session.Remove("monitor_price");
            //Session.Remove("case_price");
            //Session.Remove("power_price");
            //Session.Remove("keyboard_price");
            //Session.Remove("mouse_price");
            //Session.Remove("speaker_price");


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            //DropDownList5.SelectedIndex = 0;
            //DropDownList6.SelectedIndex = 0;
            //DropDownList7.SelectedIndex = 0;
            //DropDownList8.SelectedIndex = 0;
            //DropDownList9.SelectedIndex = 0;
            //DropDownList10.SelectedIndex = 0;
            //DropDownList11.SelectedIndex = 0;
            //DropDownList12.SelectedIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MakeCart();

            ArrayList _pName = new ArrayList();

            if (Session["cpu"] == null)
            { }
            else
            {
                _pName.Add(Session["cpu"]);
            }

            if (Session["main"] == null)
            { }
            else
            {
                _pName.Add(Session["main"]);
            }

            if (Session["ram"] == null)
            { }
            else
            {
                _pName.Add(Session["ram"]);
            }

            if (Session["hdd"] == null)
            { }
            else
            {
                _pName.Add(Session["hdd"]);
            }

            if (Session["odd"] == null)
            { }
            else
            {
                _pName.Add(Session["odd"]);
            }
            if (Session["vga"] == null)
            { }
            else
            {
                _pName.Add(Session["vga"]);
            }
            if (Session["monitor"] == null)
            { }
            else
            {
                _pName.Add(Session["monitor"]);
            }
            if (Session["case"] == null)
            { }
            else
            {
                _pName.Add(Session["case"]);
            }
            if (Session["power"] == null)
            { }
            else
            {
                _pName.Add(Session["power"]);
            }
            if (Session["keyboard"] == null)
            { }
            else
            {
                _pName.Add(Session["keyboard"]);
            }
            if (Session["mouse"] == null)
            { }
            else
            {
                _pName.Add(Session["mouse"]);
            }
            if (Session["speaker"] == null)
            { }
            else
            {
                _pName.Add(Session["speaker"]);
            }

            ArrayList _pPrice = new ArrayList();
            if (Session["cpu_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["cpu_price"]);
            }

            if (Session["main_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["main_price"]);
            }

            if (Session["ram_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["ram_price"]);
            }

            if (Session["hdd_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["hdd_price"]);
            }

            if (Session["odd_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["odd_price"]);
            }
            if (Session["vga_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["vga_price"]);
            }
            if (Session["monitor_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["monitor_price"]);
            }
            if (Session["case_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["case_price"]);
            }
            if (Session["power_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["power_price"]);
            }
            if (Session["keyboard_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["keyboard_price"]);
            }
            if (Session["mouse_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["mouse_price"]);
            }
            if (Session["speaker_price"] == null)
            { }
            else
            {
                _pPrice.Add(Session["speaker_price"]);
            }

            AddToCart(_pName, _pPrice);

            //Session.Remove["cpu"];
            //Session.Remove["main"];
            //Session.Remove["ram"];
            //Session.Remove["hdd"];
            //Session.Remove["odd"];
            //Session.Remove["vga"];
            //Session.Remove["monitor"];
            //Session.Remove["case"];
            //Session.Remove["power"];
            //Session.Remove["keyboard"];
            //Session.Remove["mouse"];
            //Session.Remove["speaker"];


            Response.Redirect("CartShow.aspx");
        }

        public void MakeCart()
        {
            if (Session["cart"] == null)
            {
                objDT = new DataTable("Cart");
                objDT.Columns.Add("ID");
                objDT.Columns["ID"].AutoIncrement = true;
                objDT.Columns["ID"].AutoIncrementSeed = 1;

                objDT.Columns.Add("ProductName");
                objDT.Columns.Add("Price");
                objDT.Columns.Add("Quantity");
                objDT.Columns.Add("Total");
                objDT.Columns.Add("Product_ID");


                Session["cart"] = objDT;
            }
            else
            {
                objDT = (DataTable)Session["cart"];
            }
        }

        public void AddToCart(ArrayList p_name, ArrayList p_price)
        {
            for (int i = 0; i < p_name.Count; i++)
            {
                objDT = (DataTable)Session["cart"];

                Common cls = new Common();
                int indexOfItem = cls.IsExistItemInShoppingCart(p_name[i].ToString(), objDT);

                if (indexOfItem != -1)
                {
                    objDT.Rows[indexOfItem]["Quantity"] = Convert.ToInt32(objDT.Rows[indexOfItem]["Quantity"]) + 1;
                }
                else
                {
                    objDR = objDT.NewRow();
                    objDR["ProductName"] = p_name[i].ToString();
                    objDR["Price"] = p_price[i];
                    objDR["Quantity"] = 1;
                    objDR["Product_ID"] = GetProductID(p_name[i].ToString());
                    objDR["Total"] = Convert.ToDecimal(p_price[i]);
                    objDT.Rows.Add(objDR);
                }
            }
            Session["cart"] = objDT;
            Session["sum"] = GetItemTotal();
        }

        protected int GetProductID(string _productName)
        {
            int _pId = 0;
            string strSql = "select Product_Id from TB_Product where Product_Name = '" + _productName.Trim() + "'";
            SqlCommand comn = new SqlCommand(strSql, objConn.SqlConn());

            comn.Connection.Open();
            SqlDataReader read = comn.ExecuteReader();
            while (read.Read())
            {
                _pId = Convert.ToInt32(read[0].ToString());
            }
            comn.Connection.Close();
            return _pId;
        }
        public decimal GetItemTotal()
        {
            int intCounter;
            decimal decRunningTotal = 0;
            DataRow objDr;

            for (intCounter = 0; intCounter < objDT.Rows.Count; intCounter++)
            {
                objDr = objDT.Rows[intCounter];
                decRunningTotal = decRunningTotal + (Convert.ToDecimal(objDr["Price"]) * Convert.ToDecimal(objDr["Quantity"]));

            }
            return decRunningTotal;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cpu"] = DropDownList1.Items[DropDownList1.SelectedIndex].Text.Trim();
            Session["cpu_price"] = DropDownList1.SelectedValue;
            Cal_TotalPrice();
        }

        protected decimal Cal_TotalPrice()
        {
            decimal _CpuPrice = Convert.ToDecimal(Session["cpu_price"]);
            decimal _MainPrice = Convert.ToDecimal(Session["main_price"]);
            decimal _RamPrice = Convert.ToDecimal(Session["ram_price"]);
            decimal _HddPrice = Convert.ToDecimal(Session["hdd_price"]);
            decimal _OddPrice = Convert.ToDecimal(Session["odd_price"]);
            decimal _VgaPrice = Convert.ToDecimal(Session["vga_price"]);
            decimal _MonitorPrice = Convert.ToDecimal(Session["monitor_price"]);
            decimal _CasePrice = Convert.ToDecimal(Session["case_price"]);
            decimal _PowerPrice = Convert.ToDecimal(Session["power_price"]);
            decimal _KeyboardPrice = Convert.ToDecimal(Session["keyboard_price"]);
            decimal _MousePrice = Convert.ToDecimal(Session["mouse_price"]);
            decimal _SpeakerPrice = Convert.ToDecimal(Session["speaker_price"]);

            _TotalPrice += _CpuPrice + _MainPrice + _RamPrice + _HddPrice + _OddPrice + _VgaPrice + _MonitorPrice + _CasePrice + _PowerPrice + _KeyboardPrice + _MousePrice + _SpeakerPrice;

            lblTotalPrice.Text = objfunc.ChangeTypeMoney(objEntities.SplitString(_TotalPrice.ToString()));

            return _TotalPrice;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["main"] = DropDownList2.Items[DropDownList2.SelectedIndex].Text.Trim();
            Session["main_price"] = DropDownList2.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["ram"] = DropDownList3.Items[DropDownList3.SelectedIndex].Text.Trim();
            Session["ram_price"] = DropDownList3.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["hdd"] = DropDownList4.Items[DropDownList4.SelectedIndex].Text.Trim();
            Session["hdd_price"] = DropDownList4.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["odd"] = DropDownList5.Items[DropDownList5.SelectedIndex].Text.Trim();
            Session["odd_price"] = DropDownList5.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["vga"] = DropDownList6.Items[DropDownList6.SelectedIndex].Text.Trim();
            Session["vga_price"] = DropDownList6.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["monitor"] = DropDownList7.Items[DropDownList7.SelectedIndex].Text.Trim();
            Session["monitor_price"] = DropDownList7.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["case"] = DropDownList8.Items[DropDownList8.SelectedIndex].Text.Trim();
            Session["case_price"] = DropDownList8.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["power"] = DropDownList9.Items[DropDownList9.SelectedIndex].Text.Trim();
            Session["power_price"] = DropDownList9.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["keyboard"] = DropDownList10.Items[DropDownList10.SelectedIndex].Text.Trim();
            Session["keyboard_price"] = DropDownList10.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["mouse"] = DropDownList11.Items[DropDownList11.SelectedIndex].Text.Trim();
            Session["mouse_price"] = DropDownList11.SelectedValue;
            Cal_TotalPrice();
        }

        protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["speaker"] = DropDownList12.Items[DropDownList12.SelectedIndex].Text.Trim();
            Session["speaker_price"] = DropDownList12.SelectedValue;
            Cal_TotalPrice();
        }
    }
}
