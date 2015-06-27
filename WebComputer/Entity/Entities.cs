using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.Security;
using System.Security;
using System.IO;
using System.Net.Mail;

namespace Entity
{
    public class Entities : System.Web.UI.Page
    {
        int sizeimge = 0;
        #region GetConfig
        public string GetValueWebConfig(string Key, bool isMapPath)
        {
            string str = string.Empty;
            if (isMapPath)
            {
                str = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings[Key]);
            }
            else
            {
                str = System.Configuration.ConfigurationManager.AppSettings[Key];
            }
            return str;
        }
        public string GetDomain()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Domain"].ToString();
        }
        #endregion GetConfig

        #region Language
        public Hashtable GetLanguage(string TableName)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            if (TableName != null && TableName != string.Empty)
            {
                ds.ReadXml(GetValueWebConfig("LanguagePath", true));
                DataTable dt = ds.Tables[TableName];

                DataRow dr = dt.Rows[0];

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ht.Add(dt.Columns[i].ColumnName, dr[i]);
                }
            }
            return ht;
        }
        #endregion Language

        #region DateTime
        public string ConvertDateTime(string datetime)
        {
            return System.DateTime.Parse(datetime).ToString("'Ngày' dd 'tháng' MM 'năm' yyyy '('HH 'giờ' mm 'phút' ss 'giây)'");
        }
        public string ConvertShortDateTime(string datetime)
        {
            return System.DateTime.Parse(datetime).ToString("dd '/' MM '/' yyyy ', 'HH ':' mm ' GMT+7 '");
        }
        public string FormatDateTimeVN(string datetime)
        {
            return System.DateTime.Parse(datetime).ToString("dd '/' MM '/' yyyy");
        }
        public string FormatDateTimeEN(string datetime)
        {
            return System.DateTime.Parse(datetime).ToString("MM '/' dd '/' yyyy");
        }
        public string FullTime()
        {
            string myFullTime = string.Empty;
            myFullTime = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Millisecond.ToString();
            return myFullTime;
        }
        public string CutDateTimeVN(System.DateTime datetime)
        {
            string strCurDT = FormatDateTimeVN(System.DateTime.Now.ToString());
            string mydt = datetime.DayOfWeek.ToString().Substring(0, 3);
            string Output = "";
            switch (mydt)
            {
                case "Mon":
                    Output = "Thứ hai, " + strCurDT;
                    break;
                case "Tue":
                    Output = "Thứ ba, " + strCurDT;
                    break;
                case "Wed":
                    Output = "Thứ tư, " + strCurDT;
                    break;
                case "Thu":
                    Output = "Thứ năm, " + strCurDT;
                    break;
                case "Fri":
                    Output = "Thứ sáu, " + strCurDT;
                    break;
                case "Sat":
                    Output = "Thứ bảy, " + strCurDT;
                    break;
                case "Sun":
                    Output = "Chủ nhật, " + strCurDT;
                    break;

            }
            return Output;
        }
        public string FullDateTimeVN(System.DateTime datetime)
        {
            string strCurDT = ConvertShortDateTime(System.DateTime.Now.ToString());
            string mydt = datetime.DayOfWeek.ToString().Substring(0, 3);
            string Output = "";
            switch (mydt)
            {
                case "Mon":
                    Output = "Thứ hai, ";
                    break;
                case "Tue":
                    Output = "Thứ ba, " ;
                    break;
                case "Wed":
                    Output = "Thứ tư, " ;
                    break;
                case "Thu":
                    Output = "Thứ năm, ";
                    break;
                case "Fri":
                    Output = "Thứ sáu, ";
                    break;
                case "Sat":
                    Output = "Thứ bảy, ";
                    break;
                case "Sun":
                    Output = "Chủ nhật, ";
                    break;

            }
           // string[] Output2 = Output.Split(' ');
            //string Output3 = Output2[0] + ' ' + Output2[1];
            //return Output3;

            string date1 = Output + datetime.Day.ToString() + "/" + datetime.Month.ToString() + "/" + datetime.Year.ToString();
            return date1;
        }
        public string CutDateTimeEN(System.DateTime datetime)
        {
            string strCurDT = FormatDateTimeEN(System.DateTime.Now.ToString());
            string mydt = datetime.DayOfWeek.ToString().Substring(0, 3);
            string Output = "";
            switch (mydt)
            {
                case "Mon":
                    Output = "Monday, " + strCurDT;
                    break;
                case "Tue":
                    Output = "Tuesday, " + strCurDT;
                    break;
                case "Wed":
                    Output = "Wednesday, " + strCurDT;
                    break;
                case "Thu":
                    Output = "Thursday, " + strCurDT;
                    break;
                case "Fri":
                    Output = "Friday, " + strCurDT;
                    break;
                case "Sat":
                    Output = "Saturday, " + strCurDT;
                    break;
                case "Sun":
                    Output = "Sunday, " + strCurDT;
                    break;

            }
            return Output;
        }
        public string FullDateTimeEN(System.DateTime datetime)
        {
            string strCurDT = System.DateTime.Now.ToString();
            string mydt = datetime.DayOfWeek.ToString().Substring(0, 3);
            string Output = "";
            switch (mydt)
            {
                case "Mon":
                    Output = "Monday, " + strCurDT;
                    break;
                case "Tue":
                    Output = "Tuesday, " + strCurDT;
                    break;
                case "Wed":
                    Output = "Wednesday, " + strCurDT;
                    break;
                case "Thu":
                    Output = "Thursday, " + strCurDT;
                    break;
                case "Fri":
                    Output = "Friday, " + strCurDT;
                    break;
                case "Sat":
                    Output = "Saturday, " + strCurDT;
                    break;
                case "Sun":
                    Output = "Sunday, " + strCurDT;
                    break;

            }
            return Output;
        }
        #endregion DateTime

        #region Images, Files
        public void Delete_Files(string PathFileName)
        {
            File.Delete(PathFileName);
        }
        public string GetPathLibraryImage()
        {
            return System.Configuration.ConfigurationManager.AppSettings["PathLibraryImage"].ToString();
        }
        public string GetVirtualPathLibraryImage()
        {
            return System.Configuration.ConfigurationManager.AppSettings["VirtualPathLibraryImage"].ToString();
        }
        public string GetPathLogo()
        {
            return System.Configuration.ConfigurationManager.AppSettings["PathLogo"].ToString();
        }
        public string GetVirtualPathLogo()
        {
            return System.Configuration.ConfigurationManager.AppSettings["VirtualPathLogo"].ToString();
        }
        public string GetPathBanner()
        {
            return System.Configuration.ConfigurationManager.AppSettings["PathBanner"].ToString();
        }
        public string GetVirtualPathBanner()
        {
            return System.Configuration.ConfigurationManager.AppSettings["VirtualPathBanner"].ToString();
        }
        public int GetMaxWidthImages()
        {
            return int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxWidthImages"].ToString());
        }
        public int GetMinWidthImages()
        {
            return int.Parse(System.Configuration.ConfigurationManager.AppSettings["MinWidthImages"].ToString());
        }
        public int GetWidthToResize()
        {
            return int.Parse(System.Configuration.ConfigurationManager.AppSettings["WidthToResize"].ToString());
        }
        public bool UploadImg(string FileName, string PathSave, double dblResize, double dblMaxWidth)
        {
            bool flag = false;
            //Lay ten file dc luu bang ngay gio he thong
            System.IntPtr myIntPtr = new System.IntPtr(1);
            System.Drawing.Image objImg = System.Drawing.Image.FromFile(PathSave + FileName + ".jpg");
            double dblRealWidth = objImg.Width;
            double dblRealHeight = objImg.Height;
            double rate;
            rate = dblRealWidth / dblResize;
            if (dblRealWidth <= dblMaxWidth)
            {
                if (rate >= 1)
                {
                    if (dblRealWidth >= dblResize)
                    {
                        double intHeightToResize = dblRealHeight / rate;
                        //Upload anh Thumb
                        objImg = objImg.GetThumbnailImage((int)dblResize, (int)intHeightToResize, null, myIntPtr);
                        objImg.Save(PathSave + FileName + "_T.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        flag = true;
                    }
                    else
                    {
                        string strCheckPath = PathSave + FileName + ".jpg";
                        if (File.Exists(strCheckPath) == true)
                        {
                            Delete_Files(strCheckPath);
                        }
                    }
                }
            }
            return flag;
        }
        #endregion Images, Files

        #region EndCodePassWord
        public string EncodePassword(string strPassword, string strFormat)
        {
            if (strFormat == "") { strFormat = "MD5"; }
            return FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, strFormat);
        }
        #endregion EndCodePassWord

        #region Check Request String
        public string SafeString(string str)
        {
            //string newChars;
            string[] badChars = { "select ", "drop ","-","''","/",";", "--", "insert ", "delete ", "xp_ ", " or " };
            for (int i = 0; i < badChars.Length; i++)
            {
                str = str.Replace(badChars[i], string.Empty);
            }
            if (str.IndexOf("'") > -1)
            {
                str = str.Replace("'", string.Empty);
            }
            return str;
        }
        public string RequestForm(string StrForm)
        {
            string strRequest = string.Empty;
            if (System.Web.HttpContext.Current.Request.Form[StrForm] != null)
            {
                strRequest = SafeString(System.Web.HttpContext.Current.Request.Form[StrForm].ToString());
            }
            else
            {
                strRequest = null;
            }
            return strRequest;
        }
        #endregion Check Request String

        #region Upper Case String
        public string UpperCaseFirst(string str)
        {
            string temp = "";
            temp = str.Substring(0, 1).ToUpper();
            temp += str.Substring(1, str.Length - 1);
            return temp;
        }
        #endregion Upper Case String

        #region Split String
        public string SplitString(string str)
        {
            string temp = "";
            //temp = str.Substring(0, 1).ToString();
            temp = str.Substring(0, str.Length - 5);
            return temp;
        }
        #endregion

        #region SendMail
        //public void sendMail(string sender, string receiver, string subject, string content)
        //{
        //    MailMessage mail = new MailMessage();
        //    mail.To = receiver;
        //    mail.From = sender;
        //    mail.BodyFormat = MailFormat.Html;
        //    mail.Subject = subject;
        //    mail.Body = content;
        //    mail.BodyEncoding = System.Text.Encoding.GetEncoding("Utf-8");
        //    SmtpMail.SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SMTPMail"].ToString();
        //    SmtpMail.Send(mail);
        //}
        public void sendMail(string sender, string receiver, string subject, string content)
        {
            //System.Web.Mail.MailMessage objEmail = new System.Web.Mail.MailMessage();
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress EmailFrom = new MailAddress(sender, sender, System.Text.Encoding.UTF8);

                smtpClient.Host = "222.255.249.118";
                //smtpClient.Host = "localhost";
                //smtpClient.Host = "isp-newmail.fpt.net";
                smtpClient.Port = int.Parse(this.GetValueWebConfig("EmailPort", false));

                //Email nguoi gui di
                message.From = EmailFrom;
                //Email nguoi nhan den
                message.To.Add(receiver);
                //Tieu de email
                message.Subject = "Lilama: " + subject;
                ///////CC cho ai do
                //message.CC.Add("lilama_ict@lilama.com.vn");
                //message.CC.Add("datdn@fpt.net");
                ///////Bcc cho ai do
                //message.Bcc.Add(new MailAddress("lampn@fpt.net"));
                //message.Bcc.Add(new MailAddress("datdn@fpt.net"));

                message.IsBodyHtml = true;

                message.Body = content;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region Cut String
        public string Left(string source, int pos)
        {
            string temp = "";
            if (pos <= source.Length)
            {
                for (int i = 0; i < pos; i++)
                {
                    temp += source[i];
                }
            }
            return temp;
        }
        public string CutString(string Str, int Pos)
        {
            int PostTemp = Pos;
            if (PostTemp <= Str.Length)
            {
                Str = Left(Str, Pos);
                int intSpacePos = Str.LastIndexOf(" ");
                Str = Left(Str, intSpacePos) + " ...";
            }
            return Str;
        }
        #endregion Cut String

        #region Method ReSize for Images
        public int GetWidthToResizeProduct()
        {
            return sizeimge;
        }
        #endregion
    }
}
