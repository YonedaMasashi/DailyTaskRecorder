using DailyTaskRecorder.Domain.Models.Setting;
using DailyTaskRecorder.Presentaion.Repository;
using DailyTaskRecorder.Presentaion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyTaskRecorder.Presentaion.Command {
    public class SettingSaveCommand : ICommand {

        public SettingSaveCommand() { }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            var timeIntervalVM = parameter as SettingsViewModel;

            TimeInterval timeInterval = new TimeInterval(
                new IntervalMinute(timeIntervalVM.WorkInterval),
                new IntervalMinute(timeIntervalVM.BreakInterval));

            TimeIntervalRepository repository = new TimeIntervalRepository();
            repository.Save(timeInterval);
        }
    }
}
