namespace ConnectionNow.Source.Core.Infrastructure.Data.UoW;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken token)
    {
        await context.SaveChangesAsync();
    }
}
