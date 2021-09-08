using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Domain.Model.Entity.Abstract;

namespace ProjectPortfolio.Domain.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void MapTrackedModel<TModel>(this ModelBuilder builder)
            where TModel : TrackedEntity
        {
            builder.Entity<TModel>(
                entity =>
                {
                    entity.HasOne(p => p.CreatedBy);
                    entity.HasOne(p => p.LastUpdatedBy);
                    entity.HasOne(p => p.CreatedBy);
                });
        }
    }
}
