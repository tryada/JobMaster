using JobMaster.Application.Common.Persistence;

namespace JobMaster.Infrastructure.Common.Persistence;

public class UnitOfWork(JobMasterDbContext dbContext) : IUnitOfWork
{
    private readonly JobMasterDbContext _dbContext = dbContext;

    public async Task BeginTransactionAsync()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}
