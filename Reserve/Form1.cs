using LibraryReserve.pojo;
using Reserve.manager;
using Reserve.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserve
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}
		private void Form1_Load(object sender, EventArgs e)
		{
			TimeThreadManager.Instance.StartThread(timeBox);
			Fresh();
		}
		private void Form1_Close(object sender, EventArgs e)
		{
			ConfigManager.Instance.Save();
		}

		private void fresh_button_Click(object sender, EventArgs e)
		{
			Fresh();
		}

		
		private void Fresh()
		{
			List<User> users = ExcelManager.Instance.ReadUser();
			DataGradViewDisplay(UserTable, users);
			folderName.Text = ConfigManager.Instance.folderPath;
		}

		private void DataGradViewDisplay(DataGridView dataGridView, List<User> users)
		{
			if (users == null || users.Count == 0)
			{
				return;
			}
			else
			{
				dataGridView.Rows.Clear();
				
				for (int i = 0; i < users.Count; i++)
				{
					DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell user = new DataGridViewTextBoxCell
                    {
                        Value = users[i].Id
                    };
                    row.Cells.Add(user);
                    DataGridViewTextBoxCell password = new DataGridViewTextBoxCell
                    {
                        Value = users[i].Password
                    };
                    row.Cells.Add(password);
                    DataGridViewTextBoxCell room = new DataGridViewTextBoxCell
                    {
                        Value = users[i].Name
                    };
                    row.Cells.Add(room);
                    DataGridViewTextBoxCell seat = new DataGridViewTextBoxCell
                    {
                        Value = users[i].Seat
                    };
                    row.Cells.Add(seat);
                    DataGridViewTextBoxCell time = new DataGridViewTextBoxCell
                    {
                        Value = users[i].Time
                    };
                    row.Cells.Add(time);
					DataGridViewButtonCell dataGridViewButtonCell = new DataGridViewButtonCell();
					users[i].Row = i;
					row.Cells.Add(dataGridViewButtonCell);
					dataGridView.Rows.Add(row);
				}
			}
		}

		private void selectFolderButton_Click(object sender, EventArgs e)
		{
			Thread dialogThread = new Thread(() =>
			{
				FolderBrowserDialog dialog = new FolderBrowserDialog();

				dialog.Description = "选择文件夹";
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
                {
					ExcelManager.Instance.DirPath = dialog.SelectedPath;
					Action AsyncUIDelegate = delegate () { Fresh(); };//定义一个委托
					this?.Invoke(AsyncUIDelegate);
				}
				
			});
			dialogThread.SetApartmentState(ApartmentState.STA);
			dialogThread.Start();
		}

        private void UserTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.ColumnIndex != -1)
			{
				DataGridViewColumn column = UserTable.Columns[e.ColumnIndex];
				if (column is DataGridViewButtonColumn)
				{
					ExcelManager.Instance.Users.ForEach(item =>
					{
						if (item.Row == e.RowIndex)
						{
							MessageBox.Show(item.ToString());
						}
					});
			
				}
			}
        }
    }
}
