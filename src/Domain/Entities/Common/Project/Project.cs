using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Domain.Entities.Common.Project;
public class Project
{
    public Project()
    {
        
    }

    public Project(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int ProjectId { get; private set; }
    public string Name { get; private set; }

    public string Description { get; private set; }
    public List<TaskEntity> Tasks { get; set; }
}
