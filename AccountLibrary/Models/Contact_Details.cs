using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Models
{
    public class Contact_Details
    {
        public int Contact_Id { get; set; }
        public string NumberOrEmail { get; set; }

        public Contact_Details(int id,string NumberOrEmail)
        {
            Contact_Id = id;
            this.NumberOrEmail = NumberOrEmail;
        }

        public override string ToString()
        {
            return $"Id : {Contact_Id}\n" +
                    $"{NumberOrEmail}\n";
        }
    }
}
