// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");


using var channel = GrpcChannel.ForAddress("http://localhost:5134");
// создаем клиент
var client = new WorkerIntegration.WorkerIntegrationClient(channel);
Console.Write("Введите имя: ");
string? name = Console.ReadLine();
WorkerList reply = client.GetWorkers(new EmptyMessage());
Console.ReadKey();

