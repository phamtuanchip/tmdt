using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Entity
{
    public class BE_OrderDetails
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

        public BE_OrderDetails(DataRow dRow)
        {
            this._OrderID = Convert.ToInt32(dRow["OrderID"]);
            this._OrderDate = Convert.ToDateTime(dRow["OrderDate"]);
            this._DeliveryAddress = Convert.ToString(dRow["DeliveryAddress"]);
            this._DeliveryName = Convert.ToString(dRow["DeliveryName"]);
            //this._Method = Convert.ToInt32(dRow["Method"]);
            this._FullName = Convert.ToString(dRow["FullName"]);
            this._Address = Convert.ToString(dRow["Address"]);
            this._Email = Convert.ToString(dRow["Email"]);
            this._Phone = Convert.ToString(dRow["Phone"]);
            this._Status = Convert.ToBoolean(dRow["Status"]);
            this._Total = Convert.ToString(dRow["Total"]);
        }
        public BE_OrderDetails()
        {
            this._OrderID = NULL_INT;
            this._OrderDate = NULL_DATETIME;
            this._DeliveryAddress = NULL_STRING;
            this._DeliveryName = NULL_STRING;
            this._Phone = NULL_STRING;
            //this._Method = NULL_INT;
            this._Email = NULL_STRING;
            this._FullName = NULL_STRING;
            this._Address = NULL_STRING;
            this._Phone = NULL_STRING;
            this._Status = false;
            this._Total = NULL_STRING;
        }

        #region Attribute
        private bool _Status;

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _OrderID;
        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        private DateTime _OrderDate;
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }       

        //private int _Method;

        //public int Method
        //{
        //    get { return _Method; }
        //    set { _Method = value; }
        //}

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Total;

        public string Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _DeliveryAddress;

        public string DeliveryAddress
        {
            get { return _DeliveryAddress; }
            set { _DeliveryAddress = value; }
        }


        private string _DeliveryName;

        public string DeliveryName
        {
            get { return _DeliveryName; }
            set { _DeliveryName = value; }
        }     
        #endregion
    }
}
