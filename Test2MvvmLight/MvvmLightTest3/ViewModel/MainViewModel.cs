using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using MvvmLightTest3.Model;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvvmLightTest3.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        public SplashScreenVM SplashScreen { get; set; }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, SplashScreenVM ssvm)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
            this.SplashScreen = ssvm;
            Task.Run(
                async () =>
                {
                    await Task.Delay(4000);
                    //this.WelcomeTitle = "Test";
                    await DispatcherHelper.RunAsync(() => {
                        this.WelcomeTitle = "Test";
                        this.SplashScreen.WelcomeTitle = "Second Title";
                    });
                    //DispatcherHelper2.DoEvents();
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}