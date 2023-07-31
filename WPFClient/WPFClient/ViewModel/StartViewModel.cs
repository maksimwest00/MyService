using MyGreetingService.Common;
using System.Text.RegularExpressions;
using System.Windows;

namespace WPFClient.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        public static IWorkerMessageRepository WorkerMessageRepository;
        public MainWindowViewModel mainVM { get; set; }

        #region Properties
        public string AddressServer { get; set; } = "http://localhost:5073";
        #endregion

        #region Constructor
        public StartViewModel()
        {
            this.LaunchAppCommand = new RelayCommand(LaunchApp, (obj) => true);
        }
        #endregion

        #region Commands
        public RelayCommand LaunchAppCommand { get; set; }
        #endregion

        #region Commands Methods
        private void LaunchApp(object obj)
        {
            if (obj is bool gRPC_Enabled)
            {
                if (gRPC_Enabled)
                {
                    string pattern = @"^http:\/\/localhost:\d{1,5}$";

                    if (!Regex.IsMatch(AddressServer, pattern))
                    {
                        MessageBox.Show("Неверный адрес");
                        return;
                    }
                    WorkerMessageRepository = new WorkerMessageRepositoryByGRPC(AddressServer);
                    this.mainVM.CurrentVM = new WorkerDataViewModel(this);
                }
                else
                {
                    WorkerMessageRepository = new WorkerMessageRepositoryWithoutGRPC(AddressServer);
                    this.mainVM.CurrentVM = new WorkerDataViewModel(this);
                }
            }
        }
        #endregion
    }

}

