using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System.Windows;
using System.Windows.Input;
using TestMvvmLight.Model;
using TestMvvmLight.SimpleIocTest;

namespace TestMvvmLight.ViewModel
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
        private readonly IDataItemService _dataItemService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

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
            }
        }
        public ICommand SayHi { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, IDataItemService dataItemService)
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

            this.SayHi = new RelayCommand(() => this.cmdBtnTry(), () => true);

            this._dataItemService = dataItemService;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private void cmdBtnTry()
        {
            //MessageBox.Show("Hello from Mvvm Light.");
            this.WelcomeTitle = this._dataItemService.GetItem().ToString();
            var manager = SimpleIoc.Default.GetInstance<DataItemManager>();
            manager.DisplayItem();
            var dialogService = SimpleIoc.Default.GetInstance<IDialogService>();
            dialogService.ShowMessage(this.WelcomeTitle, "Message from dialog service");
        }
    }
}