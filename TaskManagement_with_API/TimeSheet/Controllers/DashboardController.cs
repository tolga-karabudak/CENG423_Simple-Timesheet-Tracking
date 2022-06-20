using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Models.ViewModel;

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
            var tasks = c.Tasks;

            return View(tasks);
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

        public IActionResult editView(int id)
        {
            var entity = c.Tasks.Where(x => x.TaskId == id).FirstOrDefault();
            return View("edit", entity);
        }

        [HttpPost]
        public IActionResult edit(Models.Task p)
        {
            var foundedTaskByUser = c.Tasks.FirstOrDefault(x => x.TaskId == p.TaskId);
            if (foundedTaskByUser != null)
            {
                foundedTaskByUser.ScheduledTime = p.ScheduledHour * 3600 + p.ScheduledMin * 60;
                foundedTaskByUser.ScheduledMin = p.ScheduledMin;
                foundedTaskByUser.ScheduledHour = p.ScheduledHour;
                foundedTaskByUser.TaskDesc = p.TaskDesc;
                foundedTaskByUser.TaskName = p.TaskName;
                c.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", new { Response = "Error! There is a active task with same Task Name." });
            }
            return RedirectToAction("startingTask", new { taskId = p.TaskId });
        }

        public IActionResult finish (int id)
        {
            var entity = c.Tasks.Where(x => x.TaskId == id).FirstOrDefault();
            entity.TaskProcess = "Completed";
            entity.TimeSpent = entity.ScheduledTime;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult remove(int id)
        {
            var entity = c.Tasks.Where(x => x.TaskId == id).FirstOrDefault();
            c.Tasks.Remove(entity);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult continueTask(int id)
        {
            return RedirectToAction("startingTask", new { taskId = id });
        }


        public IActionResult startingTask(int taskId)
        {
            var task = c.Tasks.Where(x => x.TaskId == taskId).ToList();
            var completedTask = c.Tasks.Where(x => x.TaskProcess == "Completed").ToList();
            StartingTaskViewModel viewModel = new StartingTaskViewModel
            {
                 currentTask = task,
                 completedTask = completedTask,
            };


            return View(viewModel);
        }


        


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authentication");
        }


    }
}
