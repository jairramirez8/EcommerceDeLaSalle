using System.Data.Common;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using MySqlConnector;

namespace DeLaSalle.Ecommerce.Api.DataAccess;

public class DbContext : IDbContext
{
    private readonly IConfiguration _config;

    private readonly string _connectionString = 
        "server=localhost;user=root;pwd=broncos;database=ecommerce;port=3306";

    private MySqlConnection _connection;

    public DbContext(IConfiguration config)
    {
        _config = config;
    }
    
    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
            
            return _connection;
        }
    }
}