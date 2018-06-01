using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Trails.Models
{
    public class Trail
    {
        [Key]
        public int TrailID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public Double Miles { get; set; }
        public int ZoneId { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual List<Condition> Conditions { get; set; }
    }
}