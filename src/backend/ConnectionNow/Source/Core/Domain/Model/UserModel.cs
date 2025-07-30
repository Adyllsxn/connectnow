namespace ConnectionNow.Source.Core.Domain.Model;
public class UserModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "UserName is required")]
    [StringLength(50, ErrorMessage = "UserName can't be longer than 50 characters")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(150, ErrorMessage = "Email can't be longer than 150 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string PasswordHash { get; set; } = string.Empty;

    [Required(ErrorMessage = "ChatRoom is required")]
    [StringLength(20, ErrorMessage = "ChatRoom can't be longer than 20 characters")]
    public string ChatRoom { get; set; } = string.Empty;
}
