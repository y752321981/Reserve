using LibraryReserve.pojo;
using System.Collections.Generic;
namespace Reserve.utils
{
	public static class ListUtils
	{
		public static List<string> ListUserToString(this List<User> list)
		{
			List<string> listString = new List<string>();
			list.ForEach(item => listString.Add(item.ToString()));
			return listString;
		}
	}
}
