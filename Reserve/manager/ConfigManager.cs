using Reserve.pojo.entity;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Security.AccessControl;
namespace Reserve.manager
{
	public class ConfigManager
	{
		private static ConfigManager instance;
		public static ConfigManager Instance
		{
			get
			{
				if (instance == null)
					instance = new ConfigManager();
				return instance;
			}
		}
		private Config config;
		private string path;
		public string folderPath { get { return config.excelFolderPath; } set { config.excelFolderPath = value; } }
		private ConfigManager()
		{
			path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Reserve\\config";
			ReadConfig();
		}
		public void Save()
        {
			WriteConfig();
        }
		private void WriteConfig()
		{
			if(config == null)
				config = new Config();
			FileInfo fileInfo = new FileInfo(path);
			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}
			using (FileStream fs = fileInfo.Create())
			{
				byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(config));
				fs.Write(data, 0, data.Length);
			}
		}

		private void ReadConfig()
		{
			FileInfo fileInfo = new FileInfo(path);
			if(!fileInfo.Directory.Exists)
            {
				fileInfo.Directory.Create();

            }
			
			if (fileInfo.Exists)
			{
				using (FileStream fs = fileInfo.OpenRead())
				{
					byte[] data = new byte[fs.Length];
					int waitToRead = (int)fs.Length;
					int hasRead = 0;
					int ReadThisTime;
					while ((ReadThisTime = fs.Read(data, hasRead, waitToRead)) > 0)
					{
						hasRead += ReadThisTime;
						waitToRead -= ReadThisTime;
					}
					config = JsonConvert.DeserializeObject<Config>(Encoding.UTF8.GetString(data));
				}
			}
			else
			{
				config = new Config();
			}
		}


	}
}
