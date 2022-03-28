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
				Action<String> AsyncUIDelegate = delegate (string n) { timeBox.Text = n; };//定义一个委托
				while (true)
				{
					try
					{
						Thread.Sleep(1000);
						if (!ThreadEnable || timeBox == null) break;
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
