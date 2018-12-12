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
    public class TaskController : ApiController
    {
        [Route("api/Task/GetTaskDetails")]
        [HttpGet]
        public List<TaskDetails> GetTaskDetails()
        {
            TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
            return taskManagerBusinessModel.GetTaskDetails();
        }

        [Route("api/Task/GetTask")]
        [HttpGet]
        public TaskModel GetTaskbyId(int TaskId)
        {
            TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();

            return taskManagerBusinessModel.GetTaskById(TaskId);
        }

        [Route("api/Task/GetTasks")]
        [HttpGet]
        public List<ParentTask> GetTasks(int? TaskId)
        {
            TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();

            return taskManagerBusinessModel.GetTasks(TaskId);
        }

        [Route("api/Task/Create")]
        [HttpPost]
        public string Create(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
                    taskManagerBusinessModel.Create(task);
                    return "Success";
                }
                else return "Failure";
            }

            catch (Exception ex)
            {
                return "Failure";
            }
           
            
        }

        [Route("api/Task/Update")]
        [HttpPost]
        public string Update(Task task)
        {
            if (ModelState.IsValid)
            {
                TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
                taskManagerBusinessModel.Update(task);

                return "Success";
            }
            else return "Failure";
        }

        [Route("api/Task/UpdateEditFlag")]
        [HttpPost]
        public string UpdateEditFlag(int TaskId, bool EditFlag)
        {
            try
            {
                TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
                taskManagerBusinessModel.UpdateEditFlag(TaskId, EditFlag);

                return "Success";

            }

            catch (Exception ex)
            {
                return "Error";
            }


        }
    }
}
