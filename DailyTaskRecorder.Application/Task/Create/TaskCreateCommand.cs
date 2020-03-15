using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskRecorder.Application.Task.Create
{
    public class TaskCreateCommand
    {
        public TaskCreateCommand(string taskName, string categoryName) {
            TaskName = taskName;
            CategoryName = categoryName;
        }

        public string TaskName { get; }
        public string CategoryName { get; }
    }
}
