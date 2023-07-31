using Microsoft.Extensions.DependencyInjection;
using MyGreetingService.WPF.Interfaces;
using MyGreetingService.WPF.Services;
using MyGreetingService.WPF.ViewModels;
using MyGreetingService.WPF.Views;
using System;
using System.Windows;

namespace MyGreetingService.WPF
{
    public partial class App : Application
    {
        public static IServiceProvider? Container { get; protected set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            InitContainer();
            if (Container is null)
            {
                throw new Exception("ошибка контейнера");
            }
            MainWindowViewModel? MainVM = Container.GetService<MainWindowViewModel>() as MainWindowViewModel;
            var window = Container.GetService<MainWindow>() as MainWindow;
            if (window is null)
            {
                throw new Exception("ошбика создания DI контейнера окна нету");
            }
            window.DataContext = MainVM;
            window.Show();
            base.OnStartup(e);
        }

        private static void InitContainer()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<NavigationViewModel>();


            services.AddTransient<FirstViewModel>();
            services.AddTransient<SecondViewModel>();

            Container = services.BuildServiceProvider();
        }
    }
}
