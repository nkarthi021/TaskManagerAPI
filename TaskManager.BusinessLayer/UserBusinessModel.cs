using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManager.DataLayer;
using TaskManager.BusinessLayer.Model;

namespace TaskManager.BusinessLayer
{
   public class UserBusinessModel
    {
        public List<UserDetails> GetUserDetails()
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();
            //taskmanagerEntities.Configuration.ProxyCreationEnabled = false;
            var userList = (from user in taskmanagerEntities.Users
                            select new UserDetails
                               {
                                   UserId = user.User_Id,
                                   FirstName = user.First_Name,
                                   LastName = user.Last_Name,
                                   ManagerFlag = user.Manager_Flag

                               }).ToList<UserDetails>();
            return userList;
        }

        public UserModel GetUserById(int UserId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var User = (from user in taskmanagerEntities.Users
                        where user.User_Id == UserId
                        select new UserModel() { User_Id = user.User_Id, First_Name = user.First_Name, Last_Name = user.Last_Name, Manager_Flag = user.Manager_Flag }).FirstOrDefault();

            return User;
        }

        public List<Users> GetUsers()
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var users = (from User in taskmanagerEntities.Users
                               select new Users() { UserId = User.User_Id, UserName = User.First_Name }).ToList<Users>();

            users.Add(new Users() { UserId = 0, UserName = "Select" });

            return users.OrderBy(x => x.UserId).ToList();
        }

        public List<Users> GetManagers()
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var users = (from User in taskmanagerEntities.Users
                         where User.Manager_Flag == true
                         select new Users() { UserId = User.User_Id, UserName = User.First_Name }).ToList<Users>();

            users.Add(new Users() { UserId = 0, UserName = "Select" });

            return users.OrderBy(x => x.UserId).ToList();
        }

        public void Create(User user)
        {

            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();
            // taskmanagerEntities.Configuration.ProxyCreationEnabled = false;
            taskmanagerEntities.Users.Add(user);
            taskmanagerEntities.SaveChanges();

        }

        public void Update(User user)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var UpdatedTasks = taskmanagerEntities.Users.Where(x => x.User_Id == user.User_Id).FirstOrDefault();

            UpdatedTasks.First_Name = user.First_Name;
            UpdatedTasks.Last_Name = user.Last_Name;
            UpdatedTasks.Manager_Flag = user.Manager_Flag;

            taskmanagerEntities.SaveChanges();

        }

        public void Delete(int UserId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var DeletedUsers = taskmanagerEntities.Users.Where(x => x.User_Id == UserId).FirstOrDefault();

            taskmanagerEntities.Entry<User>(DeletedUsers).State = System.Data.Entity.EntityState.Deleted;

            taskmanagerEntities.SaveChanges();

        }
    }
}
