using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.Presentaion.View;
using DailyTaskRecorder.Presentaion.ViewModel;
using DailyTaskRecorder.SQLInfrastructure.Persistence.Task;
using DailyTaskRecorder.SQLInfrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DailyTaskRecorder.SqliteCreator {
    class SqliteInitializer {
        
        public static TaskListViewModel Create() {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var provider = new DatabaseConnectionProvider(connectionString);

            ITaskFactory taskFactory = new SqlTaskFactory(provider);
            ITaskRepository taskRepository = new SqlTaskRepository(provider);

            return new TaskListViewModel(taskFactory, taskRepository);

        }
    }
}
