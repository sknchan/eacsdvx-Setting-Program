using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Setting
{
	public class KeySettings
	{
		private const int KEY_INDEX_MAX = 2;

		public SettingKey[] key = new SettingKey[2];

		public string button
		{
			get;
			set;
		}

		public SettingKey this[int index]
		{
			get
			{
				return this.key[index];
			}
			set
			{
				this.key[index] = value;
			}
		}

		public bool key1State
		{
			get
			{
				return this.key[0].isSetting;
			}
		}

		public string key1str
		{
			get
			{
				return this.key[0].name;
			}
		}

		public bool key2State
		{
			get
			{
				return this.key[1].isSetting;
			}
		}

		public string key2str
		{
			get
			{
				return this.key[1].name;
			}
		}

		public KeySettings(string button, SettingKey key1, SettingKey key2)
		{
			this.button = button;
			this.key[0] = key1;
			this.key[1] = key2;
		}
	}
}