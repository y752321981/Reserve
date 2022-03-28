using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserve.utils
{
	public class Debug
	{
		private static readonly string userInfoHead = "按R刷新用户列表,按K强制执行预约计划\n" + "-----------------------------------------------" + '\n';
		private static readonly string logInfoHead = "按C清除日志\n" + "-----------------------------------------------" + '\n';
		private static List<string> userInfo = new List<string>();
		private static Dictionary<string, int> logInfo = new Dictionary<string, int>();
		public delegate void FreshDelegate();
		public static event FreshDelegate FreshEvene;
		public static string Info
		{
			get
			{
				string result = userInfoHead;
				foreach (var item in userInfo)
				{
					result += item;
				}
				result += logInfoHead;
				foreach (var item in logInfo)
				{
					result += item.Key;
					if (item.Value > 1)
					{
						result += 'x';
						result += item.Value.ToString();
					}

					result += '\n';
				}
				return result;
			}
		}

		public static void AddUserInfo(string message)
		{
			userInfo.Add(message);
			FreshEvene?.Invoke();

		}
		public static void ResetUserInfo()
		{
			userInfo.Clear();
			FreshEvene?.Invoke();
		}

		public static void Log(string message)
		{
			List<string> list = new List<string>(logInfo.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Equals(message))
				{
					logInfo[list[i]]++;
					FreshEvene?.Invoke();
					return;
				}
			}
			logInfo.Add(message, 1);
			FreshEvene?.Invoke();
		}

		public static void ResetLogInfo()
		{
			logInfo.Clear();
			FreshEvene?.Invoke();
		}
	}
}
