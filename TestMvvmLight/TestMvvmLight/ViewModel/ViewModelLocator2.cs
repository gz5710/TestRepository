/*
  In App.xaml:
  <Application.Resources>
      <vm:ModelLocator2 xmlns:vm="clr-namespace:TestMvvmLight.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TestMvvmLight.Model;
using TestMvvmLight.SimpleIocTest;

namespace TestMvvmLight.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator2
    {
        static ViewModelLocator2()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                // SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<ViewModel2>();

            // Simple Ioc test
            SimpleIoc.Default.Register<IDataItemService, OracleDataItemService>();
            SimpleIoc.Default.Register<DataItemManager>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ViewModel2 VM2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewModel2>();
            }
        }
    }
}