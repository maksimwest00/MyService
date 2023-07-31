using Grpc.Net.Client;

namespace MyGreetingService.Client.Modules
{
    public class WorkerMessageRepository
    {
        #region Properties
        public string URL { get; set; }
        public string Port { get; set; }
        #endregion

        #region Constructor
        public WorkerMessageRepository(string url, string port)
        {
            this.URL = url;
            this.Port = port;
        }
        #endregion
        public WorkerList GetWorkerList()
        {
            using (var channel = GrpcChannel.ForAddress($"{this.URL}:{this.Port}"))
            {
                var client = new WorkerIntegration.WorkerIntegrationClient(channel);
                WorkerList reply = client.GetWorkers(new EmptyMessage());
                return reply;
            }
        }

        public void WorkerAction(WorkerAction workerAction)
        {
            using (var channel = GrpcChannel.ForAddress($"{this.URL}:{this.Port}"))
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
                Console.ReadKey();
            }
        }


        private void Base()
        {
            using (var channel = GrpcChannel.ForAddress($"{this.URL}:{this.Port}"))
            {
                var client = new WorkerIntegration.WorkerIntegrationClient(channel);
                var reply = client.GetWorkers(new EmptyMessage());
                Console.ReadKey();
            }
        }
    }
}
