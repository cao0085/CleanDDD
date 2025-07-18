using CleanDDD.Application.Common;
using CleanDDD.Infrastructure.Persistence.BaseDb;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BaseDbContext _db;

    public UnitOfWork(BaseDbContext db) => _db = db;

    public Task<int> CommitAsync(CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);

    public void Dispose() => _db.Dispose();
}