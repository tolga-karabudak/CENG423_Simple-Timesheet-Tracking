using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeSheet.Controllers
{
  
    [Authorize]
    [ApiController]
    [Route("api/[action]")]
    public class ApiController : ControllerBase
    {
        Context c = new Context();
       
        [HttpGet]
        public ActionResult<List<Models.Task>>taskList(string username)
        {
            if(User.Identity.IsAuthenticated == true)
            {
                if (!string.IsNullOrEmpty(username))
                {
                    var allList = c.Tasks.Where(x => x.Username == username).ToList();
                    return Ok(allList);
                }
                else
                {
                    return BadRequest("username parameter is missing...");
                }
            }
            else
            {
                return Unauthorized();
            }
            
           
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult frameWorkInformation(string apiVersion)
        {
            if (!string.IsNullOrEmpty(apiVersion))
            {
                return Ok("Asp.net Core 3.1");
            }
            else
            {
                return BadRequest("Missing apiVersion...");
            }
        }

       




    }
}
