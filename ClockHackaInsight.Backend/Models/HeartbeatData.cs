namespace ClockHackaInsight.Backend.Models
{
    public class HeartbeatData
    {
        public string UserId { get; set; }
        public int AverageBpm { get; set; }
        public bool IsOutlyingStatus { get; set; }
    }
}
