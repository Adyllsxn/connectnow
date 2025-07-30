namespace ConnectionNow.Source.Containers.Features.Auth;
[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    #region Login
    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request, CancellationToken token)
    {
        var user = await authService.AuthenticateAsync(request.Email, request.Password, token);
        if (user is null)
            return Unauthorized("Invalid credentials");

        var jwt = authService.GenerateJwtToken(user);
        // Adicionar JWT como cookie
        Response.Cookies.Append("jwt", jwt, new CookieOptions
        {
            HttpOnly = true,
            Secure = false, // ❗ Ativa apenas se for HTTPS
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });
        return Ok(new
        {
            user.Id,
            user.UserName,
            user.Email,
            user.ChatRoom
        });
    }
    #endregion

    #region Logout
    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok("Logged out");
    }
    #endregion

    #region Register
    [HttpPost("Register")]
    [EndpointSummary("Create a new user")]
    public async Task<ActionResult> Register([FromBody] UserModel model, CancellationToken token)
    {
        var result = await authService.RegisterAsync(model, token);
        return result ? Ok("User registered") : StatusCode(500, "Register failed");
    }
    #endregion

    #region ChangePassword
    [HttpPut("ChangePassword")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken token)
    {
        var result = await authService.ChangePasswordAsync(request.UserId, request.CurrentPassword, request.NewPassword, request.ConfirmNewPassword, token);
        return result ? Ok("Password changed") : BadRequest("Password change failed");
    }
    #endregion

}
