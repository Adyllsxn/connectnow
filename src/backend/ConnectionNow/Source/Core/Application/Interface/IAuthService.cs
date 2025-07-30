namespace ConnectionNow.Source.Core.Application.Interface;
public interface IAuthService
{
    Task<bool> RegisterAsync(UserModel model, CancellationToken token);
    Task<UserModel?> AuthenticateAsync(string email, string password, CancellationToken token);
    Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword, string confirmNewPassword, CancellationToken token);
    string GenerateJwtToken(UserModel user);
}
