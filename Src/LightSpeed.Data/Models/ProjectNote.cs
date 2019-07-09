using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Data.Models
{
    public class ProjectNote
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string Content { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

    }
}
