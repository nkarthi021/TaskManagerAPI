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
    public class TaskManagerAPITestController
    {
        [TestMethod]
        public void GetTaskDetails_ShouldReturnAllTasks()
        {
            TaskManagerEntities entity = new TaskManagerEntities();
            var ActualResult = entity.Tasks.ToList();

            TaskController controller = new TaskController();

            var APIResult = controller.GetTaskDetails();

            //Assert.IsNotNull(APIResult);
            Assert.AreEqual(ActualResult.Count(), APIResult.Count());
        }

        [TestMethod]
        public void CreateTask_TaskShouldBeAdded()
        {
            TaskManager.DataLayer.Task task = new TaskManager.DataLayer.Task();
            task.Name = "Test Task";
            task.Parent_Id = 0;
            task.Priority = 14;
            task.Start_Date = Convert.ToDateTime("01-02-2018");
            task.End_Date = Convert.ToDateTime("04-02-2018");
            task.Edit_Flag = true;
            task.User_Id = 1;
            task.Project_Id = 1;

            TaskController controller = new TaskController();
            controller.Create(task);

            var result = controller.GetTaskDetails().Where(x => x.Task == "Test Task").FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Task, "Test Task");

        }

        [TestMethod]
        public void GetTaskById_ShouldReturnCorrentTask()
        {
            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            TaskController controller = new TaskController();
            var TaskId = taskManagerEntities.Tasks.Max(x => x.Task_Id);

            var result = controller.GetTaskbyId(TaskId);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Task_Id, TaskId);

        }

        [TestMethod]
        public void UpdateTask_TaskShouldBeUpdated()
        {

            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var TaskId = taskManagerEntities.Tasks.Max(x => x.Task_Id);
            TaskManager.DataLayer.Task task = new TaskManager.DataLayer.Task();
            task.Task_Id = TaskId;
            task.Name = "Updated Test Task";
            task.Parent_Id = 0;
            task.Priority = 14;
            task.Start_Date = Convert.ToDateTime("01-02-2018");
            task.Start_Date = Convert.ToDateTime("04-02-2018");
            task.User_Id = 1;
            task.Project_Id = 1;

            TaskController controller = new TaskController();
            controller.Update(task);

            var result = controller.GetTaskDetails().Where(x => x.TaskId == TaskId).FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Task, "Updated Test Task");

        }

        [TestMethod]
        public void GetParentTask_ShouldnotContainGivenTaskId()
        {
            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var TaskId = taskManagerEntities.Tasks.Max(x => x.Task_Id);

            TaskController controller = new TaskController();
            var result = controller.GetTasks(TaskId).FirstOrDefault(x => x.TaskId == TaskId);

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetParentTask_ShouldContainGivenTaskId()
        {
            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var TaskId = taskManagerEntities.Tasks.Max(x => x.Task_Id);

            TaskController controller = new TaskController();
            var result = controller.GetTasks(0).FirstOrDefault(x => x.TaskId == TaskId);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void UpdateEditFlag_EditFlagShouldBeUpdated()
        {

            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var TaskId = taskManagerEntities.Tasks.Max(x => x.Task_Id);


            TaskController controller = new TaskController();
            controller.UpdateEditFlag(TaskId, false);

            var result = controller.GetTaskDetails().Where(x => x.TaskId == TaskId).FirstOrDefault();

            
            Assert.AreEqual(result.EditFlag, false);

        }

        
    }
}
