using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using Test2MvvmLight.View;

namespace Test2MvvmLight
{
    /// <summary>
    /// 
    /// </summary>
    class App: Application
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread ( )]
        static void Main ( )
        {
            Splasher.Splash = new SplashView ( );
            Splasher.ShowSplash ( );

            Thread.Sleep(3000);
            Splasher.CloseSplash();
            new App ( );
        }
         /// <summary>
        /// 
        /// </summary>
        public App ( )
        {         
            StartupUri = new System.Uri ( "MainWindow.xaml", UriKind.Relative );

            Run ( );            
        }
    }
}
