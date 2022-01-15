using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private IProjectRepository ProjectRepository { get; set; }
        public ProjectController(IProjectRepository ProjectRepository)
        {
            this.ProjectRepository = ProjectRepository;
        }

        public ProjectController()
        {
        }

        [HttpPost]
        [Route("api/Project/createproject")]
        public IActionResult createproject(ProjectModel ProjectModel)
        {

            ProjectRepository.createproject(ProjectModel);
            return Ok(200);
        }

        [HttpPut]
        [Route("api/Project/Updateproject")]
        public IActionResult Updateproject(ProjectModel ProjectModel)
        {
            string status = ProjectRepository.Updateproject(ProjectModel);
            if (status == "success")
            {
                return Ok(200);
            }
            else
            {
                return NotFound(404);
            }
            
        }
        [HttpGet]
        [Route("api/Project/Getallproject")]
        public IActionResult Getallproject()
        {
            List<ProjectModel> lstprojectModels = ProjectRepository.Getallproject();
        
            return Ok(new { lstprojectModels });
        }
        [HttpGet]
        [Route("api/Project/Getaproject")]
        public IActionResult Getaproject(int id)
        {



            ProjectModel returnProjectModel = ProjectRepository.Getaproject(id);;


            if ((returnProjectModel == null))
            {

                return NotFound(404);
            }
            return Ok(new { returnProjectModel });
        }
    }
}