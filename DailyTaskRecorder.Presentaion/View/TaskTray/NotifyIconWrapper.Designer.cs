﻿namespace DailyTaskRecorder.Presentaion.View.TaskTray {
    partial class NotifyIconWrapper {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_TimeText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Break = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_TaskEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DailyTaskRecorder";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_TimeText,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Start,
            this.toolStripMenuItem_Break,
            this.toolStripSeparator2,
            this.toolStripMenuItem_TaskEdit,
            this.toolStripMenuItem_Settings,
            this.toolStripMenuItem_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 148);
            // 
            // toolStripMenuItem_TimeText
            // 
            this.toolStripMenuItem_TimeText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_TimeText.Image")));
            this.toolStripMenuItem_TimeText.Name = "toolStripMenuItem_TimeText";
            this.toolStripMenuItem_TimeText.Size = new System.Drawing.Size(157, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripMenuItem_Start
            // 
            this.toolStripMenuItem_Start.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Start.Image")));
            this.toolStripMenuItem_Start.Name = "toolStripMenuItem_Start";
            this.toolStripMenuItem_Start.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_Start.Text = "Start Pomodoro";
            // 
            // toolStripMenuItem_Break
            // 
            this.toolStripMenuItem_Break.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Break.Image")));
            this.toolStripMenuItem_Break.Name = "toolStripMenuItem_Break";
            this.toolStripMenuItem_Break.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_Break.Text = "Break";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripMenuItem_TaskEdit
            // 
            this.toolStripMenuItem_TaskEdit.Name = "toolStripMenuItem_TaskEdit";
            this.toolStripMenuItem_TaskEdit.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_TaskEdit.Text = "Task Edit";
            // 
            // toolStripMenuItem_Settings
            // 
            this.toolStripMenuItem_Settings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Settings.Image")));
            this.toolStripMenuItem_Settings.Name = "toolStripMenuItem_Settings";
            this.toolStripMenuItem_Settings.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_Settings.Text = "Settings...";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_Exit.Text = "Close";
            this.contextMenuStrip1.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TimeText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Start;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Break;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TaskEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Settings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
    }
}
