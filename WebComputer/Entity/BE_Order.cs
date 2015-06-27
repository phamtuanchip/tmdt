using System;
using System.Collections.Generic;
using System.Text;
namespace Entity
{

    public class BE_Order
    {
        //public BE_Order(int orderID,int cuatomerID,string userName,string address,string district,string city,DateTime orderDate,int a) 
        private int _OrderID;

        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
        private int _CustomerID;

        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _AddresslReceiver;

        public string AddresslReceiver
        {
            get { return _AddresslReceiver; }
            set { _AddresslReceiver = value; }
        }
        private string _District;

        public string District
        {
            get { return _District; }
            set { _District = value; }
        }
        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private DateTime _OrderDate;

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        private string _Total;

        public string Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        private int _Amount;

        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        private int _Mothod;

        public int Mothod
        {
            get { return _Mothod; }
            set { _Mothod = value; }
        }
        private bool _Status;

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
