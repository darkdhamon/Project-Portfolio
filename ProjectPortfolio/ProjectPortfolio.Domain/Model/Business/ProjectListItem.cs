using System;

namespace ProjectPortfolio.Domain.Model.Business
{
    public class ProjectListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Featured { get; set; }
        public DateTime Created { get; set; }
    }
}
