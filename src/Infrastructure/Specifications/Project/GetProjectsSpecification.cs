﻿using ProjectEntity = Domain.Entities.Common.Project.Project;

namespace Infrastructure.Specifications.Project;
public class GetProjectsSpecification : BaseSpecification<ProjectEntity>
{
    public GetProjectsSpecification(int userId) : base(x => x.UserId == userId)
    {
        
    }
}
