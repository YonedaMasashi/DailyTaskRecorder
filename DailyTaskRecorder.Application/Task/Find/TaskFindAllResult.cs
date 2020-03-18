using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Application.Task.Find {
    public class TaskFindAllResult {
        public TaskFindAllResult(List<Domain.Models.Task.Task> taskList) {
            TaskList = taskList;
        }

        public List<Domain.Models.Task.Task> TaskList { get; }
    }
}
