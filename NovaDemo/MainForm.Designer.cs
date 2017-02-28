namespace NovaDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.DGEvent = new System.Windows.Forms.DataGridView();
			this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LayoutActiveEvent = new System.Windows.Forms.TableLayoutPanel();
			this.SCMainWindow = new System.Windows.Forms.SplitContainer();
			this.LabelVenStatus = new System.Windows.Forms.Label();
			this.UCEventLog = new NovaDemo.EventLog();
			((System.ComponentModel.ISupportInitialize)(this.DGEvent)).BeginInit();
			this.LayoutActiveEvent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SCMainWindow)).BeginInit();
			this.SCMainWindow.Panel1.SuspendLayout();
			this.SCMainWindow.Panel2.SuspendLayout();
			this.SCMainWindow.SuspendLayout();
			this.SuspendLayout();
			// 
			// DGEvent
			// 
			this.DGEvent.AllowUserToAddRows = false;
			this.DGEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventID,
            this.StartTime,
            this.Duration,
            this.Status});
			this.DGEvent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DGEvent.Location = new System.Drawing.Point(3, 23);
			this.DGEvent.Name = "DGEvent";
			this.DGEvent.ReadOnly = true;
			this.DGEvent.Size = new System.Drawing.Size(980, 242);
			this.DGEvent.TabIndex = 0;
			// 
			// EventID
			// 
			this.EventID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.EventID.HeaderText = "Event ID";
			this.EventID.Name = "EventID";
			this.EventID.ReadOnly = true;
			// 
			// StartTime
			// 
			this.StartTime.HeaderText = "Start Time";
			this.StartTime.Name = "StartTime";
			this.StartTime.ReadOnly = true;
			this.StartTime.Width = 150;
			// 
			// Duration
			// 
			this.Duration.HeaderText = "Duration (seconds)";
			this.Duration.Name = "Duration";
			this.Duration.ReadOnly = true;
			this.Duration.Width = 120;
			// 
			// Status
			// 
			this.Status.HeaderText = "Status";
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			// 
			// LayoutActiveEvent
			// 
			this.LayoutActiveEvent.ColumnCount = 1;
			this.LayoutActiveEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.LayoutActiveEvent.Controls.Add(this.DGEvent, 0, 1);
			this.LayoutActiveEvent.Controls.Add(this.LabelVenStatus, 0, 0);
			this.LayoutActiveEvent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LayoutActiveEvent.Location = new System.Drawing.Point(0, 0);
			this.LayoutActiveEvent.Name = "LayoutActiveEvent";
			this.LayoutActiveEvent.RowCount = 2;
			this.LayoutActiveEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.LayoutActiveEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.LayoutActiveEvent.Size = new System.Drawing.Size(986, 268);
			this.LayoutActiveEvent.TabIndex = 1;
			// 
			// SCMainWindow
			// 
			this.SCMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SCMainWindow.Location = new System.Drawing.Point(0, 0);
			this.SCMainWindow.Name = "SCMainWindow";
			this.SCMainWindow.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SCMainWindow.Panel1
			// 
			this.SCMainWindow.Panel1.Controls.Add(this.LayoutActiveEvent);
			// 
			// SCMainWindow.Panel2
			// 
			this.SCMainWindow.Panel2.Controls.Add(this.UCEventLog);
			this.SCMainWindow.Size = new System.Drawing.Size(986, 586);
			this.SCMainWindow.SplitterDistance = 268;
			this.SCMainWindow.TabIndex = 2;
			// 
			// LabelVenStatus
			// 
			this.LabelVenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelVenStatus.AutoSize = true;
			this.LabelVenStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelVenStatus.Location = new System.Drawing.Point(3, 0);
			this.LabelVenStatus.Name = "LabelVenStatus";
			this.LabelVenStatus.Size = new System.Drawing.Size(155, 20);
			this.LabelVenStatus.TabIndex = 1;
			this.LabelVenStatus.Text = "Ven Event Status:";
			this.LabelVenStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UCEventLog
			// 
			this.UCEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UCEventLog.Location = new System.Drawing.Point(0, 0);
			this.UCEventLog.Name = "UCEventLog";
			this.UCEventLog.Size = new System.Drawing.Size(986, 314);
			this.UCEventLog.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(986, 586);
			this.Controls.Add(this.SCMainWindow);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DGEvent)).EndInit();
			this.LayoutActiveEvent.ResumeLayout(false);
			this.LayoutActiveEvent.PerformLayout();
			this.SCMainWindow.Panel1.ResumeLayout(false);
			this.SCMainWindow.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SCMainWindow)).EndInit();
			this.SCMainWindow.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGEvent;
		private System.Windows.Forms.TableLayoutPanel LayoutActiveEvent;
		private System.Windows.Forms.Label LabelVenStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
		private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.SplitContainer SCMainWindow;
		private EventLog UCEventLog;
	}
}

