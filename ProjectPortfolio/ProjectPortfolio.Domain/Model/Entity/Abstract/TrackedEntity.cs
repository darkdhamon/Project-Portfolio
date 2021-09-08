using System;
using System.ComponentModel.DataAnnotations;
using DarkDhamon.Common.DataRepository;

namespace ProjectPortfolio.Domain.Model.Entity.Abstract
{
    public abstract class TrackedEntity : BaseEntity, ITrackedEntity<int, AppUser>
    {
        private DateTime _created;

        [Required]
        public DateTime Created
        {
            get => 
                _created==new DateTime()        // If _created is default value
                    ?_created = DateTime.Now    // set _created to now and return
                    :_created;                  // otherwise return
            set => _created = value;
        }

        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
        [Required]
        public virtual AppUser CreatedBy { get; set; }
        public virtual AppUser LastUpdatedBy { get; set; }
        public virtual AppUser DeletedBy { get; set; }
    }
}