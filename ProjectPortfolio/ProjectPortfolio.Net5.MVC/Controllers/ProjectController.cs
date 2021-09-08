using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var projects = await ProjectRepository.GetPagedProjectListAsync();
            return View(projects);
        }
    }
}
