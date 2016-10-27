using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PhoneBook.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhoneBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private MainPage rootPage = MainPage.GetEle;
        private readonly User _user;
        private readonly IUserRepository _connection;

        public MainPage()
        {
            this.InitializeComponent();
            _user = new User();
            _connection = new UserRepository();
            PeopleListView.ItemsSource = _connection.Users;
            
        }

        private  async void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            var name = UserNameTextBox.Text;
            var number = PhoneNumberTextBox.Text;
            var date = DatePicker.Date.DateTime;
            _user.SetData(UserNameTextBox.Text, PhoneNumberTextBox.Text, LocationTextBox.Text, DatePicker.Date.DateTime, _user.Content, _user.OtherInformation);
            if (name == "" || number == "" )
            {
                var dialog = new MessageDialog("Enter user name or number!");
                await dialog.ShowAsync();
            }
            else
            {
                _user.Name         = name;
                _user.PhoneNumber  = number;
                _user.BirthdayDate = date;
                await AppointmentService.AddAppointment(sender, _user.BirthdayDate.Value, "Date Birthday :)", _user.Name);
                await _connection.AddUser(_user);

            }
        }

        private async void MoreInformationButton_Click(object sender, RoutedEventArgs e)
        {
            if (_user.OtherInformation == null)
            {
                _user.OtherInformation = new List<InformationItem>();
            }
            var dialog = new Dialog(  _user.OtherInformation);
            await dialog.ShowAsync();
        }

        private async void  AddImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            StorageFile file = await OpenFile();
            if (file != null)
            {
                var stream = await file.OpenSequentialReadAsync();
                var readStream = stream.AsStreamForRead();
                var data = new byte[readStream.Length];
                await readStream.ReadAsync(data, 0, data.Length);
                _user.Content = data;
                Photo.Source = _user.ImageSource;
            }

        }

        private static async Task<StorageFile> OpenFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            return await openPicker.PickSingleFileAsync();
        }



    }
}
