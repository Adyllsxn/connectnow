using ConnectionNow.Source.Core.Domain.Model;

namespace ConnectionNow.Source.Core.Domain.Interface;
public interface IUserRepository
{
    Task<bool> CreateAsync (UserModel model);
    Task<List<UserModel>> GetAllAsync ();
}
