using Dapper;
using Microsoft.Data.Sqlite;
using SqliteDapper.Demo.Database;
using SqliteDapper.Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.Providers
{
    public interface IProductProvider
    {
        Task<IEnumerable<Product>> Get();
    }

    public class ProductProvider : IProductProvider
    {
        private readonly DatabaseConfig _databaseConfig;
        public ProductProvider(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);

            return await connection.QueryAsync<Product>("SELECT rowid AS Id, Name, Description FROM Product;");
        }
    }
}
