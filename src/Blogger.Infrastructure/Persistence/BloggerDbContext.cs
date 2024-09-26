
using System.Data;
using Blogger.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Blogger.Infrastructure.Persistence;
public class BloggerDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator? _mediator;
    private IDbContextTransaction? _currentTransaction;

    public BloggerDbContext(DbContextOptions<BloggerDbContext> dbContextOptions)
            : base(dbContextOptions) { }

    public BloggerDbContext(DbContextOptions<BloggerDbContext> dbContextOptions, IMediator mediator/*, IDbContextTransaction dbContextTransaction*/) : base(dbContextOptions)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    }

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction!;
    public bool HasActiveTransaction => _currentTransaction != null;

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Subscriber> Subscribers => Set<Subscriber>();

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator!.DispatcherEventAsync(this);
        await base.SaveChangesAsync(cancellationToken);
        return true;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=HealthDB;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        base.OnConfiguring(optionsBuilder);

    }

    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(BloggerDbContextSchema.DefaultSchema);

        var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
    }
}
