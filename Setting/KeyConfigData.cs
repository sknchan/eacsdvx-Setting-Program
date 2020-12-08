using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Setting
{
	public class KeyConfigData
	{
		public const int DATA_COUNT = 11;

		public const int DATA_INDEX = 2;

		public const int KeyConfigStart1Default = 28;

		public const int KeyConfigA1Default = 32;

		public const int KeyConfigB1Default = 33;

		public const int KeyConfigC1Default = 36;

		public const int KeyConfigD1Default = 37;

		public const int KeyConfigFXL1Default = 123;

		public const int KeyConfigFXR1Default = 121;

		public const int KeyConfigLknobLturn1Default = 30;

		public const int KeyConfigLknobRturn1Default = 31;

		public const int KeyConfigRknobLturn1Default = 38;

		public const int KeyConfigRknobRturn1Default = 39;

		public const int KeyConfigStart2Default = 7;

		public const int KeyConfigA2Default = 0;

		public const int KeyConfigB2Default = 0;

		public const int KeyConfigC2Default = 0;

		public const int KeyConfigD2Default = 0;

		public const int KeyConfigFXL2Default = 0;

		public const int KeyConfigFXR2Default = 0;

		public const int KeyConfigLknobLturn2Default = 0;

		public const int KeyConfigLknobRturn2Default = 0;

		public const int KeyConfigRknobLturn2Default = 0;

		public const int KeyConfigRknobRturn2Default = 0;

		public readonly static string UNSELECTED_IMAGE;

		public readonly static string[] button_list;

		public readonly static string[] image_list;

		public readonly static string[,] data_list;

		public List<KeySettings> settingList
		{
			get;
			set;
		}

		static KeyConfigData()
		{
			KeyConfigData.UNSELECTED_IMAGE = "Resources/panel_base.bmp";
			string[] strArrays = new string[] { "Aボタン", "Bボタン", "Cボタン", "Dボタン", "FX-Lボタン", "FX-Rボタン", "左アナログデバイス-左回転", "左アナログデバイス-右回転", "右アナログデバイス-左回転", "右アナログデバイス-右回転", "スタートボタン" };
			KeyConfigData.button_list = strArrays;
			string[] strArrays1 = new string[] { "Resources/panel_bt1.bmp", "Resources/panel_bt2.bmp", "Resources/panel_bt3.bmp", "Resources/panel_bt4.bmp", "Resources/panel_fxL.bmp", "Resources/panel_fxR.bmp", "Resources/panel_volL_L.bmp", "Resources/panel_volL_R.bmp", "Resources/panel_volR_L.bmp", "Resources/panel_volR_R.bmp", "Resources/panel_start.bmp" };
			KeyConfigData.image_list = strArrays1;
			string[,] strArrays2 = new string[11, 2];
			strArrays2[0, 0] = "KeyConfigA1";
			strArrays2[0, 1] = "KeyConfigA2";
			strArrays2[1, 0] = "KeyConfigB1";
			strArrays2[1, 1] = "KeyConfigB2";
			strArrays2[2, 0] = "KeyConfigC1";
			strArrays2[2, 1] = "KeyConfigC2";
			strArrays2[3, 0] = "KeyConfigD1";
			strArrays2[3, 1] = "KeyConfigD2";
			strArrays2[4, 0] = "KeyConfigFXL1";
			strArrays2[4, 1] = "KeyConfigFXL2";
			strArrays2[5, 0] = "KeyConfigFXR1";
			strArrays2[5, 1] = "KeyConfigFXR2";
			strArrays2[6, 0] = "KeyConfigLknobLturn1";
			strArrays2[6, 1] = "KeyConfigLknobLturn2";
			strArrays2[7, 0] = "KeyConfigLknobRturn1";
			strArrays2[7, 1] = "KeyConfigLknobRturn2";
			strArrays2[8, 0] = "KeyConfigRknobLturn1";
			strArrays2[8, 1] = "KeyConfigRknobLturn2";
			strArrays2[9, 0] = "KeyConfigRknobRturn1";
			strArrays2[9, 1] = "KeyConfigRknobRturn2";
			strArrays2[10, 0] = "KeyConfigStart1";
			strArrays2[10, 1] = "KeyConfigStart2";
			KeyConfigData.data_list = strArrays2;
		}

		public KeyConfigData()
		{
			this.Update();
		}

		public bool IsSaveCheck()
		{
			for (int i = 0; i < 11; i++)
			{
				if ((int)Settings.Instance[KeyConfigData.data_list[i, 0]] == SettingKeyList.NONE_KEY_CODE && (int)Settings.Instance[KeyConfigData.data_list[i, 1]] == SettingKeyList.NONE_KEY_CODE)
				{
					return false;
				}
			}
			return true;
		}

		public static string SelectedImage(int button)
		{
			if (button == -1)
			{
				return KeyConfigData.UNSELECTED_IMAGE;
			}
			return KeyConfigData.image_list[button];
		}

		public void SetDefault()
		{
			int[,] numArray = new int[,] { { 32, 0 }, { 33, 0 }, { 36, 0 }, { 37, 0 }, { 123, 0 }, { 121, 0 }, { 30, 0 }, { 31, 0 }, { 38, 0 }, { 39, 0 }, { 28, 7 } };
			for (int i = 0; i < 11; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					Settings.Instance[KeyConfigData.data_list[i, j]] = numArray[i, j];
				}
			}
			this.Update();
		}

		public void Setting(int button, int index, SettingKey settings)
		{
			if (settings == null)
			{
				return;
			}
			if (!settings.isSetting)
			{
				return;
			}
			for (int i = 0; i < 11; i++)
			{
				int num = 0;
				while (num < 2)
				{
					if ((int)Settings.Instance[KeyConfigData.data_list[i, num]] != settings.keycode)
					{
						num++;
					}
					else
					{
						Settings.Instance[KeyConfigData.data_list[i, num]] = 0;
						break;
					}
				}
			}
			Settings.Instance[KeyConfigData.data_list[button, index]] = settings.keycode;
			this.Update();
		}

		public void Update()
		{
			this.settingList = new List<KeySettings>();
			for (int i = 0; i < 11; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					if (i != 10 && j != 0)
					{
						SettingKey settingKey = SettingKeyList.Get((int)Settings.Instance[KeyConfigData.data_list[i, j]]);
						if (!settingKey.isSetting || settingKey.name == SettingKeyList.UNKNOWN_KEY_NAME)
						{
							this.SetDefault();
							return;
						}
					}
				}
			}
			for (int k = 0; k < 11; k++)
			{
				this.settingList.Add(new KeySettings(KeyConfigData.button_list[k], SettingKeyList.Get((int)Settings.Instance[KeyConfigData.data_list[k, 0]]), SettingKeyList.Get((int)Settings.Instance[KeyConfigData.data_list[k, 1]])));
			}
		}
	}
}