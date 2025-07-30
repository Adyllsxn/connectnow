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
        return user is null
            ? Unauthorized("Invalid credentials")
            : Ok(new { user.Id, user.UserName, user.Email, user.ChatRoom });
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
