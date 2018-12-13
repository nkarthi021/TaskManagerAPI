using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.BusinessLayer.Model;
using TaskManager.DataLayer;

namespace TaskManager.API.Controllers
{
    public class UserAPIController : ApiController
    {
        [Route("api/User/GetUserDetails")]
        [HttpGet]
        public List<UserDetails> GetUserDetails()
        {
            UserBusinessModel UserBusinessModel = new UserBusinessModel();
            return UserBusinessModel.GetUserDetails();
        }

        [Route("api/User/GetUser")]
        [HttpGet]
        public UserModel GetUser(int UserId)
        {
            UserBusinessModel UserBusinessModel = new UserBusinessModel();

            return UserBusinessModel.GetUserById(UserId);
        }

        [Route("api/User/GetUsers")]
        [HttpGet]
        public List<Users> GetUsers()
        {
            UserBusinessModel UserBusinessModel = new UserBusinessModel();

            return UserBusinessModel.GetUsers();
        }

        [Route("api/User/GetManagers")]
        [HttpGet]
        public List<Users> GetManagers()
        {
            UserBusinessModel UserBusinessModel = new UserBusinessModel();

            return UserBusinessModel.GetManagers();
        }

        [Route("api/User/Create")]
        [HttpPost]
        public string Create(User User)
        {
            if (ModelState.IsValid)
            {
                UserBusinessModel UserBusinessModel = new UserBusinessModel();
                UserBusinessModel.Create(User);
                return "Success";
            }
            else return "Failure";
        }

        [Route("api/User/Update")]
        [HttpPost]
        public string Update(User User)
        {
            if (ModelState.IsValid)
            {
                UserBusinessModel UserBusinessModel = new UserBusinessModel();
                UserBusinessModel.Update(User);

                return "Success";
            }
            else return "Failure";
        }

        [Route("api/User/Delete")]
        [HttpPost]
        public string Delete(int UserId)
        {
            try
            {
                UserBusinessModel UserBusinessModel = new UserBusinessModel();
                UserBusinessModel.Delete(UserId);

                return "Success";

            }

            catch (Exception ex)
            {
                return "Error";
            }


        }
    }
}
