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
    public class UserController : ControllerBase
    {

        private IUserRepository UserRepository { get; set; }
        public UserController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        public UserController()
        {
        }

        /*[HttpGet]
        public int getuser()
        {
            return 1;
        }
        */
        [HttpGet]
      [Route("api/User/GetaUser")]
        public ActionResult GetaUser(int id)
        {
             UserModel returnUserModel = UserRepository.GetaUser(id);
        //    UserRepository.GetaUser(id);
            if ((returnUserModel == null  ))
            {
                
                return NotFound(404);
            }
            return Ok(new { returnUserModel });
        }

        [HttpPost]
        [Route("api/User/CreateUser")]
        public ActionResult CreateUser(UserModel UserModel)
        {
            UserRepository.CreateUser(UserModel);

             return Ok(200);
        }
     
  
        [HttpPut]
        [Route("api/User/UpdateUser")]
        public ActionResult UpdateUser(UserModel UserModel)
        {
            string status= UserRepository.UpdateUser(UserModel);

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
        [Route("api/User/Getalluser")]
        public ActionResult Getalluser()
        {
            List<UserModel> lstUserModels = UserRepository.GetGetalluser();
            return Ok(new { lstUserModels });

        }
    }


    }