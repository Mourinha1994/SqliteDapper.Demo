using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace SqliteDapper.Demo.Database
{
    public interface IDatabaseBootstrap
    {
        void Setup();
    }
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig _databaseConfig;
        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public void Setup()
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);

            var table = connection.Query<string>("SELECT * FROM sqlite_master WHERE type='table' AND name='Product';");
            var tableName = table.FirstOrDefault();

            if (!string.IsNullOrEmpty(tableName) && tableName == "Product")
                return;

            string sql = @"
               CREATE TABLE Product
               (
                Name VARCHAR(100) NOT NULL,
                Description VARCHAR(1000) NULL
                );
            ";

            connection.Execute(sql);
        }
    }
}
