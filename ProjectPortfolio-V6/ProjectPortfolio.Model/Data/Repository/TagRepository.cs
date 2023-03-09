using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkDhamon.Common.EntityFramework.DataRepository;
using ProjectPortfolio.Model.Entity;

namespace ProjectPortfolio.Model.Data.Repository
{
    public class TagRepository: EfBaseRepository<PortfolioContext,ProjectTag>,ITagRepository
    {
        public TagRepository(PortfolioContext context) : base(context)
        {
        }
    }

    public interface ITagRepository: IRepository<ProjectTag,int>
    {
    }
}
