using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Setting
{
	public class DisplayResolutionData : INotifyPropertyChanged
	{
		private int ItemIndexMax;

		private readonly static int ItemIndexMin;

		public static int[,,] ItemIndexDefault;

		private List<DisplayResolutionData.resolution>[,,] ItemDataList = new List<DisplayResolutionData.resolution>[WindowSettingsData.ItemCount, DisplaySettingsData.ItemCount, DisplayRotationData.ItemCount];

		public string[] ItemSource
		{
			get;
			private set;
		}

		public int SelectedIndex
		{
			get
			{
				int displayResolutionX = Settings.Instance.DisplayResolutionX;
				int displayResolutionY = Settings.Instance.DisplayResolutionY;
				int itemIndexDefault = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation].FindIndex((DisplayResolutionData.resolution x) => {
					if (x.resX != displayResolutionX)
					{
						return false;
					}
					return x.resY == displayResolutionY;
				});
				if (itemIndexDefault > this.ItemIndexMax)
				{
					itemIndexDefault = DisplayResolutionData.ItemIndexDefault[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation];
					Settings.Instance.DisplayResolutionX = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation][itemIndexDefault].resX;
					Settings.Instance.DisplayResolutionY = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation][itemIndexDefault].resY;
				}
				if (itemIndexDefault < DisplayResolutionData.ItemIndexMin)
				{
					itemIndexDefault = DisplayResolutionData.ItemIndexDefault[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation];
					Settings.Instance.DisplayResolutionX = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation][itemIndexDefault].resX;
					Settings.Instance.DisplayResolutionY = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation][itemIndexDefault].resY;
				}
				return itemIndexDefault;
			}
			set
			{
				if (value > this.ItemIndexMax)
				{
					value = DisplayResolutionData.ItemIndexDefault[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation];
				}
				if (value < DisplayResolutionData.ItemIndexMin)
				{
					value = DisplayResolutionData.ItemIndexDefault[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation];
				}
				Settings.Instance.DisplayResolutionX = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation][value].resX;
				Settings.Instance.DisplayResolutionY = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation][value].resY;
			}
		}

		static DisplayResolutionData()
		{
			DisplayResolutionData.ItemIndexMin = 0;
		}

		public DisplayResolutionData()
		{
			this.CreateDisplayResolutionList();
			this.Update();
			List<DisplayResolutionData.resolution> itemDataList = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation];
			int num = this.AutoSelection(Settings.Instance.DisplayResolutionX, Settings.Instance.DisplayResolutionY);
            Settings.Instance.DisplayResolutionX = 2560;// itemDataList[num].resX;
            Settings.Instance.DisplayResolutionY = 1440;// itemDataList[num].resY;
			Settings.SaveTempData();
		}

		public int AutoSelection(int x, int y)
		{
			int num = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation].FindIndex((DisplayResolutionData.resolution item) => {
				if (item.resX != x)
				{
					return false;
				}
				return item.resY == y;
			});
			if (num != -1)
			{
				return num;
			}
			return DisplayResolutionData.ItemIndexDefault[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation];
		}

		public void CreateDisplayResolutionList()
		{
			DisplayResolutionData.ItemIndexDefault = new int[WindowSettingsData.ItemCount, DisplaySettingsData.ItemCount, DisplayRotationData.ItemCount];
			for (int i = 0; i < WindowSettingsData.ItemCount; i++)
			{
				for (int j = 0; j < DisplaySettingsData.ItemCount; j++)
				{
					for (int k = 0; k < DisplayRotationData.ItemCount; k++)
					{
						this.ItemDataList[i, j, k] = new List<DisplayResolutionData.resolution>();
						if (i == 1)
						{
							this.ItemDataList[i, j, k].Add(new DisplayResolutionData.resolution(0, 0));
							DisplayResolutionData.ItemIndexDefault[i, j, k] = 0;
						}
						else if (i == 0)
						{
							int displayModeNr = DisplayResolutionData.GetDisplayModeNr(j);
							for (int l = 0; l < displayModeNr; l++)
							{
								int displayModeWitdh = DisplayResolutionData.GetDisplayModeWitdh(j, l);
								int displayModeHeight = DisplayResolutionData.GetDisplayModeHeight(j, l);
								if (this.ItemDataList[i, j, k].FindIndex((DisplayResolutionData.resolution item) => {
									if (item.resX != displayModeWitdh)
									{
										return false;
									}
									return item.resY == displayModeHeight;
								}) == -1)
								{
									this.ItemDataList[i, j, k].Add(new DisplayResolutionData.resolution(displayModeWitdh, displayModeHeight));
								}
							}
							this.ItemDataList[i, j, k].Sort((DisplayResolutionData.resolution a, DisplayResolutionData.resolution b) => a.resX * a.resX + a.resY - (b.resX * b.resX + b.resY));
							int displayWidth = DisplayResolutionData.GetDisplayWidth(j);
							int displayHeight = DisplayResolutionData.GetDisplayHeight(j);
							int num = this.ItemDataList[i, j, k].FindIndex((DisplayResolutionData.resolution item) => {
								if (item.resX != displayWidth)
								{
									return false;
								}
								return item.resY == displayHeight;
							});
							DisplayResolutionData.ItemIndexDefault[i, j, k] = (num == -1 ? 0 : num);
						}
						else if (i == 2)
						{
							int displayWidth1 = DisplayResolutionData.GetDisplayWidth(j);
							int displayHeight1 = DisplayResolutionData.GetDisplayHeight(j);
							int num1 = (DisplayRotationData.DisplayResolutionNormal(k) ? 90 : 160);
							int num2 = (DisplayRotationData.DisplayResolutionNormal(k) ? 160 : 90);
							int num3 = 4;
							do
							{
								if (!DisplayRotationData.DisplayResolutionNormal(k))
								{
									this.ItemDataList[i, j, k].Add(new DisplayResolutionData.resolution(num1 * num3, num2 * num3));
								}
								else
								{
									this.ItemDataList[i, j, k].Add(new DisplayResolutionData.resolution(num1 * num3, num2 * num3));
								}
								num3++;
							}
							while (num1 * num3 <= displayWidth1 && num2 * num3 <= displayHeight1);
							int num4 = this.ItemDataList[i, j, k].FindIndex((DisplayResolutionData.resolution item) => {
								if (item.resX != num1 * (num3 - 1))
								{
									return false;
								}
								return item.resY == num2 * (num3 - 1);
							});
							DisplayResolutionData.ItemIndexDefault[i, j, k] = (num4 == -1 ? 0 : num4);
						}
					}
				}
			}
		}

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDisplayHeight(int displayNum);

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDisplayModeHeight(int displayNum, int modeNum);

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDisplayModeNr(int displayNum);

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDisplayModeWitdh(int displayNum, int modeNum);

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDisplayWidth(int displayNum);

		public void Update()
		{
			this.ItemSource = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation].ConvertAll<string>((DisplayResolutionData.resolution x) => x.ItemName()).ToArray();
			this.ItemIndexMax = this.ItemDataList[Settings.Instance.WindowSettings, Settings.Instance.DisplaySettings, Settings.Instance.DisplayRotation].Count<DisplayResolutionData.resolution>() - 1;
			PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs("ItemSource"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private class resolution
		{
			public int resX;

			public int resY;

			public resolution(int x, int y)
			{
				this.resX = x;
				this.resY = y;
			}

			public string ItemName()
			{
				if (this.resX == 0 && this.resY == 0)
				{
					return "---";
				}
				return string.Concat(this.resX, " × ", this.resY);
			}
		}
	}
}