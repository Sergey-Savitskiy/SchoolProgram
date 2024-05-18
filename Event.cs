using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolProject
{
    [Table("Events")]
    class Event
    {
        [Key]public int idE { get; set; }
        private string eventName;
        private string eventType;
        private string eventDate;
        public string EventName { get { return eventName; } set { eventName = value; } }
        public string EventType { get { return eventType; } set { eventType = value; } }
        public string EventDate { get { return eventDate; } set { eventDate = value; } }

        public Event() { }
        public Event(string eventName, string eventType, string eventDate)
        {
            this.eventName = eventName;
            this.eventType = eventType;
            this.eventDate = eventDate;
        }
    }
}
