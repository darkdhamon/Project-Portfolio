using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Portfolio_Domain.Model.Profile
{
    [Table("ContactMethod")]
    public class EmailContactMethod : ContactMethod
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}