using System;
using System.Collections.Generic;
using System.Text;
using Project_Portfolio_Domain.Repository.Abstract;

namespace Project_Portfolio_Domain.Model.DynamicContent
{
    public class DynamicContent:Entity
    {
        /// <summary>
        /// Location where Dynamic Content is to be displayed
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Title for admin purposes
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Content displayed to Site user
        /// </summary>
        public string Content { get; set; }
        public bool Show { get; set; }
        public DateTime Updated { get; set; }
    }
}
