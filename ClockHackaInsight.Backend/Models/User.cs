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
        public bool AwaitingResponse { get; set; }
        public DateTime? BpmMessageSentTime { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public UserFrequency Frequency { get; set; }
        public List<HeartbeatHistory> HeartbeatHistory { get; set; }
        public bool EventSocialEnabled { get; set; }
        public bool EventTherapyEnabled { get; set; }
        public bool EventConferenceEnabled { get; set; }
        public bool EventSportEnabled { get; set; }
    }
}
