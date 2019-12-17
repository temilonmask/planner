using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Core
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public string Tag { get; set; }
        public Event(string name, string description, DateTime startDt, DateTime endDt, string tag)
        {
            Name = name;
            Description = description;
            StartDt = startDt;
            EndDt = endDt;
            Tag = tag;
        }
    }
}
