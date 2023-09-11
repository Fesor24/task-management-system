using UserEntity = Domain.Entities.Users.User;

namespace Infrastructure.Specifications.User;
public class GetUserByEmailSpecification : BaseSpecification<UserEntity>
{
    public GetUserByEmailSpecification(string email) : base(x => x.UserInfo.Email ==  email)
    {
        
    }
}
