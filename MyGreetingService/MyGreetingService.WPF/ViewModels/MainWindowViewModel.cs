using MyGreetingService.WPF.Interfaces;
using MyGreetingService.WPF.Services;
using System.Windows;

namespace MyGreetingService.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region NavSerivce
        public static INavigationService NavigationService { get; set; }
        #endregion

        #region Public Properties
        public BaseViewModel _navigationVM { get; set; }
        public BaseViewModel NavigationVM
        {
            get { return _navigationVM; }
            set
            {
                _navigationVM = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel _currentVM { get; set; }
        public BaseViewModel CurrentVM
        {
            get { return _currentVM; }
            set
            {
                _currentVM = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationVM = navigationViewModel;
            NavigationService = new NavigationService(this);
            NavigationService.NavigateTo(navigationViewModel.NavigationModels[0]);
        }
    }
}
