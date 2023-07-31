namespace MyGreetingService.Common
{
    public interface IWorkerMessageRepository
    {
        WorkerList GetWorkerList();
        void WorkerAction(WorkerAction workerAction);
    }
}
