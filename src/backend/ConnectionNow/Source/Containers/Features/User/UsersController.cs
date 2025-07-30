namespace ConnectionNow.Source.Containers.Features.User;
[ApiController]
[Route("api/users")]
[Authorize]

public class UsersController(IUserRepository repository) : ControllerBase
{
    #region List
    [HttpGet("ListUser")]
    [EndpointSummary("List all users")]
    public async Task<ActionResult> ListUser(CancellationToken token)
    {
        var users = await repository.GetAllAsync(token);
        return Ok(users.Select(u => new {
            u.Id, u.UserName, u.Email, u.ChatRoom
        }));
    }
    #endregion

    #region GetById
    [HttpGet("GetByIdUser")]
    [EndpointSummary("Get user by ID")]
    public async Task<ActionResult> GetByIdUser([FromQuery] Guid id, CancellationToken token)
    {
        var user = await repository.GetByIdAsync(id, token);
        if (user is null)
            return NotFound("User not found");

        return Ok(user);
    }
    #endregion

    #region Search
    [HttpGet("SearchUser")]
    [EndpointSummary("Search users by first name")]
    public async Task<ActionResult> SearchUser([FromQuery] string name, CancellationToken token)
    {
        var result = await repository.GetByNameAsync(name, token);
        return Ok(result);
    }
    #endregion

    #region Edit
    [HttpPut("EditUser")]
    [EndpointSummary("Edit user data")]
    public async Task<ActionResult> EditUser([FromBody] UserModel model, CancellationToken token)
    {
        var updated = await repository.UpdateAsync(model, token);
        if (!updated)
            return NotFound("User not found");

        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("DeleteUser")]
    [EndpointSummary("Delete user by ID")]
    public async Task<ActionResult> DeleteUser([FromQuery] Guid id, CancellationToken token)
    {
        var deleted = await repository.DeleteAsync(id, token);
        if (!deleted)
            return NotFound("User not found");

        return NoContent();
    }
    #endregion
}
