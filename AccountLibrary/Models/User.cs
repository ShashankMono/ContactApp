using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Models
{
    public class User
    {
        public int User_Id {  get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public bool isActive { get; set; } = true;
        public bool isAdmin { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();


        public User(int User_Id, string F_Name, string L_Name, bool isAdmin)
        {
            this.User_Id = User_Id;
            this.F_Name = F_Name;
            this.L_Name = L_Name;
            this.isAdmin = isAdmin;
        }

        public void SetIsActive(bool active)
        {
            isActive = active;
        }

        public void AddNewContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public override string ToString()
        {
            string active = isActive ? "Active" : "Not Active";
            string admin = isAdmin ? "Admin" : "Staff";
            return $"\nId : {User_Id}\n" +
                    $"Name : {F_Name} {L_Name}\n" +
                    $"IsActive : {active}\n" +
                    $"IsAdmin : {admin}\n" +
                    $"================================\n"; 
        }
    }
}
