using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PhoneBook.Model
{
    public class User
    {
        public void SetData(string name, string phoneNumber, string location, DateTime birsday, byte[] image, ICollection<InformationItem> otherInformation )
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Location = location;
            BirthdayDate = birsday;
            Content = image;
            OtherInformation = otherInformation;
        }

        [NotMapped]
        public ImageSource ImageSource
        {
            get
            {
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                    {
                        writer.WriteBytes(Content);
                         writer.StoreAsync().GetResults();
                    }
                    var image = new BitmapImage();
                     image.SetSource(stream);
                    return image;

                }
            }
        }

        [NotMapped]
        public string DateView
        {
            get
            {
                if(BirthdayDate != null)
                return $"Date {BirthdayDate.Value.Day} / Mounth {BirthdayDate.Value.Month}";
                else
                {
                    return "";
                }               
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public DateTime? BirthdayDate { get; set; }

        public byte[] Content { get; set; }

        public ICollection<InformationItem>  OtherInformation { get; set; }

    }
}
