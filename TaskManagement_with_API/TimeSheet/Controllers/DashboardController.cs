using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        Context c = new Context();
       
        public IActionResult Index(string Response)
        {
            if (string.IsNullOrEmpty(Response))
            {
                ViewBag.response = null;
            }
            ViewBag.response = Response;
           
            return View();
        }
        [HttpPost]
        public IActionResult Index(Models.Task p)
        {
            var foundedTaskByUser = c.Tasks.FirstOrDefault(x => x.TaskName == p.TaskName && x.Username == User.Identity.Name && x.TaskStatus == true);
            if (foundedTaskByUser == null)
            {
                p.ScheduledTime = p.ScheduledHour * 3600 + p.ScheduledMin * 60;
                c.Tasks.Add(p);
                c.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", new { Response = "Error! There is a active task with same Task Name." });
            }
            return RedirectToAction("startingTask", new { taskId = p.TaskId });
        }
        public IActionResult startingTask(int taskId)
        {
            var task = c.Tasks.Where(x => x.TaskId == taskId).ToList();
            return View(task);
        }


        


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authentication");
        }


    }
}
