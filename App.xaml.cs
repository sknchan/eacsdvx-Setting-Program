using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace Setting
{
	public partial class App : Application, IComponentConnector
    {
		public App()
		{
        }
        private bool _contentLoaded;
        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            base.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            if (this._contentLoaded)
            {
                return;
            }
            this._contentLoaded = true;
            //Application.LoadComponent(this, new Uri("/sv3c_settings;component/app.xaml", UriKind.Relative));
        }

        [STAThread]
		public static void Main()
		{
			bool flag = false;
			using (Semaphore semaphore = new Semaphore(1, 1, "SOUND VOLTEX III GRAVITY WARS Settings", out flag))
			{
				if (flag)
				{
					App app = new App();
                    app.InitializeComponent();
					app.Run();
                 
				}
				else
				{
					MessageBox.Show("SOUND VOLTEX III GRAVITY WARS Settings はすでに起動しています。", "SOUND VOLTEX III GRAVITY WARS Settings", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
		}
        [DebuggerNonUserCode]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }
    }
}