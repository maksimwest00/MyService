using System.Diagnostics;

namespace WPFClient.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _currentVM;
        public BaseViewModel CurrentVM
        {
            get
            {
                return _currentVM;
            }
            set
            {
                _currentVM = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(StartViewModel workerDataViewModel)
        {
            workerDataViewModel.mainVM = this;
            this.CurrentVM = workerDataViewModel;
        }
    }


}


