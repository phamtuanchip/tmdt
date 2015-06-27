using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Entity
{
    public class En_Bill
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
        public En_Bill(DataRow dRow)
        {
            this._BillID = Convert.ToInt32(dRow["BillID"]);
            this._BuyDate = Convert.ToDateTime(dRow["BuyDate"]);
            //this._ProvName = Convert.ToString(dRow["ProvName"]);
            this._Employee = Convert.ToString(dRow["Employee"]);
            this._Total = Convert.ToString(dRow["Total"]);
            this._Topay = Convert.ToString(dRow["ToPay"]);
            //this._Remain = Convert.ToString(dRow["Remain"]);
            //this._Notes = Convert.ToString(dRow["Notes"]);
            this._Status = Convert.ToBoolean(dRow["Status"]);
        }
        public En_Bill()
        {
            this._BillID = NULL_INT;
            this._BuyDate = NULL_DATETIME;
            this._Employee = NULL_STRING;
            //this._Notes = NULL_STRING;
            //this._ProvName = NULL_STRING;
            //this._Remain = NULL_STRING;
            this._Status = false;
            this._Topay = NULL_STRING;
            this._Total = NULL_STRING;
        }
        #region Attribute       
        public int BillID;

        public int _BillID
        {
            get { return BillID; }
            set { BillID = value; }
        }
        public int ProvID;

        public int _ProvID
        {
            get { return ProvID; }
            set { ProvID = value; }
        }

        //private string ProvName;

        //public string _ProvName
        //{
        //  get { return ProvName; }
        //  set { ProvName = value; }
        //}

        public string Employee;

        public string _Employee
        {
            get { return Employee; }
            set { Employee = value; }
        }
        public int DebtID;

        public int _DebtID
        {
            get { return DebtID; }
            set { DebtID = value; }
        }
        public DateTime BuyDate;

        public DateTime _BuyDate
        {
            get { return BuyDate; }
            set { BuyDate = value; }
        }
        public string Total;

        public string _Total
        {
            get { return Total; }
            set { Total = value; }
        }
        public bool Status;

        public bool _Status
        {
            get { return Status; }
            set { Status = value; }
        }
        //public string Notes;

        //public string _Notes
        //{
        //    get { return Notes; }
        //    set { Notes = value; }
        //}

        private string Topay;

        public string _Topay
        {
            get { return Topay; }
            set { Topay = value; }
        }

        //private string Remain;

        //public string _Remain
        //{
        //    get { return Remain; }
        //    set { Remain = value; }
        //}
#endregion
    }
}
