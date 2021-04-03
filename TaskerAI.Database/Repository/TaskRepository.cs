namespace TaskerAI.Database.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using System.Data;
    using System.Data.SqlClient;

    using System.Linq;


    using Dapper;
    using Dapper.Contrib;
    using Dapper.Contrib.Extensions;

    class TaskRepository : ITaskRepository
    {
        private readonly IDbConnection db;

        public TaskRepository(IDbConnection db)
        {
            this.db = db;
        }

        public Domain.Entities.Task Create(Domain.Entities.Task domainEntity)
        {

            var newTask = Mapper.map(domainEntity);

            var id = this.db.Insert(newTask);
            newTask.Id = (int)id;

            return Mapper.map(newTask, this.db);


        }
        public Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task domainEntity) => throw new NotImplementedException();
        public bool Delete(int id)
        {

            return this.db.Delete(new TaskerAI.Database.Entities.Task() { Id = id });

        }
        public Task<bool> DeleteAsync(int id) => throw new NotImplementedException();
        public Paged<Domain.Entities.Task> Get(string name, int? type, DateTimeOffset? intervalStart, DateTimeOffset? intervalEnd, int? status, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            var sql = "SELECT * FROM Tasks WHERE name = @Name";
            var list = this.db.Query<Entities.Task>(sql, new Entities.Task { Name = name }).ToList();

            var result = new List<Domain.Entities.Task>();

            foreach (Entities.Task item in list)
            {
                result.Add(Mapper.map(item, db));


            }

            return Paged<Domain.Entities.Task>.CreatePagedObject(result, (int)pageIndex, (int)pageSize, result.Count);
        }
        public Domain.Entities.Task Get(int id)
        {
            var task = this.db.Get<TaskerAI.Database.Entities.Task>(id);


            return Mapper.map(task, this.db);

        }
        public Task<Paged<Domain.Entities.Task>> GetAsync(string name, int? type, DateTimeOffset? intervalStart, DateTimeOffset? intervalEnd, int? status, int? pageSize, int? pageIndex, string sortBy, string sortAs) => throw new NotImplementedException();
        public Task<Domain.Entities.Task> GetAsync(int id) => throw new NotImplementedException();

        public Domain.Entities.Task Update(Domain.Entities.Task domainEntity)
        {

            this.db.Update(Mapper.map(domainEntity));
            return domainEntity;

        }
        public Task<Domain.Entities.Task> UpdateAsync(Domain.Entities.Task domainEntity) => throw new NotImplementedException();
    }


}
