using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.IO;

namespace Bussiness
{
    public class Function
    {
        public static Function Instance = new Function();
        private String User = "ADMINBANHANG";

        #region Chuyen so sang chu
        public String DocSo(double n)
        {

            string strSo = n.ToString();
            string str = "";

            try
            {
                int len = (int)strSo.Length / 3;

                if (len * 3 < strSo.Length) len++;

                string[] t = new string[len];

                int i = 0;

                while (strSo != "")
                {

                    if (strSo.Length > 3)
                    {

                        t[i] = strSo.Substring(strSo.Length - 3, 3);

                        strSo = strSo.Substring(0, strSo.Length - 3);

                    }

                    else
                    {

                        t[i] = strSo;

                        strSo = "";

                    }

                    i++;

                }



                string temp;

                for (i = t.Length - 1; i >= 0; i--)
                {

                    temp = Doc3(t[i]);

                    if (temp.Trim() != "")
                    {

                        str += temp.Trim() + " " + DonVi(i + 1) + " ";

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;

        }
        public String DonVi(int n)
        {
            string str = "";
            switch (n.ToString())
            {
                case "0":
                    str = "VN";
                    break;
                case "1":
                    str = "đồng VN";
                    break;
                case "2":
                    str = "ngàn";
                    break;
                case "3":
                    str = "triệu";
                    break;
                case "4":
                    str = "tỷ";
                    break;
            }

            return str;

        }
        public String Doc3(string n)
        {
            string tram = string.Empty, chuc = string.Empty, dv = string.Empty;
            if (n.Length == 3)
            {
                tram = n[0].ToString();
                chuc = n[1].ToString();
                dv = n[2].ToString();
            }
            if (n.Length == 2)
            {
                chuc = n[0].ToString();
                dv = n[1].ToString();
            }
            if (n.Length == 1)
            {
                dv = n[0].ToString();
            }
            if (n != "000")
            {
                if (tram != "") tram = So(int.Parse(tram)) + " trăm";
                if (chuc != "")
                {
                    switch (chuc)
                    {
                        case "0":
                            if (dv != "0")
                            {
                                chuc = "lẻ"; dv = So(int.Parse(dv));
                            }
                            else
                            {
                                dv = "";
                                chuc = "";
                            }
                            break;
                        case "1":
                            chuc = " mười";
                            if (dv != "0")
                            {
                                if (dv == "5")
                                {
                                    dv = "lăm";
                                }
                                else
                                {
                                    dv = So(double.Parse(dv));
                                }
                            }
                            else
                            {
                                dv = "";
                            }
                            break;
                        default:
                            chuc = So(int.Parse(chuc)) + " mươi";
                            if (dv == "5")
                            {
                                dv = "lăm";
                            }
                            else
                            {
                                if (dv != "0") dv = So(int.Parse(dv));
                                else dv = "";
                            }
                            //dv = So(int.Parse(dv));
                            break;
                    }
                }
                else
                {
                    if (chuc != "")
                    {
                        switch (chuc)
                        {
                            case "1":
                                chuc = " mươi";
                                if (dv != "0")
                                {
                                    if (dv == "5")
                                    {
                                        dv = "lăm";
                                    }
                                    else
                                    {
                                        dv = So(int.Parse(dv));
                                    }
                                }
                                break;
                            default:
                                chuc = So(int.Parse(chuc)) + " mươi";
                                if (dv == "5")
                                {
                                    dv = "lăm";
                                }
                                else
                                {
                                    dv = So(int.Parse(dv));
                                }
                                break;
                        }
                    }
                    else
                    {
                        dv = So(int.Parse(dv));
                    }
                }
            }
            else
            {
                tram = "";
                chuc = "";
                dv = "";
            }
            return tram + " " + chuc + " " + dv;
        }
        public String So(double n)
        {
            string str = "";
            switch (n.ToString())
            {
                case "0":
                    str = "không";
                    break;
                case "1":
                    str = "một";
                    break;
                case "2":
                    str = "hai";
                    break;
                case "3":
                    str = "ba";
                    break;
                case "4":
                    str = "bốn";
                    break;
                case "5":
                    str = "năm";
                    break;
                case "6":
                    str = "sáu";
                    break;
                case "7":
                    str = "bảy";
                    break;
                case "8":
                    str = "tám";
                    break;
                case "9":
                    str = "chín";
                    break;
            }
            return str;
        }
        #endregion

        #region dấu phân cách phần trăm
        public string ChangeTypeMoney(string str)
        {
            int count = str.Length % 3;
            int flg = 0;
            int number = str.Length / 3;
            if (count == 0)
                number = number - 1;
            for (int z = 1; z <= number; z++)
            {
                if (str.Length - 3 * z - flg >= count)
                {
                    str = str.Insert(str.Length - 3 * z - flg, ".");
                    flg = flg + 1;
                }
            }


            return str;
        }
        #endregion

        #region AddFieldSttToDataTable
        /// <summary>
        /// Thêm trường số thứ tự (STT) vào trong DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable AddSTTToDataTable(DataTable dt)
        {
            int intPos;
            intPos = 0;
            DataTable dtReturn = new DataTable();
            try
            {

                dtReturn = dt;

                dtReturn.Columns.Add("STT");

                if (dtReturn.DefaultView.Count > 0)
                {
                    foreach (DataRow dr in dtReturn.Rows)
                    {

                        dr["STT"] = intPos + 1;

                        intPos += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtReturn;
        }
        #endregion

        #region HasKyTuLa
        /// <summary>
        /// Kiểm tra một String có chứa ký tự lạ hay không
        /// </summary>
        /// <param name="strTest"></param>
        /// <returns></returns>
        public bool HasKyTuLa(string strTest)
        {
            bool bTest;
            bTest = true;
            try
            {
                if (strTest.IndexOf(' ') > 0)
                {
                    bTest = false;
                }
                else
                {
                    for (int i = 0; i < strTest.Length; i++)
                    {
                        if (((strTest[i] < 'A') || (strTest[i] > 'z')) && ((strTest[i] < '0') || (strTest[i] > '9')))
                            bTest = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bTest;
        }
        #endregion

        /// <summary>
        /// Kiểm tra xem một chuỗi có phải là một dữ liệu kiểu số hay không
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsNumber(String number)
        {
            bool bTest;
            bTest = true;
            try
            {
                Convert.ToDecimal(number.Trim());
            }
            catch
            {
                bTest = false;
            }
            return bTest;
        }

        #region ExportReportToWord
        /// <summary>
        /// Xuất báo cáo ra file word
        /// </summary>
        /// <param name="page"></param>
        /// <param name="report"></param>
        public void ExportReportToWord(Page page, ReportClass report)
        {
            MemoryStream oStream; // using System.IO
            oStream = (MemoryStream)
            report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
            page.Response.Clear();
            page.Response.Buffer = true;
            page.Response.ContentType = "application/msword";
            page.Response.BinaryWrite(oStream.ToArray());
            page.Response.End();
        }
        #endregion
        #region ExportReportToPDF
        /// <summary>
        /// Xuất báo cáo ra file PDF
        /// </summary>
        /// <param name="page"></param>
        /// <param name="report"></param>
        public void ExportReportToPDF(Page page, ReportClass report)
        {
            MemoryStream oStream; // using System.IO
            oStream = (MemoryStream)
            report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            page.Response.Clear();
            page.Response.Buffer = true;
            page.Response.ContentType = "application/pdf";
            page.Response.BinaryWrite(oStream.ToArray());
            page.Response.End();
        }
        #endregion
        #region WriteErrorToDataBase
        /// <summary>
        /// Ghi vào CSDL lỗi trong khi chạy chương trình
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="ThaoThac"></param>
        /// <param name="TenTrang"></param>
        public void WriteErrorToDataBase(System.Exception ex, String ThaoThac, String TenTrang)
        {
            try
            {

            }
            catch (System.Exception exx)
            {
                WriteErrorToDataBase(exx, "Thao tác WriteErrorToDataBase", TenTrang.Trim());
            }
        }
        #endregion

        /// <summary>
        /// Ghi lại thao tác của người sử dụng mỗi khi cập nhật thông tin trong CSDL
        /// </summary>
        /// <param name="MaNhanVien"></param>
        /// <param name="ThaoTac"></param>
        /// <param name="TrangThaoTac"></param>
        /// <param name="KetQua"></param>
        public void Write_ThaoTac_ToDataBase(String MaNhanVien, String ThaoTac, String TrangThaoTac, String KetQua)
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ghi lại thao tác của người sử dụng mỗi khi cập nhật thông tin trong CSDL
        /// Có sử dụng Transaction
        /// </summary>
        /// <param name="MaNhanVien"></param>
        /// <param name="ThaoTac"></param>
        /// <param name="TrangThaoTac"></param>
        /// <param name="KetQua"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        public void Write_ThaoTac_ToDataBase(String MaNhanVien, String ThaoTac, String TrangThaoTac, String KetQua, SqlConnection conn, SqlTransaction trans)
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Truy xuất CSDL
        /// <summary>
        /// Mục đích: Lấy ra một Connection
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            //  String strConn = MessageUtils.GetMessage(MessageKey.dbConnection);
            AppSettingsReader _configReader = new AppSettingsReader();
            //SqlConnection conn = new SqlConnection("data source=DEV-SERVER;initial catalog=DCT_ACC;UID=sa;PWD=sa");//_configReader.GetValue("Main.ConnectionString", typeof(string)).ToString());
            SqlConnection conn = new SqlConnection(_configReader.GetValue("Main.ConnectionString", typeof(string)).ToString());
            return conn;
        }
        /// <summary>
        /// Mục đích: Lấy ra một DataTable có câu Query là sql (có dùng transaction)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public DataTable GetDataTable(String sql, String tableName, SqlConnection conn, SqlTransaction trans)
        {
            DataTable dt;
            try
            {
                if (tableName == null || tableName.Trim().Equals(""))
                { dt = new DataTable(); }
                else { dt = new DataTable(tableName); }
                SqlCommand cmd = new SqlCommand(sql, conn, trans); ;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Mục đích: Lấy ra một DataTable có câu Query là sql (không dùng transaction)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetDataTable(String sql, String tableName)
        {

            DataTable dt;
            try
            {
                if (tableName == null || tableName.Trim().Equals(""))
                { dt = new DataTable(); }
                else { dt = new DataTable(tableName); }
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Mục đích: Lấy ra một DataSet có câu Query là sql (có dùng transaction)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public DataSet GetDataSet(String sql, String tableName, SqlConnection conn, SqlTransaction trans)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn, trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (tableName == null || tableName.Trim().Equals(""))
                {
                    da.Fill(ds);
                }
                else
                {
                    da.Fill(ds, tableName);
                }
            }
            catch
            {
                throw new System.Exception("Lỗi lấy dữ liệu");
            }
            return ds;
        }
        /// <summary>
        /// Mục đích: Lấy ra một DataSet có câu Query là sql (không dùng transaction)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetDataSet(String sql, String tableName)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                if (tableName == null || tableName.Trim().Equals(""))
                {
                    da.Fill(ds);
                }
                else
                {
                    da.Fill(ds, tableName);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
            return ds;
        }
        /// <summary>
        /// Mục đích: Cập nhật CSDL có câu Query là sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int UpdateData(String sql)
        {
            int i = 0;
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
            return i;
        }

        /// <summary>
        /// Mục đích: Cập nhật CSDL có câu Query là sql (Có dùng transaction)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int UpdateData(String sql, SqlConnection conn, SqlTransaction trans)
        {
            int Count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn, trans);
                Count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
            return Count;
        }
        #endregion
        #region SetPagerButtonStates

        /// <summary>
        /// Dùng để điền vào GridView một thanh Navigato phân trang
        /// Hàm này do SơnPC đảm nhiệm, ai có thắc mắc xin hỏi SơnPC
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="gvPagerRow"></param>
        /// <param name="page"></param>
        /// <param name="ButtonFirst"></param>
        /// <param name="ButtonPrevious"></param>
        /// <param name="ButtonNext"></param>
        /// <param name="ButtonLast"></param>
        /// <param name="DropDownListPageSelector"></param>

        public void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page, String ButtonFirst, String ButtonPrevious, String ButtonNext, String ButtonLast, String DropDownListPageSelector)
        {
            try
            {
                int pageIndex = gridView.PageIndex;
                int pageCount = gridView.PageCount;
                Button btnFirst = (Button)gvPagerRow.FindControl(ButtonFirst.Trim());
                Button btnPrevious = (Button)gvPagerRow.FindControl(ButtonPrevious.Trim());
                Button btnNext = (Button)gvPagerRow.FindControl(ButtonNext.Trim());
                Button btnLast = (Button)gvPagerRow.FindControl(ButtonLast.Trim());
                btnFirst.Enabled = btnPrevious.Enabled = (pageIndex != 0);
                btnNext.Enabled = btnLast.Enabled = (pageIndex < (pageCount - 1));
                DropDownList ddlPageSelector = (DropDownList)gvPagerRow.FindControl(DropDownListPageSelector.Trim());
                ddlPageSelector.Items.Clear();
                for (int i = 1; i <= gridView.PageCount; i++)
                {
                    ddlPageSelector.Items.Add(i.ToString());
                }
                ddlPageSelector.SelectedIndex = pageIndex;
                //Anonymous method (see another way to do this at the bottom)
                ddlPageSelector.SelectedIndexChanged += delegate
                {
                    gridView.PageIndex = ddlPageSelector.SelectedIndex;
                    gridView.DataBind();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Load_ExistItem
        /// <summary>
        /// Thực hiện khi load một dữ liệu lên combobox
        /// Hàm này bác SơnNX hay dùng, ai dùng thì xin liên hệ với Bác SơnNX
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="dt"></param>
        /// <param name="index"></param>
        public void Load_ExistItem(DropDownList dr, DataTable dt, String index)
        {
            try
            {
                for (int i = 0; i < dr.Items.Count; i++)
                {
                    dr.SelectedIndex = i;
                    if (dr.SelectedValue.ToString().Trim() == dt.Rows[0][index].ToString().Trim())
                    {
                        break;
                    }
                }
                if (dr.SelectedValue.ToString().Trim() != dt.Rows[0][index].ToString().Trim())
                {
                    dr.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// Di chuyển đến trang lỗi
        /// </summary>
        /// <param name="page"></param>
        /// <param name="Message"></param>
        public void RedirectToPageError(Page page, String Message)
        {
            page.Session.Add("Message", Message.Trim());
            page.Response.Redirect("~/UI/ErrorPage/ErrorPage.aspx");
        }

        // chịu trach nhiem boi nguyenLinh
        /// <summary>
        /// startCode là 2 ký tự bắt đầu.
        /// svCode là tên cột.
        /// stable là tên bảng.
        /// </summary>
        /// <param name="sStartCode"></param>
        /// <param name="svCode"></param>
        /// <param name="stable"></param>
        /// <returns></returns>
        public string CodeInc(string sStartCode, string svCode, string stable)
        {
            string sSql = "select Max(cast(substring(" + svCode.Trim() + ",3,7)as int))as Max from " + stable.Trim();
            DataTable table = Function.Instance.GetDataTable(sSql, "");
            int vCodeMax = Convert.ToInt32(table.Rows[0]["Max"].ToString());
            bool blnResult = true;
            string[] sZez0 ={ "000000", "00000", "0000", "000", "00", "0", "" };
            int n = 0;
            int m;
            int i = 0;
            string sTemp = "9";
            string sResult = string.Empty;
            do
            {
                m = Convert.ToInt32(sTemp);
                if (vCodeMax > n && vCodeMax < m)
                {
                    vCodeMax += 1;
                    sResult = sStartCode.Trim() + sZez0[i].Trim() + vCodeMax;
                    blnResult = false;

                }
                else
                {
                    n = m;
                    sTemp = m + "9";
                    i += 1;
                }
                //end if

            } while (blnResult);
            //end do.. while
            return sResult.Trim();
        }
        //end code inc

        /// <summary>
        /// Lấy giá trị trong CSDL theo một bảng nào đó
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="WhereFieldName"></param>
        /// <param name="WhereFieldValue"></param>
        /// <param name="TenTruongLayDuLieu"></param>
        /// <returns></returns>
        public object GetValue(String TableName, String WhereFieldName, String WhereFieldValue, String TenTruongLayDuLieu)
        {
            try
            {
                String sql = String.Empty;
                sql += "Select " + TenTruongLayDuLieu.Trim() + " From " + TableName.Trim() + " Where " + WhereFieldName.Trim() + " = '" + WhereFieldValue.Trim() + "'";
                DataTable table = Function.Instance.GetDataTable(sql, "");
                if (table.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return table.Rows[0][TenTruongLayDuLieu.Trim()];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Kiểm tra một chuỗi có phải là định dạng ngày hay không
        /// </summary>
        /// <param name="StringDate"></param>
        /// <returns></returns>
        public bool IsDate(String StringDate)
        {
            try
            {
                Convert.ToDateTime(StringDate.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }


        #region CreateCode
        /// <summary>
        /// Mục đích tạo một mã tự tăng 
        /// </summary>
        /// <param name="HT">Tiền tố</param>
        /// <param name="code">Mã code cũ</param>
        /// <returns></returns>
        public String CreateCode(String TienTo, String TableName, String FieldName)
        {
            string contractCode = "";
            string bCode;
            int eCode;
            String code = GET_MAX(TableName.Trim(), FieldName.Trim(), TienTo.Trim());
            if (code.Trim().Equals(String.Empty))
            { eCode = 1; }
            else
            {
                eCode = int.Parse(code);
                eCode = eCode + 1;
            }
            bCode = TienTo + eCode.ToString();
            contractCode = bCode;
            return contractCode;
        }
        #endregion


        private String GET_MAX(String TableName, String FieldName, String TienTo)
        {
            String sql = String.Empty;
            //sql += "select IsNull(MAX(MaKhachHang),'') MAX from TBL_KHACHHANG";
            sql += "select MAX(cast(t.MAX as int)) MAX ";
            sql += "from ";
            sql += "(select SUBSTRING(isnull(" + FieldName.Trim() + ",'" + TienTo.Trim() + "0')," + Convert.ToString(TienTo.Trim().Length + 1) + ",LEN(isNull(" + FieldName.Trim() + ",'" + TienTo.Trim() + "0'))) MAX from " + TableName.Trim() + ") t";
            DataTable table = Function.Instance.GetDataTable(sql, "");
            return table.Rows[0]["MAX"].ToString().Trim();
        }

        public DataTable CreateEmptyTmain(String Dscr)
        {
            try
            {
                String sql = String.Empty;
                sql += "Select distinct vName From vObject Where Dscr ='" + Dscr.Trim() + "'";
                DataTable table = GetDataTable(sql, "");
                DataTable tableReturn = new DataTable();
                String[] s = new String[table.Rows.Count + 2];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tableReturn.Columns.Add(table.Rows[i]["vName"].ToString().Trim());
                    s[i] = String.Empty;
                }
                tableReturn.Columns.Add("idauto");
                tableReturn.Columns.Add("TenHangHoa");
                s[table.Rows.Count] = String.Empty;
                s[table.Rows.Count + 1] = String.Empty;
                tableReturn.Rows.Add(s);
                return tableReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Điền dữ liệu vào DropDownList
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="TextField"></param>
        /// <param name="ValueField"></param>
        /// <param name="dr"></param>
        /// 

        #region FillDataToDropDownList
        public void FillDataToDropDownList(String TableName, String TextField, String ValueField, DropDownList dr)
        {
            try
            {
                String sql = String.Empty;
                sql += "Select " + TextField.Trim() + "," + ValueField.Trim() + " From " + TableName.Trim();
                DataTable table = GetDataTable(sql, "");
                dr.Items.Clear();
                dr.Items.Add(new ListItem("-- Chọn --", "0"));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    dr.Items.Add(new ListItem(table.Rows[i][TextField.Trim()].ToString().Trim() + " - " + table.Rows[i][ValueField.Trim()].ToString().Trim(), table.Rows[i][ValueField.Trim()].ToString().Trim()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillDataToDropDownList(String TableName, String TextField, DropDownList dr)
        {
            try
            {
                String sql = String.Empty;
                String ValueField = TextField.Trim();
                sql += "Select " + TextField.Trim() + " From " + TableName.Trim();
                DataTable table = GetDataTable(sql, "");
                dr.Items.Clear();
                dr.Items.Add(new ListItem("-- Chọn --", "0"));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    dr.Items.Add(new ListItem(table.Rows[i][ValueField.Trim()].ToString().Trim(), table.Rows[i][ValueField.Trim()].ToString().Trim()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void FillDataToDropDownList(String TableName, String[] TextField, String ValueField, DropDownList dr)
        {
            try
            {
                String sql = String.Empty;
                //sql += "Select " + TextField.Trim() + "," + ValueField.TrimEnd() + " From " + TableName.Trim();
                sql += "Select ";
                for (int i = 0; i < TextField.Length; i++)
                {
                    sql += " " + TextField[i] + ",";
                }
                sql += " " + ValueField.Trim() + " From " + TableName.Trim();

                DataTable table = GetDataTable(sql, "");
                dr.Items.Clear();
                dr.Items.Add(new ListItem("-- Chọn --", "0"));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    String Text = String.Empty;
                    for (int j = 0; j < TextField.Length; j++)
                    {
                        Text += table.Rows[i][TextField[j].Trim()] + " - ";
                    }
                    Text = Text.TrimEnd('-');
                    dr.Items.Add(new ListItem(Text.Trim(), table.Rows[i][ValueField.Trim()].ToString().Trim()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void RedirectToPage_ChungTu(Page page)
        {
            //
        }



        /// <summary>
        /// Lấy ra số tháng trong một khoảng thời gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public int GetToltalsMonths(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                String sql = String.Empty;
                sql += "Select DATEDIFF(month,'" + TuNgay.ToString("MM/dd/yyyy") + "','" + DenNgay.ToString("MM/dd/yyyy") + "') Month";
                DataTable table = GetDataTable(sql, "");
                if (table.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(table.Rows[0]["Month"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy ra User hiện tại
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        //public String GetCurrentUser(Page page)
        //{
        //    return "CurrentUser";
        //}
        public void CheckSession(Page page)
        {
            if (page.Session["MaNSD"] == null)
            {
                page.Response.Redirect("~/Login.aspx");
            }
        }
        public String GetCurrentUser(Page page)
        {
            if (page.Session["MaNSD"] != null)
            {
                return page.Session["MaNSD"].ToString().Trim();
            }
            else
            {
                return User.Trim();
            }
        }     
    }
}
