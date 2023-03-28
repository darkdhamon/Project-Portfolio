using System.ComponentModel.DataAnnotations.Schema;
using DarkDhamon.Common.EntityFramework.Model;

namespace ProjectPortfolio.Model.Entity;

[Table("Image")]
public class ProjectImage:IEntity<int>
{
    public string? ImageData { get; set; }
    public string? AltText { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int Id { get; set; }
    public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
}