
using LSEG.LogMonitoring.Core.Modules.EventAggregator;
using LSEG.LogMonitoring.Core.Modules.UIRegions;
using LSEG.LogMonitoring.Core2.Modules;
using LSEG.LogMonitoring.Module.Stats.ViewModels;

namespace LSEG.LogMonitoring.Module.Stats
{
    /// <summary>
    /// Represents the statistics module responsible for displaying
    /// job summary information in a designated UI region.
    /// </summary>
    public class LogStatsModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Initializes a new instance of the LogStatsModule class.
        /// </summary>
        /// <param name="regionManager">The region manager used to register views into UI regions.</param>
        /// <param name="eventAggregator">The event aggregator used to publish and subscribe to application-wide messages</param>
        public LogStatsModule(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Initializes the module by creating its view and view model,
        /// setting up data context, and registering the view in the main UI region
        /// </summary>
        public void Initialize()
        {
            var viewModel = new LogStatsViewModel(_eventAggregator);

            var view = new LogStatsView
            {
                DataContext = viewModel
            };

            _regionManager.RegisterView("StatsRegion", view);
        }
    }

}
