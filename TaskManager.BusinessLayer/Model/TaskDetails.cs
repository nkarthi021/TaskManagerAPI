using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.BusinessLayer.Model
{
    public class TaskDetails
    {
        public int TaskId { get; set; }
        public string Task { get; set; }
        public string ParentTask { get; set; }
        public int Priority { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool EditFlag { get; set; }
        public string User { get; set; }
        public string Project { get; set; }

    }

    public partial class TaskModel
    {
        public int Task_Id { get; set; }
        public Nullable<int> Parent_Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public int Priority { get; set; }
        public bool Edit_Flag { get; set; }
        public int User_Id { get; set; }
        public int Project_Id { get; set; }

    }

    public class ParentTask
    {
        public int TaskId { get; set; }
        public string Task { get; set; }
    }
}