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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.LabelVenStatus = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DGEvent)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
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
			this.DGEvent.Location = new System.Drawing.Point(3, 47);
			this.DGEvent.Name = "DGEvent";
			this.DGEvent.ReadOnly = true;
			this.DGEvent.Size = new System.Drawing.Size(487, 270);
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
			// 
			// Duration
			// 
			this.Duration.HeaderText = "Duration";
			this.Duration.Name = "Duration";
			this.Duration.ReadOnly = true;
			// 
			// Status
			// 
			this.Status.HeaderText = "Status";
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.DGEvent, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.LabelVenStatus, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.75F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 320);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// LabelVenStatus
			// 
			this.LabelVenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelVenStatus.AutoSize = true;
			this.LabelVenStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelVenStatus.Location = new System.Drawing.Point(3, 0);
			this.LabelVenStatus.Name = "LabelVenStatus";
			this.LabelVenStatus.Size = new System.Drawing.Size(155, 44);
			this.LabelVenStatus.TabIndex = 1;
			this.LabelVenStatus.Text = "Ven Event Status:";
			this.LabelVenStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(493, 320);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DGEvent)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGEvent;
		private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
		private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label LabelVenStatus;
	}
}

