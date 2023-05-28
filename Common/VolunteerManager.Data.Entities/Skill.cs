﻿using EntityFrameworkCore.RepositoryInfrastructure;
using VolunteerManager.Data.Enums;

namespace VolunteerManager.Data.Entities;

public class Skill : Entity, IEntity
{
    public string Name { get; set; }

    public List<OrganizationRequest> OrganizationRequests { get; } = new();
}