namespace NovaDemo.Main
{
	partial class FormCreateOpt
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
			this.cmbResource = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbOptReason = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbOptType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbResource
			// 
			this.cmbResource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbResource.FormattingEnabled = true;
			this.cmbResource.Location = new System.Drawing.Point(3, 96);
			this.cmbResource.Name = "cmbResource";
			this.cmbResource.Size = new System.Drawing.Size(312, 21);
			this.cmbResource.TabIndex = 36;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(3, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(312, 13);
			this.label5.TabIndex = 35;
			this.label5.Text = "Resource";
			// 
			// cmbOptReason
			// 
			this.cmbOptReason.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbOptReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOptReason.FormattingEnabled = true;
			this.cmbOptReason.Items.AddRange(new object[] {
            "economic",
            "emergency",
            "mustRun",
            "notParticipating",
            "outageRunStatus",
            "overrideStatus",
            "participating",
            "x-schedule"});
			this.cmbOptReason.Location = new System.Drawing.Point(3, 56);
			this.cmbOptReason.Name = "cmbOptReason";
			this.cmbOptReason.Size = new System.Drawing.Size(312, 21);
			this.cmbOptReason.TabIndex = 34;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(312, 13);
			this.label2.TabIndex = 32;
			this.label2.Text = "Opt Reason";
			// 
			// cmbOptType
			// 
			this.cmbOptType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbOptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOptType.FormattingEnabled = true;
			this.cmbOptType.Items.AddRange(new object[] {
            "optIn",
            "optOut"});
			this.cmbOptType.Location = new System.Drawing.Point(3, 16);
			this.cmbOptType.Name = "cmbOptType";
			this.cmbOptType.Size = new System.Drawing.Size(312, 21);
			this.cmbOptType.TabIndex = 33;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Opt Type";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cmbResource, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.cmbOptType, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.cmbOptReason, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 6);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(318, 155);
			this.tableLayoutPanel1.TabIndex = 37;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
			this.flowLayoutPanel1.Controls.Add(this.buttonOk);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 123);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(312, 29);
			this.flowLayoutPanel1.TabIndex = 37;
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(153, 3);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(234, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// FormCreateOpt
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(318, 155);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FormCreateOpt";
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbResource;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbOptReason;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbOptType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
	}
}