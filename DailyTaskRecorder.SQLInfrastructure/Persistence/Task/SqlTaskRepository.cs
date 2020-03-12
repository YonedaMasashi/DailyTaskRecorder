using DailyTaskRecorder.Domain.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.SQLInfrastructure.Persistence.Task
{
    public class SqlTaskRepository : ITaskRepository
    {
        public void Delete(Domain.Models.Task.Task task)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Task.Task Find(TaskId id)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Task.Task Find(TaskName name)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Models.Task.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
