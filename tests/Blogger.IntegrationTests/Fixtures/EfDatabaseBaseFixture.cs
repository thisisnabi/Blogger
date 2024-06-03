using Microsoft.EntityFrameworkCore;

namespace Blogger.IntegrationTests.Fixtures;
public abstract class EfDatabaseBaseFixture<TDbContext>
    : IDisposable where TDbContext : DbContext
{
    public TDbContext BuildDbContext(string dbName)
    {
        try
        {
            var _options = new DbContextOptionsBuilder<TDbContext>()
                            .UseInMemoryDatabase(dbName)
                            .EnableSensitiveDataLogging()
                            .Options;

            var db = BuildDbContext(_options);
            db.Database.EnsureCreated();

            return BuildDbContext(_options);
        }
        catch (Exception ex)
        {
            throw new Exception($"unable to connect to db.", ex);
        }
    }

    protected abstract TDbContext BuildDbContext(DbContextOptions<TDbContext> options);

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
