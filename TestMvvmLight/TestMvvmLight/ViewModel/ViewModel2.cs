using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using TestMvvmLight.SimpleIocTest;

namespace TestMvvmLight.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModel2 : ViewModelBase
    {
        private readonly DataItemManager _manager;
        
        private string _winTitle = "Just for test several VM locators.";

        public string WinTitle
        {
            get
            {
                return _winTitle;
            }
            set
            {
                Set(ref _winTitle, value);
            }
        }

        public ICommand BtnClick { get; set; }

        /// <summary>
        /// Initializes a new instance of the ViewModel2 class.
        /// </summary>
        public ViewModel2(DataItemManager manager)
        {
            this._manager = manager;
            this.BtnClick = new RelayCommand(this.ShowItem);
        }
        private void ShowItem()
        {
            this._manager.DisplayItem();
        }
    }
}