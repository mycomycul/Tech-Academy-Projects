using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Trails.Models
{
    public class Condition
    {
        [Key]
        public int ConditionID { get; set; }
        public Trail TrailID { get; set; }
        public DateTime Date { get; set; }
        public string ConditionText { get; set; }
        public int ThumbsUpCount { get; set; }
        public int ThumbsDownCount { get; set; }

        public virtual Trail Trail { get; set; }
    }


}