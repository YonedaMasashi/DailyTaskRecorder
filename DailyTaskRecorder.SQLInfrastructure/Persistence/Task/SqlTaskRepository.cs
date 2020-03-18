using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.SQLInfrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
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
                command.Parameters.Add(new SQLiteParameter("@TaskId", task.TaskId.Value));

                command.ExecuteNonQuery();
            }
        }

        public List<Domain.Models.Task.Task> FindAll() 
        {
            var resultList = new List<Domain.Models.Task.Task>();
            using (var command = provider.Connection.CreateCommand()) {
                command.CommandText = @"
SELECT *
FROM Task
";
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read() == true) {
                        var task = CreteTaskFormDB(reader);
                        resultList.Add(task);
                    }
                }
            }
            return resultList;
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
                command.Parameters.Add(new SQLiteParameter("@TaskId", id.Value));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read() == true) return CreteTaskFormDB(reader);
                    else return null;
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
                command.Parameters.Add(new SQLiteParameter("@TaskName", name.Value));

                using (var reader = command.ExecuteReader()) {
                    if (reader.Read() == true) return CreteTaskFormDB(reader);
                    else return null;
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
                command.Parameters.Add(new SQLiteParameter("@TaskId", task.TaskId.Value));
                command.Parameters.Add(new SQLiteParameter("@TaskName", task.TaskName.Value));
                command.Parameters.Add(new SQLiteParameter("@CategoryName", task.CategoryName.Value));
                command.Parameters.Add(new SQLiteParameter("@Status", task.Status.Value.ToString()));

                command.ExecuteNonQuery();
            }
        }


        private static Domain.Models.Task.Task CreteTaskFormDB(SQLiteDataReader reader)
        {
            var taskId = (Int64)reader["TaskId"];
            
            var taskName = (string)reader["TaskName"];
            var categoryName = (string)reader["CategoryName"];
            var taskStatus = (string)reader["Status"];

            var task = new Domain.Models.Task.Task(
                new TaskName(taskName),
                new TaskId((int)taskId),
                new CategoryName(categoryName),
                new Domain.Models.Task.TaskStatus(TaskStatusEnumUtil.ConvEnum(taskStatus))
                );
            return task;
        }

    }
}
