using Domain.Services.Users;
using System.Security.Claims;

namespace Api.Helpers;

public class UserContext : IUserContext
{
    private readonly ClaimsPrincipal _claims;

    public UserContext(IHttpContextAccessor contextAccessor)
    {
        _claims = contextAccessor?.HttpContext?.User;
    }

    public int UserId { get
        {
            var userId = _claims.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId == null ? default(int) : int.Parse(userId);
        }
    }

    public string Email { get
        {
            return _claims.FindFirstValue(ClaimTypes.Email);
        } 
    }
}
