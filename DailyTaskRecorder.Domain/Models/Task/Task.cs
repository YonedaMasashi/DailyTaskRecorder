using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Task
{
    public class Task
    {
        public Task(TaskName taskName, TaskId taskId, CategoryName categoryName, TaskStatus taskStatus)
        {
            if (taskName == null) throw new ArgumentNullException(nameof(taskName));
            if (taskId == null) throw new ArgumentNullException(nameof(taskId));
            if (categoryName == null) throw new ArgumentNullException(nameof(categoryName));
            if (taskStatus == null) throw new ArgumentNullException(nameof(taskStatus));

            TaskName = taskName;
            TaskId = taskId;
            CategoryName = categoryName;
            Status = taskStatus;
        }

        public TaskName TaskName { get; private set; }
        public TaskId TaskId { get; private set; }
        public CategoryName  CategoryName { get; private set; }
        public TaskStatus Status { get; private set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("TaskName:" + TaskName + ", ");
            sb.Append("TaskId:" + TaskId + ", ");
            sb.Append("CategoryName:" + CategoryName + ", ");
            sb.Append("Status:" + Status + ", ");
             
            return sb.ToString();
        }
    }
}
