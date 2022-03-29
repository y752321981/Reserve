using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserve.utils
{
	public class Debug
	{
		private static List<string> logInfo = new List<string>();
		public static string LogInfo 
		{
			get 
			{
				string s = string.Empty;
				logInfo.ForEach(item => s += item + "\n");
				return s;
			} 
		}
		public delegate void FreshDelegate();
		public static event FreshDelegate FreshEvene;
		
		public static void Log(string message)
		{
			logInfo.Add(DateTime.Now.ToString("MM/dd hh:mm:ss   ") + message);
			FreshEvene?.Invoke();
		}

		public static void ResetLogInfo()
		{
			logInfo.Clear();
			FreshEvene?.Invoke();
		}
	}
}
