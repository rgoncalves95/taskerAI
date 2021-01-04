namespace TaskerAI.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class TaskRepository : ITaskRepository
    {
        public Task<Domain.Task> CreateAsync(Domain.Task domainEntity) => throw new NotImplementedException();
        public System.Threading.Tasks.Task DeleteAsync(int id) => throw new NotImplementedException();
        public Task<IEnumerable<Domain.Task>> GetAsync() => throw new NotImplementedException();
        public Task<Domain.Task> GetAsync(int id) => throw new NotImplementedException();
        public Task<Domain.Task> UpdateAsync(Domain.Task domainEntity) => throw new NotImplementedException();
    }
}
