using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPortfolio.Domain.Model.Entity.Abstract;

namespace ProjectPortfolio.Domain.Model.Entity
{
    public class Project:TrackedEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
