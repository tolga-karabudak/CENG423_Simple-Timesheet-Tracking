using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetManagement.Models;

namespace TimeSheetManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        Context c = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.allTasksbyUser = allTasksbyUser(User.Identity.Name);

            return View();
        }

        [HttpPost]
        public IActionResult Index(Models.Task p)
        {
            p.ScheduledTime = p.ScheduledHour * 3600 + p.ScheduledMin * 60;
       
            c.Tasks.Add(p);
            c.SaveChanges();
            return RedirectToAction("SingleTask", new { p.TaskId });
        }

        [HttpGet]
        public IActionResult SingleTask(int taskId)
        {
            ViewBag.allTasksbyUser = allTasksbyUser(User.Identity.Name);
            
            var task = c.Tasks.Where(x => x.TaskId == taskId).ToList();
            return View(task);
        }

        public IActionResult startProcess()
        {
            return View();
        }

        public List<Models.Task> allTasksbyUser(string userName)
        {
            var allList = c.Tasks.Where(x => x.Username == userName).ToList();
            return allList;
        }

        [HttpPost]
        public void startTask (Models.Task p)
        {
            p.TaskProcess = "Started";
            c.Tasks.Update(p);
            c.SaveChanges();
        }
        [HttpGet]
        public IActionResult EditTask(int taskId)
        {
            return PartialView(c.Tasks.FirstOrDefault(x => x.TaskId == taskId));
        }
        [HttpPost]
        public IActionResult EditTask(Models.Task p)
        {

            return View();
        }



    }
}
