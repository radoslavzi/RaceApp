using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceApp.Models
{
    public class RaceEventEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OddsDecimal { get; set; }
    }
}