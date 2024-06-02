using Microsoft.EntityFrameworkCore;

namespace Blogger.IntegrationTests.Fixtures;
public abstract class EfDatabaseBaseFixture<TDbContext>
    : IDisposable where TDbContext : DbContext
{
    private readonly DbContextOptions<TDbContext> _options;
    private bool _disposedValue;

    protected EfDatabaseBaseFixture()
    {
        _options = new DbContextOptionsBuilder<TDbContext>()
                            .UseInMemoryDatabase("blogger")
                            .EnableSensitiveDataLogging()
                            .Options;
    }

    public TDbContext BuildDbContext()
    {
        try
        {
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

    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
            return;

        try
        {
            var dbCtx = BuildDbContext();
            dbCtx.Database.EnsureDeleted();
            _disposedValue = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
