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
                               select new TaskDetails { TaskId = task.Task_Id, Task = task.Task1, ParentTask = parenttask.Task1 != null ? parenttask.Task1 : "", Priority = task.Priority, StartDate = task.Start_Date.ToString(), EndDate = task.End_Date.ToString(), EditFlag = task.EditFlag }).ToList<TaskDetails>();
            return TaskDetails;
        }

        public Task GetTaskById(int TaskId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            return taskmanagerEntities.Tasks.FirstOrDefault(x => x.Task_Id == TaskId);
        }

        public List<ParentTask> GetParentTask(int? TaskId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var ParentTasks = (from task in taskmanagerEntities.Tasks
                               select new ParentTask() { Task = task.Task1, TaskId = task.Task_Id }).ToList<ParentTask>();

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
            UpdatedTasks.Task1 = task.Task1;
            UpdatedTasks.Parent_Id = task.Parent_Id;
            UpdatedTasks.Priority = task.Priority;
            UpdatedTasks.Start_Date = task.Start_Date;
            UpdatedTasks.End_Date = task.End_Date;

            taskmanagerEntities.SaveChanges();

        }

        public void UpdateEditFlag(int TaskId, bool EditFlag)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var UpdatedTasks = taskmanagerEntities.Tasks.Where(x => x.Task_Id == TaskId).FirstOrDefault();
            UpdatedTasks.EditFlag = EditFlag;

            taskmanagerEntities.SaveChanges();

        }

    }
}
