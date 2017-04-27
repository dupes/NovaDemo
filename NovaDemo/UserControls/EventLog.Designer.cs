namespace NovaDemo.UserControls
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LVEventLog = new System.Windows.Forms.ListView();
            this.logDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logDifference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbLogMessage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LVEventLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbLogMessage);
            this.splitContainer1.Size = new System.Drawing.Size(1586, 662);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 2;
            // 
            // LVEventLog
            // 
            this.LVEventLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logDate,
            this.logDifference,
            this.message});
            this.LVEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVEventLog.FullRowSelect = true;
            this.LVEventLog.Location = new System.Drawing.Point(0, 0);
            this.LVEventLog.Margin = new System.Windows.Forms.Padding(6);
            this.LVEventLog.Name = "LVEventLog";
            this.LVEventLog.Size = new System.Drawing.Size(1586, 317);
            this.LVEventLog.TabIndex = 2;
            this.LVEventLog.UseCompatibleStateImageBehavior = false;
            this.LVEventLog.View = System.Windows.Forms.View.Details;
            this.LVEventLog.SelectedIndexChanged += new System.EventHandler(this.LVEventLog_SelectedIndexChanged);
            // 
            // logDate
            // 
            this.logDate.Text = "Log Date";
            this.logDate.Width = 149;
            // 
            // logDifference
            // 
            this.logDifference.Text = "Difference (seconds)";
            this.logDifference.Width = 259;
            // 
            // message
            // 
            this.message.Text = "Message";
            this.message.Width = 180;
            // 
            // rtbLogMessage
            // 
            this.rtbLogMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogMessage.Location = new System.Drawing.Point(0, 0);
            this.rtbLogMessage.Name = "rtbLogMessage";
            this.rtbLogMessage.Size = new System.Drawing.Size(1586, 341);
            this.rtbLogMessage.TabIndex = 0;
            this.rtbLogMessage.Text = "";
            // 
            // EventLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EventLog";
            this.Size = new System.Drawing.Size(1586, 662);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView LVEventLog;
        private System.Windows.Forms.ColumnHeader logDate;
        private System.Windows.Forms.ColumnHeader logDifference;
        private System.Windows.Forms.ColumnHeader message;
        private System.Windows.Forms.RichTextBox rtbLogMessage;
    }
}
