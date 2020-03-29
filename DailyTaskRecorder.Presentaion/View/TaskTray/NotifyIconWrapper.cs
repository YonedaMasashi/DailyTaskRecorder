using DailyTaskRecorder.Domain.DataTypeDef.Enum;
using DailyTaskRecorder.Domain.Models.Setting;
using DailyTaskRecorder.Presentaion.Command;
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
        EndWorkViewModel _endWorkVM;

        // リポジトリ
        TimeIntervalRepository _repository;

        public NotifyIconWrapper(TaskListViewModel taskListVM) {
            InitializeComponent();

            _repository = new TimeIntervalRepository();

            // タイマーのインスタンス生成
            _taskListVM = taskListVM;
            _taskRecorderTimer = new TaskRecorderTimer();
            _taskRecorderTimer.DailyTaskRecorderTimerTickEventHandler += new TaskRecorderTimer.TimerTickEventHandler(CallBackEventProgress);

            // Work 終了のインスタンス作成
            _endWorkVM = new EndWorkViewModel(_taskRecorderTimer);
            _endWorkVM.PushedActionButtonCommand.DailyTaskRecorderActionChangeEventHandler += new WorkActionCommand.ActionChangeEventHandler(CallBackWorkAction);

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
                } else if (_emMode == Em_Mode.Break) {
                    toolStripMenuItem_Break.Visible = true;
                }
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
                toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Time")));
                EndWorkWindow endWorkWindow = new EndWorkWindow();
                endWorkWindow.WorkEndMessage.DataContext = _endWorkVM;
                endWorkWindow.ShowDialog();
            }
        }

        /// <summary>
        /// Mode 変更のコールバック
        /// </summary>
        /// <param name="emMode"></param>
        private void CallBackWorkAction(Em_Mode emMode) {
            EmMode = emMode;
            if (EmMode == Em_Mode.Working) {
                _taskRecorderTimer.ResetTimer();
                TimeInterval timeInterval = _repository.Load();
                _taskRecorderTimer.StartTimer(timeInterval.WorkInterval);

                toolStripMenuItem_Start.Visible = false;
                toolStripMenuItem_Break.Visible = true;

                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
                toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Start")));

            } else if (EmMode == Em_Mode.Break) {
                _taskRecorderTimer.ResetTimer();
                TimeInterval timeInterval = _repository.Load();
                _taskRecorderTimer.StartTimer(timeInterval.BreakInterval);

                toolStripMenuItem_Start.Visible = true;
                toolStripMenuItem_Break.Visible = false;

                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
                toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("Break")));

            } else {
                toolStripMenuItem_Start.Visible = true;
                toolStripMenuItem_Break.Visible = true;

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
            CallBackWorkAction(Em_Mode.Working);
        }

        /// <summary>
        /// コンテキストメニュー "Break Pomodoro" を選択したとき呼ばれます。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void toolStripMenuItem_Break_Click(object sender, EventArgs e) {
            CallBackWorkAction(Em_Mode.Break);
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
            TimeInterval timeInterval = _repository.Load();

            var settingsVM = new SettingsViewModel(timeInterval);

            SettingsWindow settingWindow = new SettingsWindow();
            settingWindow.DataContext = settingsVM;
            settingWindow.ShowDialog();
        }
    }
}
