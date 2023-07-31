using MyGreetingService.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPFClient.Views;
using Action = MyGreetingService.Common.Action;

namespace WPFClient.ViewModel
{
    public class WorkerCreateViewModel : BaseViewModel
    {
        public WorkerMessage NewWorker { get; set; }
        public RelayCommand BackCommand { get; set; }
        public WorkerCreateViewModel(Action<object> backAction)
        {
            this.BackCommand = new RelayCommand(backAction, (obj) => true);
            this.NewWorker = new WorkerMessage();
            this.AddWorkerCommand = new RelayCommand(AddWorker, (obj) => true);
            this.SexList = new List<Sex>((IEnumerable<Sex>)Enum.GetValues(typeof(Sex)));
        }
        public List<Sex> SexList { get; set; }
        public RelayCommand AddWorkerCommand { get; set; }
        private async void AddWorker(object obj)
        {
            await Task.Run(() =>
            {
                WorkerAction workerAction = new WorkerAction();
                workerAction.Worker = this.NewWorker;
                workerAction.ActionType = Action.Create;
                StartViewModel.WorkerMessageRepository.WorkerAction(workerAction);
            });
        }
    }
}

