namespace NovaDemo.UserControls
{
    partial class EventList
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
            this.components = new System.ComponentModel.Container();
            this.DGEvent = new System.Windows.Forms.DataGridView();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMSDGEvent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOptToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.createOptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGEvent)).BeginInit();
            this.CMSDGEvent.SuspendLayout();
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
            this.DGEvent.ContextMenuStrip = this.CMSDGEvent;
            this.DGEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGEvent.Location = new System.Drawing.Point(0, 0);
            this.DGEvent.Margin = new System.Windows.Forms.Padding(6);
            this.DGEvent.Name = "DGEvent";
            this.DGEvent.ReadOnly = true;
            this.DGEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGEvent.Size = new System.Drawing.Size(1065, 549);
            this.DGEvent.TabIndex = 1;
            // 
            // EventID
            // 
            this.EventID.HeaderText = "Event ID";
            this.EventID.Name = "EventID";
            this.EventID.ReadOnly = true;
            this.EventID.Width = 250;
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
            // CMSDGEvent
            // 
            this.CMSDGEvent.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.CMSDGEvent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optInToolStripMenuItem,
            this.optOutToolStripMenuItem,
            this.createOptToolStripMenuItem,
            this.createOptToolStripMenuItem1});
            this.CMSDGEvent.Name = "contextMenuStrip1";
            this.CMSDGEvent.Size = new System.Drawing.Size(254, 124);
            // 
            // optInToolStripMenuItem
            // 
            this.optInToolStripMenuItem.Name = "optInToolStripMenuItem";
            this.optInToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.optInToolStripMenuItem.Text = "Opt In";
            this.optInToolStripMenuItem.Click += new System.EventHandler(this.optInToolStripMenuItem_Click);
            // 
            // optOutToolStripMenuItem
            // 
            this.optOutToolStripMenuItem.Name = "optOutToolStripMenuItem";
            this.optOutToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.optOutToolStripMenuItem.Text = "Opt Out";
            this.optOutToolStripMenuItem.Click += new System.EventHandler(this.optOutToolStripMenuItem_Click);
            // 
            // createOptToolStripMenuItem
            // 
            this.createOptToolStripMenuItem.Name = "createOptToolStripMenuItem";
            this.createOptToolStripMenuItem.Size = new System.Drawing.Size(266, 6);
            // 
            // createOptToolStripMenuItem1
            // 
            this.createOptToolStripMenuItem1.Name = "createOptToolStripMenuItem1";
            this.createOptToolStripMenuItem1.Size = new System.Drawing.Size(269, 38);
            this.createOptToolStripMenuItem1.Text = "Create Opt ...";
            this.createOptToolStripMenuItem1.Click += new System.EventHandler(this.createOptToolStripMenuItem1_Click);
            // 
            // EventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGEvent);
            this.Name = "EventList";
            this.Size = new System.Drawing.Size(1065, 549);
            ((System.ComponentModel.ISupportInitialize)(this.DGEvent)).EndInit();
            this.CMSDGEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ContextMenuStrip CMSDGEvent;
        private System.Windows.Forms.ToolStripMenuItem optInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator createOptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOptToolStripMenuItem1;
    }
}
