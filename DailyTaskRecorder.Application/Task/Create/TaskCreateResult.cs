using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskRecorder.Application.Task.Create
{
    public class TaskCreateResult
    {
        public TaskCreateResult(int taskId)
        {
            TaskId = taskId;
        }

        public int TaskId { get; }
    }
}
