using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.API.Controllers;
using TaskManager.BusinessLayer;
using TaskManager.BusinessLayer.Model;
using TaskManager.DataLayer;

namespace TaskManager.API.Tests.Controller
{
    [TestClass]
    public class UserAPITestController
    {
        [TestMethod]
        public void GetUserDetails_ShouldReturnAllUser()
        {
            TaskManagerEntities entity = new TaskManagerEntities();
            var ActualResult = entity.Users.ToList();

            UserAPIController controller = new UserAPIController();

            var APIResult = controller.GetUserDetails();

            //Assert.IsNotNull(APIResult);
            Assert.AreEqual(ActualResult.Count(), APIResult.Count());
        }

        [TestMethod]
        public void CreateUser_UserShouldBeAdded()
        {
            User User = new User();
            User.First_Name = "Test User";
            User.Last_Name = "Test User";
            User.Manager_Flag = true;
            


            UserAPIController controller = new UserAPIController();
            controller.Create(User);

            var result = controller.GetUserDetails().Where(x => x.FirstName == "Test User").FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, "Test User");

        }

        [TestMethod]
        public void GetUserById_ShouldReturnCorrentUser()
        {
            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            UserAPIController controller = new UserAPIController();
            var UserId = taskManagerEntities.Users.Max(x => x.User_Id);

            var result = controller.GetUser(UserId);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.User_Id, UserId);

        }

        [TestMethod]
        public void UpdateUser_UserShouldBeUpdated()
        {

            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var UserId = taskManagerEntities.Users.Max(x => x.User_Id);
            User User = new User();
            User.User_Id = UserId;
            User.First_Name = "Updated Test User";
            User.Last_Name = "Test User";
            User.Manager_Flag = true;

            UserAPIController controller = new UserAPIController();
            controller.Update(User);

            var result = controller.GetUserDetails().Where(x => x.UserId == UserId).FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, "Updated Test User");

        }



        [TestMethod]
        public void Delete_UserShouldBeDeleted()
        {

            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var UserId = taskManagerEntities.Users.Max(x => x.User_Id);


            UserAPIController controller = new UserAPIController();
            controller.Delete(UserId);

            var result = controller.GetUserDetails().Where(x => x.UserId == UserId).FirstOrDefault();


            Assert.IsNull(result);

        }


    }
}
