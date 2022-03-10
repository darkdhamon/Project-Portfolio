using System;
using System.Collections.Generic;
using System.Text;
using Project_Portfolio_Domain.Repository.Abstract;

namespace Project_Portfolio_Domain.ViewModels
{
    public class ProjectCard: Entity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DemoUrl { get; set; }
        public string SourceUrl { get; set; }
        public string ImageDataUrl { get; set; }
    }
}
