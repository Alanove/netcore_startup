using lw.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;

namespace lw.Infra.DataContext;
public partial class AppDbContext : DbContext
{
    protected readonly DbContextOptions<AppDbContext> _options;

    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        _options = options;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
    public List<T> SqlQuery<T>(string query, Func<DbDataReader, T> map)
    {
        using (var command = this.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            this.Database.OpenConnection();

            using (var result = command.ExecuteReader())
            {
                var entities = new List<T>();

                while (result.Read())
                {
                    entities.Add(map(result));
                }

                return entities;
            }
        }
    }
    public void ExecuteQuery(string query)
    {
        using (var command = this.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            this.Database.OpenConnection();

            command.ExecuteReader();
        }
    }
}
