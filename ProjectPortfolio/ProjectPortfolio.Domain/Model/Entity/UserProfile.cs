using Microsoft.AspNetCore.Identity;
using ProjectPortfolio.Domain.Model.Entity.Abstract;

namespace ProjectPortfolio.Domain.Model.Entity
{
    public class UserProfile : TrackedEntity
    {
        public IdentityUser<int> User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}