using Reserve.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserve.manager
{
	public class TimeThreadManager
	{
		private static TimeThreadManager instance;
		public static TimeThreadManager Instance { get { return instance ?? (instance = new TimeThreadManager()); } }
		private bool ThreadEnable;
		private TimeThreadManager()
		{
			ThreadEnable = false;
		}
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
						Thread.Sleep(1000);
						timeBox?.Invoke(AsyncUIDelegate, new object[] { DateTime.Now.ToString("hh:mm:ss") });
					}
					catch (Exception ex)
					{
						Debug.Log(ex.Message);
					}

				}
			}).Start();
		}
		public void EndThread()
		{
			ThreadEnable = false;
		}
	}
}
