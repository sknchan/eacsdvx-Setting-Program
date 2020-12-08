using System;
using System.Runtime.InteropServices;

namespace Setting
{
	public class DisplaySettingsData
	{
		public const int ItemIndexDefault = 0;

		private readonly static int ItemIndexMax;

		private readonly static int ItemIndexMin;

		public readonly static int ItemCount;

		public readonly static DisplaySettingsData.DisplaySettingsEnum[] ItemSource;

		public bool[] IsEnabled;

		public bool Display1IsEnable
		{
			get
			{
				return this.IsEnabled[0];
			}
			private set
			{
			}
		}

		public bool Display2IsEnable
		{
			get
			{
				return this.IsEnabled[1];
			}
			private set
			{
			}
		}

		public DisplaySettingsData.DisplaySettingsEnum SelectedIndex
		{
			get
			{
				int displaySettings = Settings.Instance.DisplaySettings;
				if (displaySettings > DisplaySettingsData.ItemIndexMax)
				{
					int num = 0;
					displaySettings = num;
					Settings.Instance.DisplaySettings = num;
				}
				if (displaySettings < DisplaySettingsData.ItemIndexMin)
				{
					int num1 = 0;
					displaySettings = num1;
					Settings.Instance.DisplaySettings = num1;
				}
				return DisplaySettingsData.ItemSource[displaySettings];
			}
			set
			{
				Settings.Instance.DisplaySettings = (int)value;
			}
		}

		static DisplaySettingsData()
		{
			DisplaySettingsData.ItemIndexMax = (int)Enum.GetNames(typeof(DisplaySettingsData.DisplaySettingsEnum)).Length - 1;
			DisplaySettingsData.ItemIndexMin = 0;
			DisplaySettingsData.ItemCount = DisplaySettingsData.ItemIndexMax - DisplaySettingsData.ItemIndexMin + 1;
			DisplaySettingsData.ItemSource = new DisplaySettingsData.DisplaySettingsEnum[] { DisplaySettingsData.DisplaySettingsEnum.Display1, DisplaySettingsData.DisplaySettingsEnum.Display2 };
		}

		public DisplaySettingsData()
		{
			this.IsEnabled = new bool[DisplaySettingsData.ItemCount];
			int displayNr = DisplaySettingsData.GetDisplayNr();
			for (int i = 0; i < DisplaySettingsData.ItemCount; i++)
			{
				if (displayNr <= i)
				{
					this.IsEnabled[i] = false;
				}
				else
				{
					this.IsEnabled[i] = true;
				}
			}
			if (displayNr <= 0)
			{
				this.IsEnabled[0] = true;
			}
			while (!this.IsEnabled[(int)this.SelectedIndex])
			{
				DisplaySettingsData selectedIndex = this;
				selectedIndex.SelectedIndex = (DisplaySettingsData.DisplaySettingsEnum)((int)selectedIndex.SelectedIndex - (int)DisplaySettingsData.DisplaySettingsEnum.Display2);
			}
		}

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDisplayNr();

		public enum DisplaySettingsEnum
		{
			Display1,
			Display2
		}
	}
}