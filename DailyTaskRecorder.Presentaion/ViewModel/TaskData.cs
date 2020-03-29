using DailyTaskRecorder.Presentaion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Presentaion.ViewModel
{
    public class TaskData : ViewModelBase {
        public int _TaskId = 0;
        public int TaskId {
            get {
                return _TaskId;
            }
            set {
                _TaskId = value;
                RaisePropertyChanged("TaskId");
            }
        }

        public string _TaskName = "";
        public string TaskName {
            get {
                return _TaskName;
            }
            set {
                _TaskName = value;
                RaisePropertyChanged("TaskName");
            }
        }

        public string _CategoryName = "";
        public string CategoryName {
            get {
                return _CategoryName;
            }
            set {
                _CategoryName = value;
                RaisePropertyChanged("CategoryName");
            }
        }
        public string _Status = "";
        public string Status {
            get {
                return _Status;
            }
            set {
                _Status = value;
                RaisePropertyChanged("Status");
            }
        }
    }
}
