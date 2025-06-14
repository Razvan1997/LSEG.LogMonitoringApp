namespace LSEG.LogMonitoring.Core.Models
{
    /// <summary>
    /// Represents a job execution interval with its duration and status classification
    /// </summary>
    public class JobDuration
    {
        public int PID { get; set; }
        public string Description { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration => End - Start;
        public string Status => Duration.TotalMinutes switch
        {
            > 10 => "Error",
            > 5 => "Warning",
            _ => "OK"
        };
    }
}
