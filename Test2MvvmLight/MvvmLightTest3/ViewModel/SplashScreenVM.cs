using GalaSoft.MvvmLight;
using System.Diagnostics;

namespace MvvmLightTest3.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SplashScreenVM : ViewModelBase
    {
        private string _welcomeTitle = "First Title";

        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
                Debug.WriteLine($"New Value : {value}");
            }
        }
        /// <summary>
        /// Initializes a new instance of the SplashScreenVM class.
        /// </summary>
        public SplashScreenVM()
        {
        }
    }
}