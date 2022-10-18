using DarkDhamon.Common.EntityFramework.Model;

namespace ProjectPortfolio.Model.Entity
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }
    }
}
