using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BusinessLayer.Model
{
    public class ProjectDetails
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Priority { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Manager { get; set; }
    }

    public class Projects
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

    }

    public class ProjectModel
    {
        public int Project_Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> Manager_Id { get; set; }
    }
}
