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

    class LocationRepository : ILocationRepository
    {

        private readonly IDbConnection db;

        public LocationRepository(IDbConnection db)
        {
            this.db = db;
        }

        public Domain.Entities.Location Create(Domain.Entities.Location domainEntity)
        {

            var newLocation = Mapper.map(domainEntity);

            var id = this.db.Insert(newLocation);
            newLocation.Id = (int)id;

            return Mapper.map(newLocation);


        }
        public Task<Domain.Entities.Location> CreateAsync(Domain.Entities.Location domainEntity) => throw new NotImplementedException();
        public Paged<Domain.Entities.Location> Get(string alias, string[] tags, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            var sql = "SELECT * FROM Locations WHERE alias = @Alias or tags = @Tags";
            var list = this.db.Query<Entities.Location>(sql, new Entities.Location { Alias = alias, Tags = string.Join(',', tags) }).ToList();

            var result = new List<Domain.Entities.Location>();

            foreach(Entities.Location item in list)
            {
                result.Add(Mapper.map(item));


            }

            return Paged<Domain.Entities.Location>.CreatePagedObject(result, (int)pageIndex, (int)pageSize, result.Count);



        }
        public Domain.Entities.Location Get(string latitude, string longitude, string door, string floor)
        {

            var sql = "SELECT * FROM Locations WHERE latitude = @Latitude and longitude = @Longitude and door = @Door and floor = @Floor ";
            var result = this.db.Query<Entities.Location>(sql, new Entities.Location { Latitude = latitude, Longitude = longitude, Door =door, Floor = floor }).FirstOrDefault();


            return Mapper.map(result);

        }
        public Domain.Entities.Location Get(int id)
        {
            var location = this.db.Get<TaskerAI.Database.Entities.Location>(id);


            return Mapper.map(location);
        }
        public Task<Paged<Domain.Entities.Location>> GetAsync(string alias, string[] tags, int? pageSize, int? pageIndex, string sortBy, string sortAs) => throw new NotImplementedException();
        public Task<Domain.Entities.Location> GetAsync(string latitude, string longitude, string door, string floor) => throw new NotImplementedException();
        public Domain.Entities.Location Update(Domain.Entities.Location domainEntity)
        {
            this.db.Update(Mapper.map(domainEntity));
            return domainEntity;

        }
        public Task<Domain.Entities.Location> UpdateAsync(Domain.Entities.Location domainEntity) => throw new NotImplementedException();
    }


}
