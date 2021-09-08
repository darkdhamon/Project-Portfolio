using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DarkDhamon.Common.DataRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Domain.Data.Extensions;
using ProjectPortfolio.Domain.Model.Entity;
using ProjectPortfolio.Domain.Model.Entity.Abstract;

namespace ProjectPortfolio.Domain.Data
{
    public class ProjectPortfolioContext: IdentityDbContext<IdentityUser<int>,IdentityRole<int>, int>
    {
        private IHttpContextAccessor HttpContextAccessor { get; }
        private ClaimsPrincipal userClaimsPrincipal => HttpContextAccessor.HttpContext.User;
        private int userId
        {
            get
            {
                int.TryParse(userClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier), out int id);
                return id;
            }
        }

        private AppUser LoggedInUser => AppUsers.FirstOrDefault(user => user.Id == userId);

        public ProjectPortfolioContext(DbContextOptions<ProjectPortfolioContext> options, IHttpContextAccessor httpContextAccessor)
            :base(options)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        #region Save Changes Overrides

        public override int SaveChanges()
        {
            FillTrackingMetaData();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            FillTrackingMetaData();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            FillTrackingMetaData();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            FillTrackingMetaData();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void FillTrackingMetaData()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is TrackedEntity)
                    switch (entry.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            entry.Property(nameof(TrackedEntity.Deleted)).CurrentValue = DateTime.Now;
                            entry.Property(nameof(TrackedEntity.DeletedBy)).CurrentValue = LoggedInUser;
                            break;
                        case EntityState.Modified:
                            entry.Property(nameof(TrackedEntity.Updated)).CurrentValue = DateTime.Now;
                            entry.Property(nameof(TrackedEntity.LastUpdatedBy)).CurrentValue = LoggedInUser;
                            break;
                        case EntityState.Added:
                            entry.Property(nameof(TrackedEntity.Created)).CurrentValue = DateTime.Now;
                            entry.Property(nameof(TrackedEntity.CreatedBy)).CurrentValue = LoggedInUser;
                            entry.Property(nameof(TrackedEntity.Updated)).CurrentValue = DateTime.Now;
                            entry.Property(nameof(TrackedEntity.LastUpdatedBy)).CurrentValue = LoggedInUser;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
            }
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapTrackedModel<Project>();
            base.OnModelCreating(builder);
        }
    }
}
