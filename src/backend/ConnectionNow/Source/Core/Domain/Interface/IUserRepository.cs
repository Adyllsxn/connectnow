namespace ConnectionNow.Source.Core.Domain.Interface;
public interface IUserRepository
{
    Task<List<UserModel>> GetAllAsync (CancellationToken token);
    Task<UserModel?> GetByIdAsync(Guid id, CancellationToken token);
    Task<List<UserModel>> GetByNameAsync(string name, CancellationToken token);
    Task<bool> CreateAsync (UserModel model, CancellationToken token);
    Task<bool> UpdateAsync(UserModel model, CancellationToken token);
    Task<bool> DeleteAsync(Guid id, CancellationToken token);
}
