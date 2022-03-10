using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Portfolio_Domain.Model.Profile
{
    [Table("ContactMethod")]
    public class SocialMediaContactMethod : ContactMethod
    {
        public SocialMediaType SocialMediaType { get; set; }
        [Url]
        public string Url { get; set; }
    }
}