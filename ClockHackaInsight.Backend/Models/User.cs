using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Number { get;  set; }
        public UserFrequency Frequency { get; set; }
        public MessagePreferences MessagePreferences { get; set; }
        public EventPreference EventPreference { get; set; }
    }
}   
