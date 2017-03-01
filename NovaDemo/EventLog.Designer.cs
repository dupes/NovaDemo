namespace NovaDemo
{
	partial class EventLog
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LVEventLog = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.logDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.eventId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.startTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.logDifference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// LVEventLog
			// 
			this.LVEventLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logDate,
            this.logDifference,
            this.message,
            this.eventId,
            this.startTime,
            this.duration});
			this.LVEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LVEventLog.Location = new System.Drawing.Point(3, 23);
			this.LVEventLog.Name = "LVEventLog";
			this.LVEventLog.Size = new System.Drawing.Size(787, 318);
			this.LVEventLog.TabIndex = 0;
			this.LVEventLog.UseCompatibleStateImageBehavior = false;
			this.LVEventLog.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(787, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Event Log";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.LVEventLog, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 344);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// logDate
			// 
			this.logDate.Text = "Log Date";
			this.logDate.Width = 125;
			// 
			// eventId
			// 
			this.eventId.Text = "Event Id";
			this.eventId.Width = 116;
			// 
			// startTime
			// 
			this.startTime.Text = "Start Time";
			this.startTime.Width = 125;
			// 
			// duration
			// 
			this.duration.Text = "Duration (seconds)";
			this.duration.Width = 204;
			// 
			// logDifference
			// 
			this.logDifference.Text = "Difference (seconds)";
			this.logDifference.Width = 114;
			// 
			// message
			// 
			this.message.Text = "Message";
			// 
			// EventLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "EventLog";
			this.Size = new System.Drawing.Size(793, 344);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView LVEventLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ColumnHeader logDate;
		private System.Windows.Forms.ColumnHeader eventId;
		private System.Windows.Forms.ColumnHeader startTime;
		private System.Windows.Forms.ColumnHeader duration;
		private System.Windows.Forms.ColumnHeader logDifference;
		private System.Windows.Forms.ColumnHeader message;
	}
}
