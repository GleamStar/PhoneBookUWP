using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PhoneBook.Model;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PhoneBook
{
    public sealed partial class Dialog : ContentDialog
    {
        private ICollection<InformationItem> informationItemList;
        public Dialog(ICollection<InformationItem> userInformationItemList)
        {
            this.InitializeComponent();
            informationItemList = userInformationItemList;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var name    = InformationItemNameTextBox.Text;
            var content = InformationItemContentTextBox.Text;
            if (name != "" && content != "")
            {
                var item = new InformationItem(name, content);
                informationItemList.Add(item);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }
    }
}
