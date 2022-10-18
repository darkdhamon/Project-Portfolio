using DarkDhamon.Common.EntityFramework.DataRepository;
using ProjectPortfolio.Model.Entity;

namespace ProjectPortfolio.Model.Data.Repository;

public class ProjectRepository : EfBaseRepository<PortfolioContext, Project>, IProjectRepository
{
    public ProjectRepository(PortfolioContext context) : base(context)
    {
    }
}