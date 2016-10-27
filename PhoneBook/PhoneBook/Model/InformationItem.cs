using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model
{
    public class InformationItem
    {
        public InformationItem()
        {
            
        }
        public InformationItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
