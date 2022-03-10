using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Portfolio_Domain.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int entityId);
        void AddOrUpdate(TEntity entity);
        void Delete(int entityId);
    }
}
