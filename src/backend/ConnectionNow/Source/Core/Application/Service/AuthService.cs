namespace ConnectionNow.Source.Core.Application.Service;
public class AuthService(IUserRepository repository) : IAuthService
{
    #region Register
    public async Task<bool> RegisterAsync(UserModel model, CancellationToken token)
    {
        model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
        return await repository.CreateAsync(model, token);
    }
    #endregion

    #region Authenticate
    public async Task<UserModel?> AuthenticateAsync(string email, string password, CancellationToken token)
    {
        var users = await repository.GetAllAsync(token);
        var user = users.FirstOrDefault(u => u.Email == email);

        if (user is null) return null;

        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
    }
    #endregion

    #region ChangePassword
    public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword, string confirmNewPassword, CancellationToken token)
    {
        var user = await repository.GetByIdAsync(userId, token);
        if (user is null) return false;
        if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash)) return false;
        if (newPassword != confirmNewPassword) return false;

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        return await repository.UpdateAsync(user, token);
    }
    #endregion
}
