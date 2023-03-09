using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio.Model.Data.Repository;
using ProjectPortfolio.Model.Entity;
using ProjectPortfolio.MVC.Models;

namespace ProjectPortfolio.MVC.Controllers
{
    public class ProjectController : Controller
    {
        public IProjectRepository ProjectRepository { get; }
        public ITagRepository TagRepository { get; }

        public ProjectController(IProjectRepository projectRepository, ITagRepository tagRepository)
        {
            ProjectRepository = projectRepository;
            TagRepository = tagRepository;
        }

        // GET: ProjectController
        public ActionResult Index(int page = 0, int numPerPage = 10)
        {
            var projects = ProjectRepository.GetPagedProjects(page, numPerPage);
            var projectLineItems = projects.Select(project => new ProjectListItemViewModel
            {
                Id = project.Id,
                Title = project.Title,
                Tags = project.Tags,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            });
            return View(projectLineItems);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            var project = ProjectRepository.GetIncludeAllDetails(id);
            return View(project);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = new EditProjectViewModel
            {
                AvailibleTags = TagRepository.All(),
                Project = ProjectRepository.GetIncludeAllDetails(id)
            };
            return View(viewModel);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public class EditProjectViewModel
    {
        public IEnumerable<ProjectTag> AvailibleTags { get; set; }
        public Project? Project { get; set; }
    }
}
