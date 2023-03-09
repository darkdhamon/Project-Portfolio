using ProjectPortfolio.Model.Entity;

namespace ProjectPortfolio.MVC.Models;

public class ProjectListItemViewModel
{
    public ProjectListItemViewModel()
    {
        Title = string.Empty;
        Tags = new List<ProjectTag>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ProjectTag> Tags { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}