using AccountLibrary.Managers;
using AccountLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactApp.Presentation
{
    public class PresentContactApp
    {
        private static User user = null;

        public static void StartContactApp()
        {
            int id = TakeId("User");
            try
            {
                user = UsersManager.CheckUserExists(id);
                if(user != null)
                    UsersManager.CheckUserIsActive(user);

                if (user.isAdmin) {
                    DisplayAdminMenu();
                }
                else
                {
                    StaffMenuPresentation.StaffMenu(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                StartContactApp();
            }
        }

        public static void DisplayAdminMenu()
        {
            while (true)
            {
                Console.WriteLine($"\nWhat do you wish to do?\n" +
                    $"1.Add new user\n" +
                    $"2.Modify existing user\n" +
                    $"3.Delete user\n" +
                    $"4.Display all users \n" +
                    $"5.Find\n" +
                    $"6.Logout\n" +
                    $"7.Exit\n");
                int choice = int.Parse(Console.ReadLine());
                ExecuteAdminMenu(choice);
            }
        }

        public static void ExecuteAdminMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewUser();
                    break;
                case 2:
                    ModifyUserDetails();
                    break;
                case 3:
                    DeleteExistingUser();
                    break;
                case 4:
                    DisplayALlUsersDetails(); 
                    break;
                case 5:
                    FindUser();
                    break;
                case 6:
                    LogoutUser();
                    break;
                case 7:
                    user = null;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose correct option");
                    break;
            }
        }
        public static int TakeId(string idOf)
        {
            Console.WriteLine($"Enter id of {idOf} : ");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        public static (string,string) TakeName(string NameOf)
        {
            Console.WriteLine($"Enter first name of {NameOf} : ");
            string Fname = Console.ReadLine();
            Console.WriteLine($"Enter last name of {NameOf} : ");
            string Lname = Console.ReadLine();

            return (Fname,Lname);
        }
        public static void AddNewUser()
        {
            (string Fname, string Lname) = TakeName("User");
            UsersManager.AddNewUser(TakeId("User"), Fname, Lname, IsUserAdmin());
            Console.WriteLine("User Added!");
        }

        public static bool IsUserAdmin()
        {
            Console.WriteLine("If user is admin enter \"Yes\" else it will No");
            string isAdmin = Console.ReadLine();

            switch (isAdmin.ToLower())
            {
                case "yes":
                    return true;

                default:
                    return false;
            }
        }
        public static void ModifyUserDetails()
        {
            int id = TakeId("User");
            try
            {
                User user = UsersManager.CheckUserExists(id);
                (string Fname, string Lname) = TakeName("User");
                UsersManager.ModifyDetailsOfUser(user,Fname,Lname,IsUserAdmin());
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } 
        }

        public static void DeleteExistingUser()
        {
            int id = TakeId("User");
            if (user.User_Id == id)
            {
                Console.WriteLine("You are deleting you own account.");
                UsersManager.DeleteUser(user);
                LogoutUser();
                return;
            }
            try
            {
                User userToBeDeleted = UsersManager.CheckUserExists(id);
                UsersManager.DeleteUser(userToBeDeleted);
                Console.WriteLine("User deleted successfully!");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void DisplayALlUsersDetails()
        {
            Console.WriteLine(UsersManager.DisplayAllUser());
        }

        public static void FindUser()
        {
            try
            {
                int id = TakeId("User");
                Console.WriteLine(UsersManager.CheckUserExists(id).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void LogoutUser()
        {
            user = null;
            StartContactApp();
            Console.WriteLine("Successfully Logged Out!");
        }
    }
}
