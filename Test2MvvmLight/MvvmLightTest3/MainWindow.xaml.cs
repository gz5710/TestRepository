using System.Windows;
using MvvmLightTest3.ViewModel;
using System.Threading;
using System;

namespace MvvmLightTest3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            // Splash screen
            SplashView splash = new SplashView();
            splash.Show();
            Thread.Sleep(7000);
            splash.Close();
            if (splash is IDisposable)
            {
                (splash as IDisposable).Dispose();
            }
        }
    }
}