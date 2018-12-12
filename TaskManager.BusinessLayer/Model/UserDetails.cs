using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BusinessLayer.Model
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<bool> ManagerFlag { get; set; }


    }

    public class Users
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }

    public class UserModel
    {
        public int User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Nullable<bool> Manager_Flag { get; set; }
    }
}
