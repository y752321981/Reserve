using LibraryReserve.pojo;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reserve.utils;
using System.IO;

namespace Reserve.manager
{
	public class ExcelManager
	{
		private static ExcelManager instance;
		
		public static ExcelManager Instance 
		{ 
			get
			{ 
				if (instance == null)
					instance = new ExcelManager();
				return instance;
			} 
		}

		private ExcelManager() { }

    
        public string FilePath { get { return ConfigManager.Instance.FilePath; } set { ConfigManager.Instance.FilePath = value; } }
        public void WriteUser()
		{
            string path = FilePath;
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                fileInfo = new FileInfo(path);
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                package.Workbook.Worksheets.Dispose();
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("用户名单");
                worksheet.Cells[1, 1].Value = "账号";
                worksheet.Cells[1, 2].Value = "密码";
                worksheet.Cells[1, 3].Value = "图书馆室";
                worksheet.Cells[1, 4].Value = "座位";
                worksheet.Cells[1, 5].Value = "开始时间";
				for (int i = 2; i <= UserManager.Instance.Users.Count + 1; i++)
				{
                    worksheet.Cells[i, 1].Value = UserManager.Instance.Users[i].Id;
                    worksheet.Cells[i, 2].Value = UserManager.Instance.Users[i].Password;
                    worksheet.Cells[i, 3].Value = UserManager.Instance.Users[i].Name;
                    worksheet.Cells[i, 4].Value = UserManager.Instance.Users[i].Seat;
                    worksheet.Cells[i, 5].Value = UserManager.Instance.Users[i].Time;
                }
            }
        }
        public List<User> ReadUser()
        {
            List<User> users = new List<User>();
            string path = FilePath;
            if (!File.Exists(path))
                return null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(path))
            {
                var worksheet = package.Workbook.Worksheets[0];
                if (worksheet.Dimension == null) return null;
                int row = worksheet.Dimension.Rows;
                if (row > 1)
                {
                    for (int i = 2; i <= row; i++)
                    {
                        if (worksheet.Cells[i, 1].Value == null || worksheet.Cells[i, 2].Value == null || worksheet.Cells[i, 3].Value == null || worksheet.Cells[i, 4].Value == null || worksheet.Cells[i, 5].Value == null)
                        {
                            continue;
                        }
                        User user = new User(worksheet.Cells[i, 1].Value.ToString(), worksheet.Cells[i, 2].Value.ToString(), worksheet.Cells[i, 3].Value.ToString(), worksheet.Cells[i, 4].Value.ToString(), worksheet.Cells[i, 5].Value.ToString(), worksheet.Cells[i, 6].Value);
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
