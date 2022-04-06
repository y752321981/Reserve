using Reserve.manager;
using System;

namespace Reserve
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
		
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.timeBox = new System.Windows.Forms.TextBox();
			this.fresh_button = new System.Windows.Forms.Button();
			this.UserTable = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReserveInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DetailInfo = new System.Windows.Forms.DataGridViewButtonColumn();
			this.selectFolderButton = new System.Windows.Forms.Button();
			this.folderName = new System.Windows.Forms.RichTextBox();
			this.logText = new System.Windows.Forms.RichTextBox();
			this.reserveButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.KeepDis = new System.Windows.Forms.CheckBox();
			this.noSleep = new System.Windows.Forms.CheckBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.UserTable)).BeginInit();
			this.SuspendLayout();
			// 
			// timeBox
			// 
			this.timeBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.timeBox.Enabled = false;
			this.timeBox.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.timeBox.Location = new System.Drawing.Point(12, 12);
			this.timeBox.Name = "timeBox";
			this.timeBox.ReadOnly = true;
			this.timeBox.Size = new System.Drawing.Size(110, 28);
			this.timeBox.TabIndex = 1;
			this.timeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// fresh_button
			// 
			this.fresh_button.Location = new System.Drawing.Point(919, 625);
			this.fresh_button.Name = "fresh_button";
			this.fresh_button.Size = new System.Drawing.Size(75, 36);
			this.fresh_button.TabIndex = 2;
			this.fresh_button.Text = "刷新";
			this.fresh_button.UseVisualStyleBackColor = true;
			this.fresh_button.Click += new System.EventHandler(this.fresh_button_Click);
			// 
			// UserTable
			// 
			this.UserTable.AllowUserToAddRows = false;
			this.UserTable.AllowUserToDeleteRows = false;
			this.UserTable.AllowUserToOrderColumns = true;
			this.UserTable.AllowUserToResizeColumns = false;
			this.UserTable.AllowUserToResizeRows = false;
			this.UserTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.UserTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ReserveInfo,
            this.DetailInfo});
			this.UserTable.Location = new System.Drawing.Point(128, 12);
			this.UserTable.Name = "UserTable";
			this.UserTable.RowHeadersWidth = 51;
			this.UserTable.RowTemplate.Height = 27;
			this.UserTable.Size = new System.Drawing.Size(421, 219);
			this.UserTable.TabIndex = 4;
			this.UserTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserTable_CellContentClick);
			// 
			// ID
			// 
			this.ID.HeaderText = "账号";
			this.ID.MinimumWidth = 75;
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Width = 110;
			// 
			// ReserveInfo
			// 
			this.ReserveInfo.HeaderText = "预约信息";
			this.ReserveInfo.MinimumWidth = 6;
			this.ReserveInfo.Name = "ReserveInfo";
			this.ReserveInfo.Width = 75;
			// 
			// DetailInfo
			// 
			this.DetailInfo.HeaderText = "详细信息";
			this.DetailInfo.MinimumWidth = 6;
			this.DetailInfo.Name = "DetailInfo";
			this.DetailInfo.ReadOnly = true;
			this.DetailInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.DetailInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.DetailInfo.Width = 75;
			// 
			// selectFolderButton
			// 
			this.selectFolderButton.Location = new System.Drawing.Point(895, 196);
			this.selectFolderButton.Name = "selectFolderButton";
			this.selectFolderButton.Size = new System.Drawing.Size(99, 35);
			this.selectFolderButton.TabIndex = 5;
			this.selectFolderButton.Text = "选择文件";
			this.selectFolderButton.UseVisualStyleBackColor = true;
			this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
			// 
			// folderName
			// 
			this.folderName.Enabled = false;
			this.folderName.Location = new System.Drawing.Point(816, 136);
			this.folderName.Name = "folderName";
			this.folderName.Size = new System.Drawing.Size(178, 54);
			this.folderName.TabIndex = 6;
			this.folderName.Text = "";
			// 
			// logText
			// 
			this.logText.Location = new System.Drawing.Point(128, 237);
			this.logText.Name = "logText";
			this.logText.Size = new System.Drawing.Size(866, 382);
			this.logText.TabIndex = 7;
			this.logText.Text = "";
			// 
			// reserveButton
			// 
			this.reserveButton.Location = new System.Drawing.Point(567, 186);
			this.reserveButton.Name = "reserveButton";
			this.reserveButton.Size = new System.Drawing.Size(118, 45);
			this.reserveButton.TabIndex = 8;
			this.reserveButton.Text = "预约";
			this.reserveButton.UseVisualStyleBackColor = true;
			this.reserveButton.Click += new System.EventHandler(this.reserveButton_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(816, 625);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 36);
			this.button1.TabIndex = 9;
			this.button1.Text = "清除";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// KeepDis
			// 
			this.KeepDis.AutoSize = true;
			this.KeepDis.Location = new System.Drawing.Point(567, 12);
			this.KeepDis.Name = "KeepDis";
			this.KeepDis.Size = new System.Drawing.Size(74, 19);
			this.KeepDis.TabIndex = 10;
			this.KeepDis.Text = "不灭屏";
			this.KeepDis.UseVisualStyleBackColor = true;
			this.KeepDis.Click += new System.EventHandler(this.KeepDis_Click);
			// 
			// noSleep
			// 
			this.noSleep.AutoSize = true;
			this.noSleep.Checked = true;
			this.noSleep.CheckState = System.Windows.Forms.CheckState.Checked;
			this.noSleep.Location = new System.Drawing.Point(567, 38);
			this.noSleep.Name = "noSleep";
			this.noSleep.Size = new System.Drawing.Size(194, 19);
			this.noSleep.TabIndex = 11;
			this.noSleep.Text = "灭屏，但不睡眠（建议）";
			this.noSleep.UseVisualStyleBackColor = true;
			this.noSleep.CheckedChanged += new System.EventHandler(this.noSleep_CheckedChanged);
			this.noSleep.Click += new System.EventHandler(this.noSleep_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1.Location = new System.Drawing.Point(876, 105);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(118, 25);
			this.dateTimePicker1.TabIndex = 12;
			this.dateTimePicker1.Value = new System.DateTime(2022, 4, 6, 6, 59, 58, 0);
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Enabled = false;
			this.label1.Location = new System.Drawing.Point(761, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(233, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "自动开始预约时间,建议在7点左右";
			this.label1.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 673);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.noSleep);
			this.Controls.Add(this.KeepDis);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.reserveButton);
			this.Controls.Add(this.logText);
			this.Controls.Add(this.folderName);
			this.Controls.Add(this.selectFolderButton);
			this.Controls.Add(this.UserTable);
			this.Controls.Add(this.fresh_button);
			this.Controls.Add(this.timeBox);
			this.Name = "Form1";
			this.Text = "与恶势力坚决斗争到底";
			this.Closed += new System.EventHandler(this.Form1_Close);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.UserTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

       
        #endregion
		private System.Windows.Forms.TextBox timeBox;
		private System.Windows.Forms.Button fresh_button;
		private System.Windows.Forms.DataGridView UserTable;
		private System.Windows.Forms.Button selectFolderButton;
		private System.Windows.Forms.RichTextBox folderName;
        private System.Windows.Forms.RichTextBox logText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReserveInfo;
        private System.Windows.Forms.DataGridViewButtonColumn DetailInfo;
        private System.Windows.Forms.Button reserveButton;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox KeepDis;
		private System.Windows.Forms.CheckBox noSleep;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
	}
}

