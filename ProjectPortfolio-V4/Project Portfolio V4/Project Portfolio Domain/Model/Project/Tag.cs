using System;
using System.Collections.Generic;
using System.Text;
using Project_Portfolio_Domain.Repository.Abstract;

namespace Project_Portfolio_Domain.Model.Project
{
    public class Tag : Entity
    {
        public string Name { get; set; }
    }
}
