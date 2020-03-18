using DailyTaskRecorder.Application.Task;
using DailyTaskRecorder.Domain.Models.Task;
using DailyTaskRecorder.Presentaion.Converter;
using DailyTaskRecorder.Presentaion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyTaskRecorder.Presentaion.Command {
    class FindAllTaskCommand : ICommand {

        private readonly ITaskFactory taskFactory;
        private readonly ITaskRepository taskRepository;

        public FindAllTaskCommand(ITaskFactory taskFactory, ITaskRepository taskRepository) {
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

            var service = new TaskApplicationService(taskFactory, taskRepository);

            var taskList = service.FindAll();

            vm.TaskDataList.Clear();
            foreach (var elem in taskList) {
                var taskData = DomainVMConverter.ConvTaskDomainToVM(elem);
                vm.TaskDataList.Add(taskData);
            }

        }
    }
}
