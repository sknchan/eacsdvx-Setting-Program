using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Setting
{
	[Serializable]
	public class SettingDatas
	{
		public SerializableDictionary<string, string> Parameters
		{
			get;
			set;
		}

		public SettingDatas()
		{
			this.Parameters = new SerializableDictionary<string, string>();
		}

		internal bool GetParamAsBool(string key, bool defaultVal)
		{
			bool flag;
			try
			{
				if (this.Parameters.ContainsKey(key) && bool.TryParse(this.Parameters[key], out flag))
				{
					return flag;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal double GetParamAsDouble(string key, double defaultVal)
		{
			double num;
			try
			{
				if (this.Parameters.ContainsKey(key) && double.TryParse(this.Parameters[key], out num))
				{
					return num;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal int GetParamAsInt32(string key, int defaultVal)
		{
			int num;
			try
			{
				if (this.Parameters.ContainsKey(key) && int.TryParse(this.Parameters[key], out num))
				{
					return num;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal long GetParamAsInt64(string key, long defaultVal)
		{
			long num;
			try
			{
				if (this.Parameters.ContainsKey(key) && long.TryParse(this.Parameters[key], out num))
				{
					return num;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal float GetParamAsSingle(string key, float defaultVal)
		{
			float single;
			try
			{
				if (this.Parameters.ContainsKey(key) && float.TryParse(this.Parameters[key], out single))
				{
					return single;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal string GetParamAsString(string key, string defaultVal)
		{
			if (!this.Parameters.ContainsKey(key))
			{
				return defaultVal;
			}
			return this.Parameters[key];
		}

		internal uint GetParamAsUInt32(string key, uint defaultVal)
		{
			uint num;
			try
			{
				if (this.Parameters.ContainsKey(key) && uint.TryParse(this.Parameters[key], out num))
				{
					return num;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal ulong GetParamAsUInt64(string key, ulong defaultVal)
		{
			ulong num;
			try
			{
				if (this.Parameters.ContainsKey(key) && ulong.TryParse(this.Parameters[key], out num))
				{
					return num;
				}
			}
			catch (Exception exception)
			{
			}
			return defaultVal;
		}

		internal void SetParamAsBool(string key, bool val)
		{
			this.Parameters[key] = val.ToString();
		}

		internal void SetParamAsDouble(string key, double val)
		{
			this.Parameters[key] = val.ToString();
		}

		internal void SetParamAsInt32(string key, int val)
		{
			this.Parameters[key] = val.ToString();
		}

		internal void SetParamAsInt64(string key, long val)
		{
			this.Parameters[key] = val.ToString();
		}

		internal void SetParamAsSingle(string key, float val)
		{
			this.Parameters[key] = val.ToString();
		}

		internal void SetParamAsString(string key, string val)
		{
			this.Parameters[key] = val;
		}

		internal void SetParamAsUInt32(string key, uint val)
		{
			this.Parameters[key] = val.ToString();
		}

		internal void SetParamAsUInt64(string key, ulong val)
		{
			this.Parameters[key] = val.ToString();
		}
	}
}