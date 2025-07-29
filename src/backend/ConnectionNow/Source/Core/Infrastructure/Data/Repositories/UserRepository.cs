namespace ConnectionNow.Source.Core.Infrastructure.Data.Repositories;
public class UserRepository(AppDbContext context,IUnitOfWork unitOfWork, ILogger<UserModel> logger) : IUserRepository
{
    #region Create
    public async Task<bool> CreateAsync(UserModel model, CancellationToken token)
    {
        try
        {
            model.Id = Guid.NewGuid();
            context.Users.Add(model);
            await unitOfWork.CommitAsync(token);
            return true;
        }
        catch(Exception ex)
        {
            logger.LogError($"An error occurred while creating the user. Details: {ex.Message}");
            return false;
        }
    }
    #endregion

    #region Delete
    public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
    {
        try
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return false;

            context.Users.Remove(user);
            await unitOfWork.CommitAsync(token);
            return true;
        }
        catch(Exception ex)
        {
            logger.LogError($"An error occurred while deleting the user. Details: {ex.Message}");
            return false;
        }
    }
    #endregion

    #region GetAll
    public async Task<List<UserModel>> GetAllAsync(CancellationToken token)
    {
        try
        {
            return await context.Users.ToListAsync(token);
        }
        catch(Exception ex)
        {
            logger.LogError($"An error occurred while retrieving all users. Details: {ex.Message}");
            return null!;
        }
    }
    #endregion

    #region GetById
    public async Task<UserModel?> GetByIdAsync(Guid id, CancellationToken token)
    {
        try
        {
            return await context.Users.FindAsync(id, token);
        }
        catch(Exception ex)
        {
            logger.LogError($"An error occurred while retrieving the user by ID. Details: {ex.Message}");
            return null!;
        }
    }
    #endregion
    
    #region GetByName
    public async Task<List<UserModel>> GetByNameAsync(string name, CancellationToken token)
    {
        try
        {
            return await context.Users
                .Where(u => u.UserName.ToLower().Contains(name.ToLower()))
                .ToListAsync(token);
        }
        catch(Exception ex)
        {
            logger.LogError($"An error occurred while retrieving users by name. Details: {ex.Message}");
            return null!;
        }
    }
    #endregion

    #region Update
    public async Task<bool> UpdateAsync(UserModel model, CancellationToken token)
    {
        try
        {
            var existing = await context.Users.FindAsync(model.Id, token);
            if (existing == null) return false;

            existing.UserName = model.UserName;
            existing.ChatRoom = model.ChatRoom;
            existing.Email = model.Email;

            await unitOfWork.CommitAsync(token);
            return true;
        }
        catch(Exception ex)
        {
            logger.LogError($"An error occurred while updating the user. Details: {ex.Message}");
            return false;
        }
    }
    #endregion
}
