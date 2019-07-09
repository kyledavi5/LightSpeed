using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProjectNote> ProjectNotes { get; set; }


    }
}
