using Grpc.Net.Client;

namespace MyGreetingService.Common
{
    public class WorkerMessageRepositoryByGRPC : MainWorkerMessageRepository, IWorkerMessageRepository
    {
        public WorkerMessageRepositoryByGRPC(string url) : base(url) { }
        public WorkerList GetWorkerList()
        {
            using (var channel = GrpcChannel.ForAddress($"{this.URL}"))
            {
                var client = new WorkerIntegration.WorkerIntegrationClient(channel);
                WorkerList reply = client.GetWorkers(new EmptyMessage());
                return reply;
            }
        }
        public void WorkerAction(WorkerAction workerAction)
        {
            using (var channel = GrpcChannel.ForAddress($"{this.URL}"))
            {
                var client = new WorkerIntegration.WorkerIntegrationClient(channel);
                switch (workerAction.ActionType)
                {
                    case Action.Create:
                        EmptyMessage reply = client.CreateWorker(workerAction.Worker);
                        break;
                    case Action.Update:
                        reply = client.UpdateWorker(workerAction.Worker);
                        break;
                    case Action.Delete:
                        reply = client.DeleteWorker(workerAction.Worker);
                        break;
                }
            }
        }
    }
}
