using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trails.Models
{
    public class Zone
    {
        public int ZoneID { get; set; }
        public string Name { get; set; }
        //Eventually create a class that defines the geographic shape and location of the Zone

        public virtual List<Trail> Trails { get; set; }
    }
}