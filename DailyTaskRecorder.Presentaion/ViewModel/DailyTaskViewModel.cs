﻿using DailyTaskRecorder.Domain;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Presentaion.ViewModel {
    public class DailyTaskViewModel : BindableBase {

        private DailyTask _DailyTask = null;

        public DailyTaskViewModel(DailyTask dailyTask) {
            _DailyTask = dailyTask;
        }

        private long _No = 0;
        public long No {
            get { return _No; }
            set { SetProperty(ref this._No, value); }
        }

        private string _Status = "";
        public string Status {
            get { return _Status; }
            set { SetProperty(ref this._Status, value); }
        }

        private string _TaskName = "";
        public string TaskName {
            get { return _TaskName; }
            set { SetProperty(ref this._TaskName, value); }
        }
    }
}
