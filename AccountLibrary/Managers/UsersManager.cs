using AccountLibrary.Exceptions;
using AccountLibrary.Models;
using ContactLibrary.DataSerializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Managers
{
    public class UsersManager
    {
        public static List<User> Users;

        public static void AddNewUser(int Id, string FName, string LName, bool isAdmin)
        {
            Users.Add(new User(Id, FName, LName, isAdmin));
        }

        public static User CheckUserExists(int Id)
        {
            User user = Users.Where(user => user.User_Id == Id).FirstOrDefault();
            if (user == null) {
                throw new IdNotExistInListException("Please enter correct User Id");
            }
            return user;
        }

        public static void CheckUserIsActive(User user)
        {
            if(user.isActive == false)
            {
                throw new UserInActiveException("User is not active!");
            }
        }

        public static bool IsAdmin(User user) { 
            return user.isAdmin ;
        }

        public static void ModifyDetailsOfUser(User user,string fName, string lName,bool isAdmin)
        {
            user.L_Name = lName;
            user.F_Name = fName;
            user.isAdmin = isAdmin;

        }

        public static string DeleteUser(User user)
        {
            user.isActive = false;
            return "User deleted";
        }

        public static string DisplayAllUser()
        {
            string str = "";
            foreach(var user in Users)
            {
                str += user.ToString();
            }
            return str;
        }

        public static void UserSerializer()
        {
            Serializer.Serialization(Users);
        }
    }
}
