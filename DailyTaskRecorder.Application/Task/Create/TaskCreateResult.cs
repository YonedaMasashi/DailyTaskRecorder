using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskRecorder.Application.Task.Create
{
    public class TaskCreateResult
    {
        public TaskCreateResult(Domain.Models.Task.Task task)
        {
            Task = task;
        }

        public Domain.Models.Task.Task Task { get; }
    }
}
