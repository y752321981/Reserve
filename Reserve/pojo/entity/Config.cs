using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserve.pojo.entity
{
	public class Config
	{
		public string excelFolderPath { get; set; }

		public Config()
		{
			excelFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		}
	}
}
