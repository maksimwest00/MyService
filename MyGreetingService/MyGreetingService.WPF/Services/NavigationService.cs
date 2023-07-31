using MyGreetingService.WPF.Interfaces;
using MyGreetingService.WPF.Model;
using MyGreetingService.WPF.ViewModels;

namespace MyGreetingService.WPF.Services
{
    public class NavigationService : INavigationService
    {
        private MainWindowViewModel mainVM;
        public NavigationService(MainWindowViewModel mainWindowViewModel)
        {
            this.mainVM = mainWindowViewModel;
        }
        public void NavigateTo(NavigationModel navigationModel)
        {
            this.mainVM.CurrentVM = navigationModel.ViewModel;
        }
    }
}
