using System;
using System.Runtime.CompilerServices;

namespace Setting
{
	public class SettingKey
	{
		public bool isSetting
		{
			get;
			set;
		}

		public int keycode
		{
			get;
			set;
		}

		public string name
		{
			get;
			set;
		}

		public SettingKey(int code, string str, bool set)
		{
			this.keycode = code;
			this.name = str;
			this.isSetting = set;
		}
	}
}