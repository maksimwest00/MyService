using MyGreetingService.Common;
using System;
using System.Collections.Generic;
using Action = MyGreetingService.Common.Action;

namespace WPFClient.ViewModel
{
    public class WorkerUpdateViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public WorkerUpdateViewModel(WorkerMessage dataGridSelectedWorker , System.Action<object> backAction)
        {
            this.BackCommand = new RelayCommand(backAction, (obj) => true);

            this.EditingWorker = dataGridSelectedWorker;
            this.SexList = new List<Sex>((IEnumerable<Sex>)Enum.GetValues(typeof(Sex)));

            this.EditWorkerCommand = new RelayCommand(EditWorker, (obj) => true);
        }

        public List<Sex> SexList { get; set; }
        public WorkerMessage EditingWorker { get; set; }
        public RelayCommand EditWorkerCommand { get; set; }
        private void EditWorker(object obj)
        {
            WorkerAction workerAction = new WorkerAction();
            workerAction.Worker = this.EditingWorker;
            workerAction.ActionType = Action.Update;
            StartViewModel.WorkerMessageRepository.WorkerAction(workerAction);
        }
    }
}

