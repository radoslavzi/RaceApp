using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceApp.Models
{
    public class RaceEvent
    {
        public int Id { get; set; }
        public int EventNumber { get; set; }
        public DateTime FinishTime { get; set; }
        public uint Distance { get; set; }
        public string Name { get; set; }
    }
}