namespace TaskerAI.Infrastructure.Jobs
{
    using System.Collections.Generic;
    using System.Linq;
    using Hangfire;

    public interface IWorkerManager
    {
        void Enqueue(string jobId, params string[] operationIds);
    }

    public class WorkerManager : IWorkerManager
    {
        private readonly IEnumerable<IWorkerJob> backgroundJobs;

        public WorkerManager(IEnumerable<IWorkerJob> backgroundJobs) => this.backgroundJobs = backgroundJobs;

        public void Enqueue(string jobId, params string[] operationIds)
        {
            IWorkerJob job = this.backgroundJobs.FirstOrDefault(j => j.Id == jobId);

            if (job != null)
            {
                BackgroundJob.Enqueue(() => job.RunAsync(operationIds));
            }
        }
    }
}
