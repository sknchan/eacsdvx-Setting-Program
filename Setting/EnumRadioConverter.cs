using System;
using System.Globalization;
using System.Windows.Data;

namespace Setting
{
	public class EnumRadioConverter : IValueConverter
	{
		public EnumRadioConverter()
		{
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string str = parameter as string;
			if (str == null)
			{
				return Binding.DoNothing;
			}
			if (!Enum.IsDefined(value.GetType(), str))
			{
				return Binding.DoNothing;
			}
			object obj = Enum.Parse(value.GetType(), str);
			return value.Equals(obj);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string str = parameter as string;
			if (str == null)
			{
				return Binding.DoNothing;
			}
			if (!(bool)value)
			{
				return Binding.DoNothing;
			}
			return Enum.Parse(targetType, str);
		}
	}
}