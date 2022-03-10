using Project_Portfolio_Domain.Repository.Abstract;

namespace Project_Portfolio_Domain.Model.Project
{
    public class ProjectImages : Entity
    {
        public virtual Project Project { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string ImageTitle { get; set; }
        public bool MainImage { get; set; }
        public bool Show { get; set; }
        public int Order { get; set; }
    }
}