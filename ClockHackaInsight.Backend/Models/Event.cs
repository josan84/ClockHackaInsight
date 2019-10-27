using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Models
{
    public enum EventType
    {
        Conference,
        Social,
        Sport,
        Therapy       
    }
    public class Event
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public EventType EventType { get; set; }
        public string Content { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
