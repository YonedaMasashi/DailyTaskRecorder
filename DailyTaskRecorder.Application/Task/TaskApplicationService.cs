using DailyTaskRecorder.Application.Task.Create;
using DailyTaskRecorder.Domain.Models.Task;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DailyTaskRecorder.Application.Task
{
    class TaskApplicationService
    {
        ITaskFactory taskFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void Create(TaskCreateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var taskId = new TaskId(command.TaskId);
                var taskName = new TaskName(command.TaskName);
                var categoryName = new CategoryName(command.CategoryName);

                var task = taskFactory.Create(taskName, taskId, categoryName);
            }
        }
    }
}
