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
    public class ProjectAPITestController
    {
        [TestMethod]
        public void GetProjectDetails_ShouldReturnAllProject()
        {
            TaskManagerEntities entity = new TaskManagerEntities();
            var ActualResult = entity.Projects.ToList();

            ProjectAPIController controller = new ProjectAPIController();

            var APIResult = controller.GetProjectDetails();

            //Assert.IsNotNull(APIResult);
            Assert.AreEqual(ActualResult.Count(), APIResult.Count());
        }

        [TestMethod]
        public void CreateProject_ProjectShouldBeAdded()
        {
            Project project = new Project();
            project.Name = "Test Project";
            project.Priority = 5;
            project.Manager_Id = 1;
            project.Start_Date = Convert.ToDateTime("01-02-2018");
            project.End_Date = Convert.ToDateTime("04-02-2018");
            

            ProjectAPIController controller = new ProjectAPIController();
            controller.Create(project);

            var result = controller.GetProjectDetails().Where(x => x.Name == "Test Project").FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Test Project");

        }

        [TestMethod]
        public void GetProjectById_ShouldReturnCorrentProject()
        {
            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            ProjectAPIController controller = new ProjectAPIController();
            var ProjectId = taskManagerEntities.Projects.Max(x => x.Project_Id);

            var result = controller.GetProjectbyId(ProjectId);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Project_Id, ProjectId);

        }

        [TestMethod]
        public void UpdateProject_ProjectShouldBeUpdated()
        {

            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var ProjectId = taskManagerEntities.Projects.Max(x => x.Project_Id);
            Project project = new Project();
            project.Project_Id = ProjectId;
            project.Name = "Updated Test Project";
            project.Manager_Id = 1;
            project.Priority = 14;
            project.Start_Date = Convert.ToDateTime("01-02-2018");
            project.End_Date = Convert.ToDateTime("04-02-2018");

            ProjectAPIController controller = new ProjectAPIController();
            controller.Update(project);

            var result = controller.GetProjectDetails().Where(x => x.ProjectId == ProjectId).FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Updated Test Project");

        }

        

        [TestMethod]
        public void Delete_ProjectShouldBeDeleted()
        {

            TaskManagerEntities taskManagerEntities = new TaskManagerEntities();
            var ProjectId = taskManagerEntities.Projects.Max(x => x.Project_Id);


            ProjectAPIController controller = new ProjectAPIController();
            controller.Delete(ProjectId);

            var result = controller.GetProjectDetails().Where(x => x.ProjectId == ProjectId).FirstOrDefault();

            
            Assert.IsNull(result);

        }

        
    }
}
