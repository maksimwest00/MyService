using MyGreetingService.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGreetingService.WPF.Model
{
    public class NavigationModel
    {
        public string Name { get; set; }
        public BaseViewModel ViewModel { get; set; }
    }
}
