using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.SQLInfrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.SQLInfrastructure.Persistence.Task
{
    public class SqlTaskRepository : ITaskRepository
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlTaskRepository(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public void Delete(Domain.Models.Task.Task task)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Task WHERE TaskId = @TaskId";
                command.Parameters.Add(new SqlParameter("@TaskId", task.TaskId.Value));

                command.ExecuteNonQuery();
            }
        }

        public Domain.Models.Task.Task Find(TaskId id)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
SELECT *
FROM Task
WHERE TaskId = @TaskId
";
                command.Parameters.Add(new SqlParameter("@TaskId", id.Value));

                using (var reader = command.ExecuteReader())
                {
                    return CreteTaskFormDB(reader);
                }
            }
        }

        public Domain.Models.Task.Task Find(TaskName name)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
SELECT *
FROM Task
WHERE TaskName = @TaskName
";
                command.Parameters.Add(new SqlParameter("@TaskName", name.Value));

                using (var reader = command.ExecuteReader())
                {
                    return CreteTaskFormDB(reader);
                }
            }
        }

        public void Save(Domain.Models.Task.Task task)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
insert into Task
(TaskId, TaskName, CategoryName, Status)
values
(@TaskId, @TaskName, @CategoryName, @Status)
on conflict(TaskId)
do update
  set
    CategoryName = @CategoryName,
    Status = @Status
;";
                command.Parameters.Add(new SqlParameter("@TaskId", task.TaskId.Value));
                command.Parameters.Add(new SqlParameter("@TaskName", task.TaskName.Value));
                command.Parameters.Add(new SqlParameter("@CategoryName", task.CategoryName.Value));
                command.Parameters.Add(new SqlParameter("@Status", task.Status.Value.ToString()));

                command.ExecuteNonQuery();
            }
        }


        private static Domain.Models.Task.Task CreteTaskFormDB(SqlDataReader reader)
        {
            if (reader.Read())
            {
                var taskId = (int)reader["TaskId"];
                var taskName = (string)reader["TaskName"];
                var categoryName = (string)reader["CategoryName"];
                var taskStatus = (string)reader["Status"];

                var task = new Domain.Models.Task.Task(
                    new TaskName(taskName),
                    new TaskId(taskId),
                    new CategoryName(categoryName),
                    new Domain.Models.Task.TaskStatus(TaskStatusEnumUtil.ConvEnum(taskStatus))
                    );
                return task;
            }
            else
            {
                return null;
            }
        }

    }
}
