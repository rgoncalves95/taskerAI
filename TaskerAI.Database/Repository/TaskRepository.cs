namespace TaskerAI.Database.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using Dapper.Contrib.Extensions;
    using TaskerAI.Common;
    using TaskerAI.Domain;

    internal class TaskRepository : ITaskRepository
    {
        private readonly IDbConnection db;
        private readonly ITaskMapper mapper;

        public TaskRepository(IDbConnection db, ITaskMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Paged<Domain.Entities.Task>> GetAsync(string name, int? type, DateTimeOffset? intervalStart, DateTimeOffset? intervalEnd, int? status, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            string sql = @"SELECT * FROM Tasks t 
                        JOIN Location l on l.Id = t.LocationId
                        JOIN TaskType tt on tt.Id = t.TaskTypeId
                        WHERE name LIKE %@Name%";

            var builder = new StringBuilder(sql);

            if (type.HasValue)
            {
                builder.Append(" AND");
            }

            if (intervalStart.HasValue)
            {
                builder.Append(" AND");
            }

            if (intervalStart.HasValue)
            {
                builder.Append(" AND");
            }

            if (status.HasValue)
            {
                builder.Append(" AND");
            }

            Func<Entities.Task, Entities.Location, Entities.TaskType, Entities.Task> mapResult = (task, location, taskType) =>
            {
                task.Location = location;
                task.TaskType = taskType;
                return task;
            };

            IEnumerable<Entities.Task> dbEntities = await this.db.QueryAsync(builder.ToString(), mapResult, new { Name = name });
            IEnumerable<Domain.Entities.Task> domainEntities = this.mapper.Map(dbEntities);

            return Paged<Domain.Entities.Task>.CreatePagedObject(domainEntities, (int)pageIndex, (int)pageSize, domainEntities.Count());
        }

        public async Task<Domain.Entities.Task> GetAsync(int id)
        {
            string sql = @"SELECT * FROM Tasks t 
                        JOIN Location l on l.Id = t.LocationId
                        JOIN TaskType tt on tt.Id = t.TaskTypeId
                        WHERE id = @Id";

            Func<Entities.Task, Entities.Location, Entities.TaskType, Entities.Task> mapResult = (task, location, taskType) =>
            {
                task.Location = location;
                task.TaskType = taskType;
                return task;
            };

            Entities.Task dbEntity = (await this.db.QueryAsync(sql, mapResult, new { Id = id })).FirstOrDefault();

            return this.mapper.Map(dbEntity);
        }

        public async Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task domainEntity)
        {
            Entities.Task dbEntity = this.mapper.Map(domainEntity);

            int id = await this.db.InsertAsync(dbEntity);

            return domainEntity;
        }

        public Task<bool> UpdateAsync(Domain.Entities.Task domainEntity) => this.db.UpdateAsync(this.mapper.Map(domainEntity));

        public Task<bool> DeleteAsync(int id) => this.db.DeleteAsync(new Entities.Task() { Id = id });
    }
}
