using DailyTaskRecorder.Domain.Models.Setting;
using DailyTaskRecorder.Presentaion.Command;
using DailyTaskRecorder.Presentaion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Presentaion.ViewModel {
    public class SettingsViewModel : ViewModelBase {

        public int _WorkInterval = 15;
        public int WorkInterval {
            get { return _WorkInterval; }
            set {
                _WorkInterval = value;
                RaisePropertyChanged("WorkInterval");
            }
        }

        public int _BreakInterval = 5;
        public int BreakInterval {
            get { return _BreakInterval; }
            set {
                _BreakInterval = value;
                RaisePropertyChanged("BreakInterval");
            }
        }

        public SettingsViewModel(TimeInterval timeInterval) {
            _WorkInterval = timeInterval.WorkInterval.Value;
            _BreakInterval = timeInterval.BreakInterval.Value;

            PushedSettingSaveCommand = new SettingSaveCommand();
        }

        #region Command
        public SettingSaveCommand PushedSettingSaveCommand { get; private set; }
        #endregion

    }
}
