using Domain.Entities.Users;

namespace Domain.Services.Users;
public interface ISecurityService
{
    string GenerateJwts(User user);

    string HashPassword(string password);
}
