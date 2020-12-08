using System;

namespace Setting
{
	public class DisplayRotationData
	{
		public const int ItemIndexDefault = 0;

		private readonly static int ItemIndexMax;

		private readonly static int ItemIndexMin;

		public readonly static int ItemCount;

		public readonly static DisplayRotationData.DisplayRotationEnum[] ItemSource;

		public DisplayRotationData.DisplayRotationEnum SelectedIndex
		{
			get
			{
				int displayRotation = Settings.Instance.DisplayRotation;
				if (displayRotation > DisplayRotationData.ItemIndexMax)
				{
					int num = 0;
					displayRotation = num;
					Settings.Instance.DisplayRotation = num;
				}
				if (displayRotation < DisplayRotationData.ItemIndexMin)
				{
					int num1 = 0;
					displayRotation = num1;
					Settings.Instance.DisplayRotation = num1;
				}
				return DisplayRotationData.ItemSource[displayRotation];
			}
			set
			{
				Settings.Instance.DisplayRotation = (int)value;
			}
		}

		static DisplayRotationData()
		{
			DisplayRotationData.ItemIndexMax = (int)Enum.GetNames(typeof(DisplayRotationData.DisplayRotationEnum)).Length - 1;
			DisplayRotationData.ItemIndexMin = 0;
			DisplayRotationData.ItemCount = DisplayRotationData.ItemIndexMax - DisplayRotationData.ItemIndexMin + 1;
			DisplayRotationData.DisplayRotationEnum[] displayRotationEnumArray = new DisplayRotationData.DisplayRotationEnum[] { DisplayRotationData.DisplayRotationEnum.monitor_T, DisplayRotationData.DisplayRotationEnum.monitor_B, DisplayRotationData.DisplayRotationEnum.monitor_R, DisplayRotationData.DisplayRotationEnum.monitor_L };
			DisplayRotationData.ItemSource = displayRotationEnumArray;
		}

		public DisplayRotationData()
		{
		}

		public static bool DisplayResolutionNormal(int item_index)
		{
			if (item_index > DisplayRotationData.ItemIndexMax || item_index < DisplayRotationData.ItemIndexMin)
			{
				return false;
			}
			if ((DisplayRotationData.DisplayRotationEnum)Enum.ToObject(typeof(DisplayRotationData.DisplayRotationEnum), item_index) == DisplayRotationData.DisplayRotationEnum.monitor_R)
			{
				return false;
			}
			if ((DisplayRotationData.DisplayRotationEnum)Enum.ToObject(typeof(DisplayRotationData.DisplayRotationEnum), item_index) == DisplayRotationData.DisplayRotationEnum.monitor_L)
			{
				return false;
			}
			return true;
		}

		public enum DisplayRotationEnum
		{
			monitor_T,
			monitor_B,
			monitor_R,
			monitor_L
		}
	}
}