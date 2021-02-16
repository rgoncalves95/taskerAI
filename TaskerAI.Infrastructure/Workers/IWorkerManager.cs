namespace TaskerAI.Infrastructure.Workers
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
        private readonly IEnumerable<IWorker> backgroundJobs;

        public WorkerManager(IEnumerable<IWorker> backgroundJobs) => this.backgroundJobs = backgroundJobs;

        public void Enqueue(string jobId, params string[] operationIds)
        {
            IWorker job = this.backgroundJobs.FirstOrDefault(j => j.Id == jobId);

            if (job == null)
            {
                throw new WorkerNotFoundException($"Worker with id {jobId} not found");
            }

            BackgroundJob.Enqueue(() => job.RunAsync(operationIds));
        }
    }
}
