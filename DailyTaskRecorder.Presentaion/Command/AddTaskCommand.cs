using DailyTaskRecorder.Application.Task;
using DailyTaskRecorder.Application.Task.Create;
using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.Presentaion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyTaskRecorder.Presentaion.Command {
    class AddTaskCommand : ICommand {

        private readonly ITaskFactory taskFactory;
        private readonly ITaskRepository taskRepository;

        public AddTaskCommand(ITaskFactory taskFactory, ITaskRepository taskRepository) {
            this.taskFactory = taskFactory;
            this.taskRepository = taskRepository;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            TaskListViewModel vm = parameter as TaskListViewModel;
            return true;
        }

        public void Execute(object parameter) {
            TaskListViewModel vm = parameter as TaskListViewModel;

            var command = new TaskCreateCommand(vm.InputTaskName, vm.InputTaskName);
            var service = new TaskApplicationService(taskFactory, taskRepository);

            var task = service.Create(command);


        }
    }
}
