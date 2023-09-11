namespace Domain.Services.Users;
public interface IUserContext
{
    int UserId { get; }
    string Email { get; }
}
