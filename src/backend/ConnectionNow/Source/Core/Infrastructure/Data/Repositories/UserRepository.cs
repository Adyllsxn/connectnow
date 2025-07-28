namespace ConnectionNow.Source.Core.Infrastructure.Data.Repositories;
public class UserRepository : IUserRepository
{
    public Task<bool> CreateAsync(UserModel model)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
