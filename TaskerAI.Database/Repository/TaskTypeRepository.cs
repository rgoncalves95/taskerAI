namespace TaskerAI.Database.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using System.Data;

    using System.Data.SqlClient;

    using System.Linq;


    using Dapper;
    using Dapper.Contrib;
    using Dapper.Contrib.Extensions;

    class TaskTypeRepository : ITaskTypeRepository
    {
        private readonly IDbConnection db;

        public TaskTypeRepository(IDbConnection db)
        {
            this.db = db;
        }

        public Domain.Entities.TaskType Create(Domain.Entities.TaskType domainEntity)
        {

            var newTask = Mapper.map(domainEntity);

            var id = this.db.Insert(newTask);
            newTask.Id = (int)id;

            return Mapper.map(newTask);


        }

        //not working
        public async Task<Domain.Entities.TaskType> CreateAsync(Domain.Entities.TaskType domainEntity)
        {

            var newTask = Mapper.map(domainEntity);

            var id = await this.db.InsertAsync(newTask);
            newTask.Id = (int)id;

            return Mapper.map(newTask);


        }
        public bool Delete(int id)
        {

            return this.db.Delete(new TaskerAI.Database.Entities.TaskType() { Id = id });

        }
        public async Task<bool> DeleteAsync(int id)
        {

            return await this.db.DeleteAsync(new TaskerAI.Database.Entities.TaskType() { Id = id });

        }
        public Paged<Domain.Entities.TaskType> Get(string name, double? cost, int? duration, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            var sql = "SELECT * FROM TaskType WHERE name = @Name";
            var list = this.db.Query<Entities.TaskType>(sql, new Entities.TaskType { Name = name }).ToList();

            var result = new List<Domain.Entities.TaskType>();

            foreach (Entities.TaskType item in list)
            {
                result.Add(Mapper.map(item));


            }

            return Paged<Domain.Entities.TaskType>.CreatePagedObject(result, (int)pageIndex, (int)pageSize, result.Count);



        }
        public Domain.Entities.TaskType Get(int id)
        {
            var taskType = this.db.Get<TaskerAI.Database.Entities.TaskType>(id);


            return Mapper.map(taskType);
        }
        public Task<Paged<Domain.Entities.TaskType>> GetAsync(string name, double? cost, int? duration, int? pageSize, int? pageIndex, string sortBy, string sortAs) => throw new NotImplementedException();
        public Task<Domain.Entities.TaskType> GetAsync(int id) => throw new NotImplementedException();
        public Domain.Entities.TaskType Update(Domain.Entities.TaskType domainEntity)
        {
            this.db.Update(Mapper.map(domainEntity));
            return domainEntity;

        }
        public Task<Domain.Entities.TaskType> UpdateAsync(Domain.Entities.TaskType domainEntity) => throw new NotImplementedException();
    }


}
