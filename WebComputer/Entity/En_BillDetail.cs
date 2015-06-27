using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class En_BillDetail
    {
        public En_BillDetail()
        {
        }
        public int Product_ID;

        public int _Product_ID
        {
            get { return Product_ID; }
            set { Product_ID = value; }
        }
        public int BillID;

        public int _BillID
        {
            get { return BillID; }
            set { BillID = value; }
        }
        public string ProductName;

        public string _ProductName
        {
            get { return ProductName; }
            set { ProductName = value; }
        }
        public float UnitPrice;

        public float _UnitPrice
        {
            get { return UnitPrice; }
            set { UnitPrice = value; }
        }
        public int Quatity;

        public int _Quatity
        {
            get { return Quatity; }
            set { Quatity = value; }
        }
        public int Discount;

        public int _Discount
        {
            get { return Discount; }
            set { Discount = value; }
        }
        public float Total;

        public float _Total
        {
            get { return Total; }
            set { Total = value; }
        }


    }
}
