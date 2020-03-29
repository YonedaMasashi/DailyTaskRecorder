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

        private TaskRecorderTimer _taskRecorderTimer;
        
        #region Command
        public WorkActionCommand PushedActionButtonCommand { get; private set; }
        #endregion

        public EndWorkViewModel(TaskRecorderTimer taskRecorderTimer) {
            _taskRecorderTimer = taskRecorderTimer;
            PushedActionButtonCommand = new WorkActionCommand(_taskRecorderTimer);
        }

    }
}
