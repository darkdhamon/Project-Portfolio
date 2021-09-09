using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkDhamon.Common.API.Models;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Domain.Model.Business;
using ProjectPortfolio.Domain.Repository.Entity;

namespace ProjectPortfolio.Net5.MVC.Controllers
{
    public class ProjectController : Controller
    {
        public ProjectRepository ProjectRepository { get; }

        public ProjectController(ProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            const int entriesPerPage = 20;
            var viewModel = new PagedApiResponse<ProjectListItem>()
            {
                Data = await ProjectRepository.GetPagedProjectListAsync(page, entriesPerPage),
                Page = page,
                NumPerPage = entriesPerPage,
                TotalPages = await ProjectRepository.GetNumberOfPagesAsync(entriesPerPage)
            };
            return View(viewModel);
        }

        //public async Task<IActionResult> ProjectList(int page)
        //{
        //    var viewModel = new PagedApiResponse<ProjectListItem>();
        //    return PartialView("_ProjectTableList");
        //}

        public IActionResult Details(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
