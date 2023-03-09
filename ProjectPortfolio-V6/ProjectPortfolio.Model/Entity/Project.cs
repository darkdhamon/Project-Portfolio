using DarkDhamon.Common.EntityFramework.Model;

namespace ProjectPortfolio.Model.Entity
{
    public class Project : IEntity<int>
    {
        public Project()
        {
            Title = string.Empty;
            Tags = new List<ProjectTag>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ProjectTag> Tags { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? FormattedDescription { get; set; }
    }
}
