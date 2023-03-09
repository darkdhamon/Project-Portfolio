using DarkDhamon.Common.EntityFramework.DataRepository;
using ProjectPortfolio.Model.Entity;

namespace ProjectPortfolio.Model.Data.Repository
{
    public interface IProjectRepository:  IRepository<Project,int>
    {
        IQueryable<Project> GetPagedProjects(int page, int numPerPage);
        Project? GetIncludeAllDetails(int id);
    }
}
