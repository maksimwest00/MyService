using Microsoft.EntityFrameworkCore;

namespace MyGreetingService.Common
{
    public class WorkerMessageRepositoryWithoutGRPC : MainWorkerMessageRepository, IWorkerMessageRepository
    {
        public WorkerMessageRepositoryWithoutGRPC(string url) : base(url) { }
        public WorkerList GetWorkerList()
        {
            WorkerList workerList = new WorkerList();
            using (ApplicationContext db = new ApplicationContext())
            {
                DbSet<WorkerMessage> dbWorkers = db.Workers;
                workerList.Workers.AddRange(dbWorkers);
            }
            return workerList;
        }
        public void WorkerAction(WorkerAction workerAction)
        {
            switch (workerAction.ActionType)
            {
                case Action.Create:
                    CreateWorker(workerAction.Worker);
                    break;
                case Action.Update:
                    UpdateWorker(workerAction.Worker);
                    break;
                case Action.Delete:
                    DeleteWorker(workerAction.Worker);
                    break;
            }
        }
        public void CreateWorker(WorkerMessage worker)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Workers.Contains(worker))
                {
                    return;
                }
                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }
        public void UpdateWorker(WorkerMessage worker)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                WorkerMessage? dbworker = db.Workers.Where(dbworker => dbworker.Id == worker.Id).FirstOrDefault();
                UpdateWorker(worker, dbworker);
                db.SaveChanges();
            }
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
        public void DeleteWorker(WorkerMessage worker)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Workers.Contains(worker))
                {
                    db.Workers.Remove(worker);
                }
                db.SaveChanges();
            }
        }
    }
}
