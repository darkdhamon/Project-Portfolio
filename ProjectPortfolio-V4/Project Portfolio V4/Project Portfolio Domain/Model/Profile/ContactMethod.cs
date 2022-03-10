using System.ComponentModel.DataAnnotations.Schema;
using Project_Portfolio_Domain.Repository.Abstract;

namespace Project_Portfolio_Domain.Model.Profile
{
    [Table("ContactMethod")]
    public abstract class ContactMethod : Entity
    {
        public Profile Profile { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
    }
}