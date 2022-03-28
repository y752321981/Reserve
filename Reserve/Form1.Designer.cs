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
			TimeThreadManager.Instance.EndThread();
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
            this.logView = new System.Windows.Forms.ListView();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.fresh_button = new System.Windows.Forms.Button();
            this.UserTable = new System.Windows.Forms.DataGridView();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.folderName = new System.Windows.Forms.RichTextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReserveInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UserTable)).BeginInit();
            this.SuspendLayout();
            // 
            // logView
            // 
            this.logView.HideSelection = false;
            this.logView.Location = new System.Drawing.Point(128, 237);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(866, 382);
            this.logView.TabIndex = 0;
            this.logView.UseCompatibleStateImageBehavior = false;
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
            this.Password,
            this.Room,
            this.Seat,
            this.Time,
            this.ReserveInfo});
            this.UserTable.Location = new System.Drawing.Point(128, 12);
            this.UserTable.Name = "UserTable";
            this.UserTable.RowHeadersWidth = 51;
            this.UserTable.RowTemplate.Height = 27;
            this.UserTable.Size = new System.Drawing.Size(663, 219);
            this.UserTable.TabIndex = 4;
            this.UserTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserTable_CellContentClick);
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(797, 74);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(110, 35);
            this.selectFolderButton.TabIndex = 5;
            this.selectFolderButton.Text = "选择文件夹";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // folderName
            // 
            this.folderName.Enabled = false;
            this.folderName.Location = new System.Drawing.Point(797, 14);
            this.folderName.Name = "folderName";
            this.folderName.Size = new System.Drawing.Size(197, 54);
            this.folderName.TabIndex = 6;
            this.folderName.Text = "";
            // 
            // ID
            // 
            this.ID.HeaderText = "账号";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 110;
            // 
            // Password
            // 
            this.Password.HeaderText = "密码";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 75;
            // 
            // Room
            // 
            this.Room.HeaderText = "图书馆室";
            this.Room.MinimumWidth = 6;
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            this.Room.Width = 119;
            // 
            // Seat
            // 
            this.Seat.HeaderText = "座位";
            this.Seat.MinimumWidth = 6;
            this.Seat.Name = "Seat";
            this.Seat.ReadOnly = true;
            this.Seat.Width = 50;
            // 
            // Time
            // 
            this.Time.HeaderText = "开始时间";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 50;
            // 
            // ReserveInfo
            // 
            this.ReserveInfo.HeaderText = "预约信息";
            this.ReserveInfo.MinimumWidth = 6;
            this.ReserveInfo.Name = "ReserveInfo";
            this.ReserveInfo.ReadOnly = true;
            this.ReserveInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ReserveInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ReserveInfo.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.folderName);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.UserTable);
            this.Controls.Add(this.fresh_button);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.logView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Closed += new System.EventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

       
        #endregion

        private System.Windows.Forms.ListView logView;
		private System.Windows.Forms.TextBox timeBox;
		private System.Windows.Forms.Button fresh_button;
		private System.Windows.Forms.DataGridView UserTable;
		private System.Windows.Forms.Button selectFolderButton;
		private System.Windows.Forms.RichTextBox folderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewButtonColumn ReserveInfo;
    }
}

