using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Task
{
    public interface ITaskRepository
    {
        Task Find(TaskId id);
        Task Find(TaskName name);
        void Save(Task task);
        void Delete(Task task);
    }
}
