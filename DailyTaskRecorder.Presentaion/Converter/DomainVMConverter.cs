using DailyTaskRecorder.Presentaion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Presentaion.Converter {
    class DomainVMConverter {

        public static TaskData ConvTaskDomainToVM(DailyTaskRecorder.Domain.Models.Task.Task task) {
            var taskData = new TaskData();
            taskData.TaskName = task.TaskName.Value;
            taskData.TaskId = task.TaskId.Value;
            taskData.CategoryName = task.CategoryName.Value;
            taskData.Status = task.Status.Value.ToString();

            return taskData;
        }
    }
}
