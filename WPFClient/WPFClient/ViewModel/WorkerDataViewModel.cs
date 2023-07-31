using MyGreetingService.Common;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFClient.ViewModel
{
    public class WorkerDataViewModel : BaseViewModel
    {
        public ObservableCollection<WorkerMessage> Workers { get; set; }
        public WorkerMessage DataGridSelectedWorker { get; set; }

        public StartViewModel StartViewModel { get; set; }

        public RelayCommand DataGridSelectionChangedCommand { get; set; }

        public RelayCommand CreateWorkerCommand { get; set; }
        public RelayCommand UpdateWorkerCommand { get; set; }
        public RelayCommand DeleteWorkerCommand { get; set; }

        public WorkerDataViewModel(StartViewModel startViewModel)
        {
            this.StartViewModel = startViewModel;

            this.DataGridSelectionChangedCommand = new RelayCommand(DataGridSelectionChanged, (obj) => true);



            this.CreateWorkerCommand = new RelayCommand(CreateWorker, (obj) => true);
            this.UpdateWorkerCommand = new RelayCommand(UpdateWorker, (obj) => true);
            this.DeleteWorkerCommand = new RelayCommand(DeleteWorker, (obj) => this.DataGridSelectedWorker != null);
            GetWorkers();
        }

        private async Task GetWorkers()
        {
            this.Workers = new ObservableCollection<WorkerMessage>();
            WorkerList workerList = await Task.Run(() => StartViewModel.WorkerMessageRepository.GetWorkerList());
            foreach (var worker in workerList.Workers)
            {
                this.Workers.Add(worker);
            }
        }


        #region Action Methods
        private void CreateWorker(object obj)
        {
            this.StartViewModel.mainVM.CurrentVM = new WorkerCreateViewModel(Back);
        }
        private void UpdateWorker(object obj)
        {
            this.StartViewModel.mainVM.CurrentVM = new WorkerUpdateViewModel(this.DataGridSelectedWorker,Back);
        }
        private void DeleteWorker(object obj)
        {
            WorkerAction workerAction = new WorkerAction();
            workerAction.Worker = this.DataGridSelectedWorker;
            workerAction.ActionType = Action.Delete;
            StartViewModel.WorkerMessageRepository.WorkerAction(workerAction);
            this.Workers.Remove(this.DataGridSelectedWorker);
        }
        #endregion
        private void Back(object obj)
        {
            this.StartViewModel.mainVM.CurrentVM = new WorkerDataViewModel(StartViewModel);
            //GetWorkers();

        }

        private void DataGridSelectionChanged(object obj)
        {
            if (obj is SelectionChangedEventArgs selectionChanged)
            {
                if (selectionChanged.AddedItems.Count == 0)
                {
                    this.DataGridSelectedWorker = null;
                    return;
                }
                if (selectionChanged.AddedItems[0] is WorkerMessage worker)
                {
                    this.DataGridSelectedWorker = worker;
                }
                else
                {
                    this.DataGridSelectedWorker = null;
                    return;
                }
            }
        }

    }
}

