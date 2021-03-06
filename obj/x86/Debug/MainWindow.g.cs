﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D42791284BC44E375A983DD72ECF4FBC056C68D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using Setting;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Setting {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WindowSettingsCombobBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WindowSettingsInfo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DisplaySettingsRadioButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DisplayRotationRadioButton;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DisplayResolutionComboBox;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid keyConfigGrid;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image keyConfigImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/sv3c_settings;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 2 "..\..\..\MainWindow.xaml"
            ((Setting.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 2 "..\..\..\MainWindow.xaml"
            ((Setting.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.WindowSettingsCombobBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.WindowSettingsCombobBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WindowSettingsComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WindowSettingsInfo = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.DisplaySettingsRadioButton = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            
            #line 30 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DisplaySettingsRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 42 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DisplaySettingsRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DisplayRotationRadioButton = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            
            #line 67 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DisplayRotationRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 70 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DisplayRotationRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 75 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DisplayRotationRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 78 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.DisplayRotationRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DisplayResolutionComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\..\MainWindow.xaml"
            this.DisplayResolutionComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DisplayResolutionComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 90 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 91 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DefaultButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.keyConfigGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 93 "..\..\..\MainWindow.xaml"
            this.keyConfigGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.keyConfigGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\MainWindow.xaml"
            this.keyConfigGrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.keyConfigGrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\MainWindow.xaml"
            this.keyConfigGrid.LostFocus += new System.Windows.RoutedEventHandler(this.keyConfigGrid_LostFocus);
            
            #line default
            #line hidden
            return;
            case 16:
            this.keyConfigImage = ((System.Windows.Controls.Image)(target));
            return;
            case 17:
            
            #line 126 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 127 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FinishButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

