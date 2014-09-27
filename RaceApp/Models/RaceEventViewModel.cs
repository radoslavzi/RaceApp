using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceApp.Models
{
    public class RaceEventViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public IEnumerable<RaceEventEntry> RaceEventEntries { get; set; }
    }
}