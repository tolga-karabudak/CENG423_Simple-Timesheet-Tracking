using System.Collections.Generic;

namespace TimeSheet.Models.ViewModel
{
    public class StartingTaskViewModel
    {
        public List<Task> currentTask { get; set; }
        public List<Task> completedTask { get; set; }
    }
}
