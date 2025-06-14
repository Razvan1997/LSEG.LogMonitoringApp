using LSEG.LogMonitoring.Core.Enums;
using LSEG.LogMonitoring.Core.Models;
using System.IO;

namespace LSEG.LogMonitoring.Core.Services
{
    public class LogParser
    {
        public List<LogEntry> Parse(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var entries = new List<LogEntry>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 4) continue;

                var timestamp = TimeSpan.Parse(parts[0].Trim());
                var description = parts[1].Trim();
                var typeString = parts[2].Trim();
                var pid = int.Parse(parts[3].Trim());

                var type = typeString.Equals("START", StringComparison.OrdinalIgnoreCase)
                    ? LogType.Start
                    : LogType.End;

                entries.Add(new LogEntry
                {
                    Timestamp = timestamp,
                    Description = description,
                    PID = pid,
                    Type = type
                });
            }

            return entries;
        }

        public List<JobDuration> CalculateDurations(List<LogEntry> entries)
        {
            var grouped = entries.GroupBy(e => e.PID);
            var durations = new List<JobDuration>();

            foreach (var group in grouped)
            {
                var start = group.FirstOrDefault(e => e.Type == LogType.Start);
                var end = group.FirstOrDefault(e => e.Type == LogType.End);

                if (start != null && end != null)
                {
                    durations.Add(new JobDuration
                    {
                        PID = group.Key,
                        Description = start.Description.Replace("START", "").Trim(),
                        Start = start.Timestamp,
                        End = end.Timestamp
                    });
                }
            }

            return durations;
        }
    }
}
