using Grpc.Core;
using MyGreetingService.Client;
using MyGreetingService.Client.Modules;
using Action = MyGreetingService.Client.Action;

try
{
    var workerMessageRepository = new WorkerMessageRepository("http://localhost", "5073");

    var worker = new WorkerMessage();
    worker.Birthday = 21052005;
    worker.FirstName = "Maksim";
    worker.LastName = "Sukhared";
    worker.MiddleName = "Alexandrovich";
    worker.Sex = Sex.Male;
    worker.HaveChildren = false;

    Console.Write("Добавить? ");
    string? name = Console.ReadLine();
    workerMessageRepository.WorkerAction(new WorkerAction { Worker = worker, ActionType = Action.Create });
    Console.Write("Удалить?");
    string? delete = Console.ReadLine();
    workerMessageRepository.WorkerAction(new WorkerAction { Worker = worker, ActionType = Action.Delete });

}
catch (RpcException ex)
{
    Console.WriteLine($"Ошибка gRPC: {ex.Message}");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    Console.ReadKey();
}