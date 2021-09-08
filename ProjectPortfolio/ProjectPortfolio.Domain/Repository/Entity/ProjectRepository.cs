using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkDhamon.Common.DataRepository;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Domain.Data;
using ProjectPortfolio.Domain.Model.Business;
using ProjectPortfolio.Domain.Model.Entity;

namespace ProjectPortfolio.Domain.Repository.Entity
{
    public class ProjectRepository: EfBaseRepository<ProjectPortfolioContext,Project>
    {
        public ProjectRepository(ProjectPortfolioContext context) : base(context)
        {
        }

        private IQueryable<Project> ActiveProjects => All().Where(project=>project.Deleted==null);
        private IQueryable<Project> DisplayedProjects => ActiveProjects.Where(project=>!project.Hide);
        private IQueryable<Project> ProjectsByMostRecent => DisplayedProjects.OrderByDescending(project => project.Updated);
        
        public async Task<IEnumerable<ProjectListItem>> GetPagedProjectListAsync(int page = 1, int entriesPerPage = 10)
        {
            var projects = ProjectsByMostRecent;
            var entriesToSkip = page - 1 * entriesPerPage;
            var currentPage = projects
                .Skip(entriesToSkip)
                .Take(entriesPerPage);
            return await currentPage.Select(project=>new ProjectListItem()
            {
                Id = project.Id,
                Title = project.Title,
                Featured = project.Featured,
                Created = project.Created,
            }).ToListAsync();
        }
    }
}
