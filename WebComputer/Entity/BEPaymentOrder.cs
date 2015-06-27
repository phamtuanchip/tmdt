using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Entity
{
    public class BEPaymentOrder
    {
        public const byte NULL_BYTE = byte.MinValue;
        public const short NULL_SHORT = short.MinValue;
        public const int NULL_INT = int.MinValue;
        public const long NULL_LONG = long.MinValue;
        public const decimal NULL_DECIMAL = decimal.MinValue;
        public const float NULL_FLOAT = float.NaN;
        public const double NULL_DOUBLE = double.NaN;
        public const Single NULL_SINGLE = Single.NaN;
        public static DateTime NULL_DATETIME = DateTime.MinValue;
        public static Guid NULL_GUID = Guid.Empty;
        public static string NULL_STRING = string.Empty;
        public BEPaymentOrder(DataRow dr)
        {
            this._PaymentID = Convert.ToInt32(dr["PaymentID"]);
            this._PaymentReason = Convert.ToString(dr["ReasonPayment"]);
            this._Quantity = Convert.ToDecimal(dr["Quantity"]);
            this._Employee = Convert.ToString(dr["Employee"]);
            this._CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this._ProvID = Convert.ToInt32(dr["ProvID"]);
            this._ProvName = Convert.ToString(dr["ProvName"]);

        }
        public BEPaymentOrder()
        {
            this._PaymentID = NULL_INT;
            this._PaymentReason = NULL_STRING;
            this._Quantity = NULL_DECIMAL;
            this._Employee = NULL_STRING;
            this._CreatedDate = NULL_DATETIME;
            this._ProvID = NULL_INT;
            this._ProvName = NULL_STRING;

        }

        #region Atrribute
        private int _PaymentID;

        public int PaymentID
        {
            get { return _PaymentID; }
            set { _PaymentID = value; }
        }

        private string _PaymentReason;

        public string PaymentReason
        {
            get { return _PaymentReason; }
            set { _PaymentReason = value; }
        }

        private decimal _Quantity;

        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private string _Employee;

        public string Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        private DateTime _CreatedDate;

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private int _ProvID;

        public int ProvID
        {
            get { return _ProvID; }
            set { _ProvID = value; }
        }

        private string _ProvName;

        public string ProvName
        {
            get { return _ProvName; }
            set { _ProvName = value; }
        }
        #endregion
    }
}
