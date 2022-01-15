using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private ITaskRepository TaskRepository { get; set; }
        public TaskController(ITaskRepository TaskRepository)
        {
            this.TaskRepository = TaskRepository;
        }

        public TaskController()
        {
        }

        [HttpPost]
        [Route("api/Task/CreateTask")] 
        public ActionResult CreateTask(TaskModel TaskModel)
        {
            TaskRepository.CreateTask(TaskModel);
            return Ok(200);
        }
        [HttpPut]
        [Route("api/Task/UpdateTask")]
        public ActionResult UpdateTask(TaskModel TaskModel)
        {
            string status = TaskRepository.UpdateTask(TaskModel);
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
        [Route("api/Task/GetallTasks")]
        public ActionResult GetallTasks()
        {

            List<TaskModel> lsttaskModels = TaskRepository.GetallTasks();
        
            return Ok(new { lsttaskModels });
        }
   
        [HttpGet]
        [Route("api/Task/GetaTask")]

        public ActionResult GetaTask(int id)
        {
            TaskModel returnTaskModel = TaskRepository.GetaTask(id);

            if ((returnTaskModel == null))
            {

                return NotFound(404);
            }
            return Ok(new { returnTaskModel });
        }
    }
}