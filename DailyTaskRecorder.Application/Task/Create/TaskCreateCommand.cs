using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskRecorder.Application.Task.Create
{
    public class TaskCreateCommand
    {
        public TaskCreateCommand(string taskName, int taskId, string categoryName) {
            TaskName = taskName;
            TaskId = taskId;
            CategoryName = categoryName;
        }

        public string TaskName { get; }
        public int TaskId { get; }
        public string CategoryName { get; }
    }
}
