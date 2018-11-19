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
        public int? Priority { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool EditFlag { get; set; }

    }
}