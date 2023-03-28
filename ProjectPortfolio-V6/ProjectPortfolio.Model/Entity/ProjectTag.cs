﻿using System.ComponentModel.DataAnnotations.Schema;
using DarkDhamon.Common.EntityFramework.Model;

namespace ProjectPortfolio.Model.Entity;

[Table("Tag")]
public class ProjectTag:IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
}