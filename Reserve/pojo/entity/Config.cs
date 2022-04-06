using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserve.pojo.entity
{
	public class Config
	{
		public string excelFilePath { get; set; }
		public DateTime reserveTime { get; set; }

		public Config()
		{
			excelFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\名单.xlsx";
			reserveTime = new DateTime(1970, 1, 1, 6, 59, 58);
		}
	}
}
