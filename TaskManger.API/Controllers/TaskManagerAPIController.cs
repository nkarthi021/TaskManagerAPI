using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.BusinessLayer.Model;
using TaskManager.DataLayer;

namespace TaskManger.API.Controllers
{
    public class TaskManagerAPIController : ApiController
    {
        [Route("api/TaskManagerAPI/GetTasks")]
        [HttpGet]
        public List<TaskDetails> GetTasks()
        {
            TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
            return taskManagerBusinessModel.GetTaskDetails();
        }

        [Route("api/TaskManagerAPI/GetTask")]
        [HttpGet]
        public Task GetTaskbyId(int TaskId)
        {
            TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();

            return taskManagerBusinessModel.GetTaskById(TaskId);
        }

        [Route("api/TaskManagerAPI/GetParentTask")]
        [HttpGet]
        public List<ParentTask> GetParentTask(int? TaskId)
        {
            TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();

            return taskManagerBusinessModel.GetParentTask(TaskId);
        }

        [Route("api/TaskManagerAPI/Create")]
        [HttpPost]
        public string Create(Task task)
        {
            if (ModelState.IsValid)
            {
                TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
                taskManagerBusinessModel.Create(task);
                return "Success";
            }
            else return "Failure";
        }

        [Route("api/TaskManagerAPI/Update")]
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

        [Route("api/TaskManagerAPI/UpdateEditFlag")]
        [HttpPost]
        public string UpdateEditFlag(int TaskId, bool EditFlag)
        {
            try
            {
                TaskMangerBusinessModel taskManagerBusinessModel = new TaskMangerBusinessModel();
                taskManagerBusinessModel.UpdateEditFlag(TaskId, EditFlag);

                return "Success";

            }

            catch(Exception ex)
            {
                return "Error";
            }
               
           
        }
    }
}
