using System;
using DarkDhamon.Common.DataRepository;

namespace ProjectPortfolio.Domain.Model.Entity.Abstract
{
    public abstract class TrackedEntity : BaseEntity, ITrackedEntity<int, UserProfile>
    {
        private DateTime _created;

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
        public UserProfile CreatedBy { get; set; }
        public UserProfile LastUpdatedBy { get; set; }
        public UserProfile DeletedBy { get; set; }
    }
}