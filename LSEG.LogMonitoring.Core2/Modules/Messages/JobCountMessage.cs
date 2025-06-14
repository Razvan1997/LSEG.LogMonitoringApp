namespace LSEG.LogMonitoring.Core.Modules.Messages
{
    /// <summary>
    /// Message used to transmit the number of parsed jobs
    /// from one module to another via the event aggregator
    /// </summary>
    public class JobCountMessage
    {
        public int Count { get; set; }

        public JobCountMessage(int count)
        {
            Count = count;
        }
    }
}
