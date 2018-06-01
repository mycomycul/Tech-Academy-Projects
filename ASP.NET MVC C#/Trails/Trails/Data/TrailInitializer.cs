using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trails.Models;

namespace Trails.Data
{
    public class TrailInitializer
    {
        public static void Initialize(TrailContext context)
        {
            var zones = new Zone[]
            {
                new Zone{ ZoneID = Guid.NewGuid(), Name = "North Coast" },
                new Zone { ZoneID = Guid.NewGuid(), Name = "South Coast"}

            };
            foreach (var z in zones)
            {
                context.Zones.Add(z);
            }
            context.SaveChanges();

            var trails = new List<Trail>
            {
                new Trail{ TrailID = 0, Name = "ShiShi trail", Miles = 1.9, Description ="From Neah Bay Parking Lot to ShiShi Beach", Notes="Tpyically Very Muddy" },
                new Trail{ TrailID = 1, Name = "North Coast beach trail", Miles = 29.2, Description = "ShiShi trail to Rialto Beach", Notes="Multiple tidal Restrictions"}
            };
            foreach (var t in trails)
            {
                context.Trails.Add(t);
            }
            context.SaveChanges();



        }

    }
}