using DailyTaskRecorder.Domain.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.SQLInfrastructure.Persistence.Task
{
    public class SqlTaskFactory : ITaskFactory
    {
        public Domain.Models.Task.Task Create(TaskName name, TaskId id, CategoryName categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
