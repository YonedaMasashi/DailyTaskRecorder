﻿using DailyTaskRecorder.Presentaion.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DailyTaskRecorder {
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application {

        [STAThread]
        public static void Main() {
            TaskListWindow window = new TaskListWindow();
            window.ShowDialog();
        }
    }
}
