using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyTaskRecorder.Presentaion.Framework {
    public class DelegateCommand : ICommand {
        Action<object> execute;
        Func<object, bool> canExecute;

        public bool CanExecute(object parameter) {
            return canExecute(parameter);
        }

        public event System.EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) {
            execute(parameter);
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute)
            : this(execute, o => true) {
        }
    }
}
