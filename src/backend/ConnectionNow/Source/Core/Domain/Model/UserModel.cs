namespace ConnectionNow.Source.Core.Domain.Model;
public class UserModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string ChatRoom { get; set; } = string.Empty;
}
