using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BHB.Common.API;
using Project_Portfolio_Domain.Model.Project;
using Project_Portfolio_Domain.Repository;
using Project_Portfolio_Domain.ViewModels;

namespace Project_Portfolio_V4._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public IProjectRepository ProjectRepository { get; }

        public ProjectController(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }

        [HttpGet]
        public ApiResponse<IEnumerable<Project>> Get()
        {
            var response = new ApiResponse<IEnumerable<Project>> {Data = ProjectRepository.GetAll()};
            return response;
        }

        [HttpGet]
        [Route("page/{page}")]
        [Route("page/{page}/{numPerPage}")]
        public PagedApiResponse<IEnumerable<ProjectCard>> GetCards(int page, int numPerPage = 8)
        {
            page = page - 1;
            if (page < 0) page = 0;
            var response = new PagedApiResponse<IEnumerable<ProjectCard>>
            {
                Page = page,
                NumPerPage = numPerPage,
                Data = ProjectRepository.GetShownProjects()
                    .OrderByDescending(project=>project.Featured)
                    .ThenByDescending(project => project.Updated)
                    .Skip(page * numPerPage)
                    .Take(numPerPage)
                    .Select(project =>
                        new ProjectCard
                            {
                                Id = project.Id,
                                Name = project.Name,
                                ShortDescription = project.ShortDescription,
                                DemoUrl = project.DemoUrl,
                                SourceUrl = project.SourceUrl,
                                ImageDataUrl = project.ImageDataUrl
                            }),
                TotalPages = (int) Math.Ceiling(ProjectRepository.GetAll().Count(project => project.Show) / (decimal) numPerPage)
            };
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public ApiResponse<Project> Get(int id)
        {
            var response = new ApiResponse<Project>
            {
                Data=ProjectRepository.Get(id)
            };
            return response;
        }

        [HttpGet]
        [Route("Featured")]
        public ApiResponse<IEnumerable<ProjectCard>> Featured()
        {
            var response = new ApiResponse<IEnumerable<ProjectCard>>
            {
                Data = ProjectRepository.GetFeatured().Select(project=>new ProjectCard
                {
                    Id = project.Id,
                    Name = project.Name,
                    ShortDescription = project.ShortDescription,
                    ImageDataUrl = project.ImageDataUrl
                })
            };
            return response;
        }

        [HttpPost]
        public ApiResponse SaveProject([FromBody]Project project)
        {
            var response = new ApiResponse();
            ProjectRepository.AddOrUpdate(project);
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public ApiResponse DeleteProject(int id)
        {
            var response = new ApiResponse();
            ProjectRepository.Delete(id);
            return response;
        }
    }
}
