using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Dapper;
using Npgsql;

namespace TaskerAI.Database
{
    public interface IDatabase
    {
        Task<IEnumerable<T>> GetAsync<T>(string query);
        Task<T> GetByIdAsync<T>(string query);
    }

    public class PostgreSql : IDatabase
    {
        private readonly IDbConnection db;

        public PostgreSql(string connString) => this.db = new NpgsqlConnection(connString);

        public Task<IEnumerable<T>> GetAsync<T>(string query) => this.db.QueryAsync<T>(query);

        public Task<T> GetByIdAsync<T>(string query) => this.db.QueryFirstAsync<T>(query);
    }
}
