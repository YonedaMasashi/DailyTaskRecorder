using DailyTaskRecorder.Domain.DataTypeDef.Enum;
using DailyTaskRecorder.Presentaion.Command;
using DailyTaskRecorder.Presentaion.Component;
using DailyTaskRecorder.Presentaion.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DailyTaskRecorder.Presentaion.ViewModel {
    public class EndWorkViewModel : ViewModelBase {

        private TaskRecorderTimer _taskRecorderTimer;
        
        #region Command
        public DelegateCommand StartCommand { get; private set; }
        public DelegateCommand BreakCommand { get; private set; }
        #endregion

        #region Event Delegate
        public delegate void ActionChangeEventHandler(Em_Mode emMode);
        public event ActionChangeEventHandler DailyTaskRecorderActionChangeEventHandler;
        #endregion

        #region Property
        public string _EndMessage = "";
        public string EndMessage {
            get {
                return _EndMessage;
            }
            set {
                _EndMessage = value;
                RaisePropertyChanged("EndMessage");
            }
        }
        #endregion

        public EndWorkViewModel(TaskRecorderTimer taskRecorderTimer) {
            _taskRecorderTimer = taskRecorderTimer;
            StartCommand = new DelegateCommand(Start);
            BreakCommand = new DelegateCommand(Break);
        }

        public void Start(object parameter) {
            DailyTaskRecorderActionChangeEventHandler(Em_Mode.Working);
            var window = parameter as Window;
            window.Close();
        }

        public void Break(object parameter) {
            DailyTaskRecorderActionChangeEventHandler(Em_Mode.Break);
            var window = parameter as Window;
            window.Close();
        }
    }
}
