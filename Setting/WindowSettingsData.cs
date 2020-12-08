using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Setting
{
	public class WindowSettingsData : INotifyPropertyChanged
	{
		public const int ItemIndexDefault = 0;

		private readonly static int ItemIndexMax;

		private readonly static int ItemIndexMin;

		public readonly static int ItemCount;

		private readonly static string[] ItemList;

		private readonly static string[] InfoResource;

		public string ItemInfo
		{
			get;
			set;
		}

		public string[] ItemSource
		{
			get;
			private set;
		}

		public int SelectedIndex
		{
			get
			{
				int windowSettings = Settings.Instance.WindowSettings;
				if (windowSettings > WindowSettingsData.ItemIndexMax)
				{
					int num = 0;
					windowSettings = num;
					Settings.Instance.WindowSettings = num;
				}
				if (windowSettings < WindowSettingsData.ItemIndexMin)
				{
					int num1 = 0;
					windowSettings = num1;
					Settings.Instance.WindowSettings = num1;
				}
				return windowSettings;
			}
			set
			{
				this.ItemInfo = WindowSettingsData.InfoResource[value];
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("ItemInfo"));
				}
				Settings.Instance.WindowSettings = value;
			}
		}

		static WindowSettingsData()
		{
			WindowSettingsData.ItemIndexMax = (int)Enum.GetNames(typeof(WindowSettingsData.WindowSettingsEnum)).Length - 1;
			WindowSettingsData.ItemIndexMin = 0;
			WindowSettingsData.ItemCount = WindowSettingsData.ItemIndexMax - WindowSettingsData.ItemIndexMin + 1;
			WindowSettingsData.ItemList = new string[] { "フルスクリーン", "フィットウインドウ", "ウインドウ" };
			WindowSettingsData.InfoResource = new string[] { "指定解像度で全画面表示", "画面解像度に合わせてウィンドウ表示(フレーム無し)", "指定解像度でウィンドウ表示(フレーム有り)" };
		}

		public WindowSettingsData()
		{
			this.ItemSource = WindowSettingsData.ItemList;
			this.ItemInfo = WindowSettingsData.InfoResource[this.SelectedIndex];
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public enum WindowSettingsEnum
		{
			Fullscreen,
			FitWindow,
			Window
		}
	}
}