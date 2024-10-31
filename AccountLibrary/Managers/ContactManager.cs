using AccountLibrary.Exceptions;
using AccountLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Managers
{
    public class ContactManager
    {
        private List<Contact> contacts;
        private static ContactManager manager= null;

        private ContactManager(){}

        public static ContactManager GetInstance()
        {
            if(manager == null)
            {
                manager = new ContactManager();
            } 
            return manager;
        }

        public void SetContacts(List<Contact> contacts)
        {
            manager.contacts = contacts;
        }

        public void AddContact(int id,string Fname,string Lname)
        {
            contacts.Add(new Contact(id,Fname,Lname));
        }

        public Contact GetContact(int id) {
            Contact contact = contacts.Where(contact => contact.Contact_Id == id).FirstOrDefault();
            if (contact == null) {
                throw new IdNotExistInListException("Please enter correct id!");
            }
            return contact;
        }

        public void ModifyContact(Contact contact, string Fname, string Lname)
        {
            if(!contact.IsActive)
            {
                throw new UserInActiveException("Contact is not active!");
            }
            contact.F_Name = Fname;
            contact.L_Name = Lname;
        }

        public void DeleteContact(Contact contact) {
            contact.IsActive = false;
        }

        public string DisplayAllContactsOfUser()
        {
            string str = "";
            foreach (var contact in contacts)
            {
                str += contact.ToString();
            }
            return str;
        }

        public string GetContactDetails(Contact contact) { 
            string contactDetails = "";
            foreach(var contactDets in contact.contact_details)
            {
                contactDetails += contactDets.ToString();
            }
            return contactDetails; 
        }

        public void UpdateContactDetail(Contact contact,int id,string changeDetail) {
            Contact_Details detail = contact.contact_details.Where(detail => detail.Contact_Id == id ).FirstOrDefault();
            if (detail == null) {
                throw new IdNotExistInListException("Please enter correct Id!");
            }
            detail.NumberOrEmail = changeDetail;
        }

        public void AddContactDetail(Contact contact,int id,string NumberOrEmail)
        {
            contact.AddContactDetail(new Contact_Details(id,NumberOrEmail));
        }
    }
}
