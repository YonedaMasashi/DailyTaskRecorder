using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.Presentaion.Command;
using DailyTaskRecorder.Presentaion.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyTaskRecorder.Presentaion.ViewModel
{
    public class TaskListViewModel : ViewModelBase
    {
        #region << プロパティ >>
        public ObservableCollection<TaskData> TaskDataList { get; }

        private ObservableCollection<string> _DispStatusList = null;
        public ObservableCollection<string> DispStatusList {
            get { return _DispStatusList; }
            private set {
                _DispStatusList = value;
            }
        }

        private string _SelectedStatus = "";
        public string SelectedStatus {
            get {
                return _SelectedStatus;
            }
            set {
                _SelectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        private string _InputTaskName = "";
        public string InputTaskName {
            get {
                return _InputTaskName;
            }
            set {
                _InputTaskName = value;
                RaisePropertyChanged("InputTaskName");
            }
        }

        private string _InputCategory = "";
        public string InputCategory {
            get {
                return _InputCategory;
            }
            set {
                _InputCategory = value;
                RaisePropertyChanged("InputCategory");
            }
        }
        #endregion

        #region << コマンド >>
        public ICommand AddTaskCommand { get; private set; }
        #endregion

        public TaskListViewModel(ITaskFactory taskFactory, ITaskRepository taskRepository)
        {
            TaskDataList = new ObservableCollection<TaskData>();
            DispStatusList = new ObservableCollection<string>(TaskStatusEnumUtil.GetEnumValueList());

            AddTaskCommand = new AddTaskCommand(taskFactory, taskRepository);
        }
    }
}
