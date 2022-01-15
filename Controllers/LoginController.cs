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
    public class LoginController : ControllerBase
    {
        private ILoginrespository LoginRepository { get; set; }
        public LoginController(ILoginrespository LoginRepository)
        {
            this.LoginRepository = LoginRepository;
        }

        public LoginController()
        {
        }

        [HttpPost]
        [Route("api/Login/validateuser")]
        public IActionResult  validateuser(LoginModel LoginModel)
        {

           string status=  LoginRepository.ValidateUser(LoginModel.Name, LoginModel.Password);

            if(status == "success")
            {
                return Ok(200);
            }
            else
            {
                return NotFound(404);
            }
        }
    }
}