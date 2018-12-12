using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManager.BusinessLayer.Model;
using TaskManager.DataLayer;

namespace TaskManager.BusinessLayer
{
    public class ProjectBusinessModel
    {
        public List<ProjectDetails> GetProjectDetails()
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();
            //taskmanagerEntities.Configuration.ProxyCreationEnabled = false;
            var projectList = (from project in taskmanagerEntities.Projects
                               join users in taskmanagerEntities.Users on project.Manager_Id equals users.User_Id into uGroup
                               from users in uGroup.DefaultIfEmpty()
                               select new ProjectDetails
                               {
                                   ProjectId = project.Project_Id,
                                   Name = project.Name,
                                   StartDate = project.Start_Date.ToString(),
                                   EndDate = project.End_Date.ToString(),
                                   ManagerId = project.Manager_Id

                               }).ToList<ProjectDetails>();
            return projectList;
        }

        public ProjectModel GetProjectById(int ProjectId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var Project = (from project in taskmanagerEntities.Projects
                           where project.Project_Id == ProjectId
                           select new ProjectModel() { Project_Id = project.Project_Id, Name = project.Name, Priority = project.Priority,
                               Start_Date = project.Start_Date, End_Date = project.End_Date, Manager_Id = project.Manager_Id }).FirstOrDefault();

            return Project;
        }

        public List<Projects> GetProjects()
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var projects = (from project in taskmanagerEntities.Projects
                            select new Projects() { ProjectId = project.Project_Id, ProjectName = project.Name }).ToList<Projects>();

            projects.Add(new Projects() { ProjectId = 0, ProjectName = "Select" });

            return projects.OrderBy(x => x.ProjectId).ToList();
        }

        public void Create(Project project)
        {

            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();
            // taskmanagerEntities.Configuration.ProxyCreationEnabled = false;
            taskmanagerEntities.Projects.Add(project);
            taskmanagerEntities.SaveChanges();

        }

        public void Update(Project project)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var UpdatedProjects = taskmanagerEntities.Projects.Where(x => x.Project_Id == project.Project_Id).FirstOrDefault();

            UpdatedProjects.Name = project.Name;
            UpdatedProjects.Priority = project.Priority;
            UpdatedProjects.Start_Date = project.Start_Date;
            UpdatedProjects.End_Date = project.End_Date;
            UpdatedProjects.Manager_Id = project.Manager_Id;

            taskmanagerEntities.SaveChanges();

        }

        public void Delete(int ProjectId)
        {
            TaskManagerEntities taskmanagerEntities = new TaskManagerEntities();

            var DeletedProjects = taskmanagerEntities.Projects.Where(x => x.Project_Id == ProjectId).FirstOrDefault();

            taskmanagerEntities.Entry<Project>(DeletedProjects).State = System.Data.Entity.EntityState.Deleted;

            taskmanagerEntities.SaveChanges();

        }
    }
}
