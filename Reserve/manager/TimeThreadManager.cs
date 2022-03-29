using Reserve.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Reserve.manager
{
	public class TimeThreadManager
	{
		[DllImport("kernel32.dll")]
		static extern uint SetThreadExecutionState(uint esFlags);
		// 选项所用到的常数
		const uint ES_AWAYMODE_REQUIRED = 0x00000040;
		const uint ES_CONTINUOUS = 0x80000000;
		const uint ES_DISPLAY_REQUIRED = 0x00000002;
		const uint ES_SYSTEM_REQUIRED = 0x00000001; private static TimeThreadManager instance;
		public static TimeThreadManager Instance { get { return instance ?? (instance = new TimeThreadManager()); } }
		private bool ThreadEnable;
		private TimeThreadManager()
		{
			ThreadEnable = false;
		}
		public SleepState sleepState = SleepState.No_Sleep;
		public void StartThread(TextBox timeBox)
		{
			if (ThreadEnable) return;
			ThreadEnable = true;
			new Thread(() =>
			{
				Action<string> AsyncUIDelegate = delegate (string n) { timeBox.Text = n; };//定义一个委托
				while (ThreadEnable)
				{
					try
					{
						if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 1)
						{
							UserManager.Instance.ResetReserveState();
						}
						if ((DateTime.Now.Hour == 6 && DateTime.Now.Minute == 59 && DateTime.Now.Second >= 59) || (DateTime.Now.Hour == 7 && DateTime.Now.Minute == 0 && DateTime.Now.Second <= 10))
						{
							Debug.Log("自动启动预约");
							UserManager.Instance.StartReserve();
							
						}
						if (DateTime.Now.Minute % 2 == 0 && DateTime.Now.Second == 1)
						{
							ComputerState(sleepState);
						}
						Thread.Sleep(900);
						timeBox?.Invoke(AsyncUIDelegate, new object[] { DateTime.Now.ToString("HH:mm:ss") });
					}
					catch (Exception ex)
					{
						Debug.Log(ex.Message);
					}

				}
			}).Start();
		}

		public enum SleepState
		{
			Normal,
			No_Sleep,
			Keep_Display
		}
		private void ComputerState(SleepState sleepState)
		{
			switch (sleepState)
			{
				case SleepState.Normal:
					SetThreadExecutionState(ES_CONTINUOUS);
					break;
				case SleepState.No_Sleep:
					SetThreadExecutionState(ES_SYSTEM_REQUIRED | ES_CONTINUOUS);
					break;
				case SleepState.Keep_Display:
					SetThreadExecutionState(ES_SYSTEM_REQUIRED | ES_CONTINUOUS | ES_DISPLAY_REQUIRED);
					break;
				default:
					break;
			}
		}
		public void EndThread()
		{
			ThreadEnable = false;
		}
	}
}
