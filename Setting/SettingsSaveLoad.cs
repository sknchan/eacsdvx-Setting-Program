using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Setting
{
	public class SettingsSaveLoad
	{
		private static string SettingFileName;

		private static string CompanyName;

		private static string Project;

		private static string Application;

		private static string AppDir;

		static SettingsSaveLoad()
		{
			SettingsSaveLoad.SettingFileName = "usersettings.xml";
			SettingsSaveLoad.CompanyName = "KONAMI";
			SettingsSaveLoad.Project = "eacloud";
			SettingsSaveLoad.Application = "SOUND VOLTEX III GRAVITY WARS (e-AMUSEMENT CLOUD)";
			SettingsSaveLoad.AppDir = "game";
		}

		public SettingsSaveLoad()
		{
		}

		private static string GetSettingFile()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string str = folderPath;
			string[] companyName = new string[] { str, "\\", SettingsSaveLoad.CompanyName, "\\", SettingsSaveLoad.Project, "\\", SettingsSaveLoad.Application, "\\", SettingsSaveLoad.AppDir };
			folderPath = string.Concat(companyName);
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
			return string.Concat(folderPath, "\\", SettingsSaveLoad.SettingFileName);
		}

		public static bool Load()
		{
			return SettingsSaveLoad.LoadFromXmlFile();
		}

		private static bool LoadFromXmlFile()
		{
			bool flag = false;
			StreamReader streamReader = null;
			try
			{
				try
				{
					streamReader = new StreamReader(SettingsSaveLoad.GetSettingFile(), new UTF8Encoding(false));
					object obj = (new XmlSerializer(typeof(SettingDatas))).Deserialize(streamReader);
					if (streamReader != null)
					{
						streamReader.Close();
						streamReader = null;
					}
					Settings.Instance.Datas = (SettingDatas)obj;
					flag = true;
				}
				catch (Exception exception)
				{
					flag = false;
				}
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Close();
					streamReader = null;
				}
			}
			return flag;
		}

		public static bool Save()
		{
			return SettingsSaveLoad.SaveToXmlFile();
		}

		private static bool SaveToXmlFile()
		{
			bool flag = false;
			StreamWriter streamWriter = null;
			try
			{
				try
				{
					string settingFile = SettingsSaveLoad.GetSettingFile();
					streamWriter = new StreamWriter(settingFile, false, new UTF8Encoding(false));
					(new XmlSerializer(typeof(SettingDatas))).Serialize(streamWriter, Settings.Instance.Datas);
					if (streamWriter != null)
					{
						streamWriter.Close();
						streamWriter = null;
					}
					flag = true;
				}
				catch (Exception exception)
				{
					flag = false;
				}
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
					streamWriter = null;
				}
			}
			return flag;
		}
	}
}