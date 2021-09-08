using ProjectPortfolio.Domain.Model.Entity.Abstract;

namespace ProjectPortfolio.Domain.Model.Entity
{
    public class Project:TrackedEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public bool Hide { get; set; }
    }
}
