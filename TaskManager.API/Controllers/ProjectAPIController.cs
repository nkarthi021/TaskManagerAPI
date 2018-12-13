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
    public class ProjectAPIController : ApiController
    {
        [Route("api/Project/GetProjectDetails")]
        [HttpGet]
        public List<ProjectDetails> GetProjectDetails()
        {
            ProjectBusinessModel projectBusinessModel = new ProjectBusinessModel();
            return projectBusinessModel.GetProjectDetails();
        }

        [Route("api/Project/GetProject")]
        [HttpGet]
        public ProjectModel GetProjectbyId(int ProjectId)
        {
            ProjectBusinessModel projectBusinessModel = new ProjectBusinessModel();

            return projectBusinessModel.GetProjectById(ProjectId);
        }

        [Route("api/Project/GetProjects")]
        [HttpGet]
        public List<Projects> GetProjects()
        {
            ProjectBusinessModel projectBusinessModel = new ProjectBusinessModel();

            return projectBusinessModel.GetProjects();
        }

        [Route("api/Project/Create")]
        [HttpPost]
        public string Create(Project Project)
        {
            
            if (ModelState.IsValid)
            {
                ProjectBusinessModel projectBusinessModel = new ProjectBusinessModel();
                projectBusinessModel.Create(Project);
                return "Success";
            }
            else return "Failure";
        }

        [Route("api/Project/Update")]
        [HttpPost]
        public string Update(Project Project)
        {
            if (ModelState.IsValid)
            {
                ProjectBusinessModel projectBusinessModel = new ProjectBusinessModel();
                projectBusinessModel.Update(Project);

                return "Success";
            }
            else return "Failure";
        }

        [Route("api/Project/Delete")]
        [HttpPost]
        public string Delete(int ProjectId)
        {
            try
            {
                ProjectBusinessModel projectBusinessModel = new ProjectBusinessModel();
                projectBusinessModel.Delete(ProjectId);

                return "Success";

            }

            catch (Exception ex)
            {
                return "Error";
            }


        }
    }
}
