using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace MyGreetingService.Server.Services;

public class WorkerIntegrationService : WorkerIntegration.WorkerIntegrationBase
{
    public override Task<WorkerList> GetWorkers(EmptyMessage request, ServerCallContext context)
    {
        WorkerList workerList = new WorkerList();
        using (ApplicationContext db = new ApplicationContext())
        {
            DbSet<WorkerMessage> dbWorkers = db.Workers;
            workerList.Workers.AddRange(dbWorkers);
        }
        return Task.FromResult(workerList);
    }
    public override Task<EmptyMessage> CreateWorker(WorkerMessage worker, ServerCallContext context)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            if (db.Workers.Contains(worker))
            {
                return Task.FromResult(new EmptyMessage());
            }
            db.Workers.Add(worker);
            db.SaveChanges();
        }
        return Task.FromResult(new EmptyMessage());
    }
    public override Task<EmptyMessage> DeleteWorker(WorkerMessage worker, ServerCallContext context)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            if (db.Workers.Contains(worker))
            {
                db.Workers.Remove(worker);
            }
            db.SaveChanges();
        }
        return Task.FromResult(new EmptyMessage());
    }
    public override Task<EmptyMessage> UpdateWorker(WorkerMessage worker, ServerCallContext context)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            WorkerMessage? dbworker = db.Workers.Where(dbworker => dbworker.Id == worker.Id).FirstOrDefault();
            UpdateWorker(worker, dbworker);
            db.SaveChanges();
        }
        return Task.FromResult(new EmptyMessage());
    }
    public void UpdateWorker(WorkerMessage editedWorker, WorkerMessage dbWorker)
    {
        dbWorker.LastName = editedWorker.LastName;
        dbWorker.FirstName = editedWorker.FirstName;
        dbWorker.MiddleName = editedWorker.MiddleName;
        dbWorker.Birthday = editedWorker.Birthday;
        dbWorker.Sex = editedWorker.Sex;
        dbWorker.HaveChildren = editedWorker.HaveChildren;
    }
}