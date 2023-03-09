using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Model.Entity;

#pragma warning disable CS8618

namespace ProjectPortfolio.Model.Data;

public class PortfolioContext: DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<ProjectTag> ProjectTags { get; set; }
}