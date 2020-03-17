using DailyTaskRecorder.Presentaion.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Presentaion.ViewModel
{
    class TaskListViewModel : ViewModelBase
    {
        public ObservableCollection<TaskData> TaskDataList { get; }

        public TaskListViewModel()
        {
            TaskDataList = new ObservableCollection<TaskData>();
        }
    }
}
