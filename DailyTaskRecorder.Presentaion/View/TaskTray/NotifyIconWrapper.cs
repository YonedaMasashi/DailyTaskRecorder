using DailyTaskRecorder.Domain.DataTypeDef.Enum;
using DailyTaskRecorder.Domain.Models.Setting;
using DailyTaskRecorder.Presentaion.Component;
using DailyTaskRecorder.Presentaion.Repository;
using DailyTaskRecorder.Presentaion.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyTaskRecorder.Presentaion.View.TaskTray {
    public partial class NotifyIconWrapper : System.ComponentModel.Component {
        private Em_Mode _emMode = Em_Mode.Stop;
        public Em_Mode EmMode {
            get { return _emMode; }
            set {
                _emMode = value;
            }
        }

        /// <summary>
        /// タイマー
        /// </summary>
        TaskRecorderTimer _taskRecorderTimer;
        TaskListViewModel _taskListVM;

        /// <summary>
        /// 設定画面
        /// </summary>
        SettingsViewModel _settingsVM;

        public NotifyIconWrapper(TaskListViewModel taskListVM) {
            InitializeComponent();

            // タイマーのインスタンス生成
            _taskListVM = taskListVM;
            TimeIntervalRepository repository = new TimeIntervalRepository();
            TimeInterval timeInterval = repository.Load();
            _taskRecorderTimer = new TaskRecorderTimer(timeInterval);
            _taskRecorderTimer.DailyTaskRecorderTimerTickEventHandler += new TaskRecorderTimer.TimerTickEventHandler(CallBackEventProgress);

            // コンテキストメニューのイベントを設定
            this.toolStripMenuItem_Exit.Click += this.toolStripMenuItem_Exit_Click;
            this.toolStripMenuItem_Start.Click += this.toolStripMenuItem_Start_Click;
            this.toolStripMenuItem_Break.Click += this.toolStripMenuItem_Break_Click;
            this.toolStripMenuItem_Settings.Click += this.toolStripMenuItem_Settings_Click;
            this.toolStripMenuItem_TaskEdit.Click += this.toolStripMenuItem_TaskEdit_Click;

            // TextBox の初期化
            toolStripMenuItem_TimeText.Text = "00:00";
        }

        public NotifyIconWrapper(IContainer container) {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// タイマーの Tick のコールバック
        /// </summary>
        /// <param name="e"></param>
        private void CallBackEventProgress(TimerTickEventArgs e) {
            if (e.TickKind == Em_TickKind.Normal) {
                toolStripMenuItem_TimeText.Text = e.Time;

            } else {
                if (_emMode == Em_Mode.Working) {
                    toolStripMenuItem_Start.Enabled = true;
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
                    toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Time")));
                    //EndPomodoroWindow endPomodoroWindow = new EndPomodoroWindow(_endPomodoroVM);
                    //endPomodoroWindow.ShowDialog();

                } else if (_emMode == Em_Mode.Break) {
                    toolStripMenuItem_Break.Visible = true;
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
                    toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Time")));
                    //EndPomodoroWindow endPomodoroWindow = new EndPomodoroWindow(_endPomodoroVM);
                    //endPomodoroWindow.ShowDialog();
                }
            }
        }

        /// <summary>
        /// コンテキストメニュー "終了" を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e) {
            // 現在のアプリケーションを終了
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// コンテキストメニュー "Start Pomodoro" を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void toolStripMenuItem_Start_Click(object sender, EventArgs e) {
            EmMode = Em_Mode.Working;
            _taskRecorderTimer.ResetTimer();
            _taskRecorderTimer.StartTimer(_emMode);
            toolStripMenuItem_Start.Visible = false;
            toolStripMenuItem_Break.Visible = true;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
            toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Start")));
        }

        /// <summary>
        /// コンテキストメニュー "Break Pomodoro" を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void toolStripMenuItem_Break_Click(object sender, EventArgs e) {
            EmMode = Em_Mode.Break;
            _taskRecorderTimer.ResetTimer();
            _taskRecorderTimer.StartTimer(_emMode);

            toolStripMenuItem_Start.Visible = true;
            toolStripMenuItem_Break.Visible = false;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
            toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Break")));
        }

        /// <summary>
        /// コンテキストメニュー "Task Edit" を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void toolStripMenuItem_TaskEdit_Click(object sender, EventArgs e) {
            var taskListWindow = new TaskListWindow();
            taskListWindow.DataContext = _taskListVM;
            taskListWindow.ShowDialog();
        }

        /// <summary>
        /// コンテキストメニュー "Settings..." を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void toolStripMenuItem_Settings_Click(object sender, EventArgs e) {

            // 設定画面
            TimeIntervalRepository repository = new TimeIntervalRepository();
            TimeInterval timeInterval = repository.Load();

            var settingsVM = new SettingsViewModel(timeInterval);

            SettingsWindow settingWindow = new SettingsWindow();
            settingWindow.DataContext = settingsVM;
            settingWindow.ShowDialog();
        }
    }
}
