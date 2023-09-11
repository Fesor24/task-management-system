using System.ComponentModel.DataAnnotations;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Domain.Entities.Users;
public class User : AuditableEntity
{
    public User()
    {
        
    }

    public User(UserInfo userInfo, string password)
    {
        UserInfo = userInfo;
        Password = password;
    }

    public int UserId { get; private set; }
    [Required]
    public UserInfo UserInfo { get; private set; }
    public string Password { get; private set; }
    public List<TaskEntity> Tasks { get; private set; }
}
