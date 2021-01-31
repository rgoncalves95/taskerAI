namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TaskRepository : Domain.ITaskRepository
    {
        private static readonly List<Domain.Task> Db = CreateDummyTasks();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        public async Task<IEnumerable<Domain.Task>> GetAsync()
        {
            Func<Domain.Task, bool> filter = (t) => true;

            return await Task.FromResult(Db.Where(filter).ToList());
        }

        public async Task<Domain.Task> GetAsync(int id) => await Task.FromResult(Db.FirstOrDefault(t => t.Id == id));

        public async Task<Domain.Task> CreateAsync(Domain.Task domainEntity)
        {
            var @new = Domain.Task.Create
            (
                domainEntity.Name,
                domainEntity.Type,
                domainEntity.Location,
                domainEntity.Date,
                domainEntity.DueDate,
                domainEntity.DurationInSeconds,
                domainEntity.Notes,
                this.lastId + 1,
                domainEntity.Status,
                domainEntity.FinishDate
            );

            Db.Add(@new);

            return await Task.FromResult(@new);
        }

        public async Task<Domain.Task> UpdateAsync(Domain.Task domainEntity)
        {
            Domain.Task old = await GetAsync((int)domainEntity.Id);
            Db.Remove(old);

            return await CreateAsync(old);
        }

        public async Task DeleteAsync(int id) => Db.Remove(await GetAsync(id));

        private static List<Domain.Task> CreateDummyTasks()
        {
            var result = new List<Domain.Task>();

            var task = Domain.Task.Create(
                "Clean Office",
                new Domain.TaskType(1, "cleaning", 10.0, null, 3600, null),
                null,
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                3600,
                "some notes that we take",
                1,
                Domain.TaskStatus.Done,
                DateTimeOffset.Now
            );

            result.Add(task);

            task = Domain.Task.Create(
                "Delivery goods",
                new Domain.TaskType(2, "delivery", 20.0, null, 1800, null),
                null,
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                1800,
                "do'n't forget to take the trash",
                2,
                Domain.TaskStatus.Done,
                DateTimeOffset.Now
            );

            result.Add(task);

            task = Domain.Task.Create(
                "Check in beer",
                new Domain.TaskType(3, "check in", 10.0, null, 3600, null),
                null,
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                3600,
                "get some peanuts with it",
                3,
                Domain.TaskStatus.Done,
                DateTimeOffset.Now
            );

            result.Add(task);

            return result;
        }
    }
}
