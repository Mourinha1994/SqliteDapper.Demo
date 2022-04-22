using Dapper;
using Microsoft.Data.Sqlite;
using SqliteDapper.Demo.Database;
using SqliteDapper.Demo.Models;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.Repository
{
    public interface IProductRepository
    {
        Task Create(Product product);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public ProductRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public async Task Create(Product product)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO Product (Name, Description) VALUES (@Name, @Description);", product);
        }
    }
}
