using LSEG.LogMonitoring.Core.Enums;

namespace LSEG.LogMonitoring.Core.Models
{
    /// <summary>
    /// Represents a single entry in the log file, 
    /// indicating either the start or end of a job.
    /// </summary>
    public class LogEntry
    {
        public TimeSpan Timestamp { get; set; }
        public string Description { get; set; }
        public int PID { get; set; }
        public LogType Type { get; set; }
    }
}
