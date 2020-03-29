using DailyTaskRecorder.Domain.DataTypeDef.Enum;
using DailyTaskRecorder.Domain.Models.Setting;
using DailyTaskRecorder.Presentaion.Component;
using DailyTaskRecorder.Presentaion.Repository;
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

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            string pushedButtonName = (string)parameter;
            if (pushedButtonName == "StartWork") {
                DailyTaskRecorderActionChangeEventHandler(Em_Mode.Working);

            } else if (pushedButtonName == "Break") {
                DailyTaskRecorderActionChangeEventHandler(Em_Mode.Break);

            } else {
                DailyTaskRecorderActionChangeEventHandler(Em_Mode.Stop);

            }
        }

        #region Event Delegate
        public delegate void ActionChangeEventHandler(Em_Mode emMode);
        public event ActionChangeEventHandler DailyTaskRecorderActionChangeEventHandler;
        #endregion

    }
}
