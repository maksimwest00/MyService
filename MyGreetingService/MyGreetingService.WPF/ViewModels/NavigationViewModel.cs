using MyGreetingService.WPF.Interfaces;
using MyGreetingService.WPF.Model;
using System.Collections.Generic;

namespace MyGreetingService.WPF.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Public Properties
        public List<NavigationModel> NavigationModels { get; set; }
        #endregion

        public NavigationViewModel(
            FirstViewModel firstViewModel,
            SecondViewModel secondViewModel)
        {  
            this.NavigationModels = new List<NavigationModel>();
            this.NavigationModels.Add(new NavigationModel { Name = "Список сотрудников", ViewModel = firstViewModel });
            this.NavigationModels.Add(new NavigationModel { Name = "Удаление сотрудников", ViewModel = secondViewModel });
        }
    }
}
