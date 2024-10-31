using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Models
{
    public class Contact
    {
        public int Contact_Id { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Contact_Details> contact_details { get; set; } = new List<Contact_Details>(); 

        public Contact(int id,string Fname,string Lname)
        {
            Contact_Id = id;
            F_Name = Fname;
            L_Name = Lname;
        }

        public void SetIsActive(bool active)
        {
            IsActive = active;
        }

        public void AddContactDetail(Contact_Details contactDets)
        {
            contact_details.Add(contactDets);
        }

        public override string ToString()
        {
            return $"Contact Id : {Contact_Id}\n" +
                $"Name : {F_Name} {L_Name}\n" +
                $"Is active : {IsActive}";
        }
    }
}
