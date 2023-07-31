using MyGreetingService.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGreetingService.WPF.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(NavigationModel navigationModel);
    }
}
