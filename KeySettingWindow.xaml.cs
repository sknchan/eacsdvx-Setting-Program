using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Setting
{
	public partial class KeySettingWindow : Window
	{
		private BackgroundWorker bw;

		private KeySettingWindow.SettingMode mode;

		private SettingKey last_press_key = SettingKeyList.Get(SettingKeyList.NONE_KEY_NAME);

		public SettingKey[] SelectedKey;

		private int setting_index;

		private int setting_count;

		private string[] work_target;

		private string[] work_index;

		private string[] work_image;

		private SettingKey[] work_setting;

		public KeySettingWindow()
		{
			this.InitializeComponent();
			this.bw = new BackgroundWorker();
			this.bw.DoWork += new DoWorkEventHandler(this.bw_DoWork);
			this.bw.ProgressChanged += new ProgressChangedEventHandler(this.bw_ProgressChanged);
			this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_Completed);
			this.bw.WorkerReportsProgress = true;
			this.bw.WorkerSupportsCancellation = true;
		}

		private void bw_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			base.Close();
			KeySettingWindow.FinishSettingLibKey();
		}

		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			int num = 0;
			do
			{
				Thread.Sleep(10);
				int num1 = KeySettingWindow.CheckInputKey();
				if (num1 != 0)
				{
					backgroundWorker.ReportProgress(num1);
				}
				if (backgroundWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				num++;
			}
			while (num < 6000);
		}

		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.last_press_key = SettingKeyList.Get(e.ProgressPercentage);
			this.ButtonSetting.Text = this.last_press_key.name;
			if (!this.last_press_key.isSetting)
			{
				this.UpdateSettingStatus(KeySettingWindow.SettingStatus.SettingDisable);
			}
			else
			{
				this.UpdateSettingStatus(KeySettingWindow.SettingStatus.SettingEnable);
			}
			if (this.last_press_key.isSetting && this.mode == KeySettingWindow.SettingMode.MultiKeyMode)
			{
				this.MultiKeyMode_Next();
			}
		}

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int CheckInputKey();

		private void FinishButton_Click(object sender, RoutedEventArgs e)
		{
			this.bw.CancelAsync();
		}

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int FinishSettingLibKey();

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int InitSettingLibKey(IntPtr hWnd, IntPtr hInstance);

		private void MultiKeyMode_Next()
		{
			this.SelectedKey[this.setting_index] = this.last_press_key;
			this.setting_index++;
			if (this.setting_count <= this.setting_index)
			{
				this.bw.CancelAsync();
				return;
			}
			this.SettingSetup(this.work_target[this.setting_index], this.work_index[this.setting_index], this.work_image[this.setting_index], this.work_setting[this.setting_index]);
		}

		private void MultiKeyMode_Skip()
		{
			this.SelectedKey[this.setting_index] = this.work_setting[this.setting_index];
			this.setting_index++;
			if (this.setting_count <= this.setting_index)
			{
				this.bw.CancelAsync();
				return;
			}
			this.SettingSetup(this.work_target[this.setting_index], this.work_index[this.setting_index], this.work_image[this.setting_index], this.work_setting[this.setting_index]);
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.mode != KeySettingWindow.SettingMode.SingleKeyMode)
			{
				if (this.mode == KeySettingWindow.SettingMode.MultiKeyMode)
				{
					this.MultiKeyMode_Skip();
				}
				return;
			}
			if (!this.last_press_key.isSetting)
			{
				return;
			}
			this.SingleKeyMode_Next();
		}

		private void SettingSetup(string target, string index, string image, SettingKey now_setting)
		{
			this.ButtonSettingInfo.Content = string.Concat(target, "(", index, ") を設定しています。");
			this.ButtonSetting.Text = now_setting.name;
			this.UpdateSettingStatus(KeySettingWindow.SettingStatus.SettingEnable);
			if (image != "")
			{
				this.keyConfigImage.Source = new BitmapImage(new Uri(image, UriKind.Relative));
			}
			this.SelectedKey[this.setting_index] = now_setting;
			this.last_press_key = now_setting;
		}

		public void Setup(string[] target, string[] index, string[] image, SettingKey[] settings)
		{
			this.setting_count = target.Count<string>();
			if (this.setting_count != index.Count<string>() && this.setting_count > index.Count<string>())
			{
				this.setting_count = index.Count<string>();
			}
			if (this.setting_count != settings.Count<SettingKey>() && this.setting_count > settings.Count<SettingKey>())
			{
				this.setting_count = settings.Count<SettingKey>();
			}
			if (this.setting_count <= 0)
			{
				return;
			}
			if (this.setting_count != 1)
			{
				this.mode = KeySettingWindow.SettingMode.MultiKeyMode;
			}
			else
			{
				this.mode = KeySettingWindow.SettingMode.SingleKeyMode;
			}
			if (this.mode == KeySettingWindow.SettingMode.SingleKeyMode)
			{
				this.NextButton.Content = "設定";
				this.FinishButton.Content = "キャンセル";
			}
			else if (this.mode == KeySettingWindow.SettingMode.MultiKeyMode)
			{
				this.NextButton.Content = "スキップ";
				this.FinishButton.Content = "終了";
			}
			this.SelectedKey = new SettingKey[this.setting_count];
			this.setting_index = 0;
			this.work_target = target;
			this.work_index = index;
			this.work_image = image;
			this.work_setting = settings;
			this.SettingSetup(this.work_target[this.setting_index], this.work_index[this.setting_index], this.work_image[this.setting_index], this.work_setting[this.setting_index]);
			this.bw.RunWorkerAsync();
		}

		private void SingleKeyMode_Next()
		{
			this.SelectedKey[this.setting_index] = this.last_press_key;
			this.bw.CancelAsync();
		}

		private void UpdateSettingStatus(KeySettingWindow.SettingStatus status)
		{
			switch (status)
			{
				case KeySettingWindow.SettingStatus.SettingEnable:
				{
					this.SettingStatusInfo.Text = "設定したいキーを押してください。";
					this.SettingStatusBorder.BorderBrush = new SolidColorBrush(Colors.Black);
					return;
				}
				case KeySettingWindow.SettingStatus.SettingDisable:
				{
					this.SettingStatusInfo.Text = "そのキーを設定することはできません、別のキーを押してください。";
					this.SettingStatusBorder.BorderBrush = new SolidColorBrush(Colors.Red);
					return;
				}
				default:
				{
					return;
				}
			}
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			this.bw.CancelAsync();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			IntPtr handle = (new WindowInteropHelper(this)).Handle;
			IntPtr hINSTANCE = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
			KeySettingWindow.InitSettingLibKey(handle, hINSTANCE);
		}

		public enum SettingMode
		{
			SingleKeyMode,
			MultiKeyMode
		}

		private enum SettingStatus
		{
			SettingEnable,
			SettingDisable
		}
	}
}