using SQLiteWp8._1.Helpers;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SQLiteWp8._1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadReceiptList : Page
    {
        ObservableCollection<Receipt> DB_ReceiptList = new ObservableCollection<Receipt>();
        public ReadReceiptList()
        {
            this.InitializeComponent();
            this.Loaded += ReadReceiptList_Loaded;
        }
        private void ReadReceiptList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllReceiptsList dbreceipts = new ReadAllReceiptsList();
            DB_ReceiptList = dbreceipts.GetAllReceipts();//Get all DB contacts 
            if (DB_ReceiptList.Count > 0)
            {
                Btn_Delete.IsEnabled = true;
            }
            listBoxobj.ItemsSource = DB_ReceiptList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first. 
            List<Receipt> receipts_list = DB_ReceiptList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first. 
            double totalTax = 0;
            foreach (Receipt r in receipts_list)
            {
                totalTax += Convert.ToDouble(r.Tax);  
            }
            TotalTaxBx.Text = totalTax.ToString(); 
        }
        private void AddReceipt_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddReceipt));
        }
        private async void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to remove all your data ?");
            dialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(Command)));
            dialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(Command)));
            await dialog.ShowAsync();
        }
        private void Command(IUICommand command)
        {
            if (command.Label.Equals("Yes"))
            {
                DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
                Db_Helper.DeleteAllReceipts();//delete all DB receipts 
                DB_ReceiptList.Clear();//Clear collections 
                Btn_Delete.IsEnabled = false;
                listBoxobj.ItemsSource = DB_ReceiptList;
            }
        }
        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedReceiptID = 0;
            if (listBoxobj.SelectedIndex != -1)
            {
                Receipt listitem = listBoxobj.SelectedItem as Receipt;//Get slected listbox item Receipt ID 
                Frame.Navigate(typeof(Delete_UpdateReceipt), SelectedReceiptID = listitem.Id);        

            }
        }
    }
}
