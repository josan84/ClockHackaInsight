using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public IEnumerable<HeartbeatHistory> HeartbeatHistory { get; set; }
        public GroundingExercise GroundingExercise { get; set; }
    }
}
