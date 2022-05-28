using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Username { get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public int ScheduledHour { get; set; }
        public int ScheduledMin { get; set; }
        public int ScheduledTime { get; set; }
        public int TimeSpent { get; set; }
        public string TaskProcess { get; set; }
        public bool TaskStatus { get; set; }
    }
}
