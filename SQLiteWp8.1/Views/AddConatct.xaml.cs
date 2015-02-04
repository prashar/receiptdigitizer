using SQLiteWp8._1.Helpers;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class AddConatct : Page,IFileOpenPickerContinuable
    {
        MainPage rootPage = MainPage.Current;

        public AddConatct()
        {
            this.InitializeComponent();
        }

        private async void AddReceipt_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs 
            if (VendorBx.Text != "" & AmountBx.Text != "")
            {
                Db_Helper.Insert(new Receipt(VendorBx.Text, AmountBx.Text, TaxBx.Text, ManualDatePicker.ToString(), ImageLinkBx.Text, ReceiptTypeComboBox.SelectedValue.ToString()));
                Frame.Navigate(typeof(ReadContactList));//after add contact redirect to contact listbox page 
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Please fill two fields");//Text should not be empty 
                await messageDialog.ShowAsync();
            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.PickSingleFileAndContinue();
            
        }

        public void ContinueFileOpenPicker (FileOpenPickerContinuationEventArgs args)
        {
            ImageLinkBx.Text = args.Files[0].Name; 
        }
    }
}
