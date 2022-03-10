using System.ComponentModel.DataAnnotations;

namespace Project_Portfolio_Domain.Repository.Abstract
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}