using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Npgsql;

namespace TaskerAI.Database
{
    public interface IDatabase
    {
        Task<T> Get<T>(string query);

    }

    public class Database : IDatabase
    {
        private readonly IDbConnection db;

        public Database(string connString)
        {
            this.db = new NpgsqlConnection(connString);
        }

        public Task<T> Get<T>(string query) => throw new NotImplementedException();
    }
}
