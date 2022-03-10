using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_Portfolio_Domain.Model.Project;
using Project_Portfolio_Domain.Repository.Abstract;

namespace Project_Portfolio_Domain.Repository
{
    
    public interface IProjectRepository : IRepository<Project>
    {
        /// <summary>
        /// Get All Featured projects
        /// </summary>
        /// <remarks>
        /// Should filter from shown projects method
        /// </remarks>
        /// <returns></returns>
        IQueryable<Project> GetFeatured();
        /// <summary>
        /// Get all projects that are shown
        /// </summary>
        /// <returns></returns>
        IQueryable<Project> GetShownProjects();
    }
}
