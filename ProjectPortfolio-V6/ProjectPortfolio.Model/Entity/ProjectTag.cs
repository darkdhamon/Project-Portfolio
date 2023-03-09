using DarkDhamon.Common.EntityFramework.Model;

namespace ProjectPortfolio.Model.Entity;

public class ProjectTag:IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}