namespace NovaDemo.Main
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
            this.components = new System.ComponentModel.Container();
            this.DGEvent = new System.Windows.Forms.DataGridView();
            this.CMSDGEvent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOptToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.createOptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LayoutActiveEvent = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SCMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UCEventLog = new NovaDemo.UserControls.EventLog();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelEventPollStatic = new System.Windows.Forms.Label();
            this.LabelEventPollDynamic = new System.Windows.Forms.Label();
            this.TLMainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BClearEvents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGEvent)).BeginInit();
            this.CMSDGEvent.SuspendLayout();
            this.LayoutActiveEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SCMain)).BeginInit();
            this.SCMain.Panel1.SuspendLayout();
            this.SCMain.Panel2.SuspendLayout();
            this.SCMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.TLMainWindow.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.DGEvent.Location = new System.Drawing.Point(6, 64);
            this.DGEvent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DGEvent.Name = "DGEvent";
            this.DGEvent.ReadOnly = true;
            this.DGEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGEvent.Size = new System.Drawing.Size(1742, 439);
            this.DGEvent.TabIndex = 0;
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
            this.optInToolStripMenuItem.Size = new System.Drawing.Size(253, 38);
            this.optInToolStripMenuItem.Text = "Opt In";
            this.optInToolStripMenuItem.Click += new System.EventHandler(this.optInToolStripMenuItem_Click);
            // 
            // optOutToolStripMenuItem
            // 
            this.optOutToolStripMenuItem.Name = "optOutToolStripMenuItem";
            this.optOutToolStripMenuItem.Size = new System.Drawing.Size(253, 38);
            this.optOutToolStripMenuItem.Text = "Opt Out";
            this.optOutToolStripMenuItem.Click += new System.EventHandler(this.optOutToolStripMenuItem_Click);
            // 
            // createOptToolStripMenuItem
            // 
            this.createOptToolStripMenuItem.Name = "createOptToolStripMenuItem";
            this.createOptToolStripMenuItem.Size = new System.Drawing.Size(250, 6);
            // 
            // createOptToolStripMenuItem1
            // 
            this.createOptToolStripMenuItem1.Name = "createOptToolStripMenuItem1";
            this.createOptToolStripMenuItem1.Size = new System.Drawing.Size(253, 38);
            this.createOptToolStripMenuItem1.Text = "Create Opt ...";
            this.createOptToolStripMenuItem1.Click += new System.EventHandler(this.createOptToolStripMenuItem1_Click);
            // 
            // LayoutActiveEvent
            // 
            this.LayoutActiveEvent.ColumnCount = 1;
            this.LayoutActiveEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutActiveEvent.Controls.Add(this.DGEvent, 0, 1);
            this.LayoutActiveEvent.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.LayoutActiveEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutActiveEvent.Location = new System.Drawing.Point(0, 0);
            this.LayoutActiveEvent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LayoutActiveEvent.Name = "LayoutActiveEvent";
            this.LayoutActiveEvent.RowCount = 2;
            this.LayoutActiveEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.LayoutActiveEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutActiveEvent.Size = new System.Drawing.Size(1754, 509);
            this.LayoutActiveEvent.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1742, 46);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // SCMain
            // 
            this.SCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SCMain.Location = new System.Drawing.Point(212, 6);
            this.SCMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SCMain.Name = "SCMain";
            this.SCMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SCMain.Panel1
            // 
            this.SCMain.Panel1.Controls.Add(this.LayoutActiveEvent);
            // 
            // SCMain.Panel2
            // 
            this.SCMain.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.SCMain.Size = new System.Drawing.Size(1754, 1115);
            this.SCMain.SplitterDistance = 509;
            this.SCMain.SplitterWidth = 8;
            this.SCMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.UCEventLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1754, 598);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // UCEventLog
            // 
            this.UCEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCEventLog.Location = new System.Drawing.Point(12, 70);
            this.UCEventLog.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.UCEventLog.Name = "UCEventLog";
            this.UCEventLog.Size = new System.Drawing.Size(1730, 516);
            this.UCEventLog.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.LabelEventPollStatic);
            this.flowLayoutPanel2.Controls.Add(this.LabelEventPollDynamic);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1742, 46);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // LabelEventPollStatic
            // 
            this.LabelEventPollStatic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelEventPollStatic.AutoSize = true;
            this.LabelEventPollStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEventPollStatic.Location = new System.Drawing.Point(6, 0);
            this.LabelEventPollStatic.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelEventPollStatic.Name = "LabelEventPollStatic";
            this.LabelEventPollStatic.Size = new System.Drawing.Size(230, 36);
            this.LabelEventPollStatic.TabIndex = 4;
            this.LabelEventPollStatic.Text = "Last Status Poll:";
            this.LabelEventPollStatic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelEventPollDynamic
            // 
            this.LabelEventPollDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelEventPollDynamic.AutoSize = true;
            this.LabelEventPollDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEventPollDynamic.Location = new System.Drawing.Point(248, 0);
            this.LabelEventPollDynamic.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelEventPollDynamic.Name = "LabelEventPollDynamic";
            this.LabelEventPollDynamic.Size = new System.Drawing.Size(65, 36);
            this.LabelEventPollDynamic.TabIndex = 5;
            this.LabelEventPollDynamic.Text = "-----";
            this.LabelEventPollDynamic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TLMainWindow
            // 
            this.TLMainWindow.ColumnCount = 2;
            this.TLMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.44625F));
            this.TLMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.55375F));
            this.TLMainWindow.Controls.Add(this.SCMain, 1, 0);
            this.TLMainWindow.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.TLMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLMainWindow.Location = new System.Drawing.Point(0, 0);
            this.TLMainWindow.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TLMainWindow.Name = "TLMainWindow";
            this.TLMainWindow.RowCount = 1;
            this.TLMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLMainWindow.Size = new System.Drawing.Size(1972, 1127);
            this.TLMainWindow.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BClearEvents, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 1115);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // BClearEvents
            // 
            this.BClearEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BClearEvents.Location = new System.Drawing.Point(6, 73);
            this.BClearEvents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BClearEvents.Name = "BClearEvents";
            this.BClearEvents.Size = new System.Drawing.Size(182, 55);
            this.BClearEvents.TabIndex = 0;
            this.BClearEvents.Text = "Clear Events";
            this.BClearEvents.UseVisualStyleBackColor = true;
            this.BClearEvents.Click += new System.EventHandler(this.BClearEvents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 67);
            this.label1.TabIndex = 4;
            this.label1.Text = "Requests";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1972, 1127);
            this.Controls.Add(this.TLMainWindow);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGEvent)).EndInit();
            this.CMSDGEvent.ResumeLayout(false);
            this.LayoutActiveEvent.ResumeLayout(false);
            this.SCMain.Panel1.ResumeLayout(false);
            this.SCMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SCMain)).EndInit();
            this.SCMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.TLMainWindow.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGEvent;
		private System.Windows.Forms.TableLayoutPanel LayoutActiveEvent;
		private System.Windows.Forms.SplitContainer SCMain;
		private UserControls.EventLog UCEventLog;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label LabelEventPollStatic;
		private System.Windows.Forms.Label LabelEventPollDynamic;
		private System.Windows.Forms.TableLayoutPanel TLMainWindow;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button BClearEvents;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip CMSDGEvent;
		private System.Windows.Forms.ToolStripMenuItem optInToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optOutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator createOptToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createOptToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

