using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Setting
{
	public partial class MainWindow : Window
	{
		private KeyConfigData keyConfig;

		private WindowSettingsData windowSettings;

		private DisplaySettingsData displaySettings;

		private DisplayRotationData displayRotation;

		private DisplayResolutionData displayResolution;

		public MainWindow()
		{
			SettingsSaveLoad.Load();
			Settings.SaveTempData();
			this.InitializeComponent();
		}

		private void DefaultButton_Click(object sender, RoutedEventArgs e)
		{
			this.keyConfig.SetDefault();
			this.keyConfigGrid.ItemsSource = this.keyConfig.settingList;
		}

		private void DisplayResolution_ChangedList()
		{
			int displayResolutionX = Settings.Instance.DisplayResolutionX;
			int displayResolutionY = Settings.Instance.DisplayResolutionY;
			DisplayResolutionData displayResolutionDatum = this.displayResolution;
			if (displayResolutionDatum != null)
			{
				displayResolutionDatum.Update();
				displayResolutionDatum.AutoSelection(displayResolutionX, displayResolutionY);
			}
			if (this.DisplayResolutionComboBox != null)
			{
				if (Settings.Instance.WindowSettings == 1)
				{
					this.DisplayResolutionComboBox.IsEnabled = false;
					return;
				}
				this.DisplayResolutionComboBox.IsEnabled = true;
			}
		}

		private void DisplayResolutionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.DisplayResolutionComboBox != null)
			{
				BindingExpression bindingExpression = this.DisplayResolutionComboBox.GetBindingExpression(Selector.SelectedIndexProperty);
				if (bindingExpression != null)
				{
					bindingExpression.UpdateSource();
				}
			}
		}

		private void DisplayRotationRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			this.DisplayResolution_ChangedList();
		}

		private void DisplaySettingsRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			this.DisplayResolution_ChangedList();
		}

		private void FinishButton_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int FinishSettingLib();

		[DllImport("libsettings.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int InitSettingLib();

		private void keyConfigGrid_LostFocus(object sender, RoutedEventArgs e)
		{
			this.keyConfigImage.Source = new BitmapImage(new Uri(KeyConfigData.UNSELECTED_IMAGE, UriKind.Relative));
		}

		private void keyConfigGrid_MouseLeftButtonDown(object sender, RoutedEventArgs e)
		{
			DataGrid dataGrid = sender as DataGrid;
			if (sender == null)
			{
				return;
			}
			DataGridColumn column = dataGrid.CurrentCell.Column;
			if (column.DisplayIndex == 0)
			{
				return;
			}
			KeySettings currentItem = dataGrid.CurrentItem as KeySettings;
			int displayIndex = column.DisplayIndex - 1;
			SettingKey item = currentItem[displayIndex];
			if (!item.isSetting)
			{
				return;
			}
			string[] strArrays = new string[] { currentItem.button };
			string[] str = new string[] { column.Header.ToString() };
			string[] imageList = new string[] { KeyConfigData.image_list[dataGrid.SelectedIndex] };
			string[] strArrays1 = imageList;
			SettingKey[] settingKeyArray = new SettingKey[] { item };
			KeySettingWindow keySettingWindow = new KeySettingWindow();
			keySettingWindow.Setup(strArrays, str, strArrays1, settingKeyArray);
			keySettingWindow.ShowDialog();
			this.keyConfig.Setting(dataGrid.SelectedIndex, displayIndex, keySettingWindow.SelectedKey[0]);
			this.keyConfigGrid.ItemsSource = this.keyConfig.settingList;
		}

		private void keyConfigGrid_SelectionChanged(object sender, RoutedEventArgs e)
		{
			DataGrid dataGrid = sender as DataGrid;
			if (sender == null)
			{
				return;
			}
			this.keyConfigImage.Source = new BitmapImage(new Uri(KeyConfigData.SelectedImage(dataGrid.SelectedIndex), UriKind.Relative));
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (!this.keyConfig.IsSaveCheck())
			{
				MessageBox.Show(this, "キーコンフィグに設定されていないキーが存在します。 保存に失敗しました。", "保存失敗", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK);
				return;
			}
			Settings.SaveTempData();
			if (SettingsSaveLoad.Save())
			{
				MessageBox.Show(this, "設定ファイルの保存に成功しました。", "保存成功", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
				return;
			}
			MessageBox.Show(this, "設定ファイルの保存に失敗しました。", "保存失敗", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK);
		}

		private void SettingButton_Click(object sender, RoutedEventArgs e)
		{
			string[] buttonList = new string[21];
			string[] strArrays = new string[21];
			string[] imageList = new string[21];
			SettingKey[] settingKeyArray = new SettingKey[21];
			int[] numArray = new int[21];
			int[] numArray1 = new int[21];
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					if (SettingKeyList.Get((int)Settings.Instance[KeyConfigData.data_list[j, i]]).isSetting)
					{
						buttonList[num] = KeyConfigData.button_list[j];
						strArrays[num] = (i == 0 ? "キー割り当て１" : "キー割り当て２");
						imageList[num] = KeyConfigData.image_list[j];
						settingKeyArray[num] = SettingKeyList.Get((int)Settings.Instance[KeyConfigData.data_list[j, i]]);
						numArray[num] = j;
						numArray1[num] = i;
						num++;
					}
				}
			}
			KeySettingWindow keySettingWindow = new KeySettingWindow();
			keySettingWindow.Setup(buttonList, strArrays, imageList, settingKeyArray);
			keySettingWindow.ShowDialog();
			for (int k = 0; k < 21; k++)
			{
				this.keyConfig.Setting(numArray[k], numArray1[k], keySettingWindow.SelectedKey[k]);
			}
			this.keyConfigGrid.ItemsSource = this.keyConfig.settingList;
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			if (Settings.IsDiffTempDataCheck() && MessageBox.Show(this, "保存されていない値が存在します。 本当に終了しますか？", "終了確認", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) != MessageBoxResult.Yes)
			{
				e.Cancel = true;
				return;
			}
			MainWindow.FinishSettingLib();
			e.Cancel = false;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MainWindow.InitSettingLib();
			this.keyConfig = new KeyConfigData();
			this.keyConfigGrid.ItemsSource = this.keyConfig.settingList;
			this.windowSettings = new WindowSettingsData();
			this.WindowSettingsCombobBox.DataContext = this.windowSettings;
			this.WindowSettingsInfo.DataContext = this.windowSettings;
			this.displaySettings = new DisplaySettingsData();
			this.DisplaySettingsRadioButton.DataContext = this.displaySettings;
			this.displayRotation = new DisplayRotationData();
			this.DisplayRotationRadioButton.DataContext = this.displayRotation;
			this.displayResolution = new DisplayResolutionData();
			this.DisplayResolutionComboBox.DataContext = this.displayResolution;
		}

		private void WindowSettingsComboBox_SelectionChanged(object sender, RoutedEventArgs e)
		{
			this.DisplayResolution_ChangedList();
		}
	}
}