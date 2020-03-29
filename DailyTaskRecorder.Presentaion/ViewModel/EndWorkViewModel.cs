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

namespace DailyTaskRecorder.Presentaion.ViewModel {
    class EndWorkViewModel : ViewModelBase {

        #region Property
        private Em_Mode _emMode;
        public Em_Mode EmMode {
            get { return _emMode; }
            set {
                if (_emMode != value) {
                    _emMode = value;
                    RaisePropertyChanged("EmMode");
                }
            }
        }

        private TaskRecorderTimer _taskRecorderTimer;

        #endregion

        #region Command
        public WorkActionCommand PushedActionButtonCommand { get; private set; }
        #endregion

        public EndWorkViewModel(TaskRecorderTimer taskRecorderTimer) {
            _emMode = Em_Mode.Stop;
            _taskRecorderTimer = taskRecorderTimer;
            _taskRecorderTimer.PropertyChanged += EmMode_PropertyChanged;
            PushedActionButtonCommand = new WorkActionCommand(_taskRecorderTimer);
        }

        /// <summary>
        /// Model の変更通知を受け取る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmMode_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "EmMode") {
                EmMode = _taskRecorderTimer.EmMode;
            }
        }
    }
}
