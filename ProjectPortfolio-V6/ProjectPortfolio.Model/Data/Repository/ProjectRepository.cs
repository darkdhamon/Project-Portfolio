using DarkDhamon.Common.EntityFramework.DataRepository;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Model.Entity;

namespace ProjectPortfolio.Model.Data.Repository;

public class ProjectRepository : EfBaseRepository<PortfolioContext, Project>, IProjectRepository
{
    public ProjectRepository(PortfolioContext context) : base(context)
    {
    }

    public IQueryable<Project> GetPagedProjects(int page, int numPerPage)
    {
        if(page<1)page=1;
        var count = Context.Projects.Count();
        var numPages = count / numPerPage + (count%numPerPage>0?1:0);
        if (page>numPages)page=numPages;
        return Context.Projects.Include(project => project.Tags).Skip(numPerPage*(page-1)).Take(numPerPage);
    }

    public Project? GetIncludeAllDetails(int id)
    {
        return Context.Projects
            .Include(project => project.Tags)
            .FirstOrDefault(project=>project.Id == id);
    }
}