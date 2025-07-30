namespace ConnectionNow.Source.Core.Application.Service;
public class AuthService: IAuthService
{
    #region Contructor
    private readonly IUserRepository _repository;
    private readonly string _jwtKey;

    public AuthService(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _jwtKey = configuration["Jwt:Key"]!;
    }
    #endregion

    #region Register
    public async Task<bool> RegisterAsync(UserModel model, CancellationToken token)
    {
        model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
        return await _repository.CreateAsync(model, token);
    }
    #endregion

    #region Authenticate
    public async Task<UserModel?> AuthenticateAsync(string email, string password, CancellationToken token)
    {
        var users = await _repository.GetAllAsync(token);
        var user = users.FirstOrDefault(u => u.Email == email);

        if (user is null) return null;

        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
    }
    #endregion

    #region ChangePassword
    public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword, string confirmNewPassword, CancellationToken token)
    {
        var user = await _repository.GetByIdAsync(userId, token);
        if (user is null) return false;
        if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash)) return false;
        if (newPassword != confirmNewPassword) return false;

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        return await _repository.UpdateAsync(user, token);
    }
    #endregion

    #region GenerateJwtToken
    public string GenerateJwtToken(UserModel user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            },
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion
}
