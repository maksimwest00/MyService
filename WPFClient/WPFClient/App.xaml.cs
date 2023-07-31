using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows;
using WPFClient.ViewModel;
using WPFClient.Views;

namespace WPFClient
{
    public partial class App : Application
    {
        public static IServiceProvider? Container { get; protected set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitContainer();
            if (Container is null)
                throw new Exception("init container error");
            MainWindowViewModel? MainVM = Container.GetService<MainWindowViewModel>() as MainWindowViewModel;
            var window = Container.GetService(typeof(MainWindow)) as MainWindow;
            if (window is null)
                throw new Exception("mainwindow is null error");
            window.DataContext = MainVM;
            window.Show();
            base.OnStartup(e);
        }

        private void InitContainer()
        {
            ServiceCollection services = new();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>();
            
            services.AddTransient<StartViewModel>();
            services.AddTransient<WorkerDataViewModel>();
            services.AddSingleton<WorkerCreateViewModel>();
            services.AddSingleton<WorkerUpdateViewModel>();
            Container = services.BuildServiceProvider();
        }
    }
}
