using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWp8._1.Model
{
    public class Receipt
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Amount { get; set; }
        public string ReceiptDate { get; set; }
        public string CreationDate { get; set; }
        public string Tax { get; set; }
        public string ImageLink { get; set; }
        public string ReceiptType { get; set; }
        public Receipt()
        {
            //empty constructor
        }
        public Receipt(string name, string phone_no,string _Tax, string _ReceiptDate, string _ImageLink, string _ReceiptType)
        {
            Vendor = name;
            Amount = phone_no;
            Tax = _Tax;
            ImageLink = _ImageLink;
            ReceiptType = _ReceiptType;
            ReceiptDate = _ReceiptDate; 
            CreationDate = DateTime.Now.ToString();
        }
    }
}
