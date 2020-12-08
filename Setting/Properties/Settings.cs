using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Setting.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Setting.Properties.Settings defaultInstance;

		public static Setting.Properties.Settings Default
		{
			get
			{
				return Setting.Properties.Settings.defaultInstance;
			}
		}

		static Settings()
		{
			Setting.Properties.Settings.defaultInstance = (Setting.Properties.Settings)SettingsBase.Synchronized(new Setting.Properties.Settings());
		}

		public Settings()
		{
		}
	}
}