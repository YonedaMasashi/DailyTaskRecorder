using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.SQLInfrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.SQLInfrastructure.Persistence.Task
{
    public class SqlTaskFactory : ITaskFactory
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlTaskFactory(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public Domain.Models.Task.Task Create(TaskName name, CategoryName categoryName)
        {
            var taskId = new TaskId(AssignId());

            return new Domain.Models.Task.Task(
                name,
                taskId,
                categoryName,
                new Domain.Models.Task.TaskStatus(Em_TaskStatus.Waiting));
        }

        private int AssignId()
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = "SELECT TaskId FROM Task ORDER BY TaskId DESC";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var max = Convert.ToInt32(reader["TaskId"]);
                        var id = max + 1;
                        return id;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }
}
