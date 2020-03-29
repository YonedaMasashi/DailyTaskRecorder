using DailyTaskRecorder.Presentaion.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyTaskRecorder.Presentaion.Command {
    class WorkActionCommand : ICommand {

        private readonly TaskRecorderTimer _TaskRecorderTimer;

        public WorkActionCommand(TaskRecorderTimer taskRecorderTimer) {
            _TaskRecorderTimer = taskRecorderTimer;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            string pushedButtonName = (string)parameter;
            if (pushedButtonName == "StartPomodoro") {
                _TaskRecorderTimer.StartTimer(Domain.DataTypeDef.Enum.Em_Mode.Working);

            } else if (pushedButtonName == "Break") {
                _TaskRecorderTimer.StartTimer(Domain.DataTypeDef.Enum.Em_Mode.Break);

            }
        }
    }
}
