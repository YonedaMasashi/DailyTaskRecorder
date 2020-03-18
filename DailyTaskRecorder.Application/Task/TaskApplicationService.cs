using DailyTaskRecorder.Application.Task.Create;
using DailyTaskRecorder.Domain.Models.Task;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DailyTaskRecorder.Application.Task
{
    public class TaskApplicationService
    {
        private readonly ITaskFactory taskFactory;
        private readonly ITaskRepository taskRepository;

        public TaskApplicationService(ITaskFactory taskFactory, ITaskRepository taskRepository)
        {
            this.taskFactory = taskFactory;
            this.taskRepository = taskRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public TaskCreateResult Create(TaskCreateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var taskName = new TaskName(command.TaskName);
                var categoryName = new CategoryName(command.CategoryName);

                var task = taskFactory.Create(taskName, categoryName);

                taskRepository.Save(task);

                transaction.Complete();

                return new TaskCreateResult(task);
            }
        }


        public List<Domain.Models.Task.Task> FindAll() {
            using (var transaction = new TransactionScope()) {
                return taskRepository.FindAll();
            }
        }
    }
}
