using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Task
{
    public interface ITaskFactory
    {
        Task Create(TaskName name, CategoryName categoryName);
    }
}
