using LSEG.LogMonitoring.Core.Modules;
using LSEG.LogMonitoring.Core.Modules.EventAggregator;
using LSEG.LogMonitoring.Core.Modules.Messages;

namespace LSEG.LogMonitoring.Module.Stats.ViewModels
{
    /// <summary>
    /// ViewModel for displaying simple statistics about the loaded log entries,
    /// such as the total number of jobs processed
    /// </summary>
    public class LogStatsViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        private string _summary;
        public string Summary
        {
            get => _summary;
            set => SetProperty(ref _summary, value);
        }

        public LogStatsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe<JobCountMessage>(OnJobCountChanged);
            Summary = "Statistics: 0 logs uploaded";
        }

        private void OnJobCountChanged(JobCountMessage msg)
        {
            Summary = $"Statistics: {msg.Count} uploaded logs";
        }
    }
}
