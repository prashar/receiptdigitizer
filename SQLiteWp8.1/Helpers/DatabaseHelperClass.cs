using SQLite;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWp8._1.Helpers
{
    public class DatabaseHelperClass
    {
        SQLiteConnection dbConn;

        //Create Tabble 
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Receipt>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific Receipt from the database. 
        public Receipt ReadReceipt(int receiptId)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Receipt>("select * from Receipt where Id =" + receiptId).FirstOrDefault();
                return existingconact;
            }
        }
        // Retrieve the all Receipt list from the database. 
        public ObservableCollection<Receipt> ReadReceipts()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Receipt> myCollection = dbConn.Table<Receipt>().ToList<Receipt>();
                ObservableCollection<Receipt> ReceiptsList = new ObservableCollection<Receipt>(myCollection);
                return ReceiptsList;
            }
        }

        //Update existing receipt 
        public void UpdateReceipt(Receipt rpt)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Receipt>("select * from Receipt where Id =" + rpt.Id).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.Vendor = rpt.Vendor;
                    existingconact.Amount = rpt.Amount;
                    existingconact.CreationDate = rpt.CreationDate;
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingconact);
                    });
                }
            }
        }
        // Insert the new receipt in the receipts table. 
        public void Insert(Receipt newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }

        //Delete specific receipt 
        public void DeleteReceipt(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Receipt>("select * from Receipt where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        //Delete all receiptlist or delete receipts table 
        public void DeleteAllReceipts()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() => 
                //   { 
                dbConn.DropTable<Receipt>();
                dbConn.CreateTable<Receipt>();
                dbConn.Dispose();
                dbConn.Close();
                //}); 
            }
        }
    }
}
