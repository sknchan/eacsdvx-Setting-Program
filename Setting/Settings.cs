using System;
using System.Reflection;

namespace Setting
{
	internal class Settings
	{
		private static bool isTempDataSaved;

		private static int temp_WindowSettings;

		private static int temp_DisplaySettings;

		private static int temp_DisplayRotation;

		private static int temp_DisplayResolutionX;

		private static int temp_DisplayResolutionY;

		private static int temp_KeyConfigA1;

		private static int temp_KeyConfigA2;

		private static int temp_KeyConfigB1;

		private static int temp_KeyConfigB2;

		private static int temp_KeyConfigC1;

		private static int temp_KeyConfigC2;

		private static int temp_KeyConfigD1;

		private static int temp_KeyConfigD2;

		private static int temp_KeyConfigFXL1;

		private static int temp_KeyConfigFXL2;

		private static int temp_KeyConfigFXR1;

		private static int temp_KeyConfigFXR2;

		private static int temp_KeyConfigLknobLturn1;

		private static int temp_KeyConfigLknobLturn2;

		private static int temp_KeyConfigLknobRturn1;

		private static int temp_KeyConfigLknobRturn2;

		private static int temp_KeyConfigRknobLturn1;

		private static int temp_KeyConfigRknobLturn2;

		private static int temp_KeyConfigRknobRturn1;

		private static int temp_KeyConfigRknobRturn2;

		private static int temp_KeyConfigStart1;

		private static int temp_KeyConfigStart2;

		private SettingDatas _datas = new SettingDatas();

		private static Settings _instance;

		internal SettingDatas Datas
		{
			get
			{
				return this._datas;
			}
			set
			{
				this._datas = value;
			}
		}

		public int DisplayResolutionX
		{
			get
			{
				return this._datas.GetParamAsInt32("DisplayResolutionX", -1);
			}
			set
			{
				this._datas.SetParamAsInt32("DisplayResolutionX", value);
			}
		}

		public int DisplayResolutionY
		{
			get
			{
				return this._datas.GetParamAsInt32("DisplayResolutionY", -1);
			}
			set
			{
				this._datas.SetParamAsInt32("DisplayResolutionY", value);
			}
		}

		public int DisplayRotation
		{
			get
			{
				return this._datas.GetParamAsInt32("DisplayRotation", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("DisplayRotation", value);
			}
		}

		public int DisplaySettings
		{
			get
			{
				return this._datas.GetParamAsInt32("DisplaySettings", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("DisplaySettings", value);
			}
		}

		public static Settings Instance
		{
			get
			{
				if (Settings._instance == null)
				{
					Settings._instance = new Settings();
				}
				return Settings._instance;
			}
			set
			{
				Settings._instance = value;
			}
		}

		public object this[string propertyName]
		{
			get
			{
				return typeof(Settings).GetProperty(propertyName).GetValue(this, null);
			}
			set
			{
				typeof(Settings).GetProperty(propertyName).SetValue(this, value, null);
			}
		}

		public int KeyConfigA1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigA1", 32);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigA1", value);
			}
		}

		public int KeyConfigA2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigA2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigA2", value);
			}
		}

		public int KeyConfigB1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigB1", 33);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigB1", value);
			}
		}

		public int KeyConfigB2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigB2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigB2", value);
			}
		}

		public int KeyConfigC1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigC1", 36);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigC1", value);
			}
		}

		public int KeyConfigC2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigC2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigC2", value);
			}
		}

		public int KeyConfigD1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigD1", 37);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigD1", value);
			}
		}

		public int KeyConfigD2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigD2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigD2", value);
			}
		}

		public int KeyConfigFXL1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigFXL1", 123);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigFXL1", value);
			}
		}

		public int KeyConfigFXL2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigFXL2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigFXL2", value);
			}
		}

		public int KeyConfigFXR1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigFXR1", 121);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigFXR1", value);
			}
		}

		public int KeyConfigFXR2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigFXR2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigFXR2", value);
			}
		}

		public int KeyConfigLknobLturn1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigLknobLturn1", 30);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigLknobLturn1", value);
			}
		}

		public int KeyConfigLknobLturn2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigLknobLturn2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigLknobLturn2", value);
			}
		}

		public int KeyConfigLknobRturn1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigLknobRturn1", 31);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigLknobRturn1", value);
			}
		}

		public int KeyConfigLknobRturn2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigLknobRturn2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigLknobRturn2", value);
			}
		}

		public int KeyConfigRknobLturn1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigRknobLturn1", 38);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigRknobLturn1", value);
			}
		}

		public int KeyConfigRknobLturn2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigRknobLturn2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigRknobLturn2", value);
			}
		}

		public int KeyConfigRknobRturn1
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigRknobRturn1", 39);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigRknobRturn1", value);
			}
		}

		public int KeyConfigRknobRturn2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigRknobRturn2", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigRknobRturn2", value);
			}
		}

		public int KeyConfigStart1
		{
			get
			{
				return 28;
			}
			set
			{
			}
		}

		public int KeyConfigStart2
		{
			get
			{
				return this._datas.GetParamAsInt32("KeyConfigStart", 7);
			}
			set
			{
				this._datas.SetParamAsInt32("KeyConfigStart", value);
			}
		}

		public int WindowSettings
		{
			get
			{
				return this._datas.GetParamAsInt32("WindowSettings", 0);
			}
			set
			{
				this._datas.SetParamAsInt32("WindowSettings", value);
			}
		}

		static Settings()
		{
			Settings.isTempDataSaved = false;
			Settings.temp_WindowSettings = 0;
			Settings.temp_DisplaySettings = 0;
			Settings.temp_DisplayRotation = 0;
			Settings.temp_DisplayResolutionX = -1;
			Settings.temp_DisplayResolutionY = -1;
			Settings.temp_KeyConfigA1 = 32;
			Settings.temp_KeyConfigA2 = 0;
			Settings.temp_KeyConfigB1 = 33;
			Settings.temp_KeyConfigB2 = 0;
			Settings.temp_KeyConfigC1 = 36;
			Settings.temp_KeyConfigC2 = 0;
			Settings.temp_KeyConfigD1 = 37;
			Settings.temp_KeyConfigD2 = 0;
			Settings.temp_KeyConfigFXL1 = 123;
			Settings.temp_KeyConfigFXL2 = 0;
			Settings.temp_KeyConfigFXR1 = 121;
			Settings.temp_KeyConfigFXR2 = 0;
			Settings.temp_KeyConfigLknobLturn1 = 30;
			Settings.temp_KeyConfigLknobLturn2 = 0;
			Settings.temp_KeyConfigLknobRturn1 = 31;
			Settings.temp_KeyConfigLknobRturn2 = 0;
			Settings.temp_KeyConfigRknobLturn1 = 38;
			Settings.temp_KeyConfigRknobLturn2 = 0;
			Settings.temp_KeyConfigRknobRturn1 = 39;
			Settings.temp_KeyConfigRknobRturn2 = 0;
			Settings.temp_KeyConfigStart1 = 28;
			Settings.temp_KeyConfigStart2 = 7;
		}

		private Settings()
		{
			this.WindowSettings = 0;
			this.DisplaySettings = 0;
			this.DisplayRotation = 0;
			this.DisplayResolutionX = -1;
			this.DisplayResolutionY = -1;
			this.KeyConfigStart1 = 28;
			this.KeyConfigA1 = 32;
			this.KeyConfigB1 = 33;
			this.KeyConfigC1 = 36;
			this.KeyConfigD1 = 37;
			this.KeyConfigFXL1 = 123;
			this.KeyConfigFXR1 = 121;
			this.KeyConfigLknobLturn1 = 30;
			this.KeyConfigLknobRturn1 = 31;
			this.KeyConfigRknobLturn1 = 38;
			this.KeyConfigRknobRturn1 = 39;
			this.KeyConfigStart2 = 7;
			this.KeyConfigA2 = 0;
			this.KeyConfigB2 = 0;
			this.KeyConfigC2 = 0;
			this.KeyConfigD2 = 0;
			this.KeyConfigFXL2 = 0;
			this.KeyConfigFXR2 = 0;
			this.KeyConfigLknobLturn2 = 0;
			this.KeyConfigLknobRturn2 = 0;
			this.KeyConfigRknobLturn2 = 0;
			this.KeyConfigRknobRturn2 = 0;
		}

		public static bool IsDiffTempDataCheck()
		{
			if (!Settings.isTempDataSaved)
			{
				return false;
			}
			if (Settings.temp_WindowSettings != Settings.Instance.WindowSettings)
			{
				return true;
			}
			if (Settings.temp_DisplaySettings != Settings.Instance.DisplaySettings)
			{
				return true;
			}
			if (Settings.temp_DisplayRotation != Settings.Instance.DisplayRotation)
			{
				return true;
			}
			if (Settings.temp_DisplayResolutionX != Settings.Instance.DisplayResolutionX)
			{
				return true;
			}
			if (Settings.temp_DisplayResolutionY != Settings.Instance.DisplayResolutionY)
			{
				return true;
			}
			if (Settings.temp_KeyConfigA1 != Settings.Instance.KeyConfigA1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigA2 != Settings.Instance.KeyConfigA2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigB1 != Settings.Instance.KeyConfigB1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigB2 != Settings.Instance.KeyConfigB2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigC1 != Settings.Instance.KeyConfigC1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigC2 != Settings.Instance.KeyConfigC2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigD1 != Settings.Instance.KeyConfigD1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigD2 != Settings.Instance.KeyConfigD2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigFXL1 != Settings.Instance.KeyConfigFXL1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigFXL2 != Settings.Instance.KeyConfigFXL2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigFXR1 != Settings.Instance.KeyConfigFXR1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigFXR2 != Settings.Instance.KeyConfigFXR2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigLknobLturn1 != Settings.Instance.KeyConfigLknobLturn1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigLknobLturn2 != Settings.Instance.KeyConfigLknobLturn2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigLknobRturn1 != Settings.Instance.KeyConfigLknobRturn1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigLknobRturn2 != Settings.Instance.KeyConfigLknobRturn2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigRknobLturn1 != Settings.Instance.KeyConfigRknobLturn1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigRknobLturn2 != Settings.Instance.KeyConfigRknobLturn2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigRknobRturn1 != Settings.Instance.KeyConfigRknobRturn1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigRknobRturn2 != Settings.Instance.KeyConfigRknobRturn2)
			{
				return true;
			}
			if (Settings.temp_KeyConfigStart1 != Settings.Instance.KeyConfigStart1)
			{
				return true;
			}
			if (Settings.temp_KeyConfigStart2 != Settings.Instance.KeyConfigStart2)
			{
				return true;
			}
			return false;
		}

		public static void SaveTempData()
		{
			Settings.temp_WindowSettings = Settings.Instance.WindowSettings;
			Settings.temp_DisplaySettings = Settings.Instance.DisplaySettings;
			Settings.temp_DisplayRotation = Settings.Instance.DisplayRotation;
			Settings.temp_DisplayResolutionX = Settings.Instance.DisplayResolutionX;
			Settings.temp_DisplayResolutionY = Settings.Instance.DisplayResolutionY;
			Settings.temp_KeyConfigA1 = Settings.Instance.KeyConfigA1;
			Settings.temp_KeyConfigA2 = Settings.Instance.KeyConfigA2;
			Settings.temp_KeyConfigB1 = Settings.Instance.KeyConfigB1;
			Settings.temp_KeyConfigB2 = Settings.Instance.KeyConfigB2;
			Settings.temp_KeyConfigC1 = Settings.Instance.KeyConfigC1;
			Settings.temp_KeyConfigC2 = Settings.Instance.KeyConfigC2;
			Settings.temp_KeyConfigD1 = Settings.Instance.KeyConfigD1;
			Settings.temp_KeyConfigD2 = Settings.Instance.KeyConfigD2;
			Settings.temp_KeyConfigFXL1 = Settings.Instance.KeyConfigFXL1;
			Settings.temp_KeyConfigFXL2 = Settings.Instance.KeyConfigFXL2;
			Settings.temp_KeyConfigFXR1 = Settings.Instance.KeyConfigFXR1;
			Settings.temp_KeyConfigFXR2 = Settings.Instance.KeyConfigFXR2;
			Settings.temp_KeyConfigLknobLturn1 = Settings.Instance.KeyConfigLknobLturn1;
			Settings.temp_KeyConfigLknobLturn2 = Settings.Instance.KeyConfigLknobLturn2;
			Settings.temp_KeyConfigLknobRturn1 = Settings.Instance.KeyConfigLknobRturn1;
			Settings.temp_KeyConfigLknobRturn2 = Settings.Instance.KeyConfigLknobRturn2;
			Settings.temp_KeyConfigRknobLturn1 = Settings.Instance.KeyConfigRknobLturn1;
			Settings.temp_KeyConfigRknobLturn2 = Settings.Instance.KeyConfigRknobLturn2;
			Settings.temp_KeyConfigRknobRturn1 = Settings.Instance.KeyConfigRknobRturn1;
			Settings.temp_KeyConfigRknobRturn2 = Settings.Instance.KeyConfigRknobRturn2;
			Settings.temp_KeyConfigStart1 = Settings.Instance.KeyConfigStart1;
			Settings.temp_KeyConfigStart2 = Settings.Instance.KeyConfigStart2;
			Settings.isTempDataSaved = true;
		}
	}
}