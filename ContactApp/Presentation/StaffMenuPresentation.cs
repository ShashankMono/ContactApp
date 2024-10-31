using AccountLibrary.Managers;
using AccountLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Presentation
{
    class StaffMenuPresentation
    {
        private static ContactManager _contactManager ;
        public static void StaffMenu(User user)
        {
           _contactManager = ContactManager.GetInstance();
            _contactManager.SetContacts(user.Contacts);
            while (true)
            {
                Console.WriteLine($"\nWhat do you wish to do?\n" +
                    $"1.Add new contact\n" +
                    $"2.Modify existing contact\n" +
                    $"3.Delete contact\n" +
                    $"4.Display all contacts \n" +
                    $"5.Find contact\n" +
                    $"6.Add contact detail of contact\n" +
                    $"7.Show all contact Details of contact\n" +
                    $"8.Update contact Detail\n" +
                    $"9.Logout\n" +
                    $"10.Exit\n");
                int choice = int.Parse(Console.ReadLine());
                ExecuteStaffMenu(choice);
            }
        }

        public static void ExecuteStaffMenu(int choice) {
            switch (choice) { 
                case 1:
                    AddNewContact();
                    break;
                case 2:
                    ModifyContact();
                    break;
                case 3:
                    DeleteContact();
                    break;
                case 4:
                    DisplayAllContact();
                    break;
                case 5:
                    FIndContact();
                    break;
                case 6:
                    AddNewContactDetail();
                    break;
                case 7:
                    GetAllContactDetails();
                    break;
                case 8:
                    UpdateContactDetail();
                    break;
                case 9:
                    PresentContactApp.LogoutUser();
                    break;
                case 10:
                    PresentContactApp.LogoutUser();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose correct option!");
                    break;
            }
        }

        public static void AddNewContact()
        {
            (string Fname, string Lname) = PresentContactApp.TakeName("Contact");
            _contactManager.AddContact(PresentContactApp.TakeId("Contact"),Fname,Lname);
        }

        public static void ModifyContact()
        {
            try
            {
                int id = PresentContactApp.TakeId("Contact");
                Contact contact = _contactManager.GetContact(id);
                (string Fname, string Lname) = PresentContactApp.TakeName("Contact");
                _contactManager.ModifyContact(contact, Fname, Lname);
                Console.WriteLine("Contact added successfully!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteContact()
        {
            try
            {
                _contactManager.DeleteContact(_contactManager.GetContact(PresentContactApp.TakeId("Contact")));
                Console.WriteLine("Contact deleted successfully!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplayAllContact()
        {
            try
            {
                Console.WriteLine(_contactManager.DisplayAllContactsOfUser());
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public static void FIndContact()
        {
            try
            {
                Console.WriteLine(_contactManager.GetContact(PresentContactApp.TakeId("Contact")).ToString());
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAllContactDetails()
        {
            try
            {
                Console.WriteLine(_contactManager.
                    GetContactDetails(_contactManager.
                    GetContact(PresentContactApp.TakeId("Contact"))));
            } catch (Exception ex) { 
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void AddNewContactDetail()
        {
            try
            {
                Contact contact = _contactManager.GetContact(PresentContactApp.TakeId("Contact"));
                _contactManager.AddContactDetail(contact
                    ,PresentContactApp.TakeId($"Contact Detail of {contact.F_Name + contact.L_Name}")
                    ,TakeContactNumberOrEmail(contact.F_Name + contact.L_Name));
                Console.WriteLine("Contact detail added successfully!");
            }
            catch (Exception ex) { 
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static string TakeContactNumberOrEmail(string DetailOf)
        {
            Console.WriteLine($"Enter Contact Number or Email of {DetailOf}");
            return Console.ReadLine();

        }

        public static void UpdateContactDetail()
        {
            try
            {
                Contact contact = _contactManager.GetContact(PresentContactApp.TakeId("Contact"));
                _contactManager.UpdateContactDetail(contact
                    , PresentContactApp.TakeId($"Contact detail of {contact.F_Name + contact.L_Name}")
                    , TakeContactNumberOrEmail($"{contact.F_Name + contact.L_Name}"));

                Console.WriteLine("Contact detail added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
