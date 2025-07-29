namespace ConnectionNow.Source.Core.Domain.Interface;
public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token);
}
