using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Portfolio_Domain.Model.Profile
{
    [Table("ContactMethod")]
    public class UsPhoneContactMethod : ContactMethod
    {
        [Phone]
        public string Number { get; set; }
    }
}