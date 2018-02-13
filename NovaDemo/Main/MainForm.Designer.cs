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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLastPoll = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearEvents = new System.Windows.Forms.Button();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxRespondWithErrors = new System.Windows.Forms.CheckBox();
            this.radioButtonSendApplicationErrors = new System.Windows.Forms.RadioButton();
            this.radioButtonSendHttpErrors = new System.Windows.Forms.RadioButton();
            this.UCEventList = new NovaDemo.UserControls.EventList();
            this.UCEventLog = new NovaDemo.UserControls.EventLog();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLastPoll});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(696, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLastPoll
            // 
            this.toolStripStatusLabelLastPoll.Name = "toolStripStatusLabelLastPoll";
            this.toolStripStatusLabelLastPoll.Size = new System.Drawing.Size(0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearEvents);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(137, 405);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btnClearEvents
            // 
            this.btnClearEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearEvents.Location = new System.Drawing.Point(2, 15);
            this.btnClearEvents.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearEvents.Name = "btnClearEvents";
            this.btnClearEvents.Size = new System.Drawing.Size(133, 24);
            this.btnClearEvents.TabIndex = 0;
            this.btnClearEvents.Text = "Clear Events";
            this.btnClearEvents.UseVisualStyleBackColor = true;
            this.btnClearEvents.Click += new System.EventHandler(this.btnClearEvents_Click);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(2, 32);
            this.splitContainerRight.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.groupBox3);
            this.splitContainerRight.Size = new System.Drawing.Size(555, 371);
            this.splitContainerRight.SplitterDistance = 169;
            this.splitContainerRight.SplitterWidth = 2;
            this.splitContainerRight.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UCEventList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(555, 169);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Events";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UCEventLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(555, 200);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.settingsToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainerRight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(137, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 405);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRespondWithErrors);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSendHttpErrors);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSendApplicationErrors);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(553, 24);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // checkBoxRespondWithErrors
            // 
            this.checkBoxRespondWithErrors.AutoSize = true;
            this.checkBoxRespondWithErrors.Location = new System.Drawing.Point(3, 3);
            this.checkBoxRespondWithErrors.Name = "checkBoxRespondWithErrors";
            this.checkBoxRespondWithErrors.Size = new System.Drawing.Size(124, 17);
            this.checkBoxRespondWithErrors.TabIndex = 0;
            this.checkBoxRespondWithErrors.Text = "Respond With Errors";
            this.checkBoxRespondWithErrors.UseVisualStyleBackColor = true;
            this.checkBoxRespondWithErrors.CheckedChanged += new System.EventHandler(this.checkBoxRespondWithErrors_CheckedChanged);
            // 
            // radioButtonSendApplicationErrors
            // 
            this.radioButtonSendApplicationErrors.AutoSize = true;
            this.radioButtonSendApplicationErrors.Location = new System.Drawing.Point(242, 3);
            this.radioButtonSendApplicationErrors.Name = "radioButtonSendApplicationErrors";
            this.radioButtonSendApplicationErrors.Size = new System.Drawing.Size(135, 17);
            this.radioButtonSendApplicationErrors.TabIndex = 1;
            this.radioButtonSendApplicationErrors.Text = "Send Application Errors";
            this.radioButtonSendApplicationErrors.UseVisualStyleBackColor = true;
            // 
            // radioButtonSendHttpErrors
            // 
            this.radioButtonSendHttpErrors.AutoSize = true;
            this.radioButtonSendHttpErrors.Checked = true;
            this.radioButtonSendHttpErrors.Location = new System.Drawing.Point(133, 3);
            this.radioButtonSendHttpErrors.Name = "radioButtonSendHttpErrors";
            this.radioButtonSendHttpErrors.Size = new System.Drawing.Size(103, 17);
            this.radioButtonSendHttpErrors.TabIndex = 2;
            this.radioButtonSendHttpErrors.TabStop = true;
            this.radioButtonSendHttpErrors.Text = "Send Http Errors";
            this.radioButtonSendHttpErrors.UseVisualStyleBackColor = true;
            // 
            // UCEventList
            // 
            this.UCEventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCEventList.Location = new System.Drawing.Point(2, 15);
            this.UCEventList.Margin = new System.Windows.Forms.Padding(1);
            this.UCEventList.Name = "UCEventList";
            this.UCEventList.Size = new System.Drawing.Size(551, 152);
            this.UCEventList.TabIndex = 0;
            // 
            // UCEventLog
            // 
            this.UCEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCEventLog.Location = new System.Drawing.Point(2, 15);
            this.UCEventLog.Name = "UCEventLog";
            this.UCEventLog.Size = new System.Drawing.Size(551, 183);
            this.UCEventLog.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "NOVA Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLastPoll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.GroupBox groupBox2;
        private UserControls.EventList UCEventList;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.EventLog UCEventLog;
        private System.Windows.Forms.Button btnClearEvents;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxRespondWithErrors;
        private System.Windows.Forms.RadioButton radioButtonSendApplicationErrors;
        private System.Windows.Forms.RadioButton radioButtonSendHttpErrors;
    }
}