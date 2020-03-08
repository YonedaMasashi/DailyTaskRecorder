using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DailyTaskRecorder.Domain;
using DailyTaskRecorder.Presentaion.ViewModel;

namespace DailyTaskRecorder {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        ObservableCollection<DailyTaskViewModel> dailyTaskList = new ObservableCollection<DailyTaskViewModel>();

        public MainWindow() {
            InitializeComponent();

            dailyTaskList.Add(new DailyTaskViewModel(new DailyTask() { No = 1, Status = "nop", TaskName = "Task1" }));
            dailyTaskList.Add(new DailyTaskViewModel(new DailyTask() { No = 2, Status = "nop", TaskName = "Task2" }));

            DailyTaskListUC.DataContext = dailyTaskList;
        }
    }
}
