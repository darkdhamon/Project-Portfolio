using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Project_Portfolio_Domain.Repository.Abstract;
using BHB.Common.Extensions;

namespace Project_Portfolio_Domain.Model.Profile
{
    public class Profile:Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {(MiddleName.IsNullOrEmpty()? $"{MiddleName} ": "")}{LastName}";
        public List<ContactMethod> ContactMethods { get; set; }
        [Url]
        public string ResumeUrl { get; set; }
    }
}
