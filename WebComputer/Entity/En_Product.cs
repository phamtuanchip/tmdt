using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class En_Product
    {
        public En_Product()
        {
        }
        public int Product_ID;

        public int _Product_ID
        {
            get { return Product_ID; }
            set { Product_ID = value; }
        }
        public string Product_Code;

        public string _Product_Code
        {
            get { return Product_Code; }
            set { Product_Code = value; }
        }
        public string Product_Name;

        public string _Product_Name
        {
            get { return Product_Name; }
            set { Product_Name = value; }
        }
        public int Language_ID;

        public int _Language_ID
        {
            get { return Language_ID; }
            set { Language_ID = value; }
        }
        public int SubCatID;

        public int _SubCatID
        {
            get { return SubCatID; }
            set { SubCatID = value; }
        }
        public int Status_ID;

        public int _Status_ID
        {
            get { return Status_ID; }
            set { Status_ID = value; }
        }
        public int ProvID;

        public int _ProvID
        {
            get { return ProvID; }
            set { ProvID = value; }
        }
        public decimal Product_Price;

        public decimal _Product_Price
        {
            get { return Product_Price; }
            set { Product_Price = value; }
        }
        public int Cashby;

        public int _Cashby
        {
            get { return Cashby; }
            set { Cashby = value; }
        }
        public bool Hot_Product;

        public bool _Hot_Product
        {
            get { return Hot_Product; }
            set { Hot_Product = value; }
        }
        public bool OnHomePage;

        public bool _OnHomePage
        {
            get { return OnHomePage; }
            set { OnHomePage = value; }
        }
        public int LeadImage;

        public int _LeadImage
        {
            get { return LeadImage; }
            set { LeadImage = value; }
        }
        public string Author;

        public string _Author
        {
            get { return Author; }
            set { Author = value; }
        }
        public DateTime CreateDate;

        public DateTime _CreateDate
        {
            get { return CreateDate; }
            set { CreateDate = value; }
        }
        public string Content;

        public string _Content
        {
            get { return Content; }
            set { Content = value; }
        }
        public string Produc_Intro;

        public string _Produc_Intro
        {
            get { return Produc_Intro; }
            set { Produc_Intro = value; }
        }
        public decimal Product_Quatity;

        public decimal _Product_Quatity
        {
            get { return Product_Quatity; }
            set { Product_Quatity = value; }
        }
        public decimal Product_QuatityOut;

        public decimal _Product_QuatityOut
        {
            get { return Product_QuatityOut; }
            set { Product_QuatityOut = value; }
        }
    }
}
