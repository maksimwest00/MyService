namespace MyGreetingService.Core;

public interface IWorkerIntegration
{
    WorkerAction GetWorkerStream(EmptyMessage request);
}
