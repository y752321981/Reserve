using LibraryReserve.pojo;
using Reserve.manager;
using Reserve.pojo.constant;
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
			Debug.FreshEvene += Debug_FreshEvene;
			Debug.logText = logText;
			dateTimePicker1.Value = ConfigManager.Instance.ReserveTime;
			TimeThreadManager.Instance.reserveTime = dateTimePicker1.Value;
			Debug.Log("加载好了");
		}

        private void Debug_FreshEvene()
        {
			try
			{
				logText.Clear();
				List<ListViewItem> listViewItems = new List<ListViewItem>();
				logText.Text = Debug.LogInfo;
				logText.SelectionStart = logText.Text.Length;
				logText.ScrollToCaret();
				logText.Refresh();
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
			}
		}

        private void Form1_Close(object sender, EventArgs e)
		{
			
			Debug.FreshEvene -= Debug_FreshEvene;
			Debug.logText = null;
			ConfigManager.Instance.Save();
			TimeThreadManager.Instance.EndThread();
		}

		private void fresh_button_Click(object sender, EventArgs e)
		{
			Fresh();
		}

		
		private void Fresh()
		{
			List<User> users = UserManager.Instance.FreshUserList();
			DataGradViewDisplay(UserTable, users);
			folderName.Text = ConfigManager.Instance.FilePath;
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
					DataGridViewButtonCell reserveInfo = new DataGridViewButtonCell();
					row.Cells.Add(reserveInfo);
					DataGridViewButtonCell dataGridViewButtonCell = new DataGridViewButtonCell();
					row.Cells.Add(dataGridViewButtonCell);
					dataGridView.Rows.Add(row);
					users[i].Row = i;
				}
			}
		}

		private void selectFolderButton_Click(object sender, EventArgs e)
		{
			Thread dialogThread = new Thread(() =>
			{
				
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				dialog.Title = "选择文件";
				dialog.Filter = "Excel文件|*.xlsx;*.xls";
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
                {
					ConfigManager.Instance.FilePath = dialog.FileName;
					Action AsyncUIDelegate = delegate () { Fresh(); };//定义一个委托
					this?.Invoke(AsyncUIDelegate);
				}
			});
			dialogThread.SetApartmentState(ApartmentState.STA);
			dialogThread.Start();
		}

        private void UserTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.ColumnIndex != -1 && e.RowIndex != -1)
			{
                User user = UserManager.Instance.FindUserByRow(e.RowIndex);
                UserTableColumn columnIndex = (UserTableColumn)e.ColumnIndex;
                switch (columnIndex)
                {
                    case UserTableColumn.ID:


                        break;
                    case UserTableColumn.ReserveInfo:
						Debug.Log(user.ReserveInfo == String.Empty ? user.Id +":暂无预约信息" : user.ReserveInfo);

                        break;
                    case UserTableColumn.DetailInfo:
						MessageBox.Show(user.ToString());


						break;
                    default:
                        break;
                }
            }
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
			Debug.Log("手动启动预约");
			UserManager.Instance.StartReserve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			Debug.ResetLogInfo();
        }

		private void ComputerStateChange(bool changeResource)
		{
			if(KeepDis.CheckState == CheckState.Unchecked && noSleep.CheckState == CheckState.Unchecked)
			{
				TimeThreadManager.Instance.sleepState = TimeThreadManager.SleepState.Normal;
				Debug.Log("电脑状态切换为:" + TimeThreadManager.Instance.sleepState.ToString());
				return;
			}
			if(changeResource)
			{
				KeepDis.CheckState = CheckState.Unchecked;
				noSleep.CheckState = CheckState.Checked;
				TimeThreadManager.Instance.sleepState = TimeThreadManager.SleepState.No_Sleep;
			}
			else
			{
				noSleep.CheckState = CheckState.Unchecked;
				KeepDis.CheckState = CheckState.Checked;
				TimeThreadManager.Instance.sleepState= TimeThreadManager.SleepState.Keep_Display;
			}
			Debug.Log("电脑状态切换为:" + TimeThreadManager.Instance.sleepState.ToString());
		}

	

		private void noSleep_Click(object sender, EventArgs e)
		{
			ComputerStateChange(true);
		}

		private void KeepDis_Click(object sender, EventArgs e)
		{
			ComputerStateChange(false);
		}

		private void noSleep_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			TimeThreadManager.Instance.reserveTime = dateTimePicker1.Value;
			ConfigManager.Instance.ReserveTime = dateTimePicker1.Value;
		}
	}
}
