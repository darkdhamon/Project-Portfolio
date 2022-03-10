using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Domain.Model.Entity.Abstract;

namespace ProjectPortfolio.Domain.Model.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}