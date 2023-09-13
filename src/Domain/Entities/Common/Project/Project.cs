using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Domain.Entities.Common.Project;
public class Project
{
    public Project()
    {
        
    }

    public Project(string name, string description, int? userId)
    {
        Name = name;
        Description = description;
        UserId = userId;
    }

    public int ProjectId { get; private set; }
    public string Name { get; private set; }
    public int? UserId { get; private set; }

    public string Description { get; private set; }
    public List<TaskEntity> Tasks { get; set; }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
