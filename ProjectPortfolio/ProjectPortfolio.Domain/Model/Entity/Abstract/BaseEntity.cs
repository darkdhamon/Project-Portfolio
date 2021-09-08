using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkDhamon.Common.DataRepository;

namespace ProjectPortfolio.Domain.Model.Entity.Abstract
{
    public abstract class BaseEntity:IEntity<int>
    {
        public int Id { get; set; }
    }
}
