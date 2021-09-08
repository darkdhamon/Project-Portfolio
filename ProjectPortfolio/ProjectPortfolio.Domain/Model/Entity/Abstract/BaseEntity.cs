using DarkDhamon.Common.DataRepository;
using Microsoft.EntityFrameworkCore;

namespace ProjectPortfolio.Domain.Model.Entity.Abstract
{
    public abstract class BaseEntity:IEntity<int>
    {
        public int Id { get; set; }

        public virtual void Map(ModelBuilder builder)
        {
            
        }
    }

    
}
