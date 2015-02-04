using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWp8._1.Helpers
{
    public class ReadAllReceiptsList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<Receipt> GetAllReceipts()
        {
            return Db_Helper.ReadReceipts();
        }
    }
}
