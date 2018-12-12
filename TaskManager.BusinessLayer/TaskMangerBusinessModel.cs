using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManager.DataLayer;
using TaskManager.BusinessLayer.Model;


namespace TaskManager.BusinessLayer
{
    public class TaskMangerBusinessModel
    {
        public List<TaskDetails> GetTaskDetails()
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();
            //taskmanagerEntities.Configuration.ProxyCreationEnabled = false;
            var TaskDetails = (from task in taskmanagerEntities.Tasks
                               join parenttask in taskmanagerEntities.Tasks on task.Parent_Id equals parenttask.Task_Id into tGroup
                               from parenttask in tGroup.DefaultIfEmpty()
                               join projects in taskmanagerEntities.Projects on task.Project_Id equals projects.Project_Id into pGroup
                               from projects in pGroup.DefaultIfEmpty()
                               join users in taskmanagerEntities.Users on task.User_Id equals users.User_Id into uGroup
                               from users in uGroup.DefaultIfEmpty()
                               select new TaskDetails {
                                   TaskId = task.Task_Id, Task = task.Name, ParentTask = parenttask.Name != null ? parenttask.Name : "", Priority = task.Priority, StartDate = task.Start_Date.ToString(),
                                   EndDate = task.End_Date.ToString(), EditFlag = task.Edit_Flag, Project = projects.Name, User = users.First_Name
                               }).ToList<TaskDetails>();
            return TaskDetails;
        }

        public TaskModel GetTaskById(int TaskId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var Task = (from task in taskmanagerEntities.Tasks
                    where task.Task_Id == TaskId
                    select new TaskModel()
                    {
                        Task_Id = task.Task_Id,
                        Name = task.Name,
                        Parent_Id = task.Parent_Id,
                        Start_Date = task.Start_Date,
                        End_Date = task.End_Date,
                        Edit_Flag = task.Edit_Flag,
                        Priority = task.Priority,
                        Project_Id = task.Project_Id,
                        User_Id = task.User_Id
                    }).FirstOrDefault();

            return Task;
        }

        public List<ParentTask> GetTasks(int? TaskId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var ParentTasks = (from task in taskmanagerEntities.Tasks
                               select new ParentTask() { Task = task.Name, TaskId = task.Task_Id }).ToList<ParentTask>();

            ParentTasks.Add(new ParentTask() { Task = "Select", TaskId = 0 });

            return TaskId != 0 ? ParentTasks.Where(x => x.TaskId != TaskId).OrderBy(x => x.TaskId).ToList() : ParentTasks.OrderBy(x => x.TaskId).ToList();
        }

        public void Create(Task task)
        {

            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();
            // taskmanagerEntities.Configuration.ProxyCreationEnabled = false;
            taskmanagerEntities.Tasks.Add(task);
            taskmanagerEntities.SaveChanges();

        }

        public void Update(Task task)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var UpdatedTasks = taskmanagerEntities.Tasks.Where(x => x.Task_Id == task.Task_Id).FirstOrDefault();
            UpdatedTasks.Name = task.Name;
            UpdatedTasks.Parent_Id = task.Parent_Id;
            UpdatedTasks.Priority = task.Priority;
            UpdatedTasks.Start_Date = task.Start_Date;
            UpdatedTasks.End_Date = task.End_Date;
            UpdatedTasks.User_Id = task.Project_Id;
            UpdatedTasks.Project_Id = task.Project_Id;

            taskmanagerEntities.SaveChanges();

        }

        public void UpdateEditFlag(int TaskId, bool EditFlag)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var UpdatedTasks = taskmanagerEntities.Tasks.Where(x => x.Task_Id == TaskId).FirstOrDefault();
            UpdatedTasks.Edit_Flag = EditFlag;

            taskmanagerEntities.SaveChanges();

        }

    }
}
